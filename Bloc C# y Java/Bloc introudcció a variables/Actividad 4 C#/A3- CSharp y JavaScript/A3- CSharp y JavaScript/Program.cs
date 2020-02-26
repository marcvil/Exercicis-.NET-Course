using System;

namespace A3__CSharp_y_JavaScript
{
    class Program
    {
        static void Main(string[] args)
        {
            int startYear = 1948;
            int birthYear = 1994;

            int i = 1948;
            Console.WriteLine("Los años bisiestos entre el 1948 y el año de mi nacimiento (1994) son los siguinetes: \n");

            for ( i = 1948;  i <= birthYear; i++)
            {
                int modulus4 = (i - startYear) % 4;
                
                if (modulus4 == 0 )
                {
                    Console.WriteLine(i);
                   
                }
                
                
            }
            Console.ReadKey();
        }
    }
}
