namespace QuotationService.Controllers;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
[ApiController]
public class CitiesController:ControllerBase
{
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

    [HttpGet]
    public IActionResult Get() {
        return Ok(_cities);
    }
}
