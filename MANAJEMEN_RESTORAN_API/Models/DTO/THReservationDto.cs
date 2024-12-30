using MANAJEMEN_RESTORAN_API.Models.Domain;
using System.Text.Json.Serialization;

namespace MANAJEMEN_RESTORAN_API.Models.DTO
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
        public string note { get; set; }

        // FK
        //public int MHCabangId { get; set; }
        //public int MHTableId { get; set; }

        // navigation 
        public MHCabangDto? MHCabang { get; set; }
        public MHTableDto? MHTable { get; set; }
    }
}
