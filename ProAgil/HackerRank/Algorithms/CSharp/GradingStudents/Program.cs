using System.Collections.Generic;
using System;

namespace GradingStudents
{
    class Program
    {
        static void Main(string[] args)
        {
            var grades = new List<int> { 4, 73, 67, 38, 33 };
            System.Console.WriteLine(gradingStudents(grades));
        }

        public static List<int> gradingStudents(List<int> grades)
        {
            List<int> gradesRound = new List<int>();

            foreach (var grade in grades)
            {
                int a = grade % 5;
                if (a > 0 && grade >= 38)
                {
                    var multiple = 5 * ((grade / 5) + 1);

                    if (multiple - grade < 3)
                        gradesRound.Add(multiple);
                    else
                        gradesRound.Add(grade);
                }
                else
                    gradesRound.Add(grade);
            }

            return gradesRound;
        }

    }
}
