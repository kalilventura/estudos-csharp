using System;

namespace VeryBigSum
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] arr = new long[]
            {
                1, 10, 1000, 20, 50, 90
            };

            System.Console.WriteLine(aVeryBigSum(arr));
        }

        static long aVeryBigSum(long[] ar)
        {
            long sum = 0;
            for (long i = 0; i < ar.Length; i++)
            {
                sum += ar[i];
            }

            return sum;
        }
    }
}
