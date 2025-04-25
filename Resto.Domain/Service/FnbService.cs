using Microsoft.EntityFrameworkCore;
using Resto.Domain.Entity;

namespace Resto.Domain.Service
{
    public class FnbService : IFnbRepository
    {
        private readonly DatabaseContext dbContext;

        public FnbService(DatabaseContext dbContext)
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
