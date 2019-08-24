using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Library.Mail
{
    public class Constants
    {
        /**
         * 
         *O email utiliza o SMTP para saída 
         *POP-3 ou IMAP - Ler mensagens de e-mail
         *
         */

        //Autenticação - Gmail
        public readonly static string Usuario = "";
        public readonly static string Senha = "";

        //Servidor SMTP
        public readonly static string ServidorSMTP = "smtp.gmail.com";
        public readonly static int PortaSMTP = 587;
    }
}
