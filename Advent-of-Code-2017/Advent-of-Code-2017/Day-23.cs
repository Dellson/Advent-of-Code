using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent_of_Code_2017
{
    class Day_23
    {
        private static Dictionary<string, int> regs = new Dictionary<string, int>();
        private static List<string[]> input = new List<string[]>();

        static Day_23()
        {
            regs = new Dictionary<string, int> { { "a", 0 }, { "b", 0 }, { "c", 0 }, { "d", 0 }, { "e", 0 }, { "f", 0 }, { "g", 0 }, { "h", 0 } };
            System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-23-input.txt").ToList().
                ForEach(line => input.Add((line.Split(' '))));
        }

        public static void PuzzleOne()
        {
            regs["a"] = 0;
            int count = 0;

            for (int i = 0; i < input.Count; ++i)
            {
                string[] line = input[i];

                if (!int.TryParse(line[2], out int read))
                    read = regs[line[2]];

                if (line[0] == "set")
                    regs[line[1]] = read;
                else if (line[0] == "sub")
                    regs[line[1]] -= read;
                else if (line[0] == "mul")
                {
                    regs[line[1]] *= read;
                    count++;
                }
                else if (line[0] == "jnz")
                {
                    if (!int.TryParse(line[1], out int jump))
                        jump = regs[line[1]];
                    if (jump != 0)
                        i += read - 1;
                }
            }
            Console.WriteLine("Puzzle one answer: " + count);
        }

        public static void PuzzleTwo()
        {
            regs["a"] = 0;
            int h = 0;
            int f = 1;

            for (int b = 108100; b <= 125100; b += 17, f = 1)
            {
                for (int d = 2; d < b && f != 0; ++d)
                    for (int e = 2; d * e <= b && f != 0; ++e)
                        if (d * e == b)
                            f = 0;
                if (f == 0)
                    h++;
            }
            Console.WriteLine("Puzzle two answer: " + h);
        }
    }
}