using System;
using System.Text;

class TribonacciTriangle
{
    static void Main()
    {
        long firstMember = long.Parse(Console.ReadLine());
        long secondMember = long.Parse(Console.ReadLine());
        long thirdMember = long.Parse(Console.ReadLine());
        long l = long.Parse(Console.ReadLine());

        long termMinusThree = firstMember;
        long termMinusTwo = secondMember;
        long termMinusOne = thirdMember;

        long nthTerm;

        Console.Write(firstMember);

        if (l == 2)
        {
            Console.WriteLine();
            Console.Write(secondMember + " " + thirdMember);            
        }
        else if(l > 2)
        {
            Console.WriteLine();
            Console.Write(secondMember + " " + thirdMember);
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < l - 2; i++)
            {
                Console.WriteLine();

                for (int m = 0; m < i + 3; m++)
                {
                    nthTerm = termMinusOne + termMinusTwo + termMinusThree;
                    termMinusThree = termMinusTwo;
                    termMinusTwo = termMinusOne;
                    termMinusOne = nthTerm;

                    builder.Append(nthTerm).Append(" ");
                }
                string nthLineString = builder.ToString().Trim();
                Console.Write(nthLineString);
                builder.Clear();
            }            
        }
    }
}
