using System;

namespace A2__CSharp___Java
{
    class Program
    {
        static void Main(string[] args)
        {
            const int startYear = 1948;
            int birthYear = 1994;
            int leapYear = 4;

            int yearDifference;
            int numberOfLeapYears;

            yearDifference = birthYear - startYear;
            numberOfLeapYears = yearDifference / leapYear;
            Console.WriteLine("The number of leap years between 1948 and my birth year is: " + numberOfLeapYears + " years.");
            Console.ReadKey();
        }
    }
}
