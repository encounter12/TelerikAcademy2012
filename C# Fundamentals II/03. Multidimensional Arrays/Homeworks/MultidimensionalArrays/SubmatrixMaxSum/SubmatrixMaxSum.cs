﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmatrixMaxSum
{
    class SubmatrixMaxSum
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The initial matrix is:");
            int m = 8;
            int n = 9;
            int[,] matrix = new int[m, n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[j, i] = random.Next(0, 100);
                    Console.Write("{0} {1}", matrix[j, i], matrix[j, i] < 10 ? " " : "");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("The maximum 3x3 matrix is:");
            int[,] maxMatrix = Max3X3(matrix);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("{0} {1}", maxMatrix[j, i], maxMatrix[j, i] < 10 ? " " : "");
                }
                Console.WriteLine();
            }
        }
        public static int[,] Max3X3(int[,] matrix)
        {
            int[] max = new int[2];
            int[,] maxMatrix = new int[3, 3];
            int sum = 0;
            int maxSum = 0;
            int n = matrix.GetLength(1);
            int m = matrix.GetLength(0);
            for (int i = 0; i < n - 2; i++)
            {
                for (int j = 0; j < m - 2; j++)
                {
                    sum = 0;
                    for (int p = 0; p < 3; p++)
                    {
                        for (int q = 0; q < 3; q++)
                        {
                            sum = sum + matrix[q + j, p + i];
                        }
                    }
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        max = new int[] { j, i };
                    }
                }
            }
            for (int i = max[1]; i < max[1] + 3; i++)
            {
                for (int j = max[0]; j < max[0] + 3; j++)
                {
                    maxMatrix[j - max[0], i - max[1]] = matrix[j, i];
                }
            }
            return maxMatrix;
        }
    }
}
