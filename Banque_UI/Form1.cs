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
using Banque_App;
namespace Banque_UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Banque_Controller.Create_AppGest();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if(Banque_Controller.Create_AppGest().autentifier(textBox1.Text,textBox2.Text))
           {
                new Internal_App_Client().Show();
                this.Hide();
           }
        }
     
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
