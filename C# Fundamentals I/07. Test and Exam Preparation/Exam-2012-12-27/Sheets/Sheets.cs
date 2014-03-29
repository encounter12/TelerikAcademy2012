using System;
using System.Collections.Generic;
using System.Text;

class Sheets
{
    static int PreviousPowerOfTwo32BitInt(int x)
    {
        x = x | (x >> 1);
        x = x | (x >> 2);
        x = x | (x >> 4);
        x = x | (x >> 8);
        x = x | (x >> 16);
        return x - (x >> 1);
    }
    static void Main()
    {
        Dictionary<int, string> sheets = new Dictionary<int, string>();
        StringBuilder builder = new StringBuilder();

        for (int i  = 0; i <= 10; i ++)
        {
            sheets.Add((int)Math.Pow(2, i), builder.Append("A").Append(10 - i).ToString());
            builder.Clear();
        }

        int A10SheetsNo = int.Parse(Console.ReadLine());
        int remainder = A10SheetsNo;
       
        do
        {
            sheets.Remove(PreviousPowerOfTwo32BitInt(remainder));
            remainder -= PreviousPowerOfTwo32BitInt(remainder);                       
        } while (remainder != 0);

        foreach (KeyValuePair<int, string> item in sheets)
        {
            Console.WriteLine(item.Value);
        }
    }
}
