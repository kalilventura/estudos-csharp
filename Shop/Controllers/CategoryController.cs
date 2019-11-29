using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
    //Endpoint = Url
    //http://localhost:5000/Categories/[]
    [Route("Categories")]
    public class CategoryController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        [HttpGet]
        // Permite somente id do tipo int
        // O parametro vem via URL
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Category category, [FromServices] DataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(x => x.Errors.Select(e => e.ErrorMessage)).ToList());

            try
            {
                context.Categories.Add(category);
                await context.SaveChangesAsync();

                return Ok(category);
            }
            catch (System.Exception err)
            {
                return BadRequest(err);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody]Category category, [FromServices] DataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(x => x.Errors.Select(e => e.ErrorMessage)).ToList());

            try
            {
                // Diz que alguma coisa foi alterada e vai alterar e persistir
                context.Entry<Category>(category).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(category);
            }
            catch (DbUpdateConcurrencyException err)
            {
                return BadRequest(err);
            }
            catch (Exception err)
            {
                return BadRequest(err);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id, [FromServices] DataContext context)
        {
            try
            {
                var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);

                if (category == null)
                    return BadRequest();

                context.Categories.Remove(category);
                await context.SaveChangesAsync();

                return Ok(new { message = "Categoria removida com sucesso" });
            }
            catch (Exception err)
            {
                return BadRequest(err);
            }
        }
    }
}