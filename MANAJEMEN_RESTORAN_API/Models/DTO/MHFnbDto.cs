namespace MANAJEMEN_RESTORAN_API.Models.DTO
{
    public class MHFnbDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Stock { get; set; }
        public bool ColdHotAvailable { get; set; }
        public int Price { get; set; }
    }
}
