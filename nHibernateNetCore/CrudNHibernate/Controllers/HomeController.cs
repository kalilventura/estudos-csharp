using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrudNHibernate.Models;
using NHibernate;
using CrudNHibernate.NHibernate;

namespace CrudNHibernate.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var alunos = session.Query<Aluno>().ToList();
                return View(alunos);
            }
        }
        public IActionResult Details(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var aluno = session.Get<Aluno>(id);
                return View(aluno);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Aluno aluno)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(aluno);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var aluno = session.Get<Aluno>(id);
                return View(aluno);
            }
        }

        [HttpPost]
        public IActionResult Edit(int id, Aluno aluno)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var alunoAlterado = session.Get<Aluno>(id);

                    alunoAlterado.Sexo = aluno.Sexo;
                    alunoAlterado.Curso = aluno.Curso;
                    alunoAlterado.Email = aluno.Email;
                    alunoAlterado.Nome = aluno.Nome;

                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(alunoAlterado);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var aluno = session.Get<Aluno>(id);
                return View(aluno);
            }
        }

        [HttpPost]
        public IActionResult Delete(int id, Aluno aluno)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(aluno);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
