using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace Infrastruture.Data
{
    public class VehicleDBContext : DbContext
    {
        public VehicleDBContext(DbContextOptions<VehicleDBContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
