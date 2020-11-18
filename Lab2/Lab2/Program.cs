using System;
using System.Linq;

namespace Lab2
{
    class Program
    {

        static void zad1()
        {

            static (double?, double?) calculateQuadratic(double a, double b, double c)
            {
                if (a != 0)
                {
                    double delta = Math.Pow(b, 2) - 4 * a * c;
                    if (delta < 0) return (null, null);
                    else if (delta == 0) return (-b / 2 * a, null);
                    else return (-b - Math.Sqrt(delta) / 2 * a, -b + Math.Sqrt(delta) / 2 * a);
                }
                else if (b != 0)
                {
                    return (-c / b, null);
                }
                else if (c == 0) return (double.MaxValue, double.MaxValue);
                else return (null, null);

            }
            static string formatResult(double? res)
            {
                if (res == null) return "Brak rozwiązania";
                else if (res == double.MaxValue) return "Nieskonczona ilosc rozwiazan";
                else if (res > -0.00001 && res < 0.00001) return res?.ToString("E5");
                else return res?.ToString("F5");

            }

            Console.Write("Podaj a: ");
            string sa = Console.ReadLine();
            Console.Write("Podaj b: ");
            string sb = Console.ReadLine();
            Console.Write("Podaj c: ");
            string sc = Console.ReadLine();

            if (double.TryParse(sa, out double a) && double.TryParse(sb, out double b)
            && double.TryParse(sc, out double c))
            {
                var results = calculateQuadratic(a, b, c);
                var formattedResult = (formatResult(results.Item1), formatResult(results.Item2));
                Console.WriteLine("Rozwiązanie 1: {0}\nRozwiązanie 2: {1}", formattedResult.Item1, formattedResult.Item2);
            }
        }
        static void zad2()
        {
            Console.Write("Podaj a: ");
            string sa = Console.ReadLine();
            Console.Write("Podaj b: ");
            string sb = Console.ReadLine();

            if (int.TryParse(sa, out int a) && int.TryParse(sb, out int b))
            {
                Console.WriteLine("Wartosc binarna liczby a: {0}\n" +
                    "Wartosc binarna liczby b: {1}\n",
                    Convert.ToString(a, 2), Convert.ToString(b, 2));
                Console.WriteLine("Operacja OR: {0}", (a | b).ToString("X"));
                Console.WriteLine("Operacja AND: {0}", (a & b).ToString("X"));
                Console.WriteLine("Operacja NOT a: {0}", (~a).ToString("X"));
                Console.WriteLine("Operacja NOT b: {0}", (~b).ToString("X"));
            }
        }

        static void zad3()
        {

            Console.Write("Podaj długość ciągu: ");
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                Console.Write("Podaj ciąg: ");
                string stream = Console.ReadLine();
                (int?, int?) twoBiggests = (null, null);
                if (stream.Length >= n * 2 - 1)
                {
                    for (int i = 0; i < stream.Length; i++)
                    {
                        string number = "";
                        int k = 0;
                        while (i + k < stream.Length)
                        {
                            if (stream.Substring(i+k, 1).Equals(" "))
                            {
                                i += k;
                                k = stream.Length;
                            }
                            else
                            {
                                number = stream.Substring(i, k+1);
                                k++;
                            }
                        }
                        if (int.TryParse(number, out int value))
                        {
                            if (twoBiggests.Item1 == null || value > twoBiggests.Item1)
                            {
                                twoBiggests.Item2 = twoBiggests.Item1;
                                twoBiggests.Item1 = value;
                            }
                            else if (value < twoBiggests.Item1 && (twoBiggests.Item2 == null || value > twoBiggests.Item2))
                            {
                                twoBiggests.Item2 = value;
                            }
                        }
                        else Console.WriteLine("aaa");
                    }
                    if (twoBiggests.Item2 == null) Console.WriteLine("Brak rozwiązania");
                    else Console.WriteLine(twoBiggests.Item2);
                }
            }
        }
        static void Main(string[] args)
        {
            //zad1();
            //zad2();
            zad3();

        }
    }
}
