using AmazonPizza.Services.ProductAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AmazonPizza.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
