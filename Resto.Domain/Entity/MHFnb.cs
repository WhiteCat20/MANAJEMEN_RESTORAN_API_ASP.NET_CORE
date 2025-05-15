using Resto.Domain.DTO;

namespace Resto.Domain.Entity
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

        public MHFnbDto ToDto()
        {
            return new MHFnbDto()
            {
                Id = Id,
                Name = Name,
                Type = Type,
                Stock = Stock,
                ColdHotAvailable = ColdHotAvailable,
                Price = Price,
            };
        }
    }
}
