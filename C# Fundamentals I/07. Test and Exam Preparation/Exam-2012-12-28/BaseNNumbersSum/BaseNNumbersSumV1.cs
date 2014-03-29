using System;

class BaseNNumbersSumV1
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
        /*This program calculates the sum of two positive integer numbers of base system N (0 < N < 11)
         * Reference: Algorithms for addition and multiplication: http://www.cim.mcgill.ca/~langer/250/1-gradeschool.pdf 
         * Introduction to Computer Science (COMP 250) - Fall 2012: http://www.cim.mcgill.ca/~langer/250.html
         */

        int k1 = int.Parse(Console.ReadLine()); //enter 1st positive integer 
        int k2 = int.Parse(Console.ReadLine()); //enter 2nd positive integer
        int baseN = int.Parse(Console.ReadLine()); //enter the base system number

        int baseNMaxNumber = baseN - 1;

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
            int digitsOnPositionSum = k1Digits[i] + k2Digits[i] + carriedNumber;   

            if (digitsOnPositionSum > baseNMaxNumber)
            {
                kSumDigits[i] = digitsOnPositionSum - baseNMaxNumber - 1;
                carriedNumber = 1;
            }
            else
            {
                kSumDigits[i] = digitsOnPositionSum;
                carriedNumber = 0;
            }                               
        }

        for (int i = MaxNumberOfDigits; i >= 0; i--)
        {
            sum += kSumDigits[i] * (int)Math.Pow(10, MaxNumberOfDigits - i);
        }

        Console.WriteLine(sum);
    }
}

