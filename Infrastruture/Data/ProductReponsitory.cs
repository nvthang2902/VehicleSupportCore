using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductReponsitory : IProductReponsitory
    {
        private readonly VehicleDBContext _context;

        public ProductReponsitory(VehicleDBContext context)
        {
            _context=context;
        }

        public async Task<Product> GetProductByIdAyscn(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
