﻿using System;

namespace Advent_of_Code_2019
{
    class Day_05
    {
        public static void Puzzle()
        {
            IntcodeComputerV2 ic = new IntcodeComputerV2("Day-05-input.txt");
            Console.WriteLine($"Puzzle one answer: {ic.CalculateOutput(1)}");

            IntcodeComputerV2 ic2 = new IntcodeComputerV2("Day-05-input.txt");
            Console.WriteLine($"Puzzle two answer: {ic2.CalculateOutput(5)}");
        }
    }
}