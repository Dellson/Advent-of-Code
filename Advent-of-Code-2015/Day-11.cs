using System;
using System.Linq;
using System.Text;

namespace Advent_of_Code_2015
{
    class Day_11
    {
        public static void Challenge()
        {
            StringBuilder sb = new StringBuilder("cqjxxyzz");
            
            while (true)
            {
                sb = IncrementString(sb);

                if (VerifyReq1(sb.ToString()) && VerifyReq2(sb.ToString()) && VerifyReq3(sb.ToString()))
                    break;
            }
            Console.WriteLine(sb.ToString());
        }

        private static StringBuilder IncrementString(StringBuilder sb)
        {
                bool isIncremented = false;
                StringBuilder temp = new StringBuilder();
                string current = sb.ToString();
                
                for (int i = current.Length - 1; i >= 0; i--)
                {
                    if (!isIncremented)
                    {
                        char c = Convert.ToChar(current[i] + 1);

                        if (c <= 122)
                        {
                            isIncremented = true;
                            temp.Append(c);
                            continue;
                        }
                        else if (c >= 123)
                        {
                            temp.Append('a');
                        }
                            
                    }
                    else
                        temp.Append(current[i]);
                }

                string s = temp.ToString();
                sb = new StringBuilder();

            

                for (int i = s.Length - 1; i >= 0; i--)
                    sb.Append(s[i]);

            return sb;
        }

        private static bool VerifyReq1(string s)
        {
            for (int i = 0; i < 6; i++)
            {
                if (s[i + 0] == s[i + 1] - 1 && s[i + 1] == s[i + 2] - 1)
                    return true;
            }

            return false;
        }

        private static bool VerifyReq2(string s)
        {
            if (s.Contains("i") || s.Contains("o") || s.Contains("l"))
                return false;
            
            return true;
        }

        private static bool VerifyReq3(string s)
        {
            char firstLetter = ' ';

            for (int i = 0; i < 7; i++)
            {
                if (firstLetter != ' ' && s[i] != firstLetter && s[i] == s[i + 1])
                    return true;

                if (s[i] == s[i + 1])
                {
                    firstLetter = s[i];
                    i++;
                }
            }
            
            return false;
        }
    }
}
