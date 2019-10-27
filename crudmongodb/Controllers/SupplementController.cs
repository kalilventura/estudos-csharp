using System.Collections.Generic;
using System.Threading.Tasks;
using crudmongodb.Models;
using crudmongodb.Services;
using Microsoft.AspNetCore.Mvc;

namespace crudmongodb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplementController : ControllerBase
    {
        private readonly SupplementService _supplementService;

        public SupplementController(SupplementService supplementService)
        {
            _supplementService = supplementService;
        }

        // GET: api/Supplement
        /// <summary>
        /// Get all Supplements
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Supplement>>> Get()
        {
            return await _supplementService.Get();
        }

        // GET: api/Supplement/5
        /// <summary>
        /// Get suplement by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Supplement>> Get(string id)
        {
            var suplement = await _supplementService.Get(id);
            if (suplement == null)
            {
                return NotFound();
            }

            return suplement;
        }

        // POST: api/Supplement
        /// <summary>
        /// Create Supplement
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Supplement>> Create([FromBody] Supplement s)
        {
            await _supplementService.Create(s);
            return CreatedAtRoute("Get", new { id = s.Id.ToString() }, s);

        }

        // PUT: api/Supplement/5
        /// <summary>
        /// Alter Supplement
        /// </summary>
        /// <param name="id">Id to Supplement to alter</param>
        /// <param name="su">Supplement altered</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Supplement>> Put(string id, [FromBody] Supplement su)
        {
            var suplement = await _supplementService.Get(id);
            if (suplement == null)
            {
                return NotFound();
            }
            su.Id = suplement.Id;

            await _supplementService.Update(id, su);
            return CreatedAtRoute("Get", new { id = su.Id.ToString() }, su);
        }

        // DELETE: api/Supplement/5
        /// <summary>
        /// Delete Supplement
        /// </summary>
        /// <param name="id">id to supplement to delete</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Supplement>> Delete(string id)
        {
            var s = await _supplementService.Get(id);
            if (s == null)
            {
                return NotFound();
            }

            return NoContent();

        }
    }
}