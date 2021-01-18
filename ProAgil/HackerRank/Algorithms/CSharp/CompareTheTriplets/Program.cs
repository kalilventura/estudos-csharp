using System;
using System.Collections.Generic;

namespace CompareTheTriplets
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<int> a = new List<int> {
                10, 30, 50, 90, 09
            };

            IList<int> b = new List<int> {
                50, 60, 80, 9, 88
             };

            List<int> result = compareTriplets(a, b);

            System.Console.WriteLine();
        }

        static List<int> compareTriplets(IList<int> a, IList<int> b)
        {
            List<int> result = new List<int>();
            int scoreAlice = 0;
            int scoreBob = 0;

            for (int index = 0; index < 3; index++)
            {
                if (a[index] > b[index])
                    scoreAlice++;
                else if (a[index] < b[index])
                    scoreBob++;
            }

            result.Add(scoreAlice);
            result.Add(scoreBob);

            return result;
        }

    }
}
