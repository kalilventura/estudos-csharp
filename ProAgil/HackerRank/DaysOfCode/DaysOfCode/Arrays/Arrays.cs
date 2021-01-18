using System;
using System.Collections.Generic;
using System.Text;

namespace DaysOfCode.Arrays
{
    public class Arrays
    {
        public void reverseArray(int n, int[] array)
        {
            StringBuilder reverseArray = new StringBuilder(); ;

            for (int i = n; i > 0; i--)
            {
                if (i > 0)
                {
                    reverseArray
                        .Append($"{array[i - 1]}")
                        .Append(" ");
                }

            }

            Console.WriteLine(reverseArray.ToString());
        }
    }
}
