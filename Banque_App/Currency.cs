using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money
{
    public class MAD : Devise
    {
        static readonly double RatioToDollar= 1 / 9.24;
        static readonly double RatioToEuro = 1 / 10.4;
        public MAD(double valeur) : base(valeur){} 
        public MAD(MAD valeur) : base(valeur){}
        public override Devise Clone()
        {
            return new MAD(this);
        }
        public override string ToString()
        {
            return base.ToString() + "DH";
        }
        public override Dollar ConverToDollar()
        {
            return new Dollar(convert(RatioToDollar));
        }
        public override MAD ConverToMAD()
        {
            return  (MAD)Clone();
        }
        public override Euro ConverToEuro()
        {
            return new Euro(convert(RatioToEuro));
        }
    }
    public class Euro : Devise
    {
        static readonly  double RatioToDollar= 1.13;
        static readonly double RatioToMAD = 10.4;
        public Euro(double valeur) : base(valeur) { }
        public Euro(Euro valeur) : base(valeur) { }
        public override Devise Clone()
        {
            return new Euro(this);
        }

        public override string ToString()
        {
            return base.ToString()+"€";
        }
        public override Dollar ConverToDollar()
        {
            return new Dollar(convert(RatioToDollar));
        }
        public override MAD ConverToMAD()
        {
            return new MAD(convert(RatioToMAD));
        }
        public override Euro ConverToEuro()
        {
            return (Euro)Clone();
        }
    }
    public class Dollar : Devise
    {
        static readonly double RatioToMAD = 9.24;
        static readonly double RatioToEuro = 1 / 1.13;
        public Dollar(double valeur) : base(valeur) { }
        public Dollar(Dollar valeur) : base(valeur) { }
        public override Devise Clone()
        {
            return new Dollar(this);
        }
        public override string ToString()
        {
            return base.ToString() + "$";
        }
        public override Dollar ConverToDollar()
        {
            return (Dollar)Clone();
        }
        public override MAD ConverToMAD()
        {
            return new MAD(convert(RatioToMAD));
        }
        public override Euro ConverToEuro()
        {
            return new Euro(convert(RatioToEuro));
        }
    }
}
