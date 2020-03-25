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
    public class PessoasFisicaController : Controller
    {
        private readonly DatabaseContext _context;

        public PessoasFisicaController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: PessoasFisica/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaFisica = await _context.PessoasFisicas
                .FirstOrDefaultAsync(m => m.PessoaId == id);
            if (pessoaFisica == null)
            {
                return NotFound();
            }

            return View(pessoaFisica);
        }

        // GET: PessoasFisica/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PessoasFisica/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Sexo,PessoaId,Nome,CpfCnpj")] PessoaFisica pessoaFisica)
        {
            if (ModelState.IsValid)
            {
                pessoaFisica.PessoaId = Guid.NewGuid();
                _context.Add(pessoaFisica);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Pessoas");
            }
            return View(pessoaFisica);
        }

        // GET: PessoasFisica/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaFisica = await _context.PessoasFisicas.FindAsync(id);
            if (pessoaFisica == null)
            {
                return NotFound();
            }
            return View(pessoaFisica);
        }

        // POST: PessoasFisica/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Sexo,PessoaId,Nome,CpfCnpj")] PessoaFisica pessoaFisica)
        {
            if (id != pessoaFisica.PessoaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoaFisica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaFisicaExists(pessoaFisica.PessoaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Pessoas");
            }
            return View(pessoaFisica);
        }

        // GET: PessoasFisica/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaFisica = await _context.PessoasFisicas
                .FirstOrDefaultAsync(m => m.PessoaId == id);
            if (pessoaFisica == null)
            {
                return NotFound();
            }

            return View(pessoaFisica);
        }

        // POST: PessoasFisica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var pessoaFisica = await _context.PessoasFisicas.FindAsync(id);
            _context.PessoasFisicas.Remove(pessoaFisica);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Pessoas");
        }

        private bool PessoaFisicaExists(Guid id)
        {
            return _context.PessoasFisicas.Any(e => e.PessoaId == id);
        }
    }
}
