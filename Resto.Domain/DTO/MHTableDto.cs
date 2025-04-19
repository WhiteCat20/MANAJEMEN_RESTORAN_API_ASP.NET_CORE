using Resto.Domain.Entity;

namespace Resto.Domain.DTO
{
    public class MHTableDto
    {
        public int Id { get; set; }
        public int NomorMeja { get; set; }
        public int Lantai { get; set; }
        public bool isReserved { get; set; }
        public int Capacity { get; set; }
        public int Status { get; set; }

        public int mhCabangId { get; set; }
        // navigation
        //[JsonIgnore]
        public MHCabang MHCabang { get; set; }
    }
}
