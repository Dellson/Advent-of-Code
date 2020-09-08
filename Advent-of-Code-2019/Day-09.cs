using System;
using System.Linq;
using static Helpers.CombinatoricsHelpers;

namespace Advent_of_Code_2019
{
    public static class Day_09
    {
        private const string inputFilename = "Day-09-input.txt";
        private const int amplifiersCount = 5;

        public static void Puzzle()
        {
            PuzzleOne();
        }

        public static void PuzzleOne()
        {
            IntcodeComputerV2 ic = new IntcodeComputerV2(inputFilename);

            Console.WriteLine($"Puzzle one answer: {ic.CalculateOutput()}");
        }
    }
}