using MANAJEMEN_RESTORAN_API.Models.Domain;
using System.Text.Json.Serialization;

namespace MANAJEMEN_RESTORAN_API.Models.DTO
{
    public class THCheckinDto
    {
        public int Id { get; set; }
        // FK
        public int MHCabangId { get; set; }
        public int MHTableId { get; set; }
        public string Code { get; set; }
        public DateTime CheckIn { get; set; } = DateTime.Now;
        public DateTime CheckOut { get; set; }
        public TimeOnly Duration { get; set; }
        public string CustomerName { get; set; }
        public string? CustomerPhone { get; set; } = null;
        public int CustomerTotal { get; set; }
        public int Tax { get; set; }
        public int TotalPayment { get; set; }

        // navigation 
        //[JsonIgnore]
        public MHCabang MHCabang { get; set; }
        //[JsonIgnore]
        public MHTable MHTable { get; set; }
        //[JsonIgnore]
        public List<TDService?> TDServices { get; set; }
    }
}
