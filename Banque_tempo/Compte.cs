using System;
using System.Collections.Generic;
using System.Text;

namespace Banque_Temp
{
    public class Compte
    {
        public int numCompte { get; }
        public string Solde { get; }

    public Compte(int numCompte, string solde)
        {
            this.numCompte = numCompte;
            Solde = solde;
        }
    }
}
