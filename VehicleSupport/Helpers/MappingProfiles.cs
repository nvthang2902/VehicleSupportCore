using AutoMapper;
using Core.Entities;
using VehicleSupport.Dtos;

namespace VehicleSupport.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d=>d.ProductBrand,o=>o.MapFrom(s=>s.ProductBrand.BrandName))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.TypeName))
                .ForMember(d=>d.Image,o=>o.MapFrom<ProductUrlResolver>());
        }
    }
}
