using Banque_App;
using Money;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banque_UI
{
    public partial class Versement : Form
    {
        Banque_Controller controller = Banque_Controller.Create_AppGest();
        Devise amount;
        public Versement(Devise devise)
        {
            InitializeComponent();
            amount = devise;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num = (int)Numero.Value;
            num = controller.TryCrediter(num, amount);
            if (num == 0) MessageBox.Show("Compte doesn't existe", "Failed");
            else if (num == -1) MessageBox.Show("You can't transfer that much", "Fail");
            else
            {
                MessageBox.Show("Done!", "Success");
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
