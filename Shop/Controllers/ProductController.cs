using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
    [Route("Products")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromServices] DataContext context)
        {
            try
            {
                var products = await context
                                        .Products
                                        .Include(x => x.Category) // Com a referencia no modelo conseguimos buscar as categorias
                                        .AsNoTracking()
                                        .ToListAsync();
                return Ok(products);
            }
            catch (System.Exception err)
            {
                return BadRequest(err);
            }
        }

        [HttpGet]
        [Route("{id: int}")]
        public async Task<IActionResult> Get(int id, [FromServices] DataContext context)
        {
            try
            {
                var products = await context
                                        .Products
                                        .Include(x => x.Category) // Com a referencia no modelo conseguimos buscar as categorias
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(x => x.Id == id);
                return Ok(products);
            }
            catch (System.Exception err)
            {
                return BadRequest(err);
            }
        }

        //products/categories/1
        [HttpGet]
        [Route("categories/{id: int}")]
        public async Task<IActionResult> GetByCategory(int id, [FromServices] DataContext context)
        {
            try
            {
                var products = await context
                                        .Products
                                        .Include(x => x.Category) // Com a referencia no modelo conseguimos buscar as categorias
                                        .AsNoTracking()
                                        .Where(x => x.CategoryId == id)
                                        .ToListAsync();
                return Ok(products);
            }
            catch (System.Exception err)
            {
                return BadRequest(err);
            }
        }

    }
}