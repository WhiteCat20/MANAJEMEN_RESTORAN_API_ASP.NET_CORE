﻿using MANAJEMEN_RESTORAN_API.Models.Domain;

namespace MANAJEMEN_RESTORAN_API.Models.DTO
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
        public MHCabang MHCabang { get; set; }
    }
}
