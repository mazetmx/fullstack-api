using FullstackAssignment.DTOs;
using FullstackAssignment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullstackAssignment.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProductsController(DataContext context) : Controller
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
    {
        var products = await context.Products
            .Select(p => ProductToDto(p))
            .ToListAsync();

        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductDto>> GetProduct(int id)
    {
        var product = await context.Products
            .Where(p => p.Id == id)
            .Select(p => ProductToDto(p))
            .FirstOrDefaultAsync();

        if (product == null)
        {
            return NotFound("Product not found");
        }

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> CreateProduct(ProductCreateDto dto)
    {
        var product = new Product
        {
            Name = dto.Name,
            Category = dto.Category,
            Price = dto.Price,
            MinimumQuantity = dto.MinimumQuantity,
            DiscountRange = dto.DiscountRange
        };

        context.Products.Add(product);
        await context.SaveChangesAsync();

        var result = ProductToDto(product);

        return CreatedAtAction(nameof(GetProduct), new {id = product.Id}, result);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> EditProduct(int id, ProductEditDto dto)
    {
        var product = await context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound("Product not found");
        }

        product.Name = dto.Name ?? product.Name;
        product.Category = dto.Category ?? product.Category;
        product.Price = dto.Price ?? product.Price;
        product.MinimumQuantity = dto.MinimumQuantity ?? product.MinimumQuantity;
        product.DiscountRange = dto.DiscountRange ?? product.DiscountRange;

        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        var product = await context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound("Product not found");
        }

        context.Products.Remove(product);
        await context.SaveChangesAsync();

        return NoContent();
    }

    private static ProductDto ProductToDto(Product p)
    {
        return new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Category = p.Category,
            Price = p.Price,
            MinimumQuantity = p.MinimumQuantity,
            DiscountRange = p.DiscountRange
        };
    }
}