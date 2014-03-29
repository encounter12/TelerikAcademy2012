using System;
using System.Text;
using System.Diagnostics;

class Program
{
    static void DisplayEmptyString(int functionRowsNumber, int methodCurrentRow)
    {
        String emtpyString = new String('\u0020', functionRowsNumber - methodCurrentRow);
        Console.Write(emtpyString); //prints empty spaces on each line on the left side of the triangle
    }
    static void DisplayCharString(char displayChar, int functionCurrentRow)
    {
        String charString = new String(displayChar, functionCurrentRow - 1);
        Console.Write(charString); //prints copyright characters on each line
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
        Console.OutputEncoding = Encoding.UTF8;
        int radiusSymbolsNumber = 5;
        char myChar = '\u002a';  //'\u002a' - asterisk *; '\u00a9' - at sign @
        Console.WriteLine("THIS PROGRAM PRINTS CHRISTMAS TREE WITH RADIUS {0} {1} SYMBOLS\n", radiusSymbolsNumber, myChar);

        int rowsNumber = radiusSymbolsNumber + 1;

        for (int currentRow = 1; currentRow <= rowsNumber; currentRow++) //iterates over lines
        {

            DisplayEmptyString(rowsNumber, currentRow);
            DisplayCharString(myChar, currentRow);

            Console.Write("|"); //prints pipe which is the Christmas Tree trunk

            DisplayCharString(myChar, currentRow);

            Console.WriteLine();
        }
        Console.WriteLine();
        sw.Stop();
        Console.WriteLine("Total time (min): {0} (sec): {1} (ms): {2}", (long)sw.Elapsed.Minutes, (long)sw.Elapsed.Seconds, (long)sw.ElapsedMilliseconds);
    }
}
