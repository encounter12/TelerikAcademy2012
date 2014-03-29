using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;

namespace ExtensionMethods
{
    public static class Extensions
    {
        public struct Point
        {
            public decimal x;
            public decimal y;

            public Point(decimal x, decimal y)
            {
                this.x = x;
                this.y = y;
            }
        }
    
        //bit operations
        public static byte GetBit(uint number, byte position)
        {
            if ((number & ((uint)1 << position)) == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public static uint ModifyBit(uint number, byte position, byte bitValue)
        {
            if (bitValue == 0)
            {
                return number & ~((uint)1 << position);
            }
            else if (bitValue == 1)
            {
                return number | ((uint)1 << position);
            }

            return number;
        }
        
        public static int GetCountOfBitOne(uint number)
        {
            int count = 0;
            
            while (number != 0)
            {
                if ((number & 1) == 1)
                {
                    count++;
                }

                number = number >> 1;
            }

            return count;
        }

        public static int GetCountOfBitZero(uint number)
        {
            int count = 0;

            while (number != 0)
            {
                if ((number & 1) == 0)
                {
                    count++;
                }

                number = number >> 1;
            }

            return count;
        }

        /*
        public static int GetCountOfBitOne(uint number)
        {
            int result = 0;

            while (number != 0)
            {
                result++;
                number &= (number - 1);
            }

            return result;
        }

        public static int GetCountOfBitZero(uint number)
        {
            return GetCountOfBitOne(~number);
        }
        */
        
        static string ConvertToBinary(int number)
        {
            if (number == 0)
            {
                return "0";
            }
            if (number == 1)
            {
                return "1";
            }

            string bits = "";

            while (number > 0)
            {
                bits += number % 2;
                number = number / 2;
            }

            return StringReverse(bits);
        }

        static int ReverseBits(int number)
        {
            if (number == 0)
            {
                return 0;
            }
            if (number == 1)
            {
                return 1;
            }

            string bits = "";

            while (number > 0)
            {
                bits += number % 2;
                number = number / 2;                
            }

            return Convert.ToInt32(bits, 2);
        }

        //strings        
        static string StringReverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        
        /**
         * This method finds the number of exact substrings in a string
         * Exact substring is a substring, which do not contain itself into bigger substring
         * 
         * Example:
         * ExactSubstringsCount("101110111010001111", "111");
         * will return 2, because "1111" is not a substring of exact 3 ones.
        **/
        static int ExactSubstringsCount(string text, string substring)
        {
            int exaxtSubstringsCount = 0;

            for (var i = 0; i <= text.Length - substring.Length; i++)
            {
                if ( text.Substring(i, substring.Length) == substring &&
                     (i == 0 || text.Substring(i - 1, substring.Length) != substring) && 
                     (i == text.Length - substring.Length || text.Substring(i + 1, substring.Length) != substring) )
                {
                    exaxtSubstringsCount++;
                }
            }

            return exaxtSubstringsCount;
        }
        
        static int getLongestSubstring(string text, char symbol, out int longestSubstringsCount)
        {
            int longestSubstringLength = 0;
            longestSubstringsCount = 0;

            for (int i = text.Length; i >= 1; i--)
            {
                string pattern = new string(symbol, i);

                if (text.Contains(pattern))
                {
                    longestSubstringLength = (byte)i;
                    longestSubstringsCount = CountStringOccurrences(text, pattern);
                    break;
                }
            }

            return longestSubstringLength;
        }

        public static int CountStringOccurrences(string text, string pattern)
        {
            // Loop through all instances of the string 'text'.
            int count = 0;
            int i = 0;
            while ((i = text.IndexOf(pattern, i)) != -1)
            {
                i += pattern.Length;
                count++;
            }
            return count;
        }
        
        //prime numbers
        public static bool IsPrime(int number)
        {
            if (number <= 1 || (number > 2 && number % 2 == 0))
            {
                return false;
            }

            for (int i = 3; number >= i * i; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsPrime2(int number)
        {
            if (number <= 1 || (number > 2 && (number & 1) == 0))
            {
                return false;
            }

            int root = (int)Math.Sqrt(number);

            for (int i = 3; i <= root; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsPrimeNumber(int number)
        {
            if (number <= 7)
            {
                return number == 2 || number == 3 || number == 5 || number == 7;
            }

            if (number % 2 == 0 || number % 3 == 0)
            {
                return false;
            }

            for (int i = 6; ; i += 6)
            {
                if (number % (i - 1) == 0 || number % (i + 1) == 0)
                {
                    return false;
                }

                if ((i + 1) * (i + 1) > number)
                {
                    break;
                }
            }

            return true;
        }
        
        //get dividents without remainder for all divisors
        public static uint GetDividentsWitoutRemainderCount(uint startNumber, uint endNumber, uint divisor)
        {
            if (divisor == 0)
            {
                return 0;
            }

            if (divisor == 1)
            {
                return endNumber - startNumber;
            }
            
            uint dividentsCount = 0;

            for (uint i = startNumber; i <= endNumber; i++)
            {
                if (i % divisor == 0)
                {
                    dividentsCount++;
                }
            }

            return dividentsCount;
        }

        //get dividents without remainder for a prime divisor - experimental!!!
        public static uint GetDividentsByPrimeWitoutRemainderCount(uint startNumber, uint endNumber, uint divisor)
        {
            if (startNumber % divisor == 0 || endNumber % divisor == 0)
            {
                return (uint)((Math.Abs(endNumber - startNumber) / divisor) + 1);
            }
            else
            {
                return (uint)Math.Round((double)(Math.Abs(endNumber - startNumber) / divisor), MidpointRounding.AwayFromZero);
            }
        }
        
        public static bool SolveQuadraticEquation(int a, int b, int c, out double[] roots)
        {
            roots = new double[2];

            int discriminant = b * b - 4 * a * c;

            if (discriminant > 0)
            {
                //two roots
                roots[0] = (-b + Math.Sqrt(discriminant)) / (2 * a);
                roots[1] = (-b - Math.Sqrt(discriminant)) / (2 * a);
            }
            else if (discriminant == 0)
            {
                //one double root
                roots[0] = -b / (2 * a);
                roots[1] = -b / (2 * a);
            }
            else
            {
                return false;
            }

            return true;
        }
        
        static int FindMax(int numberOne, int numberTwo, int numberThree)
        {
            if (numberOne >= numberTwo)
            {
                if (numberOne >= numberThree)
                {
                    return numberOne;
                }
            }

            if (numberTwo > numberOne)
            {
                if (numberTwo > numberThree)
                {
                    return numberTwo;
                }
            }

            return numberThree;
        }
        
        //sorting
        static void SelectionSortAsc(decimal[] numbers)
        {
            int minKey;
            decimal tempElement;

            for (int j = 0; j < numbers.Length - 1; j++)
            {
                minKey = j;

                for (int k = j + 1; k < numbers.Length; k++)
                {
                    if (numbers[k] < numbers[minKey])
                    {
                        minKey = k;
                    }
                }

                tempElement = numbers[minKey];
                numbers[minKey] = numbers[j];
                numbers[j] = tempElement;
            }
        }

        static void SelectionSortDesc(decimal[] numbers)
        {
            int minKey;
            decimal tempElement;

            for (int j = 0; j < numbers.Length - 1; j++)
            {
                minKey = j;

                for (int k = j + 1; k < numbers.Length; k++)
                {
                    if (numbers[k] > numbers[minKey])
                    {
                        minKey = k;
                    }
                }

                tempElement = numbers[minKey];
                numbers[minKey] = numbers[j];
                numbers[j] = tempElement;
            }
        }
        
        static Dictionary<byte, int> SortDictionaryDesc(Dictionary<byte, int> dictionary)
        {
            Dictionary<byte, int> sortedDictionary = (from entry in dictionary orderby entry.Value descending select entry)
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            return sortedDictionary;
        }
        
        //GCD and LCM
        static int GreatestCommonDivisor(int numberOne, int numberTwo)
        {
            int Remainder;

            while (numberTwo != 0)
            {
                Remainder = numberOne % numberTwo;
                numberOne = numberTwo;
                numberTwo = Remainder;
            }

            return numberOne;
        }
        
        static int LowestCommonMultiple(int numberOne, int numberTwo)
        {
            return (numberOne * numberTwo) / GreatestCommonDivisor(numberOne, numberTwo);
        }
        
        //http://www.mytechinterviews.com/how-many-trailing-zeros-in-100-factorial
        static uint FactorialTrailingZeroes(uint n)
        {
            uint zeroes = 0;

            uint powerOfFive = 5;

            while (n / powerOfFive > 0)
            {
                zeroes += n / powerOfFive;
                powerOfFive *= 5;
            }

            return zeroes;
        }

        static BigInteger Factorial(uint n)
        {
            BigInteger factorial = 1;

            for (uint i = 1; i <= n; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
        
        static BigInteger CatalanNumber(uint n)
        {
            BigInteger result = 0;

            BigInteger nPlusTwoToTwoN = 1;
            BigInteger nFactorial = 1;

            for (ulong i = n + 2; i <= 2 * n; i++)
            {
                nPlusTwoToTwoN *= i;
            }

            for (uint i = 1; i <= n; i++)
            {
                nFactorial *= i;
            }

            result = nPlusTwoToTwoN / nFactorial;

            return result;
        }
        
        //subsets
        //all possible subsets of a given array
        static List<T[]> FindSubsets<T>(T[] originalArray)
        {
            List<T[]> subsets = new List<T[]>();

            for (int i = 0; i < originalArray.Length; i++)
            {
                int subsetCount = subsets.Count;
                subsets.Add(new T[] { originalArray[i] });

                for (int j = 0; j < subsetCount; j++)
                {
                    T[] newSubset = new T[subsets[j].Length + 1];
                    subsets[j].CopyTo(newSubset, 0);
                    newSubset[newSubset.Length - 1] = originalArray[i];
                    subsets.Add(newSubset);
                }
            }

            return subsets;
        }
        
        /**
         * This method finds all subsets of a set, which have specific length
        **/
        public static List<List<int>> getSubsets(List<int> superSet, int subsetsLength)
        {
            List<List<int>> subsets = new List<List<int>>();

            getSubsets(superSet, subsetsLength, 0, new List<int>(), subsets);

            return subsets;
        }

        private static void getSubsets(List<int> superSet, int subsetsLength, int index, List<int> currentSubset, List<List<int>> solution)
        {
            //successful stop clause
            if (currentSubset.Count == subsetsLength)
            {
                solution.Add(new List<int>(currentSubset));

                return;
            }

            //unseccessful stop clause
            if (index == superSet.Count) return;
            int subset = superSet[index];
            currentSubset.Add(subset);

            //"guess" x is in the subset
            getSubsets(superSet, subsetsLength, index + 1, currentSubset, solution);
            currentSubset.Remove(subset);

            //"guess" x is not in the subset
            getSubsets(superSet, subsetsLength, index + 1, currentSubset, solution);
        }
        
        //Iv
        static List<List<int>> FindAllSubsets(int[] setArray)
        {
            List<List<int>> subsetsList = new List<List<int>>();
            int variablesNumber = setArray.Length;
            for (int i = 1; i < Math.Pow(2, variablesNumber); i++)
            {
                List<int> subset = new List<int>();

                for (int m = 0; m < variablesNumber; m++)
                {
                    int mask = 1 << m;
                    int nAndMask = i & mask;
                    int bitValue = nAndMask >> m;

                    if (bitValue == 1)
                    {
                        subset.Add(setArray[m]);
                    }
                }
                subsetsList.Add(subset);
            }
            return subsetsList;
        }
        
        static List<List<int>> FindAllSubsetsHavingGivenSum(int[] setArray, int sum)
        {
            List<List<int>> subsetsListHavingGivenSum = new List<List<int>>();
            int variablesNumber = setArray.Length;
            for (int i = 1; i < Math.Pow(2, variablesNumber); i++)
            {
                List<int> subset = new List<int>();

                for (int m = 0; m < variablesNumber; m++)
                {
                    int mask = 1 << m;
                    int nAndMask = i & mask;
                    int bitValue = nAndMask >> m;

                    if (bitValue == 1)
                    {
                        subset.Add(setArray[m]);
                    }
                }
                if (subset.Sum() == sum)
                {
                    subsetsListHavingGivenSum.Add(subset);
                }               
            }
           
            return subsetsListHavingGivenSum;
        }
        
        static List<List<int>> FindAllSubsetsWithGivenLength(int[] setArray, int subsetsLength)
        {
            List<List<int>> subsetsListWithGivenLength = new List<List<int>>();
            int variablesNumber = setArray.Length;
            for (int i = 1; i < Math.Pow(2, variablesNumber); i++)
            {
                List<int> subset = new List<int>();

                for (int m = 0; m < variablesNumber; m++)
                {
                    int mask = 1 << m;
                    int nAndMask = i & mask;
                    int bitValue = nAndMask >> m;

                    if (bitValue == 1)
                    {
                        subset.Add(setArray[m]);
                    }
                }
                if (subset.Count == subsetsLength)
                {
                    subsetsListWithGivenLength.Add(subset);
                }
            }

            return subsetsListWithGivenLength;
        }
        
        //shapes
        public static double CalculateRectangleArea(double height, double width)
        {
            return height * width;
        }
        
        public static double CalculateTrapezoidArea(double sideA, double sideB, double height)
        {
            return ((sideA + sideB) / 2) * height;
        }
        
        public static double CalculateCirclePerimeter(double radius)
        {
            return 2 * Math.PI * radius;
        }

        public static double CalculateCircleArea(double radius)
        {
            return Math.PI * radius * radius;
        }
        
        public static bool IsPointWithinCircle(double circleCenterX, double circleCenterY, double circleRadius, double pointX, double pointY)
        {
            //Pythagorean theorem
            return Math.Pow((pointX - circleCenterX), 2) + Math.Pow((pointY - circleCenterY), 2) <= Math.Pow(circleRadius, 2);
        }
        
        public static bool IsPointWithinCircle(Point center, double radius, Point point,
            out bool isOnCenter, out bool isOnEdge)
        {
            isOnCenter = false;
            isOnEdge = false;
                        
            if (center.x == point.x && center.y == point.y)
            {
                isOnCenter = true;
            }

            //Pythagorean theorem
            double legsSquare = Math.Pow((point.x - center.x), 2) + Math.Pow((point.y - center.y), 2);
            double hypotenuseSquare = Math.Pow(radius, 2);
            
            if (legsSquare == hypotenuseSquare)
            {
                isOnEdge = true;
            }

            return legsSquare <= hypotenuseSquare;
        }

        public static bool IsPointWithinRectangle(double upperLeftX, double upperLeftY, double height, double width, double pointX, double pointY)
        {
            if ((upperLeftX <= pointX && pointX <= upperLeftX + width) && (upperLeftY - height <= pointY && pointY <= upperLeftY))
            {
                return true;
            }
            
            return false;
        }
        
        public static bool IsPointWithinRectangle(Point cornerOne, Point cornerTwo, Point point)
        {
            //find the bounds of the rectangle
            int minX = Math.Min(cornerOne.x, cornerTwo.x);
            int maxX = Math.Max(cornerOne.x, cornerTwo.x);
            int minY = Math.Min(cornerOne.y, cornerTwo.y);
            int maxY = Math.Max(cornerOne.y, cornerTwo.y);

            //point is within the rectangle
            if ((minX <= point.x && point.x <= maxX) && (minY <= point.y && point.y <= maxY))
            {
                return true;
            }

            //point is out of the rectangle
            return false;
        }
        
        public static bool IsPointWithinRectangle(Point cornerOne, Point cornerTwo, Point point, out bool isOnCorner, out bool isOnEdge)
        {
            isOnCorner = false;
            isOnEdge = false;

            //find the bounds of the rectangle
            int minX = Math.Min(cornerOne.x, cornerTwo.x);
            int maxX = Math.Max(cornerOne.x, cornerTwo.x);
            int minY = Math.Min(cornerOne.y, cornerTwo.y);
            int maxY = Math.Max(cornerOne.y, cornerTwo.y);

            //point is within the rectangle
            if ((minX <= point.x && point.x <= maxX) && (minY <= point.y && point.y <= maxY))
            {
                //point is on corner
                if ((point.x == minX || point.x == maxX) && (point.y == minY || point.y == maxY))
                {
                    isOnCorner = true;
                }
                else if ( ( (point.x == minX || point.x == maxX) && (point.y > minY && point.y < maxY) ) ||
                    ( (point.y == minY || point.y == maxY) && (point.x > minX && point.x < maxX) ) ) //point is on edge
                {
                    isOnEdge = true;
                }

                return true;
            }

            //point is out of the rectangle
            return false;
        }
        
        //get digit from integer
        public static int GetDigit(int number, short digit)
        {
            return (number / (int)Math.Pow(10, digit - 1)) % 10;
        }
        
        static int FindPointPositionOnCartesianCoordinateSystem(Point point)
        {
            if (point.x > 0 && point.y > 0)
            {
                return 1;
            }
            else if (point.x < 0 && point.y > 0)
            {
                return 2;
            }
            else if (point.x < 0 && point.y < 0)
            {
                return 3;
            }
            else if (point.x > 0 && point.y < 0)
            {
                return 4;
            }
            else if (point.x == 0 && point.y != 0)
            {
                return 5;
            }
            else if (point.x != 0 && point.y == 0)
            {
                return 6;
            }
            else
            {
                return 0;
            }
        }
        
        public static void Falldown(byte[,] grid)
        {
            int gridLength = grid.GetLength(0);

            for (int i = gridLength - 2; i >= 0; i--)
            {
                for (int j = 0; j < gridLength; j++)
                {
                    for (int k = i + 1; k < gridLength; k++)
                    {
                        if (grid[k - 1, j] == 1 && grid[k, j] == 0)
                        {
                            grid[k - 1, j] = 0;
                            grid[k, j] = 1;
                        }
                    }
                }
            }
        }
    
        //shuffle List values
        /*
        public static void Shuffle<T>(this IList<T> list)
        {
            Random randomGenerator = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = randomGenerator.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        */
        
        public static void Shuffle<T>(this IList<T> list)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}