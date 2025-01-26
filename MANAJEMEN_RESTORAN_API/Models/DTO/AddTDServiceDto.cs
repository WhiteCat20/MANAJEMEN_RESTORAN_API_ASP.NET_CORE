namespace MANAJEMEN_RESTORAN_API.Models.DTO
{
    public class AddTDServiceDto
    {
        public int THCheckinId { get; set; }
        public int MHServiceId { get; set; }
        public int MHFnbId { get; set; }
        public int FnbQty { get; set; }
        public bool ColdOrHot { get; set; } = false;
        public string Note { get; set; } = string.Empty;
    }
}
