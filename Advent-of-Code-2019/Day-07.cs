using System;
using System.Linq;
using static Helpers.CombinatoricsHelpers;

namespace Advent_of_Code_2019
{
    public static class Day_07
    {
        public static void Puzzle()
        {
            //PuzzleOne();
            PuzzleTwo();
        }

        public static void PuzzleOne()
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

        public static void PuzzleTwo()
        {
            int[] phaseValues = new int[] { 5, 6, 7, 8, 9 };
            var combinations = GetPermutations(phaseValues, 5);

            int maxVal = int.MinValue;

            foreach (var inputArray in combinations)
            {
                var ic = GetComputerSet();
                //int[] array = inputArray.ToArray();
                int[] array = new int[] { 9, 7, 8, 5, 6 };
                int input = 0;
                int i = 0;
                int lastOutput = int.MinValue;
                int tOutput = int.MinValue;

                int counter = 0;

                try
                {
                    while (true)
                    {
                        if (counter < 5)
                        {
                            input = ic[i].CalculateOutput(array[i], input);
                        }
                        else
                        {
                            input = ic[i].CalculateOutput(input);
                        }
                        counter++;

                        //if (input < tOutput)
                        //    break;
                        //else
                        //    tOutput = input;

                        //if (i == 4)
                        //{
                        //    lastOutput = input;
                        //}

                        maxVal = input > maxVal ? input : maxVal;

                        i++;
                        i %= 5;
                    }
                }
                catch (ArgumentException ex)
                {

                }
                

                maxVal = input > maxVal ? input : maxVal;
                break;
            }

            Console.WriteLine($"Puzzle two answer: {maxVal}");
        }

        private static IntcodeComputerV2[] GetComputerSet()
        {
            IntcodeComputerV2[] ic = new IntcodeComputerV2[]
            {
                new IntcodeComputerV2("Day-07-input.txt"),
                new IntcodeComputerV2("Day-07-input.txt"),
                new IntcodeComputerV2("Day-07-input.txt"),
                new IntcodeComputerV2("Day-07-input.txt"),
                new IntcodeComputerV2("Day-07-input.txt")
            };
            return ic;
        }
    }
}