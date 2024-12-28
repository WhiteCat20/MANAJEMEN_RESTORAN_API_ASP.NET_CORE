using MANAJEMEN_RESTORAN_API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace MANAJEMEN_RESTORAN_API.Data
{
    public class RestoDbContext : DbContext
    {
        public RestoDbContext(DbContextOptions<RestoDbContext> dbContextOptions) : base(dbContextOptions) { }
        public DbSet<MHCustomer> MHCustomers { get; set; }
        public DbSet<MHCabang> MHCabangs { get; set; }
        public DbSet<MHTable> MHTables { get; set; }
        public DbSet<MHFnb> MHFnbs { get; set; }
        public DbSet<MHService> MHServices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MHCustomer>().ToTable("MHCustomers", "dbo");
            modelBuilder.Entity<MHCabang>().ToTable("MHCabangs", "dbo");
            modelBuilder.Entity<MHTable>().ToTable("MHTables", "dbo");
            modelBuilder.Entity<MHFnb>().ToTable("MHFnbs", "dbo");
            modelBuilder.Entity<MHService>().ToTable("MHServices", "dbo");

            var cabangs = new List<MHCabang>()
            {
                new MHCabang() { Id = 1, Name = "CABANG 1", Kota = "Surabaya", JumlahLantai = 1 },
                new MHCabang() { Id = 2, Name = "CABANG 2", Kota = "Sidoarjo", JumlahLantai = 2 },
                new MHCabang() { Id = 3, Name = "CABANG 3", Kota = "Gresik", JumlahLantai = 1 },
                new MHCabang() { Id = 4, Name = "CABANG 4", Kota = "Surabaya", JumlahLantai = 2 },
                new MHCabang() { Id = 5, Name = "CABANG 5", Kota = "Sidoarjo", JumlahLantai = 1 },
                new MHCabang() { Id = 6, Name = "CABANG 6", Kota = "Gresik", JumlahLantai = 2 },
                new MHCabang() { Id = 7, Name = "CABANG 7", Kota = "Surabaya", JumlahLantai = 1 },
                new MHCabang() { Id = 8, Name = "CABANG 8", Kota = "Sidoarjo", JumlahLantai = 2 },
                new MHCabang() { Id = 9, Name = "CABANG 9", Kota = "Gresik", JumlahLantai = 1 },
                new MHCabang() { Id = 10, Name = "CABANG 10", Kota = "Surabaya", JumlahLantai = 2 },
            };

            modelBuilder.Entity<MHCabang>().HasData(cabangs);

            var tables = new List<MHTable>()
            {
                new MHTable() { Id = 1, NomorMeja = 1, Lantai = 1, isReserved = false, Capacity = 4, Status = 0, mhCabangId = 1 },
                new MHTable() { Id = 2, NomorMeja = 2, Lantai = 1, isReserved = false, Capacity = 6, Status = 1, mhCabangId = 1 },
                new MHTable() { Id = 3, NomorMeja = 3, Lantai = 2, isReserved = false, Capacity = 2, Status = 0, mhCabangId = 2 },
                new MHTable() { Id = 4, NomorMeja = 4, Lantai = 2, isReserved = false, Capacity = 4, Status = 1, mhCabangId = 2 },
                new MHTable() { Id = 5, NomorMeja = 5, Lantai = 1, isReserved = false, Capacity = 8, Status = 0, mhCabangId = 3 },
                new MHTable() { Id = 6, NomorMeja = 6, Lantai = 1, isReserved = false, Capacity = 4, Status = 1, mhCabangId = 3 },
                new MHTable() { Id = 7, NomorMeja = 7, Lantai = 2, isReserved = false, Capacity = 6, Status = 0, mhCabangId = 4 },
                new MHTable() { Id = 8, NomorMeja = 8, Lantai = 2, isReserved = false, Capacity = 2, Status = 1, mhCabangId = 4 },
                new MHTable() { Id = 9, NomorMeja = 9, Lantai = 1, isReserved = false, Capacity = 4, Status = 0, mhCabangId = 5 },
                new MHTable() { Id = 10, NomorMeja = 10, Lantai = 1, isReserved = false, Capacity = 8, Status = 1, mhCabangId = 5 },

            };

            modelBuilder.Entity<MHTable>().HasData(tables);

            var services = new List<MHService>()
            {
                new MHService() { Id = 1, ServiceName = "order"},
                new MHService() { Id = 2, ServiceName = "call"},
                new MHService() { Id = 3, ServiceName = "pay"},
                new MHService() { Id = 4, ServiceName = "complaint"},
            };

            modelBuilder.Entity<MHService>().HasData(services);

            modelBuilder.Entity<MHTable>()
            .HasOne(b => b.MHCabang) // A Table has one Cabang
            .WithMany(a => a.MHTables) // An Author has many Books
            .HasForeignKey(b => b.mhCabangId).OnDelete(DeleteBehavior.Restrict); // Foreign Key

        }
    }
}
