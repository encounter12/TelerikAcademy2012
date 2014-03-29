using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandGlass
{
    class SandGlass
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n ; i++)
            {
                if (i <= n / 2)
                {
                    for (int m = 0; m < i; m++)
                    {
                        Console.Write("."); 
                    }
                    for (int j = 0; j < n - 2*i; j++)
                    {
                        Console.Write("*");
                    }
                    for (int m = 0; m < i; m++)
                    {
                        Console.Write(".");
                    }
                }
                else
                {
                    for (int m = 0; m < (n - 1) - i; m++)
                    {
                        Console.Write("."); 
                    }
                    for (int j = 0; j < 2*(i - n/2) + 1 ; j++)
                    {
                        Console.Write("*");
                    }
                    for (int m = 0; m < (n - 1) - i; m++)
                    {
                        Console.Write(".");
                    }
                   
                }
                Console.WriteLine();
                
            }
        }
    }
}
