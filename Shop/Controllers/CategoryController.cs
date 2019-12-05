using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
    //Endpoint = Url
    //http://localhost:5000/v1/categories/[]
    [Route("v1/categories")]
    public class CategoryController : ControllerBase
    {

        [HttpGet]
        [AllowAnonymous]
        [ResponseCache(VaryByHeader = "User-Agent", Location = ResponseCacheLocation.Any, Duration = 30)]
        // Caso quiser bloquear o cache para esse método
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Get([FromServices] DataContext context)
        {
            try
            {
                return Ok(await context.Categories.AsNoTracking().ToListAsync());
            }
            catch (System.Exception err)
            {
                return BadRequest(err);
            }
        }

        [HttpGet]
        // Permite somente id do tipo int
        // O parametro vem via URL
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id, [FromServices] DataContext context)
        {
            try
            {
                return Ok(await context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id)));
            }
            catch (System.Exception err)
            {
                return BadRequest(err);
            }
        }

        [HttpPost]
        [Authorize(Roles = "employee")]
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
        [Authorize(Roles = "employee")]
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
        [Authorize(Roles = "employee")]
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