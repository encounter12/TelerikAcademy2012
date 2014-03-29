using System;
using System.Diagnostics;
class DisplayIsoscelesTriangle
{
    static void Main()
    {
        Stopwatch sw = Stopwatch.StartNew();
        int numberOfAsterisks = 9;
        char displaySymbol ='*';
        int rowsNumber = (int)Math.Sqrt(numberOfAsterisks);
        for (int currentRow = 1; currentRow <= rowsNumber - 1; currentRow++)
        {
            for (int cursorPositionEmpty = 1; cursorPositionEmpty <= rowsNumber - currentRow; cursorPositionEmpty++)
            {
                Console.Write(" ");
            }
            for (int cursorPositionAsterisks = 1; cursorPositionAsterisks <= 2*currentRow - 1; cursorPositionAsterisks++)
            {
                Console.Write(displaySymbol);
            }
            Console.WriteLine();
        }
        for (int cursorPositionAsterisks = 1; cursorPositionAsterisks <= 2*rowsNumber - 1; cursorPositionAsterisks++)
        {
            Console.Write(displaySymbol);
        }        
        Console.WriteLine();
        sw.Stop();
        Console.WriteLine("Total time : {0} min {1} sec {2} ms", (long)sw.Elapsed.Minutes, (long)sw.Elapsed.Seconds, (long)sw.ElapsedMilliseconds);
    }
    
}
