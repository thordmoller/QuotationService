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
