using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DancingBits
{
    class DancingBits
    {           
        //Count occurrences of strings.           
        static int CountSymbolOccurrence(string text, int k, char symbol)
        {
            // Loop through all instances of the string 'text'.
            int count = 0;
            int i = 0;
            String substring = new String(symbol, k);
            int substringLength = substring.Length;

            while ((i = text.IndexOf(substring, i)) != -1)
            {
                if ( (i == 0 || (text[i - 1] != symbol)) &&
                     (i + substringLength == text.Length || text[i + substringLength] != symbol) )
                {
                    count++;                                                                                                          
                }

                i += substringLength;
            }
            return count;
        }

        static void Main()
        {
            int k = int.Parse(Console.ReadLine()); //number of consequitive 1s or 0s
            int n = int.Parse(Console.ReadLine());
            
            string binaryString = null;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                binaryString += Convert.ToString(number, 2);
            }
            
            
            int DancingBitsOccurrences = 0;
            

            DancingBitsOccurrences += CountSymbolOccurrence(binaryString, k, '1');
            DancingBitsOccurrences += CountSymbolOccurrence(binaryString, k, '0');

            Console.WriteLine(DancingBitsOccurrences);
        }
    }
}
