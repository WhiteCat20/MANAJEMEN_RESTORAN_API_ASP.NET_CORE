using MANAJEMEN_RESTORAN_API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace MANAJEMEN_RESTORAN_API.Data
{
    public class RestoDbContext : DbContext
    {
        public RestoDbContext(DbContextOptions<RestoDbContext> dbContextOptions) : base(dbContextOptions) { }
        public DbSet<MHCustomer> MHCustomers { get; set; }
        public DbSet<MHCabang> MHCabangs {  get; set; }
        public DbSet<MHTable> MHTables { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    //modelBuilder.Entity<MHCustomer>().ToTable("MHCustomers", "dbo");
        //    //modelBuilder.Entity<MHCabang>().ToTable("MHCabangs", "dbo");
        //    //modelBuilder.Entity<MHTable>().ToTable("MHTables", "dbo");

        //}
    }
}   
