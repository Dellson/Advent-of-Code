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
            int min = 123257;
            int max = 647015;
            int counter = 0;

            int[] minT = new int[] { 1, 2, 3, 2, 5, 7 };
            int[] maxT = new int[] { 6, 4, 7, 0, 1, 5 };

            for (int i = 123257; i <= 647015; i++)
            {
                string converted = i.ToString();
                var unsorted = converted.Select(digit => int.Parse(digit.ToString())).ToList();
                var sorted = new List<int>(unsorted);
                sorted.Sort();

                if (Analyze(unsorted, sorted))
                {
                    //unsorted.ForEach(e => Console.Write(e + ", "));
                    //Console.Write("\t\t");
                    //sorted.ForEach(e => Console.Write(e + ", "));
                    //Console.WriteLine();
                    counter++;
                }
            }

            //Console.WriteLine(647015 - 123257);
            Console.WriteLine(counter);

            var puzzleOneAnswer = counter;
            var puzzleTwoAnswer = "Null pointer exception: answer not found";

            Console.WriteLine($"Puzzle one answer: {puzzleOneAnswer}");
            Console.WriteLine($"Puzzle two answer: {puzzleTwoAnswer}");
        }

        private static bool Analyze(List<int> unsorted, List<int> sorted)
        {
            bool areAllConditionsMet = false;

            if (unsorted.SequenceEqual(sorted)
                    && sorted.Distinct().Count() != sorted.Count())
            {
                List<int> digitsCount = new List<int>();

                foreach (var digit in sorted)
                {
                    digitsCount.Add(sorted.FindAll(d => d == digit).Count);
                }

                if (digitsCount.Contains(2))
                {
                    areAllConditionsMet = true;
                }
            }

            return areAllConditionsMet;
        }
    }
}