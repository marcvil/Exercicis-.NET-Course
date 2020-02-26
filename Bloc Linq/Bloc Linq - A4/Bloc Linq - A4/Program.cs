using System;
using System.Linq;
using System.Collections.Generic;

namespace Bloc_Linq___A2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] namesArray = new string[7] {"David", "Sergio", "Maria", "Laura", "Oscar", "Julia", "Oriol"};

            char c = char.Parse("O");
            IEnumerable<string> namesQuery = namesArray.Where(name => name[0] == c);

            ShowResult(namesQuery);
            Console.WriteLine("******");
            IEnumerable<string> namesLengthQuery = namesArray.Where(name => name.Length > 6);

            ShowResult(namesLengthQuery);
            Console.WriteLine("******");
            IEnumerable<string> namesOrderedQuery = from namesOrdered in namesArray
                                                    orderby namesOrdered
                                                    select namesOrdered;
            ShowResult(namesOrderedQuery);                                      

        }
        static void ShowResult(IEnumerable<string> numIEnumerable)

        {
            foreach (string result in numIEnumerable)
            {
                Console.WriteLine(result);

            }
        }

    }
}

