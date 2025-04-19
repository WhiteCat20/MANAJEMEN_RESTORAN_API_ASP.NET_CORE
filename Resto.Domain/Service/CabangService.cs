using Microsoft.EntityFrameworkCore;
using Resto.Domain.Data;
using Resto.Domain.Entity;

namespace Resto.Domain.Service
{
    public class CabangService : ICabangRepository
    {
        private readonly RestoDbContext dbContext;

        public CabangService(RestoDbContext dbContext)
        { 
            this.dbContext = dbContext;
        }

        public async Task<List<MHCabang>> GetAllAsync()
        {
            return await dbContext.MHCabangs.Include(a=>a.MHTables).ToListAsync();
        }

        public async Task<MHCabang?> GetByIdAsync(int id)
        {
            return await dbContext.MHCabangs.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<MHCabang> CreateAsync(MHCabang cabang)
        {
            await dbContext.MHCabangs.AddAsync(cabang);
            await dbContext.SaveChangesAsync();

            return cabang; 
        }

        public async Task<MHCabang?> UpdateAsync(int id, MHCabang cabang)
        {
            var existingCabang = await dbContext.MHCabangs.FirstOrDefaultAsync(x => x.Id == id);
            if (existingCabang == null)
            {
                return null;
            }
            existingCabang.Name = cabang.Name;
            existingCabang.Kota = cabang.Kota;
            existingCabang.JumlahLantai = cabang.JumlahLantai;
            await dbContext.SaveChangesAsync();

            return existingCabang;
        }

        public async Task<MHCabang?> DeleteAsync(int id)
        {
            var existingCabang = await dbContext.MHCabangs.FirstOrDefaultAsync(x => x.Id == id);
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
