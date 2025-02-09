using _6_webapi.DTO;
using _6_webapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _6_webapi.Controllers;

// localhost:5000/api/route...
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductsContext _context;
    public ProductsController( ProductsContext context )
    {
        _context = context;
    }
        
    // localhost:5000/api/products => GET
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        // var products = await _context.Products.ToListAsync(); No DTO
        var products = await _context.Products
            .Where(i => i.IsActive)
            .Select(p => GetProductDTO(p)) // With DTO and IsActive filter
            .ToListAsync();
        
        return Ok(products);
    }
    
    // localhost:5000/api/product/1 => GET
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int? id)
    {
        if (id == null)
        {
            return NotFound();
            // return StatusCode(404, "Product not found");
        }
        
        var p = await _context.Products?
            .Select(p => GetProductDTO(p)).FirstOrDefaultAsync(p => p.ProductId == id);
        
        if (p == null)
        {
            return NotFound();
        }
        return Ok(p);
    }

    // localhost:5000/api/product/createproduct => POST
    [HttpPost]
    public async Task<IActionResult> CreateProduct(Product entity)
    {
        await _context.Products.AddAsync(entity);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetProduct), new { id = entity.ProductId }, entity);
    }

    // localhost:5000/api/product/updateproduct/id => PUT
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, Product entity)
    {
        if (id != entity.ProductId)
        {
            return BadRequest(); // 401 code
        }
        var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
        if (product == null)
        {
            return NotFound();
        }
        product.ProductId = entity.ProductId;
        product.ProductName = entity.ProductName;
        product.Price = entity.Price;
        product.IsActive = entity.IsActive;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return NotFound();
        }
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);

        if (product == null)
        {
            return NotFound();
        }
        _context.Products.Remove(product);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return NotFound();
        }
        return NoContent();
    }

    private static ProductDTO GetProductDTO(Product p)
    {
        return new ProductDTO
        {
            ProductId = p.ProductId,
            ProductName = p.ProductName,
            Price = p.Price
        };
    }
}