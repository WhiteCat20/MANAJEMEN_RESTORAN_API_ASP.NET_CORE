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
            return await dbContext.mh_customer.ToListAsync();
        }

        public async Task<MHCustomer?> GetByIdAsync(int id)
        {
            return await dbContext.mh_customer.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<MHCustomer> CreateAsync(MHCustomer customer)
        {
            await dbContext.mh_customer.AddAsync(customer);
            await dbContext.SaveChangesAsync();

            return customer; // mengembalikan customer, yang nantinya akan diubah menjadi DTO sebagai response message
        }

        public async Task<MHCustomer?> UpdateAsync(int id, MHCustomer customer)
        {
            var existingCustomer = await dbContext.mh_customer.FirstOrDefaultAsync(x=>x.id == id);
            if (existingCustomer == null) {
                return null;
            }
            existingCustomer.customer_name = customer.customer_name;
            existingCustomer.customer_phone = customer.customer_phone;
            await dbContext.SaveChangesAsync();

            return existingCustomer;
        }

        public async Task<MHCustomer?> DeleteAsync(int id)
        {
            var existingCustomer = await dbContext.mh_customer.FirstOrDefaultAsync(x=> x.id == id);
            if (existingCustomer == null) {
                return null;
            }

            dbContext.Remove(existingCustomer);
            await dbContext.SaveChangesAsync();

            return existingCustomer;
        }
    }
}
