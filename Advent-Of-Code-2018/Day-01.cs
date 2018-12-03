using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2018
{
    class Day_01
    {
        private static int[] _input;

        static Day_01()
        {
            string[] rawInput = System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-01-input.txt");
            _input = new int[rawInput.Length];

            for (int i = 0; i < rawInput.Length; i++)
                _input[i] = Convert.ToInt32(Regex.Match(rawInput[i], @"-?\d+").Value);
        }

        public static void Puzzle()
        {
            int sum = 0;
            var collection = new HashSet<int>();

            for (int i = 0; ; i++)
            {
                for (int j = 0; j < _input.Length; j++)
                {
                    sum += _input[j];
                    if (collection.Contains(sum))
                    {
                        Console.WriteLine($"Puzzle two answer: {sum}");
                        return;
                    }
                    collection.Add(sum);
                }
                if (i == 0)
                    Console.WriteLine($"Puzzle one answer: {sum}");
            }
        }
    }
}