using Money;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banque_App
{
    public abstract class Compte
    {
        static Devise plafond=new MAD(2000);
        static int count=0;
        int _numcompte = ++count;
        Client _client;
        Devise _solde;
        List<Transaction> _transactions;
        public virtual bool debiter(Devise devise)
        {
            if(_solde>=devise && devise <= plafond)
            {
                debiter_direct(devise);
                return true;
            }
            return false;
        }
        protected Compte(Client client, Devise solde)
        {
            this._client = client;
            this._solde = solde;
            _transactions = new List<Transaction>();
            _client.add_Compte(this);
        }
        protected Compte(int id, Client client, Devise solde)
        {
            _numcompte = id;
            this._client = client;
            this._solde = solde;
            _transactions = new List<Transaction>();
            _client.add_Compte(this);
        }
        
        public virtual void crediter(Devise devise)
        {
            _solde += devise;
            Add_transaction(devise, true);
        }
        public bool verser(Devise M, Compte C)
        {
            if (debiter(M))
            {
                C.crediter(M);
                return true;
            }
            return false;
        }
        protected void add_pursontage(double D)
        {
            _solde += _solde * (D/100);
        }
        protected bool check_moitier(Devise D)
        {
            Devise devise = _solde / 2;
            return devise >= D;
        }
        protected bool check_Solde_sup(Devise D)
        {
            return _solde >= D;
        }
        protected void debiter_direct(Devise M)
        {
            _solde -= _solde - M;
            Add_transaction(M, false);
        }
        protected void Add_transaction(Devise Amount, bool Type,bool Base_save=true)
        {
            if (Type) _transactions.Add(new OpV(Amount, this));
            else _transactions.Add(new OpR(Amount, this));
            if (Base_save) App_Gest.Create_AppGest().save_Transaction_Tobase(Amount, Type, this._numcompte);
        }

        public override string ToString()
        {
            return "numero du compte : " + _numcompte + ", Solde :" + _solde;
        }
    }
}
