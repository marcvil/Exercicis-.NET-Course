using  System;

namespace Bloc_3__A4_CSharp_y_Java
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

            ///Array string de city
            string[] cityArray = new string[6];

            //Read USerInput and reverse
            for (int i = 0; i < 6; i++)
            {
                Console.Write("Escriu el nom de la Ciutat " + (i + 1) + "\n");
                cityArray[i] = Console.ReadLine();

            }
            Console.Write("Enter per escriure el nom de les ciutats. \n");
            for (int j = 0; j < 6; j++)
            {
                string ciudadreverso;
                ciudadreverso = reverseString(cityArray[j]);
                Console.Write("El nom de la ciutat " + (j + 1) + " al revés és: " + ciudadreverso + "\n");

            }



        }
        private static string reverseString(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            string ciudadReverso = new string(charArray);
            return ciudadReverso;
        }
    }
}
