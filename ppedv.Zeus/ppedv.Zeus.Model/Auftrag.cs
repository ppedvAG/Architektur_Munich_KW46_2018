using System;

namespace ppedv.Zeus.Model
{
    public class Auftrag : Entity
    {
        public DateTime Start { get; set; } = DateTime.Now;

        public virtual Drucker Drucker { get; set; }

        public Auftragstatus Status { get; set; }

        public virtual Modell Modell { get; set; }
    }
}