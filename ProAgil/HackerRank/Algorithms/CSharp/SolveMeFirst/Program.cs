using System;

namespace SolveMeFirst
{
    // https://www.hackerrank.com/challenges/solve-me-first/problem
    class Program
    {
        static void Main(string[] args)
        {
            int val1 = 10;
            int val2 = 20;
            int sum = solveMeFirst(val1, val2);
            Console.WriteLine(sum);
        }

        static int solveMeFirst(int a, int b)
        {
            var result = a + b;
            return result;
        }
    }
}
