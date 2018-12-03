using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace Advent_of_Code_2015
{
    class Day_12
    {
        private static string _input = System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-12-input.txt")[0];

        public static void Challenge()
        {
            int sum = 0;
            int charsSoFar = 0;
            string[] splitted = _input.Split(new string[] { "red" }, StringSplitOptions.None);
            List<string> intsToRemove = new List<string>();

            for (int i = 0; i < splitted.Length - 1; i++)
            {
                int start = -1;
                int end = -1;
                string s1 = splitted[i];
                string s2 = splitted[i + 1];
                StringBuilder sb = new StringBuilder();

                for (int j = s1.Length - 1; j >= 0; j--)
                {
                    if (s1[j] == '{')
                    {
                        start = j;
                        break;
                    }
                }

                int counter = 0;
                for (int j = 0; j < s2.Length; j++)
                {
                    if (s2[j] == '{')
                        counter++;
                    if (s2[j] == '}')
                        counter--;
                    if (counter < 0)
                    {
                        end = j;
                        break;
                    }
                }

                var sub = _input.Substring(charsSoFar + start, splitted[i].Length - start + end + 4);
                charsSoFar += splitted[i].Length;

                if (splitted[i][splitted[i].Length - 2] == ',')
                    continue;

                var matches2 = Regex.Matches(sub, @"-?\d+");

                foreach (var match in matches2)
                    sum += Convert.ToInt32(match.ToString());
            }
            Console.WriteLine(156366 - sum);
            //Console.WriteLine(15 - sum);
            // 91488 - too low
            // 102840 - too high
        }
    }
}
