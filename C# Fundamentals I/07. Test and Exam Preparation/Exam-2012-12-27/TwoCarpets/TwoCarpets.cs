using System;
using System.Text;

class Program
{
    static StringBuilder builderLeft = new StringBuilder();
    static StringBuilder builderRight = new StringBuilder();

    static void DrawCarpet(int n, int patternHorizontalCount, int patternVerticalCount)
    {
        int x = n / 2;

        for (int s = 0; s < patternVerticalCount; s++)
        {
            for (int i = 1; i <= x; i++)
            {
                if (i % 2 != 0)
                {
                    builderLeft.Append('/');
                    builderRight.Insert(0, '\\');
                }
                else
                {
                    builderLeft.Append(' ');
                    builderRight.Insert(0, ' ');
                }

                for (int m = 0; m < patternHorizontalCount; m++)
                {
                    Console.Write(new String('.', x - i));
                    Console.Write(builderLeft);
                    Console.Write(builderRight);
                    Console.Write(new String('.', x - i));
                }

                Console.WriteLine();
            }

            builderLeft.Replace('/', '\\');
            builderRight.Replace('\\', '/');

            for (int i = 1; i <= x; i++)
            {
                for (int m = 0; m < patternHorizontalCount; m++)
                {
                    Console.Write(new String('.', i - 1));
                    Console.Write(builderLeft);
                    Console.Write(builderRight);
                    Console.Write(new String('.', i - 1));
                }

                Console.WriteLine();

                builderLeft.Length--;
                builderRight.Remove(0, 1);
            }            
        }               
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int patternHorizontalCount = int.Parse(Console.ReadLine());
        int patternVerticalCount = int.Parse(Console.ReadLine());

        DrawCarpet(n, patternHorizontalCount, patternVerticalCount);
        
    }
}

