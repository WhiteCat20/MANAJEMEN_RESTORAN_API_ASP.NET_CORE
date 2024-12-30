using MANAJEMEN_RESTORAN_API.Data;
using MANAJEMEN_RESTORAN_API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace MANAJEMEN_RESTORAN_API.Repositories
{
    public class SQLFnbRepository : IFnbRepository
    {
        private readonly RestoDbContext dbContext;

        public SQLFnbRepository(RestoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<MHFnb>> GetAllFnb()
        {
            return await dbContext.MHFnbs.Where(x => !x.isDeleted).ToListAsync();
        }

        public Task<MHFnb?> GetFnbById(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<MHFnb?> CreateFnb(MHFnb fnb)
        {
            await dbContext.MHFnbs.AddAsync(fnb);
            await dbContext.SaveChangesAsync();
            return fnb;
        }

        public Task<MHFnb?> UpdateFnb(int id, MHFnb fnb)
        {
            throw new NotImplementedException();
        }
        
        public async Task<MHFnb?> SoftDelete(int id)
        {
            var fnb = await dbContext.MHFnbs.FirstOrDefaultAsync(x => x.Id == id);
            if(fnb != null)
            {
                fnb.isDeleted = true;
                await dbContext.SaveChangesAsync();
            }
            return fnb;
        }
    }
}
