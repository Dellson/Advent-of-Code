using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Console;

namespace Advent_of_Code_2018
{
    class Day_05
    {
        private static string _rawInput = System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-05-input.txt")[0];
        private static char[] input;

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
            // - 32
            bool isPolymerUnstable = true;
            int count = 0;
            int nextcount = 0;
            int inc = 0;

            while (true)
            {
                count = input.Count(c => c != '*');
                //bool isSkipped = false;
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
                    var y = input[i + j];

                    if (input[i] == input[i + j] + 32 || input[i] == input[i + j] - 32)
                    {
                        //isSkipped = true;
                        input[i] = '*';
                        input[i + j] = '*';
                    }
                }
                nextcount = input.Count(c => c != '*');

                if (nextcount == count)
                {
                    break;
                }
                //if (!isSkipped)
                //    break;
            }
            // 12388 too high
            //Console.WriteLine(new string(input));
            Console.WriteLine(input.Count(c => c != '*'));

            return input.Count(c => c != '*');
        }

        public static void Puzzle()
        {
            var l = new List<int>();
            // - 32
            bool isPolymerUnstable = true;
            int count = 0;
            int nextcount = 0;
            int inc = 0;

            for (int p = 65; p <= 90; p++)
            {
                for (int i = 0; i < _rawInput.Length; i++)
                    input[i] = _rawInput[i];

                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == p || input[i] == (p + 32))
                        input[i] = '*';
                }


                l.Add(PuzzleOne());
            }
            //Console.WriteLine(new string(input));
            Console.WriteLine("RERSULT " + l.Min());
        }
    }
}
