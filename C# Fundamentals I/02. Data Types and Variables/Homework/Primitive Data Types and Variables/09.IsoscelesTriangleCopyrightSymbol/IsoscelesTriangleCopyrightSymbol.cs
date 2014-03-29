using System;
using System.Text;

class IsoscelesTriangleCopyrightSymbol
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        int numberOfSymbols = 9;
        char copyrightCharacter = '\u00a9';
        Console.WriteLine("THIS PROGRAM PRINTS ISOSCELES TRIANGLE USING {0} COPYRIGHT {1} SYMBOLS\n", numberOfSymbols, copyrightCharacter);
            
        int rowsNumber = (int)Math.Sqrt(numberOfSymbols);

        for (int currentRow = 1; currentRow <= rowsNumber; currentRow++) //iterates over lines
        {
            for (int cursorPositionEmpty = 1; cursorPositionEmpty <= rowsNumber - currentRow; cursorPositionEmpty++)
            {
                Console.Write(" "); //prints empty spaces on each line on the left side of the triangle
            }
            for (int cursorPositionCopyright = 1; cursorPositionCopyright <= 2 * currentRow - 1; cursorPositionCopyright++)
            {
                Console.Write(copyrightCharacter); //prints copyright characters on each line
            }
            Console.WriteLine();
        }
    }
}
