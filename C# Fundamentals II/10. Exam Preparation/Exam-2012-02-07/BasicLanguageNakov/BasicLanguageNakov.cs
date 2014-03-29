using System;
using System.Diagnostics;
using System.Text;

class BasicLanguageNakov
{
    static StringBuilder result = new StringBuilder();
    

    static void Main()
    {
        StringBuilder buffer = new StringBuilder();
        bool inBrackets = false;

        while (true)
        {
            int nextConsoleToken = Console.Read();
            if (nextConsoleToken == -1)
            {
                break;
            }

            char nextChar = (char)nextConsoleToken;
            if (nextChar == '(')
            {
                inBrackets = true;
            }
            if (nextChar == ')')
            {
                inBrackets = false;
            }
            if (nextChar == ';' && !inBrackets)
            {
                string statement = buffer.ToString();
                if (ProcessStatement(statement))
                {
                    break;
                }
                buffer.Clear();
            }
            else
            {
                buffer.Append(nextChar);
            }            
        }

        Console.WriteLine(result);
    }

   private static bool ProcessStatement(string statement)
   {
        long count = 1;
        string[] commands = statement.Split(')');
        for (int i = 0; i < commands.Length; i++)
        {
            string cmd = commands[i];
            cmd = cmd.TrimStart();
            if (cmd.StartsWith("EXIT!"))
            {
                return true;
            }
            else if (cmd.StartsWith("PRINT"))
            {
                int startIndex = cmd.IndexOf('(') + 1;
                string content = cmd.Substring(startIndex);
                if (content.Length > 0)
                {
                    for (int c = 0; c < count; c++)
                    {
                        result.Append(content);
                    }
                }
            }            
            else if (cmd.StartsWith("FOR"))
            {
                int startIndex = cmd.IndexOf('(') + 1;
                int commaIndex = cmd.IndexOf(',');
                if (commaIndex ==-1)
                {
                    string forCountStr = cmd.Substring(startIndex);
                    int forCount = int.Parse(forCountStr);
                    count *= forCount;
                }
                else
                {
                    string forStartCountStr = cmd.Substring(startIndex, commaIndex - startIndex);
                    int forStartCount = int.Parse(forStartCountStr);
                    string forEndCountStr = cmd.Substring(commaIndex + 1);
                    int forEndCount = int.Parse(forEndCountStr);
                    int forCount = forEndCount - forStartCount + 1;
                    count *= forCount;
                }
            }
        }
        return false;
   }
}

