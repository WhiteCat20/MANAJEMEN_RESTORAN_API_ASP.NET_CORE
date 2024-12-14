using MANAJEMEN_RESTORAN_API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace MANAJEMEN_RESTORAN_API.Data
{
    public class RestoDbContext : DbContext
    {
        public RestoDbContext(DbContextOptions<RestoDbContext> dbContextOptions) : base(dbContextOptions) { }
        public DbSet<MHCustomer> mh_customer { get; set; }
        public DbSet<MHCabang> mh_cabang {  get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MHCustomer>().ToTable("mh_customer", "dbo");
            modelBuilder.Entity<MHCabang>().ToTable("mh_cabang", "dbo");
        }
    }
}
