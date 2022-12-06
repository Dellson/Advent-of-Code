using System;
using System.Linq;

namespace AdventOfCode2022
{
    class Day06
    {
        private static string[] _input;

        public static void Puzzle()
        {
            _input = Program.GetTextInputData("6");
            Puzzle(4);
            Puzzle(14);
        }

        private static void Puzzle(int distinctCount)
        {
            var input = _input[0].ToList();

            for (int i = distinctCount - 1; i < input.Count; i++)
            {
                if (input.GetRange(i - (distinctCount - 1), distinctCount).Distinct().Count() == distinctCount)
                {
                    Console.WriteLine($"Marker has been found at index {i + 1} for {distinctCount} distinct characters.");
                    break;
                }
            }
        }
    }
}
