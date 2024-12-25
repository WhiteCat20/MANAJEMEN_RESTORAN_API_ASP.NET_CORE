using MANAJEMEN_RESTORAN_API.Models.Domain;

namespace MANAJEMEN_RESTORAN_API.Repositories
{
    public interface ITableRepository
    {
        Task<List<MHTable>> GetAllAsync();
        Task<MHTable?> GetByIdAsync(int id);
        Task<MHTable> CreateAsync(MHTable table);
        Task<MHTable?> UpdateAsync(int id, MHTable table);
        Task<MHTable?> DeleteAsync(int id);
    }
}
