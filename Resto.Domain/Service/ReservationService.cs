using Microsoft.EntityFrameworkCore;
using Resto.Domain.Data;
using Resto.Domain.Entity;

namespace Resto.Domain.Service
{
    public class ReservationService : IReservationRepository
    {
        private readonly RestoDbContext dbContext;

        public ReservationService(RestoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<THReservation>> GetAll()
        {
            var reservations = await dbContext.THReservations
             .Include(r => r.MHCabang) // Eager load related MHCabang
             .Include(r => r.MHTable)
             .ToListAsync();
            return reservations;
        }

        public async Task<THReservation?> GetById(int id)
        {
            var reservation = await dbContext.THReservations.FirstOrDefaultAsync(x=> x.Id == id);
            if(reservation == null)
            {
                return null;
            }
            return reservation;
        }

        public async Task<THReservation?> Create(THReservation reservation)
        {
            // cek apakah cabang nya ada
            var reservedCabang = await dbContext.MHCabangs.FirstOrDefaultAsync(c => c.Id == reservation.MHCabangId);
            if (reservedCabang == null)
            {
                return null;
            }
            var reservedTable = await dbContext.MHTables.FirstOrDefaultAsync(t => t.Id == reservation.MHTableId);
            var reservationTimeCheck = ReservationTimeCheck(reservation);
            if (reservedTable?.isReserved == true && reservationTimeCheck)
            {
                return null;
            }
            reservedTable.isReserved = true;
            await dbContext.THReservations.AddAsync(reservation);
            await dbContext.SaveChangesAsync();
            return reservation;
        }

        public Task<THReservation?> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<THReservation?> Update(int id, THReservation reservation)
        {
            throw new NotImplementedException();
        }

        private bool ReservationTimeCheck(THReservation reservation)
        {
            // cek apakah waktu sudah menunjukan sepuluh menit sebelum waktu reservasi
            var reservationTime = TimeSpan.Parse(reservation.ReservationTime.ToString("HH:mm:ss"));
            var timeNow = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
            var tenMinutesBefore = reservationTime - TimeSpan.FromMinutes(10);
            return timeNow > tenMinutesBefore;
        }
    }
}
