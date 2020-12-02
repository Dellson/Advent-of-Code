using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent_of_Code_2018
{
    class Day_06
    {
        private static string _rawInput = System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-05-input.txt")[0];
        private static char[] input;

        static Day_06()
        {
            input = new char[_rawInput.Length];

            for (int i = 0; i < _rawInput.Length; i++)
                input[i] = _rawInput[i];
        }

        public static void Puzzle()
        {
            Console.WriteLine("Puzzle one answer: " + PuzzleOne());
            PuzzleTwo();
        }

        private static int PuzzleOne()
        {
            int count = 0;
            int nextcount = 0;

            while (true)
            {
                count = input.Count(c => c != '*');

                for (int i = 0; i < input.Length - 1; i++)
                {
                    if (input[i] == '*')
                        continue;
                    int j = 1;

                    while ((i + j < input.Length) && input[i + j] == '*')
                        j++;
                    if (i + j >= input.Length)
                        break;

                    var x = input[i];
                    var y = input[i+j];

                    if (input[i] == input[i+j] + 32 || input[i] == input[i+j] - 32)
                    {
                        input[i] = '*';
                        input[i+j] = '*';
                    }
                }
                nextcount = input.Count(c => c != '*');

                if (nextcount == count)
                    break;
            }
            return input.Count(c => c != '*');
        }

        private static void PuzzleTwo()
        {
            var polymerVariants = new List<int>();

            for (int p = 65; p <= 90; p++)
            {
                for (int i = 0; i < _rawInput.Length; i++)
                    input[i] = _rawInput[i];

                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == p || input[i] == (p + 32))
                        input[i] = '*';
                }

                polymerVariants.Add(PuzzleOne());
            }
            Console.WriteLine("Puzzle two answer: " + polymerVariants.Min());
        }
    }
}
