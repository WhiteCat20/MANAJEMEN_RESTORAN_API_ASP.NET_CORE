using MANAJEMEN_RESTORAN_API.Models.Domain;

namespace MANAJEMEN_RESTORAN_API.Repositories
{
    public interface ITDServiceRepository
    {
        Task<List<TDService>> GetAll();
        Task<TDService?> CreateService(TDService service);
    }
}
