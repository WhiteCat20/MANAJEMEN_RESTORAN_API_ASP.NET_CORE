using MANAJEMEN_RESTORAN_API.Data;
using MANAJEMEN_RESTORAN_API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace MANAJEMEN_RESTORAN_API.Repositories
{
    public class SQLTableRepository : ITableRepository
    {
        private readonly RestoDbContext dbContext;

        public SQLTableRepository(RestoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<MHTable>> GetAllAsync()
        {
            return await dbContext.mh_table.ToListAsync();
        }

        public Task<MHTable?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MHTable> CreateAsync(MHTable table)
        {
            throw new NotImplementedException();
        }
        public Task<MHTable?> UpdateAsync(int id, MHTable table)
        {
            throw new NotImplementedException();
        }
        public Task<MHTable?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
