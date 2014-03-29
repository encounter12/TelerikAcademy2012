using System;

class BaseNNumbersSum
{
    static int[] AssignPositiveIntegerDigitsToArray(int k, int kDigitsCount)
    {
        int[] kDigits = new int[kDigitsCount + 1];
        for (int i = 0; i <= kDigitsCount; i++)
        {
            kDigits[kDigitsCount - i] = (k / (int)Math.Pow(10, i)) % 10;
        }
        return kDigits;
    }
    static void Main()
    {
        /*This program takes K positive integer in base 7 system and finds the K+1 number*/

        int k1 = int.Parse(Console.ReadLine());
        int k2 = 1;
        int baseN = 7;

        int k1DigitsCount = k1.ToString().Length;
        int k2DigitsCount = k2.ToString().Length;
        int MaxNumberOfDigits = Math.Max(k1DigitsCount, k2DigitsCount);
        int sum = 0;

        int[] k1Digits = AssignPositiveIntegerDigitsToArray(k1, MaxNumberOfDigits);
        int[] k2Digits = AssignPositiveIntegerDigitsToArray(k2, MaxNumberOfDigits);
        int[] kSumDigits = new int[MaxNumberOfDigits + 1];

        int carriedNumber = 0;

        for (int i = MaxNumberOfDigits; i >= 0; i--)
        {
            kSumDigits[i] = (k1Digits[i] + k2Digits[i] + carriedNumber) % baseN;
            carriedNumber = (k1Digits[i] + k2Digits[i] + carriedNumber) / baseN;
        }

        for (int i = MaxNumberOfDigits; i >= 0; i--)
        {
            sum += kSumDigits[i] * (int)Math.Pow(10, MaxNumberOfDigits - i);
        }

        Console.WriteLine(sum);
    }
}


