using System.Text.Json.Serialization;

namespace MANAJEMEN_RESTORAN_API.Models.Domain
{
    public class MHService
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        [JsonIgnore]
        public List<TDService?> TDServices { get; set; }
    }
}
