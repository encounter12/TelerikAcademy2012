using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAllLoveBits
{
    class WeAllLoveBits
    {
        static int ReversedBitsNumber(int number)
        {
            int quotient = number;
            int bitAtPosition;
            string reversedNumberString = null;
            int reversedBitsNumber;
            do
            {

                bitAtPosition = quotient % 2;
                reversedNumberString += bitAtPosition.ToString();
                quotient = quotient / 2;


            } while (quotient != 0);

            reversedBitsNumber = Convert.ToInt32(reversedNumberString, 2);

            return reversedBitsNumber;
        }

        static void Main()
        {
            ushort n = ushort.Parse(Console.ReadLine());
            int[] numbers = new int[n];            

            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int[] invertedNumbers = new int[n];

            for (int i = 0; i < n; i++)
			{
                invertedNumbers[i] = ~numbers[i];
			}
            
            
            int[] reversedBitsNumbers = new int[n];
            

            for (int i = 0; i < n; i++)
            {
                reversedBitsNumbers[i] = ReversedBitsNumber(numbers[i]);
            }
            
            /*newNumbers[i] = (numbers[i] ^ invertedNumbers[i]) & reversedNumbers[i] = reversedNumbers[i]; 
             * So the loop below is not necessary
             */

            int[] newNumbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                newNumbers[i] = (numbers[i] ^ invertedNumbers[i]) & reversedBitsNumbers[i];
                Console.WriteLine(newNumbers[i]);
            }

           
        }
    }
}
