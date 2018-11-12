using System;

namespace HalloBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Schrank meinSchrank = new Schrank.SchrankBuilder().SetAnzahlTüren(5).SetOberfläche(Oberfläche.Lackiert).SetFarbe("Rot").Create();

            Console.ReadLine();
        }
    }

    class Schrank
    {
        public int AnzahlTüren { get; private set; }
        public Oberfläche Oberfläche { get; private set; }
        public string Farbe { get; private   set; }
        public int Böden { get; private set; }
        public bool Stange { get; private set; }

        public class SchrankBuilder
        {
            private Schrank result = new Schrank();

            public SchrankBuilder SetAnzahlTüren(int zahl)
            {
                if (zahl < 2 || zahl > 10)
                    throw new ArgumentException("Zu viele oder zu wenig Türen");

                result.AnzahlTüren = zahl;
                return this;
            }

            public SchrankBuilder SetFarbe(string farbe)
            {
                if (result.Oberfläche != Oberfläche.Lackiert)
                    throw new ArgumentException("Nur lackierte Schränke können eine Farbe haben");

                result.Farbe = farbe;
                return this;
            }

            public SchrankBuilder SetOberfläche(Oberfläche of)
            {
                result.Oberfläche = of;
                return this;
            }
            public Schrank Create()
            {
                return result;
            }
        }
    }

    enum Oberfläche
    {
        Unbehandelt,
        Gewachst,
        Lackiert
    }
}
