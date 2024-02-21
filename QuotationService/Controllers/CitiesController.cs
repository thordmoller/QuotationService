﻿namespace QuotationService.Controllers;
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
    public async Task<ActionResult<City>> GetCityById(int id) {
        var city = await _context.Cities
            .Include(c => c.Services)
            .FirstOrDefaultAsync(c => c.Id == id);
        return Ok(city);
    }

    [HttpGet("names")]
    public ActionResult<IEnumerable<CityNameDTO>> GetCityNames() {
        var cities = _context.Cities
            .Select(c => new CityNameDTO { Id = c.Id, Name = c.Name })
            .ToList();

        return Ok(cities);
    }

    [HttpGet("{cityId}/services")]
    public ActionResult GetCityServices(int cityId) {
        var service = _cityService.GetCityServices(cityId);

        return Ok(service);
    }




    [HttpGet]
    public IActionResult Get() {
        return Ok(_cities);
    }
}
