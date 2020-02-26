using System;
using System.Linq;
using System.Collections.Generic;

namespace Bloc_Linq___A1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numArray = new int[15] { 2, 6, 8, 4, 5, 5, 9, 2, 1, 8, 7, 5, 9, 6, 4 };

            var numQuery = from num in numArray
                             where (num % 2) == 0
                             select num;
            
            foreach(int num in numQuery)
            {
                Console.WriteLine(num);
            }
        }
    }
}
