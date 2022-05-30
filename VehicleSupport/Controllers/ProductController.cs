using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastruture.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleSupport.Dtos;
using VehicleSupport.Helpers;

namespace VehicleSupport.Controllers
{
    
    //Run
    //dotnet watch -p C:\Users\OS\Documents\InternshipTT\.NetTT\VehicleSupport\VehicleSupport\VehicleSupport.csproj run
    public class ProductController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductController(IGenericRepository<Product> productRepo, 
            IGenericRepository<ProductBrand> productBrandRepo, IGenericRepository<ProductType>
            productTypeRepo, IMapper mapper)
        {
            _productRepo=productRepo;
            _productBrandRepo=productBrandRepo;
            _productTypeRepo=productTypeRepo;
            _mapper=mapper;
        }
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductDto>>> GetProducts(
            [FromQuery]ProductSpecParams productParams)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(productParams);

            var countSpec = new ProductWithFiltersForCountSpecification(productParams);

            var totalItems = await _productRepo.CountAsync(countSpec);

            var products = await _productRepo.ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);

            return Ok(new Pagination<ProductDto>(productParams.PageIndex,productParams.PageSize,totalItems,data));

        }
        [HttpGet("{id}")]
        //public async Task<ActionResult<Product>> GetProduct(int id)
        //{
        //    var spec = new ProductsWithTypesAndBrandsSpecification(id);
        //    return await _productRepo.GetEntityWithSpec(spec);
        //}
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productRepo.GetEntityWithSpec(spec);

            return _mapper.Map<Product, ProductDto>(product);

        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepo.ListAllAsync());
            
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypeRepo.ListAllAsync());

        }
    }
}
