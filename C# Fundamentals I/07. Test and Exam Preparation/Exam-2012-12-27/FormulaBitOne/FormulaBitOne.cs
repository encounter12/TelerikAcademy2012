using System;

namespace Formula
{    
    class FormulaBitOne
    {
        static int row = 0;
        static int column = 7;

        static bool IsFinalPointReached()
        {
            bool finalPointReached = false;
            if (row == 7 && column == 0)
            {
                finalPointReached = true;
            }
            return finalPointReached;
        }
        static int GetBitOnPosition(byte number, int position)
        {
            byte bitMask = (byte)(1 << position);
            int result = (number & bitMask) >> position;
            return result;
        }

        static void Main()
        {
            int[,] grid = new int[8,8];        

            byte number;                      
            for (int i = 0; i < 8; i++)
            {
                number = byte.Parse(Console.ReadLine());

                for (int j = 7; j >= 0; j--)
                {
                    grid[i, j] = GetBitOnPosition(number, 7 - j);
                }
            }

            if (grid[0, 7] == 1)
            {
                Console.WriteLine("No 0");
                return;
            }

            int trackLength = 1;
            int turnsCount = 0;
            bool trackInterrupted = true;

            while (true)
            {                
                while (row < 7 && grid[row + 1, column] == 0)
                {
                    trackInterrupted = false;
                    row++;
                    trackLength++;
                }
                if (IsFinalPointReached() || trackInterrupted)
                {
                    break;
                }

                turnsCount++;
                trackInterrupted = true;

                while (column > 0 && grid[row, column - 1] == 0)
                {
                    trackInterrupted = false;
                    column--;
                    trackLength++;
                }
                if (IsFinalPointReached() || trackInterrupted)
                {
                    break;
                }

                turnsCount++;
                trackInterrupted = true;

                while (row > 0 && grid[row - 1, column] == 0)
                {
                    trackInterrupted = false;
                    row--;
                    trackLength++;
                }

                if (IsFinalPointReached() || trackInterrupted)
                {
                    break;
                }

                turnsCount++;
                trackInterrupted = true;

                while (column > 0 && grid[row, column - 1] == 0)
                {
                    trackInterrupted = false;
                    column--;
                    trackLength++;
                }

                if (IsFinalPointReached() || trackInterrupted)
                {
                    break;
                }

                turnsCount++;
                trackInterrupted = true;
            }            

            if (IsFinalPointReached())
            {
                Console.WriteLine("{0} {1}", trackLength, turnsCount);
            }
            else
            {
                Console.WriteLine("No {0}", trackLength);
            }
            
        }                                
    }
}

