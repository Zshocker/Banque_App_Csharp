using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banque_App
{
    public class Client
    {
        private string _CIN, _nom, _prenom,_adresse;
        private List<Compte> _comptes;
        public Client(string cIN, string nom, string prenom,string addr)
        {
            _CIN = cIN;
            _adresse = addr;
            this._nom = nom;
            this._prenom = prenom;
            _comptes = new List<Compte>();
        }
        public void add_Compte(Compte se)
        {
            if (_comptes.Contains(se)) return;
            _comptes.Add(se);
        }
        public override string ToString()
        {
            return "CIN =" + _CIN + " nom=" + _nom + " prenom=" + _prenom + " addresse=" + _adresse;
        }
    }
}
