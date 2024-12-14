using AutoMapper;
using MANAJEMEN_RESTORAN_API.Models.Domain;
using MANAJEMEN_RESTORAN_API.Models.DTO;

namespace MANAJEMEN_RESTORAN_API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() {
            // source, destination
            CreateMap<MHCustomer, MHCustomerDto>().ReverseMap();
            CreateMap<MHCustomer, AddMHCustomerRequestDto>().ReverseMap();
            CreateMap<MHCustomer, UpdateMHCustomerRequestDto>().ReverseMap();
        }
    }
}
