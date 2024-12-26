using MANAJEMEN_RESTORAN_API.Models.Domain;
using System.Text.Json.Serialization;

namespace MANAJEMEN_RESTORAN_API.Models.DTO
{
    public class MHCabangDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Kota { get; set; }
        public int JumlahLantai { get; set; }

        //[JsonIgnore]
        public List<MHTable?> MHTables { get; set; }
        
    }
}
