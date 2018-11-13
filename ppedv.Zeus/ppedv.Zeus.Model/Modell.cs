using System.Collections.Generic;

namespace ppedv.Zeus.Model
{
    public class Modell : Entity
    {
        public string Name { get; set; }
        public byte[] STL { get; set; }

        public virtual HashSet<Auftrag> Auftraege { get; set; } = new HashSet<Auftrag>();
    }
}