using System;

namespace Advent_of_Code_2019
{
    class Day_02
    {
        public static void Puzzle()
        {
            Console.WriteLine($"Puzzle one answer: {PuzzleOne()}");
            Console.WriteLine($"Puzzle two answer: {PuzzleTwo()}");
        }

        private static long PuzzleOne()
        {
            IntcodeComputerV2 ic = new IntcodeComputerV2("Day-02-input.txt");

            ic.Instructions[1] = 12;
            ic.Instructions[2] = 2;
            ic.CalculateOutput();

            return ic.Instructions[0];
        }

        private static long PuzzleTwo()
        {
            const int minVal = 0;
            const int maxVal = 99;
            const int outputSought = 19690720;

            for (int noun = minVal; noun <= maxVal; ++noun)
            {
                for (int verb = minVal; verb <= maxVal; ++verb)
                {
                    IntcodeComputerV2 ic = new IntcodeComputerV2("Day-02-input.txt");
                    ic.Instructions[1] = noun;
                    ic.Instructions[2] = verb;
                    ic.CalculateOutput();

                    if (ic.Instructions[0] == outputSought)
                        return (noun * 100 + verb);
                }
            }

            return -1;
        }
    }
}