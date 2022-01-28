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
        static Devise plafond = new MAD(2000);
        static int count = 0;
        public int _numcompte { get; } = ++count;
        Client _client;
        public Devise _solde { get; private set; }
        public List<Transaction> _transactions { get; private set; }
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
            if (id > count) count = id;
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
                C.crediter(M.Clone());
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
            _solde = _solde - M;
            Add_transaction(M, false);
        }
        public void Add_transaction(Devise Amount, bool Type)
        {
            Transaction transaction;
            if (Type) transaction= new OpV(Amount, this);
            else transaction= new OpR(Amount, this);
            Banque_Controller.Create_AppGest().save_new_Transaction_Tobase(transaction);
            Add_transaction(transaction);
        }
        public void Add_transaction(Transaction transaction)
        {
            _transactions.Add(transaction);
        }

        public override string ToString()
        {
            return "numero du compte : " + _numcompte +" , Type : "+Get_Type();
        }
        private String Get_Type()
        {
            if (this is ComptePayant) return "Compte Payant";
            if (this is CompteEpargne) return "Compte Epargne";
            return "Compte Courant";
        }
    }
}
