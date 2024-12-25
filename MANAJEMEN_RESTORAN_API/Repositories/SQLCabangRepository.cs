using MANAJEMEN_RESTORAN_API.Data;
using MANAJEMEN_RESTORAN_API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace MANAJEMEN_RESTORAN_API.Repositories
{
    public class SQLCabangRepository : ICabangRepository
    {
        private readonly RestoDbContext dbContext;

        public SQLCabangRepository(RestoDbContext dbContext)
        { 
            this.dbContext = dbContext;
        }

        public async Task<List<MHCabang>> GetAllAsync()
        {
            return await dbContext.mh_cabang.ToListAsync();
        }

        public async Task<MHCabang?> GetByIdAsync(int id)
        {
            return await dbContext.mh_cabang.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<MHCabang> CreateAsync(MHCabang cabang)
        {
            await dbContext.mh_cabang.AddAsync(cabang);
            await dbContext.SaveChangesAsync();

            return cabang; 
        }

        public async Task<MHCabang?> UpdateAsync(int id, MHCabang cabang)
        {
            var existingCabang = await dbContext.mh_cabang.FirstOrDefaultAsync(x => x.id == id);
            if (existingCabang == null)
            {
                return null;
            }
            existingCabang.name = cabang.name;
            existingCabang.kota = cabang.kota;
            existingCabang.jumlah_lantai = cabang.jumlah_lantai;
            await dbContext.SaveChangesAsync();

            return existingCabang;
        }

        public async Task<MHCabang?> DeleteAsync(int id)
        {
            var existingCabang = await dbContext.mh_cabang.FirstOrDefaultAsync(x => x.id == id);
            if (existingCabang == null)
            {
                return null;
            }

            dbContext.Remove(existingCabang);
            await dbContext.SaveChangesAsync();

            return existingCabang;
        }
    }
}
