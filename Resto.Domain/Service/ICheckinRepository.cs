using Resto.Domain.Entity;

namespace Resto.Domain.Service
{
    public interface ICheckinRepository
    {
        Task<List<THCheckin>> GetAll();
        Task<THCheckin?> GetById(int id);
        Task<THCheckin?> CreateDirectly(THCheckin checkin);
        Task<THCheckin?> CreateFromReservation(int THReservationId);
        
    }
}
