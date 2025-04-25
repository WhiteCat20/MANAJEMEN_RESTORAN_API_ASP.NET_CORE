using Microsoft.EntityFrameworkCore;
using Resto.Domain.Entity;

namespace Resto.Domain.Service
{
    public class TableService : ITableRepository
    {
        private readonly DatabaseContext dbContext;

        public TableService(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<MHTable>> GetAllAsync()
        {
            return await dbContext.MHTables.Where(x=> x.isReserved == false).Include("MHCabang").ToListAsync();
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
