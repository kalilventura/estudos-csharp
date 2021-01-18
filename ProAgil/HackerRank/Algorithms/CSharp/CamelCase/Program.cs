using System.Linq;
using System;
using System.Text;

namespace CamelCase
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(camelcase("paoDeBatata"));
            System.Console.WriteLine(camelcase("abcd"));
            System.Console.WriteLine(camelcase("ABCD"));
        }

        static int camelcase(string s)
        {
            int words = 0;
            int beginOfCapitalLetter = 0;

            byte[] ASCIIValues = Encoding.ASCII.GetBytes(s);

            for (int i = 0; i < ASCIIValues.Count(); i++)
            {
                if (ASCIIValues[i] >= 65 && ASCIIValues[i] <= 90)
                {
                    if (beginOfCapitalLetter == 0)
                        beginOfCapitalLetter = i;

                    words++;
                }
            }

            if (beginOfCapitalLetter >= 0 && ASCIIValues.Count() > 0)
                words++;

            return words;
        }
    }
}
