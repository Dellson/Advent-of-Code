using System;
using System.IO;
using System.Linq;

namespace Advent_of_Code_2019
{
    class Day_01
    {
        public static void Puzzle()
        {
            var listOfMasses = 
                File.ReadAllLines(Program.InputFolderPath + "Day-01-input.txt")
                .ToList()
                .ConvertAll(Convert.ToInt32);

            int puzzleOneAnswer = listOfMasses.Select(mass => PuzzleOneCalculator(mass)).Sum();
            int puzzleTwoAnswer = listOfMasses.Select(mass => PuzzleTwoCalculator(mass)).Sum();

            Console.WriteLine($"Puzzle one answer: {puzzleOneAnswer}");
            Console.WriteLine($"Puzzle two answer: {puzzleTwoAnswer}");
        }

        private static int PuzzleOneCalculator(int mass) => (mass / 3) - 2;

        private static int PuzzleTwoCalculator(int mass)
        {
            int fuelMass = PuzzleOneCalculator(mass);

            if (fuelMass > 0)
                return fuelMass + PuzzleTwoCalculator(fuelMass);
            else
                return 0;
        }
    }
}