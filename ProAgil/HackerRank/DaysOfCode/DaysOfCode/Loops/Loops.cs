using System;
using System.Collections.Generic;
using System.Text;

namespace DaysOfCode.Loops
{
    public class Loops
    {
        public void multiples(int number)
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{number} x {i} = {number * i}");
            }
        }
    }
}
