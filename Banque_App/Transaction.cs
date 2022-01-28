using Money;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banque_App
{
    public abstract class Transaction
    {
        public static string libel { get; }
        static long incr=0;
        public long _numT { get; } = ++incr;
		public DateTime _date_heure { get; }
		public Devise _Val { get; }
		public Compte _compte { get; }
		public Transaction(Devise Value,Compte compte)
        {
			_Val = Value;
			_compte=compte;
			_date_heure = DateTime.Now;
        }
        public Transaction(int id, Devise Value, Compte compte ,string date)
        {
            if (id > incr) incr = id;
            _numT = id;
            _Val = Value;
            _compte = compte;
            _date_heure = DateTime.Parse(date);
        }
        protected string Details()
        {
            return "Date and Time :" + _date_heure + " \nTransaction numero:" + _numT;
        }
        protected string Montant()
        {
            return _Val.ToString();
        }
    }
    public class OpR : Transaction
    {
        new public static string libel { get; } = "-";
        public OpR(Devise Value, Compte compte) : base(Value, compte)
        {
        } 
        public OpR(int id,Devise Value, Compte compte ,string date) : base(id,Value, compte,date)
        {
        }
        public override string ToString()
        {
            return Details() + "\nMantant:" + libel + Montant();
        }
    }
    public class OpV : Transaction
    {
        new public static string libel { get; } = "+";
        public OpV(Devise Value, Compte compte) : base(Value, compte)
        {
        } 
        public OpV(int id,Devise Value, Compte compte, string date) : base(id,Value, compte, date)
        {
        }
        public override string ToString()
        {
            return Details() + "\nMantant:" + libel + Montant();
        }
    }
}
