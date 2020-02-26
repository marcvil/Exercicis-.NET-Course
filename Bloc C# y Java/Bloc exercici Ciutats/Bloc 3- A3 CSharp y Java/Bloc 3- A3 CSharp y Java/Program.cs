using System;

namespace Bloc_3__A3_CSharp_y_Java
{
    class Program
    {
        static void Main(string[] args)
        {
            /*VARIABLES*/
            string city1;
            string city2;
            string city3;
            string city4;
            string city5;
            string city6;

            string[] cityArray = new string[6];

            //Read USerInput
            for (int i = 0; i < 6; i++)
            {
                Console.Write("Escriu el nom de la Ciutat " + (i + 1) + "\n");
                cityArray[i] = Console.ReadLine();
            }
            Console.Write("Enter per escriure el nom de les ciutats. \n");
            Console.ReadKey();
            //

            Array.Sort(cityArray);
            
            for (int j = 0; j < 6; j++)
            {
                cityArray[j]= cityArray[j].Replace("a", "4");
                
                Console.Write("El nom de la ciutat " + (j + 1) + " és: " + cityArray[j] + "\n");

            }
        }
    }
}
