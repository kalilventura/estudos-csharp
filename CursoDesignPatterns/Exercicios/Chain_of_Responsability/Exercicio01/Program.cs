using System;
using Exercicio01.Entidades;
using Exercicio01.Formatos;
using Exercicio01.Formatos.Enum;

namespace Exercicio01
{
    class Program
    {
        static void Main(string[] args)
        {
            var requisicao = new Requisicao(Formato.CSV);
            var conta = new Conta("Kalil", 2000);
            var verificaFormato = new VerificaFormato();

            string resultado = verificaFormato.Verificar(requisicao, conta);

            Console.WriteLine(resultado);
        }
    }
}
