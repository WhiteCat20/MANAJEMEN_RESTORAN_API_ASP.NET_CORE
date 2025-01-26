using MANAJEMEN_RESTORAN_API.Data;
using MANAJEMEN_RESTORAN_API.Models.Domain;

namespace MANAJEMEN_RESTORAN_API.Repositories
{
    public class SQLTDServiceRepository : ITDServiceRepository
    {
        private readonly RestoDbContext dbContext;

        public SQLTDServiceRepository(RestoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<TDService?> CreateService(TDService service)
        {
            await dbContext.TDServices.AddAsync(service);
            await dbContext.SaveChangesAsync();
            return service;
        }

        public Task<List<TDService>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
