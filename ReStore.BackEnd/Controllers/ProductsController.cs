using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReStore.BackEnd.Data;
using ReStore.BackEnd.Entities;

namespace ReStore.BackEnd.Controllers;

public class ProductsController : BaseApiController
{
    private readonly StoreContext _context;

    public ProductsController(StoreContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var result = await _context.Products.ToListAsync();
        if (result is not null)
        {
            return Ok(result);
        }

        return NotFound();
    }

    [HttpGet("{id}")]
    public async Task<Product?> GetProduct(int id) => await _context.Products.FindAsync(id); // ?? new Product();
}
