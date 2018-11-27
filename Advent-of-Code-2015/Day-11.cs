using System;
using System.Linq;
using System.Text;

namespace Advent_of_Code_2015
{
    class Day_11
    {
        public static void Challenge()
        {
            string current = "cqjxjnds";
            //string current = "cqjxxyzz";

            do { current = IncrementString(current); }
            while (!(VerifyReq1(current) && VerifyReq2(current) && VerifyReq3(current)));
                
            Console.WriteLine(current);
        }

        private static string IncrementString(string current)
        {
            StringBuilder temp = new StringBuilder(current);
                
            for (int i = current.Length - 1; i >= 0; i--)
            {
                char c = Convert.ToChar(current[i] + 1);

                if (c <= 122)
                {
                    temp[i] = c;
                    break;
                }
                if (c == 123)
                    temp[i] = 'a';
            }

            return temp.ToString();
        }

        private static bool VerifyReq1(string s)
        {
            for (int i = 0; i < s.Length - 2; i++)
                if (s[i + 0] == s[i + 1] - 1 && s[i + 1] == s[i + 2] - 1)
                    return true;
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

            for (int i = 0; i < s.Length - 1; i++)
            {
                if (firstLetter != ' ' && s[i] != firstLetter && s[i] == s[i + 1])
                    return true;
                if (s[i] == s[i + 1])
                    firstLetter = s[i++];
            }
            return false;
        }
    }
}
