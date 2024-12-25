using MANAJEMEN_RESTORAN_API.Models.Domain;

namespace MANAJEMEN_RESTORAN_API.Models.DTO
{
    public class MHCabangDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Kota { get; set; }
        public int JumlahLantai { get; set; }
    }
}
