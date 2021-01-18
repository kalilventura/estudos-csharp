using System;

namespace TimeConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(timeConversion("07:05:45PM"));
        }

        static string timeConversion(string s)
        {
            DateTime timeValue = Convert.ToDateTime(s);
            return timeValue.ToString("HH:mm:ss");
        }
    }
}
