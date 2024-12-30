using MANAJEMEN_RESTORAN_API.Models.Domain;

namespace MANAJEMEN_RESTORAN_API.Repositories
{
    public interface ICheckinRepository
    {
        Task<List<THCheckin>> GetAll();
        Task<THCheckin?> GetById(int id);
        Task<THCheckin?> CreateDirectly(THCheckin checkin);
        Task<THCheckin?> CreateFromReservation(int THReservationId);
        
    }
}
