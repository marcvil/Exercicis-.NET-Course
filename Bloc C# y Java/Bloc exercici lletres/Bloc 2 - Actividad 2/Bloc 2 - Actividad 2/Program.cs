using System;
using System.Collections.Generic;

namespace Bloc_2___Actividad_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This application will split your name by it's letters.");
            Console.WriteLine("First, write your name: ");

            // Input usuario
            string inputString = Console.ReadLine();

            //Crear Lista y temporary array para separar las letras
            List<string> letterNameList = new List<string>();
            char[] temp = new char[inputString.Length];

            //letras en array
            temp = inputString.ToCharArray();

            //for loop para añadir cada letra en una posición
            int i = 0;
            for (i = 0; i < inputString.Length; i++)
            {
                letterNameList.Add(Convert.ToString(temp[i]));

            }

            /* letterNameList.ForEach(i => Console.Write("{0}\t" + "\n", i));     Output por consoloa Manera Sencilla, no entiendo muy bien como fnciona el operador =>    */

            
            ManagingLetters(letterNameList);
        }

        private static void ManagingLetters(List<string> letterNameList)
        {
            //for loop para comparar letras en la lista con array de vocales,  NO TIENE EN CUENTA ACENTOS!!!!!
            string[] vocals = new string[5];
            vocals[0] = "a";
            vocals[1] = "e";
            vocals[2] = "i";
            vocals[3] = "o";
            vocals[4] = "u";


            for (int j = 0; j < letterNameList.Count; j++)
            {
                for (int k = 0; k < vocals.Length; k++)
                {
                    if (vocals[k] == letterNameList[j])
                    {
                        Console.Write(letterNameList[j] + " es vocal" + "\n");
                        break;
                    }
                    if (vocals[k] != letterNameList[j] && k == (vocals.Length - 1))
                    {
                        Console.Write(letterNameList[j] + " no es una vocal." + "\n");
                        break;
                    }
                    if (vocals[k].GetType() != letterNameList[j].GetType())
                    {
                        Console.Write(letterNameList[j] + " no es una letra!" + "\n");
                        break;
                    }
                }
            }

            /*a PARTIR DE FOREACH LOOP Y CON FOR LOOP DENTRO

           foreach (string c in letterNameList)
           {
               for (int k = 0; k < vocals.Length; k++)
               {
                   if (vocals[k] == c)
                   {
                       Console.Write(c + " es vocal" + "\n");
                       break;
                   }
                   if (vocals[k] != c && k == vocals.Length - 1)
                   {
                       Console.Write(c + " no es vocal" + "\n");
                       break;
                   }
               }
           }
          */
        }
    }
}
