using System;
using System.Collections.Generic;

class ExcelColumns
{
    static void Main()
    {
        Dictionary<char, int> alphabet = new Dictionary<char,int>();

        int letterNumber = 1; 

        for (char letter = 'A'; letter <= 'Z'; letter++)
        {
            alphabet.Add(letter, letterNumber);
            letterNumber++;
        }

        int n = int.Parse(Console.ReadLine());

        int[] digitsArray = new int[n]; 

        for (int i = 0; i < n; i++)
        {
            char inputChar = Convert.ToChar(Console.ReadLine());
            digitsArray[i] = alphabet[inputChar]; 
        }

        long columnIndex = 0;

        for (int i = n - 1; i >= 0; i--)
        {
            columnIndex += digitsArray[i] * (long)Math.Pow(26, n - 1 - i);   
        }

        Console.WriteLine(columnIndex);
    }
}

