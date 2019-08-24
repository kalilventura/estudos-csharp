using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto01.Library.Mail;
using Projeto01.Models;

namespace Projeto01.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Contato = new Contato();
            return View();
        }

        public IActionResult ReceberContato(
            [FromForm]Contato contato)
        {
            if (ModelState.IsValid)
            {
                //Mostra a mensagem no html
                //string conteudo = string.Format("nome {0}, email {1}, assunto: {2}, mensagem: {3}", contato.Nome,
                //contato.Email, contato.Assunto, contato.Mensagem);
                // return new ContentResult() { Content = conteudo };

                //Envia email
                ViewBag.Contato = new Contato();
                EnviarEmail.EnviarMensagem(contato);
                ViewBag.Mensagem = "Menagem enviada com sucesso !!";
                return View("Index");
            }
            else
            {
                //Retornando o objeto
                ViewBag.Contato = contato;
                return View("Index");
            }
            
            
        }

        /* Obter dados manualmente
        public IActionResult ReceberContato()
        {
            //GET - Request.Query/Request.QueryString
            //POST - Request.Form
            Contato c = new Contato();
            c.Nome = Request.Form["nome"];
            c.Email = Request.Form["email"];
            c.Assunto = Request.Form["assunto"];
            c.Mensagem = Request.Form["mensagem"];
            string conteudo = string.Format("nome {0}, email {1}, assunto: {2}, mensagem: {3}",c.Nome, c.Email, c.Assunto, c.Mensagem);
            return new ContentResult() { Content = conteudo};
        }*/
    }
}