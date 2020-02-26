using System;

namespace A4_CSharp_y_Java
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Marc";
            string surname1 = "Vilà";
            string surname2 = "Espuña";

            int birthDay = 07;
            int birthMonth = 09;
            int birthYear = 1994;

            int yearModulus4 = birthYear % 4;

            Console.WriteLine("Em dic " + name + " " + surname1 + " " + surname2 + ".");
            Console.WriteLine("Vaig neixer el dia " + birthDay + "/" + birthMonth + "/" + birthYear + ".");
            if (yearModulus4 == 0)
            {
                Console.WriteLine("El meu any de naixement va ser un any de traspàs.");
            }
            else  {
                Console.WriteLine("El meu any de naixement no va ser un any de traspàs.");
            }
            Console.ReadKey();

        }
    }
}
