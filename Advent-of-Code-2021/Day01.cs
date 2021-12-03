using System;
using System.Collections.Generic;

namespace AdventOfCode2021
{
    class Day01
    {
        static List<int> _input;

        public static void Puzzle()
        {
            _input = Program.GetNumberInputData("1");

            Puzzle1();
            Puzzle2();
        }

        private static void Puzzle1()
        {
            int count = 0;

            for (int i = 0; i < _input.Count - 1; i++)
            {
                if (_input[i + 1] > _input[i]) count++;
            }

            Console.WriteLine($"Puzzle 1 answer: {count}");
        }

        private static void Puzzle2()
        {
            int count = 0;
            int previousWindow = _input[0] + _input[1] + _input[2];

            for (int i = 1; i < _input.Count - 2; i++)
            {
                int currentWindow = _input[i] + _input[i + 1] + _input[i + 2];
                if (currentWindow > previousWindow) count++;
                previousWindow = currentWindow;
            }

            Console.WriteLine($"Puzzle 2 answer: {count}");
        }
    }
}