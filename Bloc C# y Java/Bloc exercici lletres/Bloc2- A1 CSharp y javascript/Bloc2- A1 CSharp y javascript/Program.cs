using System;

namespace Bloc2__A1_CSharp_y_javascript
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This application will split your name by it's letters.");
            Console.WriteLine("First, write your name: ");

            string inputString = Console.ReadLine();
            string[] result = new string[inputString.Length];
            char[] temp = new char[inputString.Length];


            temp = inputString.ToCharArray();

            int i = 0;
            for (i = 0; i< inputString.Length; i++)
            {
                result[i] = Convert.ToString(temp[i]);
                Console.WriteLine(result[i]);
            }
            Console.ReadKey();

            /* const int arrayLength = 40;
            string[] Letras = new string[arrayLength];
            Letras[0] = "M";
            Letras[1] = "a";
            Letras[2] = "r";
            Letras[3] = "c";
            Letras[4] = "";
            Letras[5] = "V";
            Letras[6] = "i";
            Letras[7] = "l";
            Letras[8] = "à";

            int i = 0;

            for (i = 0; i<= Letras.Length; i++)
            {
                Console.WriteLine(Letras[i]);
                if (Letras[i] == null)
                {
                    return;
                }
            }


            Console.ReadKey();
            */
        }
    }
}
