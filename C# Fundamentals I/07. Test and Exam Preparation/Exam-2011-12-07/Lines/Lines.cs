using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lines
{
    class Lines
    {
        static int GetBitOnPosition(int number, int position)
        {
            int extractedBit;

            extractedBit = (number & (1 << position)) >> position;
            return extractedBit;
        }
        //Count occurrences of strings.           
        static int CountStringOccurrence(string text, int k, char symbol)
        {
            // Loop through all instances of the string 'text'.
            int count = 0;
            int i = 0;
            String substring = new String(symbol, k);
            int substringLength = substring.Length;

            while ((i = text.IndexOf(substring, i)) != -1)
            {
                if ((i == 0 || (text[i - 1] != symbol)) &&
                     (i + substringLength == text.Length || text[i + substringLength] != symbol))
                {
                    count++;
                }

                i += substringLength;
            }
            return count;
        }
        static void Main()
        {
            int numbersCount = 8;
            int[] inputNumbers = new int[numbersCount];
            int[,] grid = new int[numbersCount, sizeof(byte) * 8];
            int MaxLineLength = 0;
            int LinesOccurrences = 0;

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

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                String rowString = null;                

                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    rowString += grid[i, j].ToString();
                }                

                for (int m  = grid.GetLength(1); m  >= 1; m --)
                {
                    if (CountStringOccurrence(rowString, m, '1') > 0)
                    {
                        if (m > MaxLineLength)
                        {
                            MaxLineLength = m;
                            LinesOccurrences = CountStringOccurrence(rowString, m, '1');;
                            break;
                        }
                        else if (m == MaxLineLength)
                        {
                            LinesOccurrences += CountStringOccurrence(rowString, m, '1');
                            break;
                        }                        
                    }                    
                }                              
            }

            for (int j = 0; j < grid.GetLength(1); j++)
            {
                String columnString = null;

                for (int i = 0; i < grid.GetLength(0); i++)
                {
                    columnString += grid[i, j].ToString();
                }

                for (int m = grid.GetLength(0); m >= 1; m--)
                {
                    if (CountStringOccurrence(columnString, m, '1') > 0)
                    {
                        if (m > MaxLineLength)
                        {
                            MaxLineLength = m;
                            LinesOccurrences = CountStringOccurrence(columnString, m, '1'); ;
                            break;
                        }
                        else if (m == MaxLineLength && m > 1)
                        {
                            LinesOccurrences += CountStringOccurrence(columnString, m, '1');
                            break;
                        }
                        
                    }
                }     
            }

            Console.WriteLine(MaxLineLength);
            Console.WriteLine(LinesOccurrences);
        }
    }
}
