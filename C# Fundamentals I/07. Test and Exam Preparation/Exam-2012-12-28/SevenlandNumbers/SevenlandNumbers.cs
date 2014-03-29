using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exams2012
{
    class SevenlandNumbers
    {
        static int[] AssignPositiveIntegerDigitsToArray(int k)
        {
            int kDigitsCount = k.ToString().Length;
            int[] kDigits = new int[kDigitsCount];

            for (int i = 0; i < kDigitsCount; i++)
            {
                kDigits[kDigitsCount - 1 - i] = (k / (int)Math.Pow(10, i)) % 10;
            }
            return kDigits;
        }        
        static void Main()
        {
            /*This program takes as input a 7-based integer number K and calculates and prints the next number following it (K+1).*/

            int k = int.Parse(Console.ReadLine());
            int kPlusOne = 0;
            int kDigitsCount = k.ToString().Length;

            int[] kDigits = AssignPositiveIntegerDigitsToArray(k);

            int[] kPlusOneDigits = new int[kDigitsCount + 1];
            kPlusOneDigits[0] = 0;

            Array.Copy(kDigits, 0, kPlusOneDigits, 1, kDigitsCount);

            for (int i = kDigitsCount; i > 0; i--)
            {
                if (kDigits[i - 1] == 6 && i == 1)
                {
                    kPlusOneDigits[i] = 0;
                    kPlusOneDigits[0] = 1;
                }
                else if (kDigits[i - 1] == 6)
                {
                    kPlusOneDigits[i] = 0;
                }
                else
                {
                    kPlusOneDigits[i] = kDigits[i - 1] + 1;
                    break;
                }
            }

            for (int i = kDigitsCount; i >= 0; i--)
            {
                kPlusOne += kPlusOneDigits[i] * (int)Math.Pow(10, kDigitsCount - i);
            }

            Console.WriteLine(kPlusOne);
           
        }
    }
}
