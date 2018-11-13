using ppedv.Zeus.Model;
using System.Data.Entity;

namespace ppedv.Zeus.Data.EF
{
    public class EfContext : DbContext
    {
        public DbSet<Drucker> Drucker { get; set; }
        public DbSet<Auftrag> Auftraege { get; set; }
        public DbSet<Modell> Modelle { get; set; }
    }
}
