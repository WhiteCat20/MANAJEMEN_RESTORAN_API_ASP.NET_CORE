using System.Text.Json.Serialization;

namespace MANAJEMEN_RESTORAN_API.Models.Domain
{
    public class TDService
    {
        public int Id { get; set; }
        public int THCheckinId { get; set; }
        public int MHServiceId { get; set; }
        public int MHFnbId { get; set; }
        public int FnbQty { get; set; }
        public bool ColdOrHot { get; set; } = false;
        public string Note { get; set; } = string.Empty;
        // 0 = pending, 1 = process, 2 = done, 3 = canceled (by kitchen)
        public int Status { get; set; } = 0;
        [JsonIgnore]
        public THCheckin THCheckin { get; set; }
        [JsonIgnore]
        public MHService MHService { get; set; }
        [JsonIgnore]
        public MHFnb MHFnb { get; set; }
    }
}
