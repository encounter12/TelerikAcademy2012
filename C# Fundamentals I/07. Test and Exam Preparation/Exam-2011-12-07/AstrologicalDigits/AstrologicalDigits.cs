using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstrologicalDigits
{
    class AstrologicalDigits
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();
            ulong sum;

            do
            {
                sum = 0;
                foreach (char digitChar in n)
                {
                    if (digitChar != '.' && digitChar != '-')
                    {
                        int mydigit = Convert.ToInt32(digitChar - '0');
                        sum += (ulong)mydigit;
                    }
                }
                n = sum.ToString();
                
            } while (sum > 9);

            Console.WriteLine(n);
            
        }
    }
}
