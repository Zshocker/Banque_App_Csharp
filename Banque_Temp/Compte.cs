using System;
using System.Collections.Generic;
using System.Text;

namespace Banque_Temp
{
    public class Compte
    {
        public int numCompte;
        public string Solde;

        public Compte(int numCompte, string solde)
        {
            this.numCompte = numCompte;
            Solde = solde;
        }
    }
}
