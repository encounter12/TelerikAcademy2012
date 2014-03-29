using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnesAndZerosTriangle
{
    class OnesAndZerosRectangularTriangle
    {
        static void Main()
        {
            {
                int n = int.Parse(Console.ReadLine());
                StringBuilder builder = new StringBuilder();   
                for (int i = 1; i <= n; i++)
                {
                    if (i % 2 != 0)
                    {
                        builder.Append(1);
                    }
                    else
                    {
                        builder.Append(0);
                    }                    
                    
                    Console.WriteLine(builder);
                }

            }
        }
    }
}
