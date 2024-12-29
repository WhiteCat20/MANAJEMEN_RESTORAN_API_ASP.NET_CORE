using MANAJEMEN_RESTORAN_API.Models.Domain;

namespace MANAJEMEN_RESTORAN_API.Repositories
{
    public interface IReservationRepository
    {
        Task<List<THReservation>> GetAll();
        Task<THReservation?> GetById(int id);
        Task<THReservation?> Create(THReservation reservation);
        Task<THReservation?> Update(int id, THReservation reservation);
        Task<THReservation?> Delete(int id);
    }
}
