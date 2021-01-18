using System;

namespace DataTypes
{
    public class DataTypes
    {
        static void sayHello()
        {
            int i = 4;
            double d = 4.0;
            string s = "HackerRank ";

            // Declare second integer, double, and String variables.
            int secondInt = 12;
            double secondDouble = 4.0;
            string secondString = "is the best place to learn and practice coding!";

            // Read and save an integer, double, and String to your variables.
            // secondInt = Convert.ToInt32(Console.ReadLine());
            // secondDouble = Convert.ToDouble(Console.ReadLine());
            // secondString = Console.ReadLine();
            // Print the sum of both integer variables on a new line.
            Console.WriteLine(i + secondInt);
            // Print the sum of the double variables on a new line.
            double doubleSum = d + secondDouble;
            Console.WriteLine(doubleSum.ToString("N1"));
            // Concatenate and print the String variables on a new line
            // The 's' variable above should be printed first.
            Console.WriteLine(s + secondString);
        }
    }
}
