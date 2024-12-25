namespace MANAJEMEN_RESTORAN_API.Models.Domain
{
    public class MHCabang
    {
        public int id { get; set; }
        public string name { get; set; }
        public string kota { get; set; }
        public int jumlah_lantai { get; set; }

        public ICollection<MHTable> mh_table { get; set; } = new List<MHTable>();
    }
}
