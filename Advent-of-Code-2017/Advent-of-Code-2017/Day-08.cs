using static System.Convert;
using System.Collections.Generic;
using System.Linq;

namespace Advent_of_Code_2017
{
    class Day_08
    {
        public static void Puzzle()
        {
            List<string[]> input = new List<string[]>();
            Dictionary<string, int> regs = new Dictionary<string, int>();
            System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-08-input.txt").ToList().
                ForEach(line => input.Add((line.Split(' '))));

            int max = 0;
            foreach (var line in input)
            {
                if (!regs.ContainsKey(line[0])) regs.Add(line[0], 0);
                if (!regs.ContainsKey(line[4])) regs.Add(line[4], 0);

                int currentMax = regs.Max(reg => reg.Value);
                max = (currentMax > max ? currentMax : max);

                if  (line[5] == ">" && regs[line[4]] > ToInt32(line[6]) ||
                    (line[5] == "<" && regs[line[4]] < ToInt32(line[6])) ||
                    (line[5] == ">=" && regs[line[4]] >= ToInt32(line[6])) ||
                    (line[5] == "<=" && regs[line[4]] <= ToInt32(line[6])) ||
                    (line[5] == "==" && regs[line[4]] == ToInt32(line[6])) ||
                    (line[5] == "!=" && regs[line[4]] != ToInt32(line[6])))
                    regs[line[0]] += (line[1] == "dec" ? -1 : 1) * ToInt32(ToInt32(line[2]));
            }
            System.Console.WriteLine("Part one: " + regs.Max(reg => reg.Value));
            System.Console.WriteLine("Part two: " + max);
        }
    }
}