using Microsoft.EntityFrameworkCore;

namespace QuotationService.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<City> Cities { get; set; }
        public DbSet<Service> Services { get; set; }

        //lägger in data som behövs i databasen
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Name = "Stockholm", Rate = 65 },
                new City { Id = 2, Name = "Uppsala", Rate = 55 }
            );
            modelBuilder.Entity<Service>().HasData(
                new Service { Id = 1, Name = "Fönsterputs", Price = 300, CityId = 1 },
                new Service { Id = 2, Name = "Balkongstädning", Price = 150, CityId = 1 },

                new Service { Id = 3, Name = "Fönsterputs", Price = 300, CityId = 2 },
                new Service { Id = 4, Name = "Balkongstädning", Price = 150, CityId = 2 },
                new Service { Id = 5, Name = "Bortforsling av skräp", Price = 400, CityId = 2 }
                );
        }
    }
}
