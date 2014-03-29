using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleExams
{
    class FirTree
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n-1; i++)
            {
                for (int m = 1; m <= n - i - 1; m++)
                {
                    Console.Write(".");
                }

                for (int j = 1; j <= 2 * i - 1; j++)
                {
                    Console.Write("*");
                }

                for (int m = 1; m <= n - i - 1; m++)
                {
                    Console.Write(".");
                }
                
                Console.WriteLine();
            }

            for (int m = 1; m <= n - 2; m++)
            {
                Console.Write(".");
            }
            
            Console.Write("*");

            for (int m = 1; m <= n - 2; m++)
            {
                Console.Write(".");
            }

            Console.WriteLine();
        }
    }
}
