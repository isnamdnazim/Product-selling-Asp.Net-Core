using Microsoft.EntityFrameworkCore;
using TestProject.Models;

namespace TestProject.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<CustomerInfo> CustomerInfos { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<SalesProduct> SalesProducts { get; set; }
        public DbSet<Qrs> Qrs { get; set; }
    }
}
