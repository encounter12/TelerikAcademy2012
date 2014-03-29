using System;

class TelerikLogo
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            Console.Write(new String('.', n - i));
            Console.Write("*");
            if (i > 1)
            {
                Console.Write(new String('.', 2 * i - 3));
                Console.Write("*");
            }
            Console.Write(new String('.', n - i));

            Console.WriteLine();
        }
    }
}
