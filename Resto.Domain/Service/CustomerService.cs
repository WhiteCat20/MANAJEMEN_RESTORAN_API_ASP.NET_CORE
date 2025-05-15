using Microsoft.EntityFrameworkCore;
using Resto.Domain.Entity;

namespace Resto.Domain.Service
{
    public class CustomerService : ICustomerRepository
    {
        private readonly DatabaseContext _dbContext;

        public CustomerService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<MHCustomer>> GetAllAsync()
        {
            return await _dbContext.MHCustomers.ToListAsync();
        }

        public async Task<MHCustomer?> GetByIdAsync(int id)
        {
            return await _dbContext.MHCustomers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<MHCustomer> CreateAsync(MHCustomer customer)
        {
            await _dbContext.MHCustomers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();

            return customer; // mengembalikan customer, yang nantinya akan diubah menjadi DTO sebagai response message
        }

        public async Task<MHCustomer?> UpdateAsync(int id, MHCustomer customer)
        {
            var existingCustomer = await _dbContext.MHCustomers.FirstOrDefaultAsync(x=>x.Id == id);
            if (existingCustomer == null) {
                return null;
            }
            existingCustomer.CustomerName = customer.CustomerName;
            existingCustomer.CustomerPhone = customer.CustomerPhone;
            await _dbContext.SaveChangesAsync();

            return existingCustomer;
        }

        public async Task<MHCustomer?> DeleteAsync(int id)
        {
            var existingCustomer = await _dbContext.MHCustomers.FirstOrDefaultAsync(x=> x.Id == id);
            if (existingCustomer == null) {
                return null;
            }

            _dbContext.Remove(existingCustomer);
            await _dbContext.SaveChangesAsync();

            return existingCustomer;
        }
    }
}
