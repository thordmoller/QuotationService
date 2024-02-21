using Microsoft.AspNetCore.Mvc;
using QuotationService.Data;
using QuotationService.DTOs;
using QuotationService.Services;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuotationService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuoteController:ControllerBase
    {
        private readonly QuoteService _quoteService;

        public QuoteController(QuoteService quoteService) {
            _quoteService = quoteService;
        }


        [HttpGet("{id}")]
        public string Get(int id) {
            return "value";
        }
        [HttpPost]
        public string Post([FromBody] QuoteDTO quote) {
            decimal quoteCalculation = Math.Round(_quoteService.CalculateTotal(quote), 2);

            return quoteCalculation.ToString();
        }
    }
}
