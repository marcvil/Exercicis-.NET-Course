using System;
using System.Collections.Generic;

namespace Bloc_2___Actividad_3
{
    class Letter
    {
        public string letter;
        public int numberRepetitions;
    }



    class Program
    {
      
        static void Main(string[] args)
        {
            Console.WriteLine("This application will split your name by it's letters.");
            Console.WriteLine("First, write your name: ");

            // Input usuario
            string inputString = Console.ReadLine();

            //Crear dictionary y temporary array para separar las letras

            IDictionary<int, string> dictionaryletters = new Dictionary<int, string>();

            char[] temp = new char[inputString.Length];

            //letras en array
            temp = inputString.ToCharArray();

            //for loop para añadir cada letra en una posición
            int i = 0;
            for (i = 0; i < inputString.Length; i++)
            {
                dictionaryletters.Add(i, temp[i].ToString());
            }

            /* letterNameList.ForEach(i => Console.Write("{0}\t" + "\n", i));     Manera Sencilla, no entiendo muy bien como fnciona el operador =>    */

            ManagingLetters(dictionaryletters);
        }

        private static void ManagingLetters(IDictionary<int, string> dictionaryletters)
        {
            foreach (string c in dictionaryletters.Values)
            {
                int numberOfRepetitions = 0;
                for (int l = 0; l < dictionaryletters.Count; l++)
                {
                    if (c == dictionaryletters[l] && l < (dictionaryletters.Count - 1))
                    {
                        numberOfRepetitions = numberOfRepetitions + 1;

                    }
                    if (c == dictionaryletters[l] && l == (dictionaryletters.Count - 1))
                    {
                        numberOfRepetitions = numberOfRepetitions + 1;
                        
                        
                    }
                    if (c != dictionaryletters[l] && l == (dictionaryletters.Count - 1))
                    {
                        

                    }
                    

                }
                Console.Write("El numero de repeticiones  de la letra:" + c + " es " + numberOfRepetitions + "\n");
                

            }

            /*
              //for loop para comparar letras en la lista con array de vocales,  NO TIENE EN CUENTA ACENTOS!!!!!
            string[] vocals = new string[5];
            vocals[0] = "a";
            vocals[1] = "e";
            vocals[2] = "i";
            vocals[3] = "o";
            vocals[4] = "u";


            for (int j = 0; j < dictionaryletters.Count; j++)
            {
                for (int k = 0; k < vocals.Length; k++)
                {
                    if (vocals[k] == dictionaryletters[j])
                    {
                        Console.Write(dictionaryletters[j] + " es vocal" + "\n");
                        break;
                    }
                    if (vocals[k] != dictionaryletters[j] && k == (vocals.Length - 1))
                    {
                        Console.Write(dictionaryletters[j] + " no es una vocal." + "\n");
                        break;
                    }
                    if (vocals[k].GetType() != dictionaryletters[j].GetType())
                    {
                        Console.Write(dictionaryletters[j] + " no es una letra!" + "\n");
                        break;
                    }
                }
                */






        }
    }
    }
}/*         /*
                if (lettersRepeated.Count == 0)
                {
                    Letter letter = new Letter();
                    letter.letter = dictionaryletters[j].ToString();
                    letter.numberRepetitions++;
                    lettersRepeated.Add(letter);
                    
                }
                for (int l = 0; l < lettersRepeated.Count; l++)
                {
                   
                    if (dictionaryletters[j] != lettersRepeated[l].letter && l == (lettersRepeated.Count))
                    {
                        Letter letter = new Letter();
                        letter.letter = dictionaryletters[j];
                        letter.numberRepetitions++;
                        lettersRepeated.Add(letter);
                        Console.Write(lettersRepeated[l].letter, lettersRepeated[l].numberRepetitions);
                        continue;
                    }
                    if (dictionaryletters[j] == lettersRepeated[l].letter)
                    {
                        lettersRepeated[l].numberRepetitions++;
                        Console.Write(lettersRepeated[l]);
                    }
                    //Console.Write(lettersRepeated[l].letter, lettersRepeated[l].numberRepetitions);
                }
               */

