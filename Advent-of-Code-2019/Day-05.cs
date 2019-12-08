using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2019
{
    class Day_05
    {
        public static void Puzzle()
        {
            var list =
                File.ReadAllLines(Program.InputFolderPath + "Day-05-input.txt")[0];

            var inputInstructions = Regex.Matches(list, @"-?\d+")
                .Cast<Match>()
                .Select(number => Convert.ToInt32(number.Value))
                .ToArray();

            int[] copiedInstructions = new int[inputInstructions.Length];
            IntcodeComputer ic = new IntcodeComputer();
            
            inputInstructions.CopyTo(copiedInstructions, 0);
            var input_1 = copiedInstructions.ToList();
            Console.WriteLine($"Puzzle one answer {ic.CalculateOutput(ref input_1, 1)}");

            inputInstructions.CopyTo(copiedInstructions, 0);
            var input_2 = copiedInstructions.ToList();
            Console.WriteLine($"Puzzle two answer {ic.CalculateOutput(ref input_2, 5)}");
        }
    }
}