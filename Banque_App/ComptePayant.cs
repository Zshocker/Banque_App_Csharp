using Money;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banque_App
{
    class ComptePayant : CompteCourant
    {
        public ComptePayant(Client client, Devise solde, Devise decouvert) : base(client, solde, decouvert)
        {

        }
        public ComptePayant(int id,Client client, Devise solde, Devise decouvert) : base(id,client, solde, decouvert)
        {

        }
        public override void crediter(Devise devise)
        {
            base.crediter(devise);
            Devise devise1 = devise.Clone() * 0.05;
            debiter_direct(devise1);
        }
        public override bool debiter(Devise devise)
        {
            Devise devise1 = devise.Clone() * 0.05;
            if (!check_Solde_sup(devise + devise1)) return false;
            debiter_direct(devise);
            debiter_direct(devise1);
            return true;
        }
    }
}
