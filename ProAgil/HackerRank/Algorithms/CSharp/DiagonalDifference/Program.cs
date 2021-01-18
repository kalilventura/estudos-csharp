using System.Collections.Generic;
using System;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new List<List<int>>();

            arr.Add(new List<int> { 11, 2, 4 });
            arr.Add(new List<int> { 4, 5, 6 });
            arr.Add(new List<int> { 10, 8, -12 });

            System.Console.WriteLine(diagonalDifference(arr));

        }

        public static int diagonalDifference(List<List<int>> arr)
        {
            int diagonalPrimary = 0;
            int diagonalSecundary = 0;
            for (int line = 0; line < arr.Count; line++)
            {
                for (int column = 0; column < arr[line].Count; column++)
                {
                    if (column == line)
                        diagonalPrimary += arr[line][column];

                    if (column == (arr[line].Count - 1 - line))
                        diagonalSecundary += arr[line][column];
                }
            }
            return Math.Abs(diagonalPrimary - diagonalSecundary);
        }
    }
}
