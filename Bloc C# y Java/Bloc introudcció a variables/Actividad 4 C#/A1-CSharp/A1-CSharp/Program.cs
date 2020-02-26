using System;

namespace A1_CSharp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string name = "Marc" ;
            string surname1 = "Vilà";
            string surname2 = "Espuna";

            int day = 29;
            int month = 01;
            int year = 2020;

            Console.WriteLine( surname1 + " " + surname2 + "," + name  );
            Console.WriteLine(day + "/" + month + "/" + year);
            Console.ReadKey();

        }



    }
}
