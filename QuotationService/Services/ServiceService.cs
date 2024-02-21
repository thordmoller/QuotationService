
using Microsoft.EntityFrameworkCore;
using QuotationService.Data;

namespace QuotationService.Services
{
    public class ServiceService
    {
        private readonly DataContext _context;

        public ServiceService(DataContext context) {
            _context = context;
        }

        /// <summary>
        /// hämtar priset på en tillvalstjänst baserat på id
        /// </summary>
        public decimal GetServicePrice(int serviceId) {
            var service = _context.Services
                .AsNoTracking()
                .FirstOrDefault(s => s.Id == serviceId);

            if(service == null) {
                throw new ArgumentException("Service not found", nameof(serviceId));
            }

            return service.Price;
        }
    }
}