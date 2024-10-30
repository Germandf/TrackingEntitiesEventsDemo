using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingEntitiesEventsDemo.Data;
using TrackingEntitiesEventsDemo.Data.Entities;

namespace TrackingEntitiesEventsDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(AppDbContext _context) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _context.Products.ToListAsync();
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(ProductBody productBody)
    {
        var product = new Product
        {
            Name = productBody.Name,
            Description = productBody.Description,
            Price = productBody.Price
        };
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return Ok(product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(Guid id, ProductBody productBody)
    {
        var product = await _context.Products.FirstAsync(x => x.Id == id);
        product.Name = productBody.Name;
        product.Description = productBody.Description;
        product.Price = productBody.Price;
        await _context.SaveChangesAsync();
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        var product = await _context.Products.FirstAsync(x => x.Id == id);
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return Ok(product);
    }
}

public class ProductBody
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
}
