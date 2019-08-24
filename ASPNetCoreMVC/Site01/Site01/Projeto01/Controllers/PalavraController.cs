using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Projeto01.Database;
using Projeto01.Library.Filters;
using Projeto01.Models;
using X.PagedList;

namespace Projeto01.Controllers
{
    [Login]
    public class PalavraController : Controller
    {
        List<Nivel> nivel = new List<Nivel>();
        private DatabaseContext _db;
        public PalavraController(DatabaseContext db)
        {
            _db = db;


            nivel.Add(new Nivel() { Id = 1, Nome = "Fácil" });
            nivel.Add(new Nivel() { Id = 2, Nome = "Médio" });
            nivel.Add(new Nivel() { Id = 3, Nome = "Dificil" });
        }

        //Listar todas as paalvras do Banco de dados
        public IActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;

            var palavras = _db.Palavras.ToList();
            var resultadoPaginado = palavras.ToPagedList(pageNumber, 5);

            return View(resultadoPaginado);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            ViewBag.Nivel = nivel;
            return View(new Palavra());
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm]Palavra palavra)
        {
            ViewBag.Nivel = nivel;
            if (ModelState.IsValid)
            {
                _db.Add(palavra);
                _db.SaveChanges();

                TempData["Mensagem"] = "A palavra '" + palavra.Nome + "' foi cadastrada com sucesso !!";

                return RedirectToAction("Index");
            }
            return View(palavra);
        }

        [HttpGet]
        public IActionResult Atualizar(int id)
        {
            ViewBag.Nivel = nivel;
            Palavra palavra = _db.Palavras.Find(id);

            return View("Cadastrar", palavra);

        }

        [HttpPost]
        public IActionResult Atualizar([FromForm] Palavra palavra)
        {
            ViewBag.Nivel = nivel;
            if (ModelState.IsValid)
            {
                _db.Update(palavra);
                _db.SaveChanges();

                TempData["Mensagem"] = "A palavra '" + palavra.Nome + "' foi atualizada com sucesso !!";

                return RedirectToAction("Index");
            }
            return View("Cadastrar", palavra);
        }

        //Rota - palavras/excluir/id?
        [HttpGet]
        public IActionResult Excluir(int id)
        {
            Palavra palavra = _db.Palavras.Find(id);
            _db.Remove(palavra);
            _db.SaveChanges();

            TempData["Mensagem"] = "A palavra '" + palavra.Nome + "' foi excluida com sucesso !!";

            return RedirectToAction("Index");
        }

    }
}