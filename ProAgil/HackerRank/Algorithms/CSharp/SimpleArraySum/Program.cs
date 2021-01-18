using System;

namespace SimpleArraySum
{
    // https://www.hackerrank.com/challenges/simple-array-sum/problem
    class Program
    {
        static void Main(string[] args)
        {
            int[] ar = { 10, 11, 50, 90, 80, 60 };
            int result = simpleArraySum(ar);

            Console.WriteLine(result);
        }

        static int simpleArraySum(int[] ar)
        {
            int result = 0;
            foreach (var num in ar)
            {
                result += num;
            }
            return result;
        }
    }
}
