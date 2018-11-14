using ppedv.Zeus.Logic;
using ppedv.Zeus.Model;
using System;

namespace ppedv.Zeus.UI.RootConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** GROOOOOT Console ****");

            var core = new Core();

            core.CreateDemodaten();


            foreach (var d in core.Repository.GetAll<Drucker>())
            {
                Console.WriteLine($"{d.Hersteller} {d.Model} {d.Speed}m/s {d.MaxX}x{d.MaxY}x{d.MaxZ} {d.Schnittstelle}");

                foreach (var a in d.Auftraege)
                {
                    Console.WriteLine($"\t{a.Start:d} {a?.Modell.Name} {a.Status}");
                }
            }

            Console.ReadLine();
        }
    }
}
