using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    class Day02
    {
        static List<(string command, int value)> _input = new List<(string command, int value)>();

        public static void Puzzle()
        {
            var std = Program.GetTextInputData("2").ToList();
            foreach (var line in std)
            {
                var splittedLine = line.Split(' ');
                _input.Add(
                    (splittedLine[0], Convert.ToInt32(splittedLine[1]))
                    );
            }

            Puzzle1();
            Puzzle2();
        }

        private static void Puzzle1()
        {
            int horizontal = 0;
            int depth = 0;

            foreach (var line in _input)
            {
                switch (line.command)
                {
                    case "forward":
                        horizontal += line.value;
                        break;
                    case "up":
                        depth -= line.value;
                        break;
                    case "down":
                        depth += line.value;
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }

            Console.WriteLine($"Puzzle 1 answer: {horizontal * depth}");
        }

        private static void Puzzle2()
        {
            int horizontal = 0;
            int depth = 0;
            int aim = 0;

            foreach (var line in _input)
            {
                switch (line.command)
                {
                    case "forward":
                        horizontal += line.value;
                        depth += (aim * line.value);
                        break;
                    case "up":
                        aim -= line.value;
                        break;
                    case "down":
                        aim += line.value;
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }

            Console.WriteLine($"Puzzle 1 answer: {horizontal * depth}");
        }
    }
}