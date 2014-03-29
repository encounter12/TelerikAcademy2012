using System;
using System.Text;
using System.Diagnostics;

class Program
{
    static void DisplayWhiteSpaces(int emptyCurrentRow, int functionRowsNumber, ref ulong iterationsCounter)
    {
        for (int emptyCharCounter = 1; emptyCharCounter <= functionRowsNumber - emptyCurrentRow; emptyCharCounter++)
        {
            Console.Write(" "); //prints empty spaces on each line on the left side of the Christmas Tree
            iterationsCounter++;
        }
    }
    static void DisplayChars(int functionCurrentRow, char displayChar, ref ulong iterationsCounter)
    {
        for (int CharCounter = 1; CharCounter <= functionCurrentRow - 1; CharCounter++)
        {
            Console.Write(displayChar); //prints characters/braches on both sides of the tree trunk
            iterationsCounter++;
        }
    }

    static void Main()
    {
        /*
               |
              *|*
             **|**
            ***|***
           ****|****
          *****|*****
        
         */

        Stopwatch sw = Stopwatch.StartNew();
        ulong iterationsCounter = 0;
        Console.OutputEncoding = Encoding.UTF8;
        int radiusSymbolsNumber = 5;
        char myChar = '\u002a';  //'\u002a' - asterisk *; '\u00a9' - at sign @
        Console.WriteLine("THIS PROGRAM PRINTS CHRISTMAS TREE WITH RADIUS {0} {1} SYMBOLS\n", radiusSymbolsNumber, myChar);

        int rowsNumber = radiusSymbolsNumber + 1;

        for (int currentRow = 1; currentRow <= rowsNumber; currentRow++) //iterates over lines
        {

            DisplayWhiteSpaces(currentRow, rowsNumber, ref iterationsCounter);
            DisplayChars(currentRow, myChar, ref iterationsCounter);

            Console.Write("|"); //prints pipe which is the Christmas Tree trunk

            DisplayChars(currentRow, myChar, ref iterationsCounter);

            Console.WriteLine();
        }
        sw.Stop();
        Console.WriteLine();
        Console.WriteLine("Radius size N: {0}", radiusSymbolsNumber);
        Console.WriteLine("Program execution time: {0} min {1} sec {2} ms", (long)sw.Elapsed.Minutes, (long)sw.Elapsed.Seconds, (long)sw.ElapsedMilliseconds);
        Console.WriteLine("Iterations number: {0}", iterationsCounter);

    }
}


