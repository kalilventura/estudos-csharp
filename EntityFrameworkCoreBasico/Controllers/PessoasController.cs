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
    public class PessoasController : Controller
    {
        private readonly DatabaseContext _context;

        public PessoasController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Pessoas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pessoas.ToListAsync());
        }

    }
}
