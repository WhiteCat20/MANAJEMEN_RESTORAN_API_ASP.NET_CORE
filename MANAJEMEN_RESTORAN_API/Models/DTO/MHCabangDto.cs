using MANAJEMEN_RESTORAN_API.Models.Domain;

namespace MANAJEMEN_RESTORAN_API.Models.DTO
{
    public class MHCabangDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string kota { get; set; }
        public int jumlah_lantai { get; set; }

        public ICollection<MHTableDto> mh_table { get; set; } = new List<MHTableDto>();
    }
}
