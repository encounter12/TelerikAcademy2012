using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pillars
{
    class Pillars
    {
        static int GetBitOnPosition(int number, int position)
        {
            int extractedBit;

            extractedBit = (number & (1 << position)) >> position;
            return extractedBit;
        }
        

        static void Main(string[] args)
        {
            int numbersCount = 8;
            int[] inputNumbers = new int[numbersCount];
            int[,] grid = new int[numbersCount, sizeof(byte) * 8]; 


            for (int i = 0; i < numbersCount; i++)
            {
                inputNumbers[i] = byte.Parse(Console.ReadLine());
            }

            for (int i = 0; i < numbersCount; i++)
			{
                for (int j = grid.GetLength(1) - 1; j >= 0; j--)
                {
                    grid[i, grid.GetLength(1) - 1 - j] = GetBitOnPosition(inputNumbers[i], j);                   
                }			 
			}                                             

            int leftSum = 0;
            int rightSum = 0;
            int m = 0;
         
            for (m = 0; m < grid.GetLength(1); m++)
            {
                leftSum = 0;
                rightSum = 0;
                for (int j = 0; j < m; j++)
                {
                    for (int i = 0; i < numbersCount; i++)
                    {
                        leftSum += grid[i, j];
                    }

                }
                for (int j = m + 1; j < grid.GetLength(1); j++)
                {
                    for (int i = 0; i < numbersCount; i++)
                    {
                        rightSum += grid[i, j];
                    }

                }
                if (leftSum == rightSum)
                {
                    break;
                }
            }

            if (leftSum == rightSum)
            {
                Console.WriteLine(grid.GetLength(1) - 1 - m);
                Console.WriteLine(leftSum);
            }
            else
            {
                Console.WriteLine("No");
            }

        }
    }
}
