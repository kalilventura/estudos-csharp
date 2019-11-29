using System;

namespace Aula1_CriarTipos
{
    public class TiposDeValor : IAulaItem
    {
        public void Executar()
        {
            // Tipos
            char c = 's'; // Somente char System.Char
            byte b = 0xFF; // 0 - 255 - nao permite negativos
            short s = -230; //Int16 - permite negativos
            int p = 100; //Int32 - permite negativos
            long l = 200000; //Int64 - permite negativos

            // Variacoes dos tipos
            sbyte sb = -126; // System.Sbyte
            ushort us = 250; // UInt16 (Não pode ter sinal negativo) 
            uint ui = 1500; // UInt32 (Não pode ter sinal negativo) 
            ulong ul = 5000; // UInt64 (Não pode ter sinal negativo) 
        }
    }
}