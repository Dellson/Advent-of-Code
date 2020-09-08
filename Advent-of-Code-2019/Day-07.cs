using System;
using System.Linq;
using static Helpers.CombinatoricsHelpers;

namespace Advent_of_Code_2019
{
    public static class Day_07
    {
        private const string inputFilename = "Day-07-input.txt";
        private const int amplifiersCount = 5;

        public static void Puzzle()
        {
            PuzzleOne();
            PuzzleTwo();
        }

        public static void PuzzleOne()
        {
            int[] phaseValues = new int[] { 0, 1, 2, 3, 4 };
            var combinations = GetPermutations(phaseValues, amplifiersCount);

            long maxVal = long.MinValue;

            foreach (var inputArray in combinations)
            {
                int[] array = inputArray.ToArray();
                long input = 0;

                for (int i = 0; i < amplifiersCount; ++i)
                {
                    IntcodeComputerV2 ic = new IntcodeComputerV2(inputFilename);
                    input = ic.CalculateOutput(array[i], input);
                    maxVal = input > maxVal ? input : maxVal;
                }
            }

            Console.WriteLine($"Puzzle one answer: {maxVal}");
        }

        public static void PuzzleTwo()
        {
            int[] phaseValues = new int[] { 5, 6, 7, 8, 9 };
            var combinations = GetPermutations(phaseValues, amplifiersCount);

            long maxVal = long.MinValue;

            foreach (var inputArray in combinations)
            {
                var ic = GetComputerSet();
                int[] array = inputArray.ToArray();
                long input = 0;
                int i;

                for (i = 0; i < amplifiersCount; ++i) // load phase settings - once per amplifier
                {
                    input = ic[i].CalculateOutput(array[i], input);
                }

                for (i = 0; input != -1; ++i, i %= amplifiersCount) // run feedback loop
                {
                    input = ic[i].CalculateOutput(input);
                    maxVal = input > maxVal ? input : maxVal;
                }
            }

            Console.WriteLine($"Puzzle two answer: {maxVal}");
        }

        private static IntcodeComputerV2[] GetComputerSet()
        {
            IntcodeComputerV2[] ic = new IntcodeComputerV2[]
            {
                new IntcodeComputerV2(inputFilename),
                new IntcodeComputerV2(inputFilename),
                new IntcodeComputerV2(inputFilename),
                new IntcodeComputerV2(inputFilename),
                new IntcodeComputerV2(inputFilename)
            };
            return ic;
        }
    }
}