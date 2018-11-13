using System.Collections.Generic;

namespace ppedv.Zeus.Model
{
    public class Drucker : Entity
    {
        public string Hersteller { get; set; }
        public string Model { get; set; }
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public int MaxZ { get; set; }
        public string Schnittstelle { get; set; }
        public double Speed { get; set; }

        public virtual HashSet<Auftrag> Auftraege { get; set; } = new HashSet<Auftrag>();
    }
}
