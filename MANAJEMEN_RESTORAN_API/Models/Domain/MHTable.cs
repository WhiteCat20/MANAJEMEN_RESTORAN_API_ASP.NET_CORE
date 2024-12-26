using System.Text.Json.Serialization;

namespace MANAJEMEN_RESTORAN_API.Models.Domain
{
    public class MHTable
    {
        public int Id { get; set; }
        public int NomorMeja { get; set; }
        public int Lantai {  get; set; }
        public bool isReserved { get; set; }
        public int Capacity { get; set; }
        public int Status { get; set; }

        public int mhCabangId { get; set; }
        // navigation
        [JsonIgnore]
        public MHCabang MHCabang { get; set; }
    }
}
