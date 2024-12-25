namespace MANAJEMEN_RESTORAN_API.Models.Domain
{
    public class MHTable
    {
        public int id { get; set; }
        public int nomor_meja { get; set; }
        public int lantai {  get; set; }
        public int is_reserved { get; set; }
        public int capacity { get; set; }
        public int status { get; set; }

        public int id_mh_cabang { get; set; }
        // navigation
        public MHCabang mh_cabang { get; set; } = null!;
    }
}
