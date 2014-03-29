using System;
using System.Diagnostics;
//using System.Text

class Program
{
    static void Main(string[] args)
    {
        //Console.OutputEncoding = Encoding.UTF8;
        Stopwatch sw = Stopwatch.StartNew();
        int numberOfAsterisks = 9;
        char mySymbol = '\u002a'; //asterisk symbol
        int rowsNumber = (int)Math.Sqrt(numberOfAsterisks);
        for (int currentRow = 1; currentRow <= rowsNumber; currentRow++) //iterates over lines
        {
            for (int cursorPositionEmpty = 1; cursorPositionEmpty <= rowsNumber - currentRow; cursorPositionEmpty++)
            {
                Console.Write(" "); //prints empty spaces on each line on the left side of the asterisks
            }
            for (int cursorPositionAsterisks = 1; cursorPositionAsterisks <= 2 * currentRow - 1; cursorPositionAsterisks++)
            {
                Console.Write(mySymbol); //prints asterisks on each line
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        sw.Stop();
        Console.WriteLine("Total time : {0} min {1} sec {2} ms", (long)sw.Elapsed.Minutes, (long)sw.Elapsed.Seconds, (long)sw.ElapsedMilliseconds);
    }
}
