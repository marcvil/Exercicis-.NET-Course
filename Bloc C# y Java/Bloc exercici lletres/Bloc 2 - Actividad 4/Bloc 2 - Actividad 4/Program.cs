using System;
using System.Collections.Generic;

namespace Bloc_2___Actividad_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This application will split your name by it's letters.");
            Console.WriteLine("First, write your name : ");

            // Input usuario
            string inputString = Console.ReadLine();
            Console.WriteLine("Write your surname : ");
            string inputString2 = Console.ReadLine();

            //Crear Lista y temporary array para separar las letras
            List<string> letterNameList = new List<string>();
            char[] temp = new char[inputString.Length];

            List<string> letterNameList2 = new List<string>();
            char[] temp2 = new char[inputString2.Length];

            //letras en array
            temp = inputString.ToCharArray();
            temp2 = inputString2.ToCharArray();

            //for loop para añadir cada letra en una posición
            
            for (int i = 0; i < inputString.Length; i++)
            {
                letterNameList.Add(Convert.ToString(temp[i]));
            }
            for (int n = 0; n < inputString.Length; n++)
            {
                letterNameList2.Add(Convert.ToString(temp2[n]));
            }

            /* letterNameList.ForEach(i => Console.Write("{0}\t" + "\n", i));     Manera Sencilla, no entiendo muy bien como fnciona el operador =>    */

            letterNameList.Add(" ");
            letterNameList.AddRange(letterNameList2);

            Console.Write("Fullname: " + "\n");
            WriteLetters(letterNameList);
        }

        static void WriteLetters(List<string> letterlist)
        {
            for (int j = 0; j < letterlist.Count; j++)
            {
                Console.Write(letterlist[j]);
            }
        }
    }
}

