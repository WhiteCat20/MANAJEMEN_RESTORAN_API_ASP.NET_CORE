using System.Text.Json.Serialization;

namespace MANAJEMEN_RESTORAN_API.Models.Domain
{
    public class THReservation
    {
        public int Id { get; set; }     
        public DateTime ReservationTime { get; set; }
        public TimeOnly ReservationDuration { get; set; }
        public string CustomerName { get; set; }    
        public string CustomerPhone { get; set; }
        public int CustomerTotal { get; set; }
        public int DownPayment { get; set; }
        public string note { get; set; }
        public bool isFinished { get; set; } = false; 

        // FK
        public int MHCabangId { get; set; }
        public int MHTableId { get; set; }

        // navigation 
        [JsonIgnore]
        public MHCabang MHCabang { get; set; }
        [JsonIgnore]
        public MHTable MHTable { get; set; }

    }
}
