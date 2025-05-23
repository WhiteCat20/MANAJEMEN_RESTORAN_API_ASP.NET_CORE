﻿using System.Text.Json.Serialization;

namespace Resto.Domain.Entity
{
    public class MHCabang
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Kota { get; set; }
        public int JumlahLantai { get; set; }
        [JsonIgnore]
        public List<MHTable?> MHTables { get; set; }
        [JsonIgnore]
        public List<THReservation?> THReservations { get; set; }
        [JsonIgnore]
        public List<THCheckin?> THCheckins { get; set; }
    }
}
