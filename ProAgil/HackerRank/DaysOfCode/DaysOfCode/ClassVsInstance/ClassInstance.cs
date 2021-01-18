using System;
using System.Collections.Generic;
using System.Text;

namespace DaysOfCode.ClassVsInstance
{
    public class Person
    {
        public int age;
        public Person(int initialAge)
        {
            checkInitialAgeIsNotNegative(initialAge);
        }

        public void amIOld()
        {
            if (age < 13)
                Console.WriteLine("You are young.");
            else if (age >= 13 && age < 18)
                Console.WriteLine("You are a teenager.");
            else
                Console.WriteLine("You are old.");
        }

        public void yearPasses()
        {
            age++;
        }

        private void checkInitialAgeIsNotNegative(int initialAge)
        {
            if (initialAge < 0)
            {
                this.age = 0;
                Console.WriteLine("Age is not valid, setting age to 0.");
                return;
            }

            age = initialAge;
        }
    }
}
