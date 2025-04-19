using Resto.Domain.Entity;

namespace Resto.Domain.Service
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
