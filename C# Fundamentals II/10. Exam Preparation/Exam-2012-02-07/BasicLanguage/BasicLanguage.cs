using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicLanguage
{
    class BasicLanguage
    {
        static void Main(string[] args)
        {
            StringBuilder inputCode = new StringBuilder();

            while (true)
            {
                string line = Console.ReadLine();
                inputCode.Append(line);
                if (line.EndsWith("EXIT;"))
                {
                    break;
                }
            }

            string code = inputCode.ToString();


            string textToBePrinted = "";
            for (int i = 0; i < code.Length; i++)
            {
                char ch = code[i];
                if (ch == 'P')
                {
                    int outputTextStartIndex = code.IndexOf('(', i) + 1;
                    int outputTextEndIndex = code.IndexOf(')', i);
                    textToBePrinted = code.Substring(outputTextStartIndex, outputTextEndIndex - outputTextStartIndex);

                    i = outputTextEndIndex + 1;
                }
                else if (ch == 'F')
                {

                    
                }
            }

            Console.WriteLine(textToBePrinted);
        }
    }
}
