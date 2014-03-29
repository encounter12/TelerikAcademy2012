using System;
using System.Text;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int x = n / 2;
        StringBuilder builderLeft = new StringBuilder();
        StringBuilder builderRight = new StringBuilder();
        for (int i = 1; i <= x; i++)
        {                        
            if (i % 2 != 0)
            {
                builderLeft.Append('/');
                builderRight.Insert(0, '\\');
            }
            else
            {
                builderLeft.Append(' ');
                builderRight.Insert(0, ' ');
            }

            Console.Write(new String('.', x - i));
            Console.Write(builderLeft);
            Console.Write(builderRight);
            Console.WriteLine(new String('.', x - i));
        }
        builderLeft.Replace('/', '\\');
        builderRight.Replace('\\', '/');

        for (int i = 1; i <= x; i++)
        {
            Console.Write(new String('.', i - 1));
            Console.Write(builderLeft);
            Console.Write(builderRight);
            Console.WriteLine(new String('.', i - 1));

            builderLeft.Length--;
            builderRight.Remove(0, 1);          
        }
    }
}
