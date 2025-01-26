using System.Text.Json.Serialization;

namespace MANAJEMEN_RESTORAN_API.Models.Domain
{
    public class MHFnb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int Stock { get; set; } = 100;
        public bool ColdHotAvailable { get; set; }
        public int Price { get; set; }
        public bool isDeleted { get; set; }
        [JsonIgnore]
        public List<TDService?> TDServices { get; set; }
    }
}
