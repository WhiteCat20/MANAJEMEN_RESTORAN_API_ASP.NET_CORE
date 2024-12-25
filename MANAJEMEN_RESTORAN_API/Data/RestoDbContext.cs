using MANAJEMEN_RESTORAN_API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace MANAJEMEN_RESTORAN_API.Data
{
    public class RestoDbContext : DbContext
    {
        public RestoDbContext(DbContextOptions<RestoDbContext> dbContextOptions) : base(dbContextOptions) { }
        public DbSet<MHCustomer> mh_customer { get; set; }
        public DbSet<MHCabang> mh_cabang {  get; set; }
        public DbSet<MHTable> mh_table { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<MHCabang>()
                .HasMany(m => m.mh_table)
                .WithOne(s => s.mh_cabang)
                .HasForeignKey(s => s.id_mh_cabang)
                .IsRequired();

            modelBuilder.Entity<MHTable>()
                .HasOne(e => e.mh_cabang)
                .WithMany(e => e.mh_table)
                .HasForeignKey(e => e.id_mh_cabang)
                .IsRequired();

            modelBuilder.Entity<MHCustomer>().ToTable("mh_customer", "dbo");
            modelBuilder.Entity<MHCabang>().ToTable("mh_cabang", "dbo");
            modelBuilder.Entity<MHTable>().ToTable("mh_table", "dbo");

            
            
        }
    }
}   
