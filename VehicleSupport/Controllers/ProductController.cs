using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleSupport.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //Run
    //dotnet watch -p C:\Users\OS\Documents\InternshipTT\.NetTT\VehicleSupport\VehicleSupport\VehicleSupport.csproj run
    public class ProductController : ControllerBase
    {
        private readonly IProductReponsitory _repo;

        public ProductController(IProductReponsitory repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _repo.GetProductsAsync();
            return Ok(products);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _repo.GetProductByIdAyscn(id);
        }
    }
}
