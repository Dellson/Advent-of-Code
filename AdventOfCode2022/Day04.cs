using System;
using System.Collections.Generic;
using System.Linq;

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
            Puzzle2();
        }

        private static IEnumerable<int> Puzzle1()
        {
            foreach (string line in _input)
            {
                var s = ParseLine(line);                
                yield return ((s.a1 >= s.b1 && s.a2 <= s.b2) ||
                    (s.b1 >= s.a1 && s.b2 <= s.a2)) ? 1 : 0;
            }
        }

        private static IEnumerable<int> Puzzle2()
        {
            foreach (string line in _input)
            {
                var s = ParseLine(line);
                yield return (s.a2 >= s.b1 && (s.a1 <= s.b2)) ? 1 : 0;
            }
        }
        private static (int a1, int a2, int b1, int b2) ParseLine(string line)
        {
            var splitted = line.Split(',');
            var first = splitted[0].Split('-');
            var second = splitted[1].Split('-');
            return (Convert.ToInt32(first[0]), Convert.ToInt32(first[1]), Convert.ToInt32(second[0]), Convert.ToInt32(second[1]));
        }
    }
}
