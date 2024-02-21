
using Microsoft.EntityFrameworkCore;
using QuotationService.Data;
using QuotationService.Services;

namespace QuotationService
{
    public class Program
    {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            IConfigurationRoot Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            builder.Services.AddDbContext<DataContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(8, 0, 34)),
                b => b.MigrationsAssembly("QuotationService")));

            builder.Services.AddScoped<CityService, CityService>();
            builder.Services.AddScoped<ServiceService, ServiceService>();
            builder.Services.AddScoped<QuoteService, QuoteService>();

            builder.Services.AddControllersWithViews();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if(!app.Environment.IsDevelopment()) {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            if(app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");

            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}