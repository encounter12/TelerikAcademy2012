using System;

class Program
{
    static bool isPrimeOptimized(ulong inputNumber, out ulong steps, out ulong divisor)
    {
        steps = 0;
        divisor = 1;
        bool isPrime = true;
        ulong upperBound = (ulong)Math.Floor(Math.Sqrt(inputNumber));
        
        if (inputNumber % 2 == 0 && inputNumber != 2)
        {
            isPrime = false;
            divisor = 2;
            steps ++;
        }
        else
        {
            for (ulong i = 3; i <= upperBound; i += 2)
            {
                steps ++;
                if (inputNumber % i == 0)
                {                    
                    isPrime = false;
                    divisor = i;
                    break;
                }
            }
        }
        return isPrime;
    }
    static void Main()
    {
        ulong steps;
        ulong divisor;
        Console.WriteLine("Enter a positive integer number:");
        ulong inputNumber = ulong.Parse(Console.ReadLine());
        bool isNumberPrime = isPrimeOptimized(inputNumber, out steps, out divisor);

        if (isNumberPrime)
        {
            Console.WriteLine("The number {0} is prime", inputNumber);
        }
        else
        {
            Console.WriteLine("The number {0} is not a prime. It is divisible by {1}", inputNumber, divisor);
        }
       
        Console.WriteLine("Number of steps performed: {0}", steps);
    }
}
