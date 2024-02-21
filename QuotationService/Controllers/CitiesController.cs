namespace QuotationService.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuotationService.Data;

[Route("[controller]")]
[ApiController]
public class CitiesController:ControllerBase
{
    private readonly CityService _cityService;
    private readonly DataContext _context;

    public CitiesController(DataContext context, CityService cityService) {
        _context = context;
        _cityService = cityService;
    }
    private static readonly IEnumerable<City> _cities = new[]
    {
        new City { Id=1, Name = "Stockholm", Rate=65, Services = new List<Service>
            {
                new Service { Name = "Fönsterputs", Price= 300 },
                new Service { Name = "Balkongstädning", Price=150 }
            } },
        new City { Id=2, Name = "Uppsala", Rate=55, Services = new List<Service>
            {
                new Service { Name = "Fönsterputs", Price= 300 },
                new Service { Name = "Balkongstädning", Price=150 },
                new Service { Name = "Bortforsling av skräp", Price=400 }
            } }
    };

    [HttpGet("{id}")]
    public ActionResult GetCityById(int id) {

        return Ok(_cityService.GetCityById(id));
    }

    [HttpGet("names")]
    public ActionResult GetCityNames() {

        return Ok(_cityService.GetCityNames());
    }

    [HttpGet("{cityId}/services")]
    public ActionResult GetCityServices(int cityId) {
        var service = _cityService.GetCityServices(cityId);

        return Ok(service);
    }
}
