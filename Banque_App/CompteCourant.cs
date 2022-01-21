using Money;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banque_App
{
    class CompteCourant : Compte
    {
        Devise _decouvert;
        public CompteCourant(Client client, Devise solde,Devise decouvert) : base(client, solde)
        {
            _decouvert = decouvert;
        }
        public override bool debiter(Devise D)
        {
            if (!check_Solde_sup(D + _decouvert)) return false;
            return base.debiter(D);
        }
        
    }
}
