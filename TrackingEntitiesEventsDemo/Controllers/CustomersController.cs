using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingEntitiesEventsDemo.Data;
using TrackingEntitiesEventsDemo.Data.Entities;

namespace TrackingEntitiesEventsDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController(AppDbContext _context) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetCustomers()
    {
        var customers = await _context.Customers.ToListAsync();
        return Ok(customers);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer(CustomerBody customerBody)
    {
        var customer = new Customer
        {
            Name = customerBody.Name,
            Email = customerBody.Email,
            Phone = customerBody.Phone
        };
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        return Ok(customer);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(Guid id, CustomerBody customerBody)
    {
        var customer = await _context.Customers.FirstAsync(x => x.Id == id);
        customer.Name = customerBody.Name;
        customer.Email = customerBody.Email;
        customer.Phone = customerBody.Phone;
        await _context.SaveChangesAsync();
        return Ok(customer);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(Guid id)
    {
        var customer = await _context.Customers.FirstAsync(x => x.Id == id);
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
        return Ok(customer);
    }
}

public class CustomerBody
{
    public required string Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
}
