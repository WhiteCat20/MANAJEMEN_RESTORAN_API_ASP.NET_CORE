using MANAJEMEN_RESTORAN_API.Models.Domain;
using MANAJEMEN_RESTORAN_API.Models.DTO;

namespace MANAJEMEN_RESTORAN_API.Mappings
{
    public static class MHFnbMapper
    {
        public static MHFnbDto MapToDto(MHFnb source)
        {
            return new MHFnbDto
            {
                Id = source.Id,
                Name = source.Name,
                Price = source.Price,
                Stock = source.Stock,
                Type = source.Type == 0 ? "food" : source.Type == 1 ? "drink" : "unknown",
                ColdHotAvailable = source.ColdHotAvailable
            };
        }

        public static List<MHFnbDto> MapToDtoList(List<MHFnb> sourceList)
        {
            return sourceList.Select(source => MapToDto(source)).ToList();
        }
    }
}
