using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using static System.Console;

namespace Advent_of_Code_2018
{
    class Day_05
    {
        private static string _rawInput = System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-05-input.txt")[0];
        private static char[] input;
        static Stopwatch sw = new Stopwatch();

        static Day_05()
        {
            input = new char[_rawInput.Length];

            for (int i = 0; i < _rawInput.Length; i++)
            {
                input[i] = _rawInput[i];
            }
        }

        public static int PuzzleOne()
        {
            int count = input.Length;
            int nextcount = 0;

            while (true)
            {
                nextcount = count;
                count = input.Length;

                for (int i = 0; i < input.Length - 1; i++)
                {
                    if (input[i] == '*')
                    {
                        count--;
                        continue;
                    }
                        
                    int j = 1;
                    
                    while ((i + j < input.Length - 1) && input[i + j] == '*')
                        j++;                        

                    if (Math.Abs(input[i] - input[i+j]) == 32)
                    {
                        input[i] = '*';
                        input[i + j] = '*';
                        count -= 2;
                    }
                }
                if (nextcount == count)
                    break;
            }
            WriteLine(count);
            return count;
        }

        public static void Puzzle()
        {
            sw.Start();
            var l = new List<int>();
            char[] inputArray = _rawInput.ToCharArray();

            for (int p = 65; p <= 90; p++)
            {
                input = _rawInput.ToCharArray();

                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == p || input[i] == (p + 32))
                        input[i] = '*';
                }

                l.Add(PuzzleOne());
            }
            WriteLine("result " + l.Min());
            sw.Stop();
            WriteLine(sw.Elapsed);
        }
    }
}
