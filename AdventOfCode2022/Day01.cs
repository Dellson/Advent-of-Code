using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022
{
    class Day01
    {
        static string[] _input;

        public static void Puzzle()
        {
            _input = Program.GetTextInputData("1");

            Puzzle(1);
            Puzzle(3);
        }

        private static void Puzzle(int takeCount)
        {
            List<int> elves = new List<int> { 0 };
            foreach (var item in _input)
            {
                if (item == string.Empty)
                    elves.Add(0);
                else
                    elves[^1] += Convert.ToInt32(item);
            }

            Console.WriteLine($"Puzzle answer: {elves.OrderByDescending(num => num).Take(takeCount).Sum()}");
        }
    }
}
