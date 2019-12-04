using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent_of_Code_2019
{
    class Day_04
    {
        public static void Puzzle()
        {
            var puzzleOneAnswer = 0;
            var puzzleTwoAnswer = 0;

            for (int i = 123257; i <= 647015; i++)
            {
                var converted = i.ToString();
                var unsorted = converted.Select(digit => int.Parse(digit.ToString())).ToList();
                var sorted = new List<int>(unsorted);
                sorted.Sort();

                if (unsorted.SequenceEqual(sorted) && sorted.Distinct().Count() != sorted.Count())
                {
                    puzzleOneAnswer++;
                    
                    if (sorted.GroupBy(g => g).ToList().Exists(g => g.Count() == 2))
                        puzzleTwoAnswer++;
                }
            }            

            Console.WriteLine($"Puzzle one answer: {puzzleOneAnswer}");
            Console.WriteLine($"Puzzle two answer: {puzzleTwoAnswer}");
        }
    }
}