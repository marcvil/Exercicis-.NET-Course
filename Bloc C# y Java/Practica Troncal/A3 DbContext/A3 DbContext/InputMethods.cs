using System;
using System.Collections.Generic;

namespace A3_DbContext
{
    public class Input
    {
        public static int InputInt()
        {
            int input;
            bool parseCheck = Int32.TryParse(Console.ReadLine(), out input);


            //Clause to see if it's really an int, else repeat the function
            if (parseCheck is true)
            {
                return input;
            }
            else
            {
                Console.WriteLine("No es un número. Vuelve a introducir el dato.");
                InputInt();

            }
            return 0;
        }



    }
}