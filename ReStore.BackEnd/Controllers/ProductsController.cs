using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public async Task<IActionResult> GetProduct(int id)
    {
       var result = await _context.Products.FindAsync(id);
       if(result is not null)
       {
         return Ok(result);
       }

       return NotFound();
    }
}
