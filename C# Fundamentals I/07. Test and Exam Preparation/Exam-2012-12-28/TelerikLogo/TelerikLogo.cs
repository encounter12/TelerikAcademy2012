using System;

class TelerikLogo
{
    static void Main()
    {
        int x = int.Parse(Console.ReadLine());
        int z = (x + 1) / 2;

        for (int i = 1; i <= z; i++)
        {
            Console.Write(new String('.', z - i));
            Console.Write("*");
            if (i > 1)
            {
                Console.Write(new String('.', 2 * i - 3));
                Console.Write("*");
            }
            Console.Write(new String('.', z - i));

            Console.Write(new String('.', 2 * z - 3));

            Console.Write(new String('.', z - i));
            Console.Write("*");
            if (i > 1)
            {
                Console.Write(new String('.', 2 * i - 3));
                Console.Write("*");
            }
            Console.Write(new String('.', z - i));

            Console.WriteLine();
        }
        for (int i = 1; i <= (x-3)/2; i++)
        {
            Console.Write(new String('.', x - 1 + i));
            Console.Write("*");
            Console.Write(new String('.', x - 2 * (i + 1)));
            Console.Write("*");
            Console.Write(new String('.', x - 1 + i));
            Console.WriteLine();
        }

        for (int i = 1; i <= x ; i++)
        {
            Console.Write(new String('.', (3 * x - 1)/2 - i));
            Console.Write("*");
            if (i > 1)
            {
                Console.Write(new String('.', 2 * i - 3));
                Console.Write("*");
            }
            Console.Write(new String('.', (3 * x - 1) / 2 - i));

            Console.WriteLine();
        }
        for (int i = x - 1; i >= 1; i--)
        {
            Console.Write(new String('.', (3 * x - 1) / 2 - i));
            Console.Write("*");
            if (i > 1)
            {
                Console.Write(new String('.', 2 * i - 3));
                Console.Write("*");
            }
            Console.Write(new String('.', (3 * x - 1) / 2 - i));

            Console.WriteLine();
        }        
    }
}
