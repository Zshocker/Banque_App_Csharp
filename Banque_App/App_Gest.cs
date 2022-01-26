using Money;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banque_App
{
    public class App_Gest
    {
        SqlConnection sql = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Banque;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets = True;");
        List<Client> clients = new List<Client>();
        static App_Gest app_Gest = null;
        public static App_Gest Create_AppGest()
        {
            if (app_Gest != null) return app_Gest;
            return new App_Gest();
        }
        private App_Gest()
        {
            sql.Open();
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
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.UpdateCommand = new SqlCommand(com, sql);
            adapter.UpdateCommand.ExecuteNonQuery();
            adapter.UpdateCommand.Dispose();
        }
        private void Delete_Com(string com)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.DeleteCommand = new SqlCommand(com, sql);
            adapter.DeleteCommand.ExecuteNonQuery();
            adapter.DeleteCommand.Dispose();
        }
        private void Insert_Com(string com)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = new SqlCommand(com, sql);
            adapter.InsertCommand.ExecuteNonQuery();
            adapter.InsertCommand.Dispose();
        }
        private SqlDataReader Select_com(string sqle)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(sqle, sql);
            SqlDataReader st = adapter.SelectCommand.ExecuteReader();
            adapter.SelectCommand.Dispose();
            return st;
        }
        private Compte Read_Compte(Client client, SqlDataReader sqlData)
        {
            Compte compte;
            if (sqlData["id_decouvert"] == null)
            {
                compte= new CompteEpargne(int.Parse(sqlData["NumCompte"].ToString()), client, Read_Devise(int.Parse(sqlData["id_Solde"].ToString())), int.Parse(sqlData["Taux_aug"].ToString()));
            }
            else if (int.Parse(sqlData["Payant"].ToString()) == 1)
            {
                compte= new ComptePayant(int.Parse(sqlData["NumCompte"].ToString()), client, Read_Devise(int.Parse(sqlData["id_Solde"].ToString())),Read_Devise(int.Parse(sqlData["id_decouvert"].ToString())));
            }
            else compte= new CompteCourant(int.Parse(sqlData["NumCompte"].ToString()), client, Read_Devise(int.Parse(sqlData["id_Solde"].ToString())), Read_Devise(int.Parse(sqlData["id_decouvert"].ToString())));
            return compte;
        }
        private Devise Read_Devise(int id)
        {
            SqlDataReader dataReader = Select_com("select * from Devise where id="+id);
            dataReader.Read();
            string type = Read_Type(int.Parse(dataReader["id_type"].ToString()));
            double valeur = double.Parse(dataReader["value"].ToString());
            if (type == "MAD") return new MAD(valeur);
            if (type == "Dollar") return new Dollar(valeur);
            return new Euro(valeur);
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
        public void save_Transaction_Tobase(Devise Amount, bool Type,int id_comp)
        {

        }
    }
}
