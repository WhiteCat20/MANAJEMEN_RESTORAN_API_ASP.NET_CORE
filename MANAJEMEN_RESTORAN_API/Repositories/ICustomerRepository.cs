using MANAJEMEN_RESTORAN_API.Models.Domain;

namespace MANAJEMEN_RESTORAN_API.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<MHCustomer>> GetAllAsync();
        Task<MHCustomer> GetAsync(int id);
    }
}
