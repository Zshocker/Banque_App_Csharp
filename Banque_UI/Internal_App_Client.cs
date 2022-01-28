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
using Money;

namespace Banque_UI
{
    public partial class Internal_App_Client : Form
    {
        Banque_Controller controller = Banque_Controller.Create_AppGest();
        public Internal_App_Client()
        {
            InitializeComponent();
            timer1.Start();
            foreach (Compte compte in controller.ClientAuth._comptes)
            {
                comboBox1.Items.Add(compte);
            } 
        }
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            controller.compte_Selection= (Compte)comboBox1.SelectedItem;
            Transactions.DataSource = controller.compte_Selection._transactions;
            Solde_Am.Text = controller.compte_Selection._solde.ToString();
        }

        private void Crediter_Click(object sender, EventArgs e)
        {
            if (controller.compte_Selection != null)
            {
                double d = (double)Amount.Value;
                string sel = (string)Currency.SelectedItem;
                Devise devise;
                if (sel == "MAD") devise = new MAD(d);
                else if (sel == "$") devise = new Dollar(d);
                else devise = new Euro(d);
                controller.compte_Selection.crediter(devise);
                MessageBox.Show("Done!", "Success");
            }
            else {
                MessageBox.Show("Chose a Compte first", "Fail");
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (controller.compte_Selection != null)
            {
                Solde_Am.Text = controller.compte_Selection._solde.ToString();
                Transactions.DataSource = controller.compte_Selection._transactions;
            }
        }

        private void Retirer_Click(object sender, EventArgs e)
        {
            if (controller.compte_Selection != null)
            {
                double d = (double)Amount.Value;
                string sel = (string)Currency.SelectedItem;
                Devise devise;
                if (sel == "MAD") devise = new MAD(d);
                else if (sel == "$") devise = new Dollar(d);
                else devise = new Euro(d);
                if (controller.compte_Selection.debiter(devise)) MessageBox.Show("Done!", "Success");
                else MessageBox.Show("not Done!", "Failed");
            }
            else
            {
                MessageBox.Show("Chose a Compte first", "Fail");
            }
        }

        private void Verser_Click(object sender, EventArgs e)
        {
            if (controller.compte_Selection != null)
            {
                double d = (double)Amount.Value;
                string sel = (string)Currency.SelectedItem;
                Devise devise;
                if (sel == "MAD") devise = new MAD(d);
                else if (sel == "$") devise = new Dollar(d);
                else devise = new Euro(d);
                new Versement(devise).Show();
            }
            else
            {
                MessageBox.Show("Choose a Compte first", "Fail");
            }
        }
    }
}
