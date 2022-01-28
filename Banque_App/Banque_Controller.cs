using Money;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banque_App
{
    public class Banque_Controller
    {
        SqlConnection sql = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Banque;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets = True;");
        List<Client> clients = new List<Client>();
        static Banque_Controller app_Gest = null;
        public Client ClientAuth { get; private set; } = null;
        public Compte compte_Selection { get; set; } = null;
        public static Banque_Controller Create_AppGest()
        {
            if (app_Gest == null) app_Gest = new Banque_Controller();
            return app_Gest;
        }
        public static void Destoy_AppGest()
        {
            app_Gest = null;
        }
        private Banque_Controller()
        {
            if (sql.State != System.Data.ConnectionState.Open) sql.Open();
            SqlDataReader reader = Select_com("Select * from Client"), reader1;
            while (reader.Read())
            {
                Client temp = new Client(int.Parse(reader["id"].ToString()), reader["CIN"].ToString(), reader["nom"].ToString(), reader["prenom"].ToString(), reader["addresse"].ToString(), reader["login"].ToString(), reader["password"].ToString());
                reader1 = Select_com("select * from Compte where id_Client=" + temp.id);
                while (reader1.Read())
                {
                    temp.add_Compte(Read_Compte(temp,reader1));
                }
                reader1.Close();
                clients.Add(temp);
            }
            reader.Close();
            sql.Close();
        }
        private void Update_Comm(string com)
        {
            if (sql.State != System.Data.ConnectionState.Open) sql.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.UpdateCommand = new SqlCommand(com, sql);
            adapter.UpdateCommand.ExecuteNonQuery();
            adapter.UpdateCommand.Dispose();
            sql.Close();
        }
        private void Delete_Com(string com)
        {
            if (sql.State != System.Data.ConnectionState.Open) sql.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.DeleteCommand = new SqlCommand(com, sql);
            adapter.DeleteCommand.ExecuteNonQuery();
            adapter.DeleteCommand.Dispose();
            sql.Close();
        }
        private void Insert_Com(string com)
        {
            if (sql.State != System.Data.ConnectionState.Open) sql.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = new SqlCommand(com, sql);
            adapter.InsertCommand.ExecuteNonQuery();
            adapter.InsertCommand.Dispose();
            sql.Close();
        }
        private SqlDataReader Select_com(string sqle)
        {
            if(sql.State != System.Data.ConnectionState.Open)sql.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(sqle, sql);
            SqlDataReader st = adapter.SelectCommand.ExecuteReader();
            adapter.SelectCommand.Dispose();
 
            return st;
        }
        private Compte Read_Compte(Client client, SqlDataReader sqlData)
        {
            Compte compte;
            int a = int.Parse(sqlData["Payant"].ToString());
            if (sqlData["id_decouvert"].ToString() == "")
            {
                compte= new CompteEpargne(int.Parse(sqlData["NumCompte"].ToString()), client, Read_Devise(int.Parse(sqlData["id_Solde"].ToString())), int.Parse(sqlData["Taux_aug"].ToString()));
            }
            else if (int.Parse(sqlData["Payant"].ToString()) == 1)
            {
                compte= new ComptePayant(int.Parse(sqlData["NumCompte"].ToString()), client, Read_Devise(int.Parse(sqlData["id_Solde"].ToString())),Read_Devise(int.Parse(sqlData["id_decouvert"].ToString())));
            }
            else compte= new CompteCourant(int.Parse(sqlData["NumCompte"].ToString()), client, Read_Devise(int.Parse(sqlData["id_Solde"].ToString())), Read_Devise(int.Parse(sqlData["id_decouvert"].ToString())));
            SqlDataReader reader = Select_com("Select * from Transactions where id_Compte="+compte._numcompte);
            while (reader.Read())
            {
                compte.Add_transaction(Read_transaction_toCompte(compte, reader));
            }
            reader.Close();
            return compte;
        }
        private int Read_old_Devise(int a)
        {
            SqlDataReader sqlr = Select_com("Select id_Solde from Compte where numCompte=" + a);
            sqlr.Read();
            int va= int.Parse(sqlr["id_Solde"].ToString());
            sqlr.Close();
            return va;
        }
        private void Delete_Devise(int a)
        {
            Delete_Com("DELETE From Devise where Id="+a);
        }
        private Transaction Read_transaction_toCompte(Compte compte, SqlDataReader reader)
        {
            int type = int.Parse(reader["type"].ToString());
            if (type == 1)
            {
                return new OpV(int.Parse(reader["Id"].ToString()), Read_Devise(int.Parse(reader["id_Value"].ToString())), compte, reader["dateTrans"].ToString());
            }
            return new OpR(int.Parse(reader["Id"].ToString()), Read_Devise(int.Parse(reader["id_Value"].ToString())), compte, reader["dateTrans"].ToString());
        }
        private Devise Read_Devise(int id)
        {
            SqlDataReader dataReader = Select_com("select * from Devise where id="+id);
            dataReader.Read();
            string type = Read_Type(int.Parse(dataReader["id_type"].ToString()));
            double valeur = double.Parse(dataReader["value"].ToString());
            if (type == "MAD") return new MAD(id,valeur);
            if (type == "Dollar") return new Dollar(id,valeur);
            return new Euro(id,valeur);
        }
        private string Read_Type(int id)
        {
            SqlDataReader dataReader = Select_com("select type from Devise_type where id=" + id);
            while (dataReader.Read())
            {
                return dataReader["type"].ToString();
            }
            return "MAD";
        }
        public void save_new_Transaction_Tobase(Transaction transaction)
        {
            int type = 1;
            if (transaction is OpR) type = 0;
            Update_Compte_Devise(transaction._compte);
            save_new_Devise(transaction._Val);
            Insert_Com("insert into Transactions values ("+transaction._numT+","+transaction._Val._id+","+transaction._compte._numcompte+","+type+", '"+transaction._date_heure.ToString()+"'    ) ");
        }
        public void save_new_Devise(Devise devise)
        {
            Insert_Com("insert into Devise values(" + devise._id + "," + devise._valeur + " ," + get_Devise_type(devise) + " )");
        }
        //private void update_Devise(Devise devise)
        //{
        //    Update_Comm("Update Devise set value=" + devise._valeur+" where Id="+devise._id);
        //}
        private void Update_Compte_Devise(Compte compte)
        {
            save_new_Devise(compte._solde);
            int c = Read_old_Devise(compte._numcompte);
            Update_Comm("Update Compte set id_Solde =" + compte._solde._id + " where NumCompte=" + compte._numcompte);
            Delete_Devise(c);
        }
        private int get_Devise_type(Devise devise)
        {
            if (devise is Dollar) return 2;
            if (devise is MAD) return 1;
            return 3;
        }
        public bool autentifier(string login,string password)
        {
            foreach (Client client in clients)
            {
                if (client.auth(login, password))
                {
                    ClientAuth = client;
                    return true;
                }
            }
            return false;
        }
        public int TryCrediter(int num,Devise devise)
        {
            foreach (Client client in clients)
            {
                foreach (Compte compte in client._comptes)
                {
                    if (compte._numcompte == num) {
                        bool a=compte_Selection.verser(devise, compte);
                        if (a) return 1;
                        return -1;
                    }
                }
            }
            return 0;
        }
    }
}
