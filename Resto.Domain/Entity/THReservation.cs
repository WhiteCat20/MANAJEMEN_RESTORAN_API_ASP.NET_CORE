using System.Text.Json.Serialization;
using Resto.Domain.DTO;

namespace Resto.Domain.Entity
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
        public string Note { get; set; }
        public bool isFinished { get; set; } = false; 

        // FK
        public int MHCabangId { get; set; }
        public int MHTableId { get; set; }

        // navigation 
        [JsonIgnore]
        public MHCabang MHCabang { get; set; }
        [JsonIgnore]
        public MHTable MHTable { get; set; }

        public THReservationDto ToDto()
        {
            return new THReservationDto()
            {
                Id = Id,
                ReservationTime = ReservationTime,
                ReservationDuration = ReservationDuration,
                CustomerName = CustomerName,
                CustomerPhone = CustomerPhone,
                CustomerTotal = CustomerTotal,
                DownPayment = DownPayment,
                Note = Note,
                MHCabang = MHCabang,
                MHTable = MHTable,
            };
        }
        
    }
}
