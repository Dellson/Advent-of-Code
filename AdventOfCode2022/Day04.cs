using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2022
{
    class Day04
    {
        private static string[] _input;

        public static void Puzzle()
        {
            _input = Program.GetTextInputData("4");
            Console.WriteLine(Puzzle1().Sum());
            Console.WriteLine(Puzzle2().Sum());
        }

        private static IEnumerable<int> Puzzle1()
        {
            foreach (string line in _input)
            {
                var (a1, a2, b1, b2) = ParseLine(line);                
                yield return ((a1 >= b1 && a2 <= b2) ||
                    (b1 >= a1 && b2 <= a2)) ? 1 : 0;
            }
        }

        private static IEnumerable<int> Puzzle2()
        {
            foreach (string line in _input)
            {
                var (a1, a2, b1, b2) = ParseLine(line);
                yield return (a2 >= b1 && (a1 <= b2)) ? 1 : 0;
            }
        }
        private static (int a1, int a2, int b1, int b2) ParseLine(string line)
        {
            MatchCollection matches = Regex.Matches(line, @"\d+");
            return (Convert.ToInt32(matches[0].Value), Convert.ToInt32(matches[1].Value), Convert.ToInt32(matches[2].Value), Convert.ToInt32(matches[3].Value));
        }
    }
}
