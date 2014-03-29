using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anachi
{
    class Anachi
    {
        static int termNMinusOne = 0;
        static int termNMinusTwo = 0;
        static Dictionary<char, int> alphabet = new Dictionary<char, int>();
        static string termNLetter = "";

        static void FindAnachiTermNLetter()
        {
            int termNNumber = termNMinusOne + termNMinusTwo;

            if (termNNumber == 52)
            {
                termNNumber = 26;
            }
            else if (termNNumber > 26)
            {
                termNNumber = termNNumber % 26;
            }

            termNMinusTwo = termNMinusOne;
            termNMinusOne = termNNumber;
            termNLetter = (alphabet.FirstOrDefault(x => x.Value == termNNumber).Key).ToString();

        }
        /*The A-nacci sequence is a sequence similar to the Fibonacci sequence – 
         * each element is formed by the sum of the previous two, but with a little different rules for the elements.
         * The elements in the A-nacci sequence are the capital letters from the English alphabet. 
         * Each letter has a code, determined by its position in the alphabet – A has the code 1, B has the code 2, …, Z has the code 26.
         * The first two elements in the sequence can be any two of the letters above. 
         * Every next element has a code equal to the sum of the codes of the previous two elements.
         * If the sum of two codes is larger than 26, then that sum is taken by its modulus by 26.
         * The A-nacci figure consists of lines of sequential elements from an A-nacci sequence, printed out on the console.
         * The first line contains exactly one element – the first element of an A-nacci sequence.
         * The second line contains the 2nd and 3rd elements of the sequence concatenated without any whitespaces.
         * The 3rd line contains the 4th and 5th elements separated by a single whitespace.
         * The 4th line contains the 6th and 7th elements separated by 2 whitespaces and so on...
         * Write a program, which, by given the first two elements (letters) of the A-nacci sequence and the number of lines in the A-nacci figure, 
         * prints an A-nacci figure on the console.*/

        static void Main(string[] args)
        {

            int letterNumber = 1;

            for (char i = 'A'; i <= 'Z'; i++)
            {

                alphabet.Add(i, letterNumber);
                letterNumber++;
            }

            char termOneLetter = Convert.ToChar(Console.ReadLine());
            char termTwoLetter = Convert.ToChar(Console.ReadLine());

            int l = int.Parse(Console.ReadLine());

            int termOneNumber = alphabet[termOneLetter];
            int termTwoNumber = alphabet[termTwoLetter];

            termNMinusOne = termTwoNumber;
            termNMinusTwo = termOneNumber;

            Console.Write(termOneLetter);

            if (l > 1)
            {
                Console.WriteLine();
                FindAnachiTermNLetter();
                Console.Write(termTwoLetter + termNLetter);
            }

            for (int i = 3; i <= l; i++)
            {
                Console.WriteLine();
                FindAnachiTermNLetter();
                Console.Write(termNLetter + new String(' ', i - 2));
                FindAnachiTermNLetter();
                Console.Write(termNLetter);
            }
        }
    }
}

