using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2019
{
    class Day_02
    {
        public static void Puzzle()
        {
            Console.WriteLine($"Puzzle one answer: {PuzzleOne()}");
            Console.WriteLine($"Puzzle one answer: {PuzzleTwo()}");
        }

        private static int PuzzleOne()
        {
            IntcodeComputerV2 intcodeComputer = new IntcodeComputerV2("Day-02-input.txt");

            intcodeComputer.Instructions[1] = 12;   // noun
            intcodeComputer.Instructions[2] = 2;    // verb

            return intcodeComputer.CalculateOutput();
        }

        private static int PuzzleTwo()
        {
            const int minVal = 0;
            const int maxVal = 99;
            const int outputSought = 19690720;

            for (int noun = minVal; noun <= maxVal; ++noun)
            {
                for (int verb = minVal; verb <= maxVal; ++verb)
                {
                    IntcodeComputerV2 intcodeComputer = new IntcodeComputerV2("Day-02-input.txt");
                    intcodeComputer.Instructions[1] = noun;
                    intcodeComputer.Instructions[2] = verb;

                    if (intcodeComputer.CalculateOutput() == outputSought)
                        return (noun * 100 + verb);
                }
            }

            return -1;
        }
    }
}