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
		static long incr=0;
		readonly long _numT=++incr;
		DateTime _date_heure;
		Devise _Val;
		Compte _compte;
		public Transaction(Devise Value,Compte compte)
        {
			_Val = Value;
			_compte=compte;
			_date_heure = DateTime.Now;
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
        static string libel="-";
        public OpR(Devise Value, Compte compte) : base(Value, compte)
        {
        }
        public override string ToString()
        {
            return Details() + "\nMantant:" + libel + Montant();
        }
    }
    public class OpV : Transaction
    {
        static string libel="+";
        public OpV(Devise Value, Compte compte) : base(Value, compte)
        {
        }
        public override string ToString()
        {
            return Details() + "\nMantant:" + libel + Montant();
        }
    }
}
