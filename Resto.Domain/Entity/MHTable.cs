using System.Text.Json.Serialization;
using Resto.Domain.DTO;

namespace Resto.Domain.Entity
{
    public class MHTable
    {
        public int Id { get; set; }
        public int NomorMeja { get; set; }
        public int Lantai {  get; set; }
        public bool isReserved { get; set; } = false;
        public int Capacity { get; set; }
        public int Status { get; set; }

        public int mhCabangId { get; set; }
        // navigation
        [JsonIgnore]
        public MHCabang MHCabang { get; set; }
        [JsonIgnore]
        public List<THReservation?> THReservations { get; set; }
        [JsonIgnore]
        public List<THCheckin?> THCheckins { get; set; }

        public MHTableDto ToDto()
        {
            return new MHTableDto
            {
                Id = Id,
                NomorMeja = NomorMeja,
                Lantai = Lantai,
                Capacity = Capacity,
                Status = Status,
            };
        }
    }
}
