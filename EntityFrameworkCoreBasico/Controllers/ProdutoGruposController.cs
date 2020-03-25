using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkCore.Database;
using EntityFrameworkCore.Models;

namespace EntityFrameworkCore.Controllers
{
    public class ProdutoGruposController : Controller
    {
        private readonly DatabaseContext _context;

        public ProdutoGruposController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: ProdutoGrupos
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProdutosGrupos.ToListAsync());
        }

        // GET: ProdutoGrupos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoGrupo = await _context.ProdutosGrupos
                .FirstOrDefaultAsync(m => m.ProdutoGrupoId == id);
            if (produtoGrupo == null)
            {
                return NotFound();
            }

            return View(produtoGrupo);
        }

        // GET: ProdutoGrupos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProdutoGrupos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdutoGrupoId,Nome")] ProdutoGrupo produtoGrupo)
        {
            if (ModelState.IsValid)
            {
                produtoGrupo.ProdutoGrupoId = Guid.NewGuid();
                _context.Add(produtoGrupo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produtoGrupo);
        }

        // GET: ProdutoGrupos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoGrupo = await _context.ProdutosGrupos.FindAsync(id);
            if (produtoGrupo == null)
            {
                return NotFound();
            }
            return View(produtoGrupo);
        }

        // POST: ProdutoGrupos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ProdutoGrupoId,Nome")] ProdutoGrupo produtoGrupo)
        {
            if (id != produtoGrupo.ProdutoGrupoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produtoGrupo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoGrupoExists(produtoGrupo.ProdutoGrupoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(produtoGrupo);
        }

        // GET: ProdutoGrupos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoGrupo = await _context.ProdutosGrupos
                .FirstOrDefaultAsync(m => m.ProdutoGrupoId == id);
            if (produtoGrupo == null)
            {
                return NotFound();
            }

            return View(produtoGrupo);
        }

        // POST: ProdutoGrupos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var produtoGrupo = await _context.ProdutosGrupos.FindAsync(id);
            _context.ProdutosGrupos.Remove(produtoGrupo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoGrupoExists(Guid id)
        {
            return _context.ProdutosGrupos.Any(e => e.ProdutoGrupoId == id);
        }
    }
}
