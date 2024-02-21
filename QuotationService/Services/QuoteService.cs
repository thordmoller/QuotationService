using QuotationService.DTOs;

namespace QuotationService.Services
{
    public class QuoteService
    {
        private readonly CityService _cityService;
        private readonly ServiceService _serviceService;

        public QuoteService(CityService cityService, ServiceService serviceservice) {
            _cityService = cityService;
            _serviceService = serviceservice;
        }
        /// <summary>
        /// beräknar totala priset av en offert från klienten
        /// </summary>
        public decimal CalculateTotal(QuoteDTO quote) {

            decimal total = 0;

            decimal rate = _cityService.GetCityRate(quote.CityId);
            decimal totalSquareMeterPrice = quote.SquareMeters * rate;

            decimal totalAdditionalServicesPrice = 0;
            foreach(var service in quote.services) {
                if(service.Checked) {
                    decimal serviceRate = _serviceService.GetServicePrice(service.Id);
                    totalAdditionalServicesPrice += serviceRate;
                }

            }

            total += totalSquareMeterPrice += totalAdditionalServicesPrice;

            return total;
        }
    }
}
