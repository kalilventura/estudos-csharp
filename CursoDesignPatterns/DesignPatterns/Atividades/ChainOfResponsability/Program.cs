using System;
using Exercicios.Entidades;
using Exercicios.Formatos;
using Exercicios.Formatos.Enum;

namespace Exercicios
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
