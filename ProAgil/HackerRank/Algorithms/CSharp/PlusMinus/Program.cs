using System;

namespace PlusMinus
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { -4, 3, -9, 0, 4, 1 };
            plusMinus(arr);
        }

        static void plusMinus(int[] arr)
        {
            decimal positive = 0, negative = 0, zero = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                    negative++;
                else if (arr[i] > 0)
                    positive++;
                else
                    zero++;
            }

            Console.WriteLine(positive / arr.Length);
            Console.WriteLine(negative / arr.Length);
            Console.WriteLine(zero / arr.Length);

        }

    }
}
