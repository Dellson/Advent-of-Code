using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2019
{
    class Day_04
    {
        public static void Puzzle()
        {
            var input = File.ReadAllLines(Program.InputFolderPath + "Day-04-input.txt");

            var puzzleOneAnswer = "PUZZLE ONE ANSWER";
            var puzzleTwoAnswer = "PUZZLE TWO ANSWER";

            Console.WriteLine($"Puzzle one answer: {puzzleOneAnswer}");
            Console.WriteLine($"Puzzle two answer: {puzzleTwoAnswer}");
        }
    }
}