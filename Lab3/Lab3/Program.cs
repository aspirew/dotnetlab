using System;

namespace Lab3
{
    class Program
    {
        static void zad1()
        {
            Random rnd = new Random();
            Console.Write("Podaj wymiar n: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Podaj wymiar m: ");
            int m = int.Parse(Console.ReadLine());

            void zad1a(){

                int[,] array = new int[n, m];

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        int rand = rnd.Next(0, 100);
                        array[i, j] = rand;
                        Console.Write("{0}, ", rand);
                    }
                    Console.WriteLine("\n");
                }

                for (int i = 0; i < n/2; i++)
                {
                    for(int j = 0; j < m; j++)
                    {
                        int buffer = array[i,j];
                        array[i, j] = array[n - 1 - i, j];
                        array[n - 1 - i, j] = buffer;

                    }
                }

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        Console.Write("{0}, ", array[i,j]);
                    }
                    Console.WriteLine("\n");
                }

            }

            void zad1b(){
                int[][] arrayOfArrays = new int[n][];

                for (int i = 0; i < n; i++)
                {
                    arrayOfArrays[i] = new int[m];
                    for (int j = 0; j < m; j++)
                    {
                        int rand = rnd.Next(0, 100);
                        arrayOfArrays[i][j] = rand;
                        Console.Write("{0}, ", rand);
                    }
                    Console.WriteLine("\n");
                }

                for (int i = 0; i < n/2; i++)
                {
                    int[] buffer;
                    buffer = arrayOfArrays[i];
                    arrayOfArrays[i] = arrayOfArrays[n - 1 - i];
                    arrayOfArrays[n - 1 - i] = buffer;
                }

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        Console.Write("{0}, ", arrayOfArrays[i][j]);
                    }
                    Console.WriteLine("\n");
                }
            
            }

            zad1a();
            zad1b();

        }

        static void zad2()
        {

            void fun((string imie, string nazwisko, int wiek, double placa) userInfo)
            {
                Console.WriteLine("Imie: {0} Naziwsko: {1}", userInfo.imie, userInfo.nazwisko);
                Console.WriteLine($"Wiek: {userInfo.Item3} płaca {userInfo.placa}");
            }

            (string imie, string nazwisko, int wiek, double placa) userInfo;
            Console.Write("Podaj imie: ");
            userInfo.imie = Console.ReadLine();
            Console.Write("Podaj nazwisko: ");
            userInfo.nazwisko = Console.ReadLine();
            Console.Write("Podaj wiek: ");
            userInfo.wiek = int.Parse(Console.ReadLine());
            Console.Write("Podaj płacę: ");
            userInfo.Item4 = double.Parse(Console.ReadLine());

            fun(userInfo);

        }

        static void zad4()
        {
            int[] array = new int[10] { 8, 2, 9, 3, 4, 6, 7, 1, 5, 0 };
            System.Array.Sort(array);
            System.Array.Reverse(array);
            System.Array.ForEach(array, elem => Console.Write(elem + " "));
            Console.WriteLine();
            System.Array.Resize(ref array, 6);
            System.Array.ForEach(array, elem => Console.Write(elem + " "));
            Console.WriteLine();
            Console.WriteLine(System.Array.Exists(array, elem => elem == 0));
        }
        static void Main(string[] args)
        {
            zad1();
        }
    }
}
