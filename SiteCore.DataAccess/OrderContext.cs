using Microsoft.EntityFrameworkCore;
using WebApiSample.DataAccess.Models;

namespace WebApiSample.DataAccess
{
    public class SiteCoreContext : DbContext
    {

        public SiteCoreContext()
        {
        }

        public SiteCoreContext(DbContextOptions<SiteCoreContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
