using Microsoft.EntityFrameworkCore;
using Resto.Domain.Data;
using Resto.Domain.Entity;

namespace Resto.Domain.Service
{
    public class CheckinService : ICheckinRepository
    {
        private readonly RestoDbContext dbContext;

        public CheckinService(RestoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<THCheckin>> GetAll()
        {
            var thCheckins = await dbContext.THCheckins.Include(x=>x.MHCabang).Include(x=>x.MHTable).ToListAsync();
            return thCheckins;
        }
        public async Task<THCheckin?> GetById(int id)
        {
            var checkin = await dbContext.THCheckins
                .Include(x => x.MHCabang)
                .Include(x => x.MHTable)
                .FirstOrDefaultAsync(x => x.Id == id);
            return checkin;
        }
        public async Task<THCheckin?> CreateDirectly(THCheckin checkin)
        {
            var cabang = await dbContext.MHCabangs.FirstOrDefaultAsync(c => c.Id == checkin.MHCabangId);
            var table = await dbContext.MHTables.FirstOrDefaultAsync(t => t.Id == checkin.MHTableId);
            if (cabang == null)
            {
                return null;
            }
            if(table?.isReserved == true)
            {
                return null;
            }

            // ambil duration
            var durationTimeSpan = TimeSpan.Parse(checkin.Duration.ToString("HH:mm:ss"));
            checkin.CheckOut = checkin.CheckIn.Add(durationTimeSpan);

            // update state table ke true, agar tidak nampak di get all
            table.isReserved = true;

            await dbContext.THCheckins.AddAsync(checkin);
            await dbContext.SaveChangesAsync();
            return checkin;
            
        }

        public async Task<THCheckin?> CreateFromReservation(int THReservationId)
        {
            // take the thReservation first
            var reservation = await dbContext.THReservations.FindAsync(THReservationId);
            if(reservation == null)
            {
                return null;
            }
            var newCheckin = new THCheckin
            {
                MHCabangId = reservation.MHCabangId,
                MHTableId = reservation.MHTableId,
                CheckIn = reservation.ReservationTime,
                CheckOut = reservation.ReservationTime.Add(TimeSpan.Parse(reservation.ReservationDuration.ToString("HH:mm:ss"))),
                Duration = reservation.ReservationDuration,
                CustomerName = reservation.CustomerName,
                CustomerPhone = reservation.CustomerPhone,
                CustomerTotal = reservation.CustomerTotal,
                Tax = 0,
                TotalPayment = 0,
            };
            await dbContext.THCheckins.AddAsync(newCheckin);
            await dbContext.SaveChangesAsync();
            return newCheckin;
        }

        
    }
}
