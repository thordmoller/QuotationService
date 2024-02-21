using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuotationService.Data;

namespace QuotationService
{
    public class CityService
    {
        private readonly DataContext _context;

        public CityService(DataContext context) {
            _context = context;
        }

        /// <summary>
        /// hämta alla tillvalstjänster som är tillgängliga för en stad baserat på stadens id
        /// </summary>
        public IEnumerable<ServiceDTO> GetCityServices(int cityId) {
            var city = _context.Cities
                .Include(c => c.Services)
                .FirstOrDefault(c => c.Id == cityId);

            if(city == null) {
                return Enumerable.Empty<ServiceDTO>();
            }

            var services = city.Services.Select(o => new ServiceDTO { Id = o.Id, Name = o.Name, Price = o.Price }).ToList();
            return services;
        }

        /// <summary>
        /// hämtar kostnaden per kvadratmeter för en stad baserat på dess id
        /// </summary>
        public decimal GetCityRate(int cityId) {
            var city = _context.Cities
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == cityId);

            if(city == null) {
                throw new ArgumentException("City not found", nameof(cityId));
            }

            return city.Rate;
        }

        public async Task<City> GetCityById(int id) {
            var city = await _context.Cities
                .Include(c => c.Services)
                .FirstOrDefaultAsync(c => c.Id == id);
            return city;
        }

        public IEnumerable<CityNameDTO> GetCityNames() {
            var cities = _context.Cities
                .Select(c => new CityNameDTO { Id = c.Id, Name = c.Name })
                .ToList();

            return cities;
        }
    }

}
