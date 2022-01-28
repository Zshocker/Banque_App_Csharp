using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money
{
    public abstract class Devise
    {
        private static int incr = 0;
        public double _valeur { get; private set; }
        public int _id { get; private set; } = ++incr;
        public Devise(double valeur)
        {
            this._valeur = valeur;
        }
        public Devise(int id,double valeur)
        {
            if (id > incr) incr = id;
            this._id = id;
            this._valeur = valeur;
        }
        public Devise(Devise devise)
        {
            _id = devise._id;
            this._valeur = devise._valeur;
        }
        public abstract Devise Clone();
        public abstract Dollar ConverToDollar();
        public abstract MAD ConverToMAD();
        public abstract Euro ConverToEuro();
        public override string ToString()
        {
            return _valeur.ToString();
        }
        public double convert(double d)
        {
            return _valeur * d;
        }
        public static Devise operator+(Devise devise, Devise d)
        {
            Devise dr = devise.Clone();
            dr._valeur += devise.ConvertToMe(d)._valeur;
            return dr;
        }
        public static Devise operator-(Devise devise, Devise d)
        {
            Devise dr = devise.Clone();
            dr._valeur -= devise.ConvertToMe(d)._valeur;
            return dr;
        }
        public static Devise operator*(Devise devise, Devise d)
        {
            Devise dr = devise.Clone();
            dr._valeur *= devise.ConvertToMe(d)._valeur;
            return dr;
        } 
        public static Devise operator/(Devise devise, Devise d)
        {
            Devise dr = devise.Clone();
            try
            {
                dr._valeur /= devise.ConvertToMe(d)._valeur;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e);
            }
            return dr;
        }
        public static bool operator<=(Devise d1, Devise devise)
        {
            return d1._valeur <= d1.ConvertToMe(devise)._valeur;
        } 
        public static bool operator>=(Devise d1, Devise devise)
        {
            return d1._valeur >= d1.ConvertToMe(devise)._valeur;
        } 
        public static Devise operator*(Devise devise,double d)
        {
            Devise dr = devise.Clone();
            dr._valeur *= d;
            return dr;
        }
        public static Devise operator/(Devise devise,double d)
        {
            Devise dr = devise.Clone();
            dr._valeur /= d;
            return dr;
        }
        private Devise ConvertToMe(Devise D)
        {
            if (D.GetType() == this.GetType()) return D;
            if (this is Dollar) return D.ConverToDollar();
            if (this is MAD) return D.ConverToMAD();
            return D.ConverToEuro();
        }
       
    }
}
