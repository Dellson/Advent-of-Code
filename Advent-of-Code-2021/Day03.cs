using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    class Day03
    {
        static readonly List<bool[]> _input = new List<bool[]>();

        public static void Puzzle()
        {
            var std = Program.GetTextInputData("3").ToList();
            foreach (var line in std)
            {
                var binary = new bool[line.Length];

                for (int i = 0; i < line.Length; i++)
                {
                    binary[i] = line[i] == '1';
                }

                _input.Add(binary);
            }

            Puzzle1();
            Puzzle2();
        }

        private static void Puzzle1()
        {
            int lineLength = _input.First().Length;
            var gamma = new bool[lineLength];
            var epsilon = new bool[lineLength];

            for (int i = 0; i < lineLength; i++)
            {
                epsilon[i] = GetMostPopulousAtIndex(_input, i);
                gamma[i] = !epsilon[i];
            }

            Console.WriteLine($"Puzzle 1 answer: {BinaryToDecimalConverter(gamma) * BinaryToDecimalConverter(epsilon)}");
        }

        private static void Puzzle2()
        {
            int lineLength = _input.First().Length;
            var filteredOxygen = new List<bool[]>(_input);
            var filteredScrubber = new List<bool[]>(_input);

            for (int i = 0; i < lineLength; i++)
            {
                var mostPopulousOxygen = GetMostPopulousAtIndex(filteredOxygen, i);
                var mostPopulousScrubber = GetMostPopulousAtIndex(filteredScrubber, i);

                if (filteredOxygen.Count > 1)
                {
                    filteredOxygen.RemoveAll(item => item[i] != mostPopulousOxygen);
                }

                if (filteredScrubber.Count > 1)
                {
                    filteredScrubber.RemoveAll(item => item[i] == mostPopulousScrubber);
                }
            }

            Console.WriteLine($"Puzzle 2 answer: {BinaryToDecimalConverter(filteredOxygen.FirstOrDefault()) * BinaryToDecimalConverter(filteredScrubber.FirstOrDefault())}");
        }

        private static double BinaryToDecimalConverter(bool[] binary)
        {
            double result = 0;

            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i])
                {
                    result += Math.Pow(2, binary.Length - i - 1);
                }
            }

            return result;
        }
    
        private static bool GetMostPopulousAtIndex(List<bool[]> list, int columnIndex)
        {
            int zeroes = 0;

            for (int rowIndex = 0; rowIndex < list.Count; rowIndex++)
            {
                if (!list[rowIndex][columnIndex]) zeroes++;
            }

            return zeroes <= list.Count / 2;            
        }
    }
}