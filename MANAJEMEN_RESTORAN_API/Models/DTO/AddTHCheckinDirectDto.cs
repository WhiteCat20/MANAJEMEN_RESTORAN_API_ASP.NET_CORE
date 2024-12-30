namespace MANAJEMEN_RESTORAN_API.Models.DTO
{
    public class AddTHCheckinDirectDto
    {
        public int MHCabangId { get; set; }
        public int MHTableId { get; set; }
        public DateTime CheckIn { get; set; } = DateTime.Now;
        public TimeOnly Duration { get; set; }
        public string CustomerName { get; set; }
        public string? CustomerPhone { get; set; } = null;
        public int CustomerTotal { get; set; }
    }
}
