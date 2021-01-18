namespace DaysOfCode.ConditionalStatements
{
    public static class Conditional
    {
        public static string OddOrEven(int number)
        {
            if (number % 2 != 0 ||
                ((number % 2 == 0) && number >= 6 && number <= 20))
                return "Weird";

            if (number >= 2 || number <= 5)
                return "Not Weird";

            return "Not Weird";
        }
    }
}
