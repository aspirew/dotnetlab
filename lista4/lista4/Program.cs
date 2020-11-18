using System;

namespace lista4
{
    class Program
    {

        static void zad1()
        {

            (int, int) GetFromConsoleXYV1(string line1, string line2)
            {
                int num1, num2;

                Console.WriteLine(line1);
                num1 = int.Parse(Console.ReadLine());
                Console.WriteLine(line2);
                num2 = int.Parse(Console.ReadLine());

                return (num1, num2);
            }

            void GetFromConsoleXYV2(string line1, string line2, out int num1, out int num2)
            {

                Console.WriteLine(line1);
                num1 = int.Parse(Console.ReadLine());
                Console.WriteLine(line2);
                num2 = int.Parse(Console.ReadLine());

            }

            Console.WriteLine(GetFromConsoleXYV1("Linia tekstu 1", "2 tekstu linia"));
            int a, b;

            GetFromConsoleXYV2("Linia tekstu 1", "2 tekstu linia", out a, out b);

            Console.WriteLine(a + " " + b);
        }

        static void zad2()
        {

            static void DrawCard(string name, string surname = "Behrendt", char border = 'X', int thick = 2, int wide = 20)
            {

                void writeNameLine(string line)
                {

                    for (int j = 0; j < thick; j++)
                    {
                        Console.Write(border);
                    }

                    int spaces = (wide - line.Length - thick * 2);

                    for (int j = 0; j < (spaces / 2) + (wide - line.Length - thick * 2) % 2; j++)
                    {
                        Console.Write(" ");
                    }

                    Console.Write(line);

                    for (int j = 0; j < spaces / 2; j++)
                    {
                        Console.Write(" ");
                    }

                    for (int j = 0; j < thick; j++)
                    {
                        Console.Write(border);
                    }
                    Console.WriteLine();
                }

#if DEBUG
                int currentWide = wide;
#endif

                wide = Math.Max(wide, thick * 2 + Math.Max(name.Length, surname.Length));


#if DEBUG
                if (wide != currentWide)
                {
                    Console.WriteLine("Dane wizytówki wymusiły zmianę szerkości");
                    Console.WriteLine("Szerokość podana: {0}", currentWide);
                    Console.WriteLine("Nowa szerokość: {0}", wide);
                }
#endif
                for (int i = 0; i < thick; i++)
                {
                    for (int j = 0; j < wide; j++)
                    {
                        Console.Write(border);
                    }
                    Console.WriteLine();
                }

                writeNameLine(name);
                writeNameLine(surname);

                for (int i = 0; i < thick; i++)
                {
                    for (int j = 0; j < wide; j++)
                    {
                        Console.Write(border);
                    }
                    Console.WriteLine();
                }

            }

            DrawCard("Rafał", wide: 5);

        }

        static void zad3()
        {

            (int evenNumbers, int realPositiveNum, int fiveLettersStrings, int diffrent) CountMyTypes(params object[] parameters)
            {
                int evenNumbers = 0;
                int realPositiveNum = 0;
                int fiveLettersStrings = 0;
                int diffrent = 0;

                for (int i = 0; i < parameters.Length; i++)
                {
#if DEBUG
                    Console.WriteLine("Aktualnie sprawdzana wartość jest typu: {0}", parameters[i].GetType());
                    if (parameters[i] is string)
                    {
                        Console.WriteLine("Długość podanego stringa: {0}", parameters[i].ToString().Length);
                    }
#endif
                    switch (parameters[i])
                    {
                        case Int32 p when p % 2 == 0:
                            evenNumbers++;
                            break;
                        case Double p when p > 0:
                            realPositiveNum++;
                            break;
                        case String p when p.Length > 4:
                            fiveLettersStrings++;
                            break;
                        default:
                            diffrent++;
                            break;
                    }
                }

                return (evenNumbers, realPositiveNum, fiveLettersStrings, diffrent);
            }

            var res = CountMyTypes("asdasd", 23, 3.2, "aaaaaaaaaaaa", "ww", 'w');

            Console.WriteLine("Liczby parzyste: " + res.evenNumbers);
            Console.WriteLine("Liczby rzeczywiste dodatnie: " + res.realPositiveNum);
            Console.WriteLine("Pięcio literowe ciągi znaków: " + res.fiveLettersStrings);
            Console.WriteLine("Inne: " + res.diffrent);

        }

        static void Main(string[] args)
        {
            //zad1();
            //zad2();
            zad3();
        }
    }
}
