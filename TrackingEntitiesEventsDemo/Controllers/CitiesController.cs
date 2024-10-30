using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingEntitiesEventsDemo.Data;
using TrackingEntitiesEventsDemo.Data.Entities;

namespace TrackingEntitiesEventsDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CitiesController(AppDbContext _context) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetCities()
    {
        var cities = await _context.Cities.ToListAsync();
        return Ok(cities);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCity(CityBody cityBody)
    {
        var city = new City
        {
            Name = cityBody.Name,
        };
        _context.Cities.Add(city);
        await _context.SaveChangesAsync();
        return Ok(city);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCity(Guid id, CityBody cityBody)
    {
        var city = await _context.Cities.FirstAsync(x => x.Id == id);
        city.Name = cityBody.Name;
        await _context.SaveChangesAsync();
        return Ok(city);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCity(Guid id)
    {
        var city = await _context.Cities.FirstAsync(x => x.Id == id);
        _context.Cities.Remove(city);
        await _context.SaveChangesAsync();
        return Ok(city);
    }
}

public class CityBody
{
    public required string Name { get; set; }
}
