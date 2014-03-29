using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static int PreviousPowerOfTwo(int x)
    {
        x = x | (x >> 1);
        x = x | (x >> 2);
        x = x | (x >> 4);
        x = x | (x >> 8);
        x = x | (x >> 16);
        return x - (x >> 1);
    }

    static void Main()
    {
        Console.WriteLine("Enter positive integer number:");
        int myInt = int.Parse(Console.ReadLine());

        Console.WriteLine("The number that is previous power of 2 is: {0}", PreviousPowerOfTwo(myInt));
    }
}

