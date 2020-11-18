using System;

namespace lab6
{
    class Zad1
    {

        abstract class Pojazd
        {
            public string Producent { get; set; }
            public int RokProdukcji { get; private set; }

            public Pojazd(string producent, int rokProdukcji)
            {
                Producent = producent;
                RokProdukcji = rokProdukcji;
            }

            public virtual void Odglos()
            {
                Console.WriteLine("ziuum");
            }

            public override string ToString()
            {
                return $"Mój rok produkcji to {RokProdukcji}, a producent {Producent}. " ;
            }

        }

        abstract class Samochod : Pojazd
        {
            public int PredkoscMaksymalna { get; set; }
            public int KM { get; set; }
            public Samochod(string producent, int rokProdukcji, int predkosc, int km) : base(producent, rokProdukcji)
            {
                PredkoscMaksymalna = predkosc;
                KM = km;
            }

            public virtual void klakson()
            {
                Console.WriteLine("doot");
            }

            public override string ToString()
            {
                return base.ToString() + $"Jadę z maksymalną prędkością {PredkoscMaksymalna} i mam {KM} KM. ";

            }
        }

        class Rower : Pojazd
        {
            public Rower(string producent, int rokProdukcji, string rodzaj, int iloscPrzerzutek = 1) : base(producent, rokProdukcji)
            {
                Rodzaj = rodzaj;
                IloscPrzerzutek = iloscPrzerzutek;
                swiatlo = false;
            }
            private bool swiatlo;
            public string Rodzaj { get; set; }
            public int IloscPrzerzutek { get; set; }

            public override void Odglos()
            {
                Console.WriteLine("wziuu");
            }

            public bool Swiatlo
            {
                get
                {
                    if (swiatlo) Console.WriteLine("Światlo włączone");
                    else Console.WriteLine("Światło wyłączone");
                    return swiatlo;
                }
                set { swiatlo = value; }
            }

            public override string ToString()
            {
                return base.ToString() + $"Jestem rowerem typu {Rodzaj}. " +
                    $"Posiadam {IloscPrzerzutek} przerzutek";
            }
        }

        class SamochodOsobowy : Samochod
        {
            public SamochodOsobowy(string producent, int rokProdukcji, int predkosc, int km, double czasDo100, bool automat) : base(producent, rokProdukcji, predkosc, km)
            {
                CzasDo100 = czasDo100;
                Automat = automat;
            }

            public double CzasDo100 {get; set;}
            public bool Automat { get; set; }

            public override void Odglos()
            {
                Console.WriteLine("wruum");
            }
            override public void klakson()
            {
                Console.WriteLine("beep");
            }

            public override string ToString()
            {
                string sb = " Mam manualną skrzynię biegów.";
                if (Automat)
                    sb = " Mam automatyczną skrzynię biegów.";

                return base.ToString() + $"Rozpędzam się do 100 km/h w {CzasDo100} s." + sb;
            }

        }

        class SamochodCiezarowy : Samochod
        {
           public SamochodCiezarowy(string producent, int rokProdukcji, int predkosc, int km, int nosnosc, double ladownosc) : base(producent, rokProdukcji, predkosc, km)
            {
                Nosnosc = nosnosc;
                Ladownosc = ladownosc;
            }

            public int Nosnosc { get; set; }
            public double Ladownosc { get; set; }

            public override void Odglos()
            {
                Console.WriteLine("bruum");
            }

            public void przewiez(string material)
            {
                Console.WriteLine("Przewożę {1}", material);
            }
            public override string ToString()
            {
                return base.ToString() + $"Moja nośność wynosi {Nosnosc}, a ładowność {Ladownosc}.";
            }

        }

        public void zad1()
        {
            Pojazd rower = new Rower("AMD", 2020, "gorski");
            Pojazd sedan = new SamochodOsobowy("Ford", 2015, 200, 150, 9.7, false);
            Pojazd ciezarowka = new SamochodCiezarowy("Scania", 2018, 160, 400, 1000, 1250.5);
            Pojazd ciezarowka2 = new SamochodCiezarowy("Volvo", 2016, 180, 420, 1400, 1380.1);
            Pojazd[] pojazdy = new Pojazd[4] { rower, sedan, ciezarowka, ciezarowka2 };

            int sumarycznaNosnosc = 0;

            for(int i = 0; i < pojazdy.Length; i++)
            {
                Console.WriteLine(pojazdy[i].ToString());
                pojazdy[i].Odglos();
                if(pojazdy[i] is Samochod)
                    ((Samochod)pojazdy[i]).klakson();
                if (pojazdy[i] is SamochodCiezarowy)
                    sumarycznaNosnosc += ((SamochodCiezarowy)pojazdy[i]).Nosnosc;
            }

            Console.WriteLine("Sumaryczna nosnosc: {0}", sumarycznaNosnosc);

        }
    }

    class Zad2
    {
        interface IFigure
        {
            public double XCoordinate { get; set; }
            public double YCoordinate { get; set; }
            void moveTo(double x, double y);
        }

        interface IHasInterior
        {
            public string Color { get; set; }
        }

        class Square : IFigure, IHasInterior
        {
            public Square()
            {
                XCoordinate = 0;
                YCoordinate = 0;
                Color = "black";
            }

            public string Color { get; set; }
            public double XCoordinate { get; set; }
            public double YCoordinate { get; set; }

            public void moveTo(double x, double y)
            {
                XCoordinate = x;
                YCoordinate = y;
            }
        }

        class Ball : IFigure
        {
            public Ball()
            {
                XCoordinate = 0;
                YCoordinate = 0;
            }
            public double XCoordinate { get; set; }
            public double YCoordinate { get; set; }
            void IFigure.moveTo(double x, double y)
            {
                XCoordinate = x;
                YCoordinate = y;
            }
        }

        public static void checkColor(object[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                IHasInterior obj = arr[i] as IHasInterior;
                if (obj != null)
                   Console.WriteLine("Color: {0}", obj.Color);
                else
                   Console.WriteLine("No color");
            }
        }

        public void zad2()
        {
            Ball ball = new Ball();
            Ball ball2 = new Ball();
            Square square = new Square();
            Square square2 = new Square();
            Square square3 = new Square();
            IFigure figureCast = (IFigure)ball;
            figureCast.moveTo(3, 5);

            square.moveTo(10, 9.5);
            square.Color = "white";
            square2.Color = "green";

            object[] interfaceArray = { ball, ball2, square, square2, square3, 5 };

            checkColor(interfaceArray);
            

        }

    }

    class MainClass
    {
        static void Main(string[] args)
        {
            Zad1 zad1 = new Zad1();
            Zad2 zad2 = new Zad2();

            //zad1.zad1();
            zad2.zad2();
        }
    }

}
