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

            var numQuery = from num in numArray
                           select num;

            Average(numQuery);
            Min(numQuery);
            Max(numQuery);
        }
        static void Min(IEnumerable<int> numArray)
        {
            int min = 10;

            foreach(int num in numArray)
            {
                if(num < min)
                {
                    min = num;
                }
            }
           
            Console.WriteLine("La nota mínima es de " + min);
        }
        static void Max(IEnumerable<int> numArray)
        {
            int max = 0;

            foreach (int num in numArray)
            {
                if (num > max)
                {
                    max = num;
                }
            }

            Console.WriteLine("La nota máxima es de " + max);
        }
        static void Average(IEnumerable<int> numArray)
        {
            int sum = 0;
            int media;

            foreach (int num in numArray)
            {
                sum += num;
            }
            media = sum / numArray.Count();
            Console.WriteLine("La media es de " + media);
        }

    }
}
