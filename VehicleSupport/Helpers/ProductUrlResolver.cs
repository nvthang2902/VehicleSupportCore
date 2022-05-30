using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;
using VehicleSupport.Dtos;

namespace VehicleSupport.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductDto, string>
    {
        private readonly IConfiguration _config;

        public ProductUrlResolver(IConfiguration config)
        {
            _config=config;
        }

        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Image))
            {
                return _config["ApiUrl"] + source.Image;

            }
            return null;
        }
    }
}
