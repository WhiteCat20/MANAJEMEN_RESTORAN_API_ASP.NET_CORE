using Resto.Domain.Entity;

namespace Resto.Domain.Service
{
    public interface ICustomerRepository
    {
        Task<List<MHCustomer>> GetAllAsync();
        Task<MHCustomer?> GetByIdAsync(int id);
        Task<MHCustomer> CreateAsync(MHCustomer customer);
        Task<MHCustomer?> UpdateAsync(int id, MHCustomer customer);
        Task<MHCustomer?> DeleteAsync(int id);
    }
}
