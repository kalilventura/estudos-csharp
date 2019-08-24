using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Rewrite.Internal.UrlActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Library.Filters
{
    public class LoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //Verificar a sessão
            if (context.HttpContext.Session.GetString("Login") == null)
            {
                if (context.Controller != null)
                {
                    Controller controlador = context.Controller as Controller;
                    controlador.TempData["MensagemErro"] = "Faça o login para ter permissão de entrar nessa página";
                }
                //Redirecionar
                context.Result = new RedirectToActionResult("Login","Home",null);

            }
        }
    }
}
