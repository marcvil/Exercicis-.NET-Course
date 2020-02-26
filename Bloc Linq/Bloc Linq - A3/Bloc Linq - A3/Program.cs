using System;
using System.Linq;
using System.Collections.Generic;

namespace Bloc_Linq___A2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numArray = new int[15] { 2, 6, 8, 4, 5, 5, 9, 2, 1, 8, 7, 5, 9, 6, 4 };

            var numQueryAbove = from num in numArray
                           where (num>= 5 )
                           select num;
            var numQueryUnder = from num in numArray
                                where (num < 5)
                                select num;
            Console.WriteLine("Numeros por debajo del cinco:");
            ShowNumbers(numQueryUnder);
            Console.WriteLine("");
            Console.WriteLine("Numeros por encima del cinco, incluyéndolo:");
            ShowNumbers(numQueryAbove);

        }
        static void ShowNumbers ( IEnumerable<int> numIEnumerable)
        
        {
            foreach( int num in numIEnumerable)
            {
                Console.WriteLine(num);

            } 
        }
       
    }
}

