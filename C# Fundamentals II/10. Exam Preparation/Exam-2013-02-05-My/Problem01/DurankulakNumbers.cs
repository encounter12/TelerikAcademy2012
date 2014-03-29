using System;
using System.Collections.Generic;
using System.Numerics;

class Program
{
    //Completed
    static void Main()
    {
        string durankulakNumber = Console.ReadLine();
        int digit168 = 0;
        List<int> base168Numbers = new List<int>();

        int i = durankulakNumber.Length - 1;
        while (i >= 0)
        {
            if (i - 1 == 0)
            {
                if (char.IsLower(durankulakNumber[i - 1]))
                {
                    digit168 = (durankulakNumber[i] - 'A') + (durankulakNumber[i - 1] + 1 - 'a') * 26;
                    base168Numbers.Add(digit168);
                    break;
                }
                else
                {
                    digit168 = (durankulakNumber[i] - 'A') * 26;
                    base168Numbers.Add(digit168);
                }
            }
            else if (i == 0)
            {
                digit168 = durankulakNumber[i] - 'A';
                base168Numbers.Add(digit168);
            }
            else
            {
                if (char.IsLower(durankulakNumber[i - 1]))
                {
                    digit168 = (durankulakNumber[i] - 'A') + (durankulakNumber[i - 1] + 1 - 'a') * 26;
                    base168Numbers.Add(digit168);
                    i = i - 2;
                    continue;
                }
                else
                {
                    digit168 = durankulakNumber[i] - 'A';
                    base168Numbers.Add(digit168);
                }
            }
            i--;
        }

        BigInteger decimalNumber = 0;

        for (int m = 0; m < base168Numbers.Count; m++)
        {
            decimalNumber += (BigInteger)(base168Numbers[m] * Math.Pow(168, m));
        }

        Console.WriteLine(decimalNumber);
    }
}