using MANAJEMEN_RESTORAN_API.Models.Domain;

namespace MANAJEMEN_RESTORAN_API.Repositories
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
