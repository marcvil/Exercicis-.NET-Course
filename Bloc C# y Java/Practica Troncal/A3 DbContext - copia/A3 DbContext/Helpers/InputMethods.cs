using System;
using System.Collections.Generic;

namespace A3_DbContext
{
    public class Input
    {
        public static int InputInt()
        {
            int input;
            bool parseCheck = int.TryParse(Console.ReadLine(), out input);


            //Clause to see if it's really an int, else repeat the function
            if (!parseCheck )
            {
                Console.WriteLine("No es un número. Vuelve a introducir el dato.");
                InputInt();
            }
           
            return input;
        }



    }
}