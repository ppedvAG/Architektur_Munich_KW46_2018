using ppedv.Zeus.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ppedv.Zeus.Data.EF
{
    public class EfContext : DbContext
    {
        public DbSet<Drucker> Drucker { get; set; }
        public DbSet<Auftrag> Auftraege { get; set; }
        public DbSet<Modell> Modelle { get; set; }

        public EfContext(string conString) : base(conString)
        { }

        public EfContext() : this("Server=.;Database=Zeus;Trusted_Connection=true;")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //System.Data.Entity.ModelConfiguration.Conventions;
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Drucker>().Property(x => x.Hersteller)
                                          .IsRequired()
                                          .HasMaxLength(97)
                                          .HasColumnName("Herstellername");
        }

    }
}
