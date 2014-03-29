using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Tribonacci
{
    class Tribonacci
    {
        static void Main()
        {
            int term01= int.Parse(Console.ReadLine());
            int term02 = int.Parse(Console.ReadLine());
            int term03 = int.Parse(Console.ReadLine());

            ushort n = ushort.Parse(Console.ReadLine());

            BigInteger nMinusThreeTerm = term01;
            BigInteger nMinusTwoTerm = term02; 
            BigInteger nMinusOneTerm = term03;
            BigInteger nthTerm = 0;

            if (n == 1)
            {
                nthTerm = term01;
            }
            else if (n == 2)
            {
                nthTerm = term02;
            }
            else if (n == 3)
            {
                nthTerm = term03;
            }
            else
            {
                for (ushort i = 4; i <= n; i++)
                {

                    nthTerm = nMinusOneTerm + nMinusTwoTerm + nMinusThreeTerm;
                    nMinusThreeTerm = nMinusTwoTerm;
                    nMinusTwoTerm = nMinusOneTerm;
                    nMinusOneTerm = nthTerm;

                }

            }
            
            Console.WriteLine(nthTerm);

        }
    }
}
