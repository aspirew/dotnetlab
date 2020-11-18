using System;
using System.Linq;
using System.Text;

namespace lab5
{

    class MixedNumber
    {
        private int numerator, denominator;
        static public int TotalChanges { get; private set; }
        public int Total { get; set; }
        public int Numerator
        {
            get { return numerator; }
            set {
                numerator = Math.Abs(value);
                TotalChanges++;
                NormalizeFraction();
                }
        }
        public int Denominator
        {
            get { return denominator; }
            set {
                if (value < 0) denominator *= -1;
                else if (value == 0) { denominator = 1; numerator = 0; }
                else denominator = value;
                TotalChanges++;
                NormalizeFraction();
            }
        }

        public MixedNumber(int total) 
        {
            Total = total;
            numerator = 0;
            denominator = 1;
            TotalChanges += 3;
        }

        public MixedNumber(int total, int numerator, int denominator) : this(total)
        {
            this.numerator = numerator;
            this.denominator = denominator;
            TotalChanges += 2;
            NormalizeFraction();
        }

        public MixedNumber(double dbl)
        {
            var converted = convertDouble(dbl);
            Total = converted.total;
            numerator = converted.numerator;
            denominator = converted.denominator;
            TotalChanges += 3;
            NormalizeFraction();
        }

        private void NormalizeFraction()
        {
            if (numerator == denominator)
            {
                if (Total < 0)
                {
                    Total--;
                    TotalChanges++;
                }
                else {
                    Total++;
                    TotalChanges++;
                }

                Numerator = 0;
                return;
            }

            if (numerator > denominator)
            {
                if (Total < 0)
                {
                    Total -= numerator / denominator;
                    TotalChanges++;
                }
                else
                {
                    Total += numerator / denominator;
                    TotalChanges++;
                }

                numerator = numerator % denominator;
                TotalChanges++;
            }

            if (numerator > 1)
            {
                int nwd = NWD(numerator, denominator);

                numerator = numerator / nwd;
                denominator = denominator / nwd;
                TotalChanges+=2;
            }
            
        }

        static private int NWD(int a, int b)
        {
            while (b > 0)
            {
                int rem = a % b;
                a = b;
                b = rem;
            }
            return a;
        }

        private (int total, int numerator, int denominator) convertDouble(double dbl)
        {
            bool isNegative = dbl < 0;
            if (isNegative) dbl *= -1;
            int total = (int)dbl;
            dbl -= total;
            double modulus = dbl % 0.01d;
            dbl -= modulus;
            if (modulus >= 0.005d)
                dbl += 0.01d;

            int size = dbl.ToString().Length - 2;
            Denominator = (int)Math.Pow(10, size);
            Numerator = (int)(dbl * denominator);

            if (isNegative) total *= -1;

            return (total, numerator, denominator);
        }

        public override string ToString()
        {
            if (numerator != 0)
                return Total + " " + numerator + "/" + denominator;
            else return Total.ToString();
        }
        public static MixedNumber operator +(MixedNumber a, MixedNumber b)
        {
            int total = a.Total + b.Total;
            int numerator;
            int denominator = a.Denominator * b.Denominator;
            if (a.Total * b.Total > 0) numerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
            else if (a.Total < 0) numerator = (b.Numerator * a.Denominator - a.Numerator * b.Denominator) * -1;
            else numerator = (a.Numerator * b.Denominator - b.Numerator * a.Denominator) * -1;
            if(numerator < 0)
            {
                numerator = denominator + numerator;
                if (total < 0) total++;
                else total--;
            }
            return new MixedNumber(total, numerator, denominator);
        }

    }

    public static class StringExtension
    {
        public static string Zad2(this string str)
        {
            string result = "";
            for (int i = 0; i < str.Length; i++)
            {
                if ((str[i] >= 'A' && str[i] <= 'Z') || (str[i] >= 'a' && str[i] <= 'z'))
                {
                    if (i % 2 == 1) result += str[i].ToString().ToUpper();
                    else result += str[i].ToString().ToLower();
                }
                else result += '.';
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MixedNumber num1 = new MixedNumber(0);
            MixedNumber num2 = new MixedNumber(3, 6, 4);
            num2.Denominator = 3;
            num2.Numerator = 10;

            MixedNumber num3 = new MixedNumber(1.6);
            Console.WriteLine("{0}", num1);
            Console.WriteLine("{0}", num2);
            Console.WriteLine("{0}", num3);

            Console.WriteLine("Ilosc zmian: {0}", MixedNumber.TotalChanges);


            MixedNumber res = num2 + num3;

            Console.WriteLine("{0}", res);

            Console.WriteLine("Ilosc zmian: {0}", MixedNumber.TotalChanges);

            Console.WriteLine("Zadanie 2 wykonane!".Zad2());
        }
    }
}
