using Resto.Domain.Entity;

namespace Resto.Domain.DTO
{
    public class THReservationDto
    {
        public int Id { get; set; }
        public DateTime ReservationTime { get; set; }
        public TimeOnly ReservationDuration { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public int CustomerTotal { get; set; }
        public int DownPayment { get; set; }
        public string Note { get; set; }

        // FK
        //public int MHCabangId { get; set; }
        //public int MHTableId { get; set; }

        // navigation 
        public MHCabang? MHCabang { get; set; }
        public MHTable? MHTable { get; set; }
    }
}
