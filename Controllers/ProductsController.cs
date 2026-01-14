using Microsoft.AspNetCore.Mvc;

namespace SampleWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private static readonly List<Product> Products = new()
    {
        new Product { Id = 1, Name = "Laptop", Price = 999.99m, InStock = true },
        new Product { Id = 2, Name = "Mouse", Price = 29.99m, InStock = true },
        new Product { Id = 3, Name = "Keyboard", Price = 79.99m, InStock = false }
    };

    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAll()
    {
        _logger.LogInformation("Retrieving all products");
        return Ok(Products);
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetById(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            _logger.LogWarning("Product with ID {Id} not found", id);
            return NotFound($"Product with ID {id} not found");
        }

        return Ok(product);
    }

    [HttpPost]
    public ActionResult<Product> Create([FromBody] Product product)
    {
        if (product == null)
        {
            return BadRequest("Product cannot be null");
        }

        product.Id = Products.Max(p => p.Id) + 1;
        Products.Add(product);
        _logger.LogInformation("Created product with ID {Id}", product.Id);

        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, [FromBody] Product product)
    {
        var existingProduct = Products.FirstOrDefault(p => p.Id == id);
        if (existingProduct == null)
        {
            return NotFound($"Product with ID {id} not found");
        }

        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;
        existingProduct.InStock = product.InStock;
        _logger.LogInformation("Updated product with ID {Id}", id);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound($"Product with ID {id} not found");
        }

        Products.Remove(product);
        _logger.LogInformation("Deleted product with ID {Id}", id);

        return NoContent();
    }
}
