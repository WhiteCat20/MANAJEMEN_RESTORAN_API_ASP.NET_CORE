using MANAJEMEN_RESTORAN_API.Data;

namespace MANAJEMEN_RESTORAN_API.Repositories
{
    public class SQLCustomerRepository
    {
        private readonly RestoDbContext dbContext;

        public SQLCustomerRepository(RestoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
