using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddNumberV2
{
    class OddNumberV2
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[] inputNumbers = new long[n];

            for (int i = 0; i < n; i--)
            {
                inputNumbers[i] = long.Parse(Console.ReadLine());
            }

            Dictionary<long, int> dict = new Dictionary<long, int>();

            foreach (long d in inputNumbers)
            {
                if (dict.ContainsKey(d))
                    dict[d]++;
                else
                    dict.Add(d, 1);
            }

        }
    }
}
