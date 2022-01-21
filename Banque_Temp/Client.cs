using System;
using System.Collections.Generic;

namespace Banque_Temp
{
    public class Client
    {
        private string _CIN, _nom, _prenom, _adresse;
        private string _login, _password;
        private List<Compte> _comptes;
        public Client(string cIN, string nom, string prenom, string addr)
        {
            _CIN = cIN;
            _adresse = addr;
            this._nom = nom;
            this._prenom = prenom;
            _comptes = new List<Compte>();
        }

        public Client(string cIN, string nom, string prenom, string adresse, string login, string password) : this(cIN, nom, prenom, adresse)
        {
            _login = login;
            _password = password;
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
        public bool auth(string login,string pass)
        {
            return login == _login && pass == _password; 
        }
    }
}
