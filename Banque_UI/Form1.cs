using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Banque_App;
namespace Banque_UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client c = new Client("BB115644", "Sen", "Hich");
            MessageBox.Show(c.ToString(),"Client");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
