using Projeto01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Library.Mail
{
    public class EnviarEmail
    {
        public static object Smtp { get; private set; }

        public static void EnviarMensagem(Contato contato)
        {

            string conteudo = string.Format("nome {0}<br /> email {1}<br /> assunto: {2}<br /> mensagem: {3}",
                contato.Nome, contato.Email, contato.Assunto, contato.Mensagem);

            //Configurar o servidor SMTP
            SmtpClient smtpClient = new SmtpClient(Constants.ServidorSMTP, Constants.PortaSMTP);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(Constants.Usuario, Constants.Senha);

            //Construir uma mensagem de email
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("");
            mailMessage.To.Add("");
            mailMessage.Subject = "Formulário de contato";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = "<h1> Forumário de contato</h1>" + conteudo;

            smtpClient.Send(mailMessage);
        }
    }
}
