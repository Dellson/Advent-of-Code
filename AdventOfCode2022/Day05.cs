using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2022
{
    class Day05
    {
        private static List<Stack<char>> stacks;
        private static List<(int quantity, int from, int to)> commands;

        public static void Puzzle()
        {
            Puzzle1();
            Puzzle2();
        }

        private static void Puzzle1()
        {
            ParseInput();

            foreach (var (quantity, from, to) in commands)
            {
                for (int move = 0; move < quantity; move++)
                {
                    stacks[to - 1].Push(stacks[from - 1].Pop());
                }
            }

            Console.WriteLine(new string(stacks.Select(s => s.Peek()).ToArray()));
        }

        private static void Puzzle2()
        {
            ParseInput();

            foreach (var (quantity, from, to) in commands)
            {
                var temp = new List<char>();

                for (int move = 0; move < quantity; move++)
                {
                    temp.Add(stacks[from - 1].Pop());
                }

                temp.Reverse();
                temp.ForEach(crate => stacks[to - 1].Push(crate));
            }

            Console.WriteLine(new string(stacks.Select(s => s.Peek()).ToArray()));
        }

        private static void ParseInput()
        {
            string[]  input = Program.GetTextInputData("5");
            stacks = new List<Stack<char>>();
            commands = new List<(int quantity, int from, int to)>();
            var stackIds = input.SkipWhile(i => i.Contains('[')).ToList().First();
            var stacksQuantity = Regex.Matches(stackIds, @"\d+").Count;
            var indexOfStacksIds = input.ToList().IndexOf(stackIds);

            for (int i = 0; i < stacksQuantity; i++)
            {
                stacks.Add(new Stack<char>());

                for (int j = indexOfStacksIds - 1; j >= 0; j--)
                {
                    var value = input[j][i * 4 + 1];
                    if (value != ' ') stacks[i].Push(value);
                }
            }

            for (int i = indexOfStacksIds + 2; i < input.Length; i++)
            {
                var command = Regex.Matches(input[i], @"\d+").Select(m => Convert.ToInt32(m.Value)).ToList();
                commands.Add((command[0], command[1], command[2]));
            }
        }
    }
}
