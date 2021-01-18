using System;
using System.Text;

namespace Staircase
{
    // https://www.hackerrank.com/challenges/staircase/problem
    class Program
    {
        static void Main(string[] args)
        {
            staircase(6);
        }

        static void staircase(int n)
        {
            string[] stairs = new string[n];
            string star = "";

            for (int i = 0; i < n; i++)
            {
                star += "#";
                stairs[i] = Indent(n - (i + 1)) + star;
                System.Console.WriteLine(stairs[i]);
            }
        }

        public static string Indent(int count)
        {
            return "".PadLeft(count);
        }
    }
}
