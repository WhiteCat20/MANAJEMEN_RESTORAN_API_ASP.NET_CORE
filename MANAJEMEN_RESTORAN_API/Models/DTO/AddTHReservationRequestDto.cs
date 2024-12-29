namespace MANAJEMEN_RESTORAN_API.Models.DTO
{
    public class AddTHReservationRequestDto
    {
        // FK
        public int MHCabangId { get; set; }
        public int MHTableId { get; set; }
        public DateTime ReservationTime { get; set; }
        public TimeOnly ReservationDuration { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public int CustomerTotal { get; set; }
        public int DownPayment { get; set; }
        public string note { get; set; }
        
    }
}
