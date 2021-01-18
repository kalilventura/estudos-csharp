using System;

namespace MinMaxSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 1, 2, 3, 4, 5 };
            miniMaxSum(arr);
        }

        static void miniMaxSum(int[] arr)
        {
            long valMax = 0;
            long valMin = 0;

            List<int> ordenedArray = arr.OrderBy(x => x).ToList();
            for (int i = 0; i < ordenedArray.Count(); i++)
            {
                if (i < 4)
                    valMin += ordenedArray[i];
                else
                    break;
            }

            ordenedArray.Reverse();
            for (int i = 0; i < ordenedArray.Count(); i++)
            {
                if (i < 4)
                    valMax += ordenedArray[i];
                else
                    break;
            }

            System.Console.WriteLine(valMin + " " + valMax);
        }
    }
}
