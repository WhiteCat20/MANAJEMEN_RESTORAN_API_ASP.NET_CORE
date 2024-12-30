using System.Text.Json.Serialization;

namespace MANAJEMEN_RESTORAN_API.Models.Domain
{
    public class THCheckin
    {
        public int Id { get; set; }
        // FK
        public int MHCabangId { get; set; }
        public int MHTableId { get; set; }
        public string Code { get; set; } = GenerateCode();
        public DateTime CheckIn { get; set; } = DateTime.Now;
        public DateTime CheckOut { get; set; }
        public TimeOnly Duration { get; set; } 
        public string CustomerName { get; set; }
        public string? CustomerPhone { get; set; } = null;
        public int CustomerTotal { get; set; }
        public int Tax { get; set; }
        public int TotalPayment { get; set; }

        // navigation 
        [JsonIgnore]
        public MHCabang MHCabang { get; set; }
        [JsonIgnore]
        public MHTable MHTable { get; set; }

        private static string GenerateCode()
        {
            string dateTimePart = DateTime.Now.ToString("yyyyMMdd");
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            string randomPart = new string(Enumerable.Repeat(chars, 6)
                                        .Select(s => s[random.Next(s.Length)])
                                        .ToArray());

            return $"{dateTimePart}{randomPart}";
        } 
    }
}
