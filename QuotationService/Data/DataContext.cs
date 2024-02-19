using Microsoft.EntityFrameworkCore;

namespace QuotationService.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<City> Cities { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}
