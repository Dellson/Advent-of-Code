using System;
using System.Linq;
using static Helpers.CombinatoricsHelpers;

namespace Advent_of_Code_2019
{
    public static class Day_07
    {
        public static void Puzzle()
        {
            int[] phaseValues = new int[] { 0, 1, 2, 3, 4 };
            var combinations = GetPermutations(phaseValues, 5);

            int maxVal = int.MinValue;

            foreach (var inputArray in combinations)
            {
                int[] array = inputArray.ToArray();
                int input = 0;

                for (int i = 0; i < 5; ++i)
                {
                    IntcodeComputerV2 ic = new IntcodeComputerV2("Day-07-input.txt");
                    input = ic.CalculateOutput(array[i], input);
                    maxVal = input > maxVal ? input : maxVal;
                }
            }

            Console.WriteLine($"Puzzle one answer: {maxVal}");
        }
    }
}