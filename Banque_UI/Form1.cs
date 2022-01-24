using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Banque_Temp;
namespace Banque_UI
{
    public partial class Form1 : Form
    {
        SqlConnection sql = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Banque;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        List<Client> clients = new List<Client>();
        public Form1()
        {
            InitializeComponent();
            sql.Open();
            SqlDataReader reader = Select_com("Select * from Client"),reader1;
            while (reader.Read())
            {
                Client temp = new Client(int.Parse(reader["id"].ToString()), reader["CIN"].ToString(), reader["nom"].ToString(), reader["prenom"].ToString(), reader["addresse"].ToString(), reader["login"].ToString(), reader["password"].ToString());
                clients.Add(temp);
            }
            reader.Close();
            foreach (Client client in clients)
            {
                reader1 = Select_com("select * from Compte where id_Client=" + client.id);
                while (reader1.Read())
                {
                    client.add_Compte(new Compte(int.Parse(reader1["NumCompte"].ToString()), double.Parse(reader1["Solde"].ToString())));
                }
                reader1.Close();
            }
            sql.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Client client in clients)
            {
                if (client.auth(textBox1.Text, textBox2.Text))
                {
                    dataGridView1.DataSource = client._comptes;
                 
                    MessageBox.Show("Loged");
                    break;
                }
            }
        }
        private void Update_Comm(string com)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.UpdateCommand = new SqlCommand(com,sql);
            adapter.UpdateCommand.ExecuteNonQuery();
            adapter.UpdateCommand.Dispose();
        }
        private void Delete_Com(string com)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.DeleteCommand = new SqlCommand(com,sql);
            adapter.DeleteCommand.ExecuteNonQuery();
            adapter.DeleteCommand.Dispose();
        }
        private void Insert_Com(string com)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = new SqlCommand(com,sql);
            adapter.InsertCommand.ExecuteNonQuery();
            adapter.InsertCommand.Dispose();
        }
        private SqlDataReader Select_com(string sqle)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(sqle, sql);
            SqlDataReader st= adapter.SelectCommand.ExecuteReader();
            adapter.SelectCommand.Dispose();
            return st;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
