using MANAJEMEN_RESTORAN_API.Data;
using MANAJEMEN_RESTORAN_API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace MANAJEMEN_RESTORAN_API.Repositories
{
    public class SQLCustomerRepository : ICustomerRepository
    {
        private readonly RestoDbContext dbContext;

        public SQLCustomerRepository(RestoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<MHCustomer>> GetAllAsync()
        {
            return await dbContext.MHCustomers.ToListAsync();
        }

        public async Task<MHCustomer?> GetByIdAsync(int id)
        {
            return await dbContext.MHCustomers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<MHCustomer> CreateAsync(MHCustomer customer)
        {
            await dbContext.MHCustomers.AddAsync(customer);
            await dbContext.SaveChangesAsync();

            return customer; // mengembalikan customer, yang nantinya akan diubah menjadi DTO sebagai response message
        }

        public async Task<MHCustomer?> UpdateAsync(int id, MHCustomer customer)
        {
            var existingCustomer = await dbContext.MHCustomers.FirstOrDefaultAsync(x=>x.Id == id);
            if (existingCustomer == null) {
                return null;
            }
            existingCustomer.CustomerName = customer.CustomerName;
            existingCustomer.CustomerPhone = customer.CustomerPhone;
            await dbContext.SaveChangesAsync();

            return existingCustomer;
        }

        public async Task<MHCustomer?> DeleteAsync(int id)
        {
            var existingCustomer = await dbContext.MHCustomers.FirstOrDefaultAsync(x=> x.Id == id);
            if (existingCustomer == null) {
                return null;
            }

            dbContext.Remove(existingCustomer);
            await dbContext.SaveChangesAsync();

            return existingCustomer;
        }
    }
}
