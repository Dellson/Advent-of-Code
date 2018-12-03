using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2017
{
    class Day_06
    {
        private static string rawInput = System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-06-input.txt")[0];
        private static List<int> input = new List<int>();

        static Day_06()
        {
            var matches = Regex.Matches(rawInput, @"\d+");

            for (int j = 0; j < matches.Count; ++j)
                input.Add(Convert.ToInt32(Convert.ToInt32(matches[j].Value)));
        }

        public static void Puzzle()
        {
            List<string> s = new List<string>();

            int i = 0;
            int steps = 0;

            while (!s.Contains(string.Join(" ", input)))
            {
                s.Add(string.Join(" ", input));
                i = input.IndexOf(input.Max());
                int buffer = input[i];
                input[i] = 0;

                while (buffer > 0)
                {
                    i = (i == input.Count - 1) ? 0 : i + 1;
                    input[i]++;
                    buffer--;
                }
                steps++;
            }

            Console.WriteLine("Steps: " + steps);
            Console.WriteLine("Diff:  " + (steps - s.IndexOf(string.Join(" ", input))));
        }
    }
}
