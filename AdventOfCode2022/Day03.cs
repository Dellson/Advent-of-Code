using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022
{
    class Day03
    {
        static string[] _input;

        // upper: 65 - 90 (27 - 52)
        // lower: 97 - 122 (1 - 26)
        static int GetLetterPriority(char letter) => letter > 96 ? letter - 96 : letter - 38;

        public static void Puzzle()
        {
            _input = Program.GetTextInputData("3");
            Console.WriteLine(Puzzle1().Sum(item => GetLetterPriority(item)));
            Console.WriteLine(Puzzle2().Sum(item => GetLetterPriority(item)));
        }

        private static IEnumerable<char> Puzzle1()
        {
            for (int i = 0; i < _input.Length; i++)
            {
                var len = _input[i].Length / 2;
                var firstCompartment = _input[i].Take(len);
                var secondCompartment = _input[i].TakeLast(len);

                yield return firstCompartment.Intersect(secondCompartment).SingleOrDefault();
            }
        }

        private static IEnumerable<char> Puzzle2()
        {
            for (int i = 0; i < _input.Length; i+=3)
            {
                yield return _input[i].Intersect(_input[i+1]).Intersect(_input[i+2]).SingleOrDefault();
            }
        }
    }
}
