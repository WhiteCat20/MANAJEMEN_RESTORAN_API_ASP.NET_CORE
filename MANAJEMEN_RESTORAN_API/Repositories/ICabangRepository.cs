using MANAJEMEN_RESTORAN_API.Models.Domain;

namespace MANAJEMEN_RESTORAN_API.Repositories
{
    public interface ICabangRepository
    {
        Task<List<MHCabang>> GetAllAsync();
        Task<MHCabang?> GetByIdAsync(int id);
        Task<MHCabang> CreateAsync(MHCabang cabang);
        Task<MHCabang?> UpdateAsync(int id, MHCabang cabang);
        Task<MHCabang?> DeleteAsync(int id);
    }
}
