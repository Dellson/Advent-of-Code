using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2015
{
    class Day_06
    {
        private static string[] input = System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-06-input.txt");
        private static List<Tuple<int, int, int, int, int>> commands = new List<Tuple<int, int, int, int, int>>();
        const int size = 1000;

        static Day_06()
        {
            foreach (string line in input)
            {
                int mode = 0;
                var matches = Regex.Matches(line, @"\d+");

                if (line.Contains("turn on"))
                    mode = 1;
                if (line.Contains("turn off"))
                    mode = -1;

                commands.Add(new Tuple<int, int, int, int, int>(
                    mode,
                    Convert.ToInt32(matches[0].Value),
                    Convert.ToInt32(matches[1].Value),
                    Convert.ToInt32(matches[2].Value),
                    Convert.ToInt32(matches[3].Value)));
            }
        }

        public static void BothStars()
        {
            PuzzleOne();
            PuzzleTwo();
        }

        private static void PuzzleOne()
        {
            bool[,] lightsArray = new bool[size, size];

            for (int i = 0; i < size; ++i)
                for (int j = 0; j < size; ++j)
                    lightsArray[i, j] = false;

            foreach (var line in commands)
            {
                for (int i = line.Item2; i <= line.Item4; ++i)
                {
                    for (int j = line.Item3; j <= line.Item5; ++j)
                    {
                        if (line.Item1 == 0)
                            lightsArray[i, j] = !lightsArray[i, j];
                        if (line.Item1 == 1)
                            lightsArray[i, j] = true;
                        if (line.Item1 == -1)
                            lightsArray[i, j] = false;
                    }
                }
            }

            int count = 0;

            for (int i = 0; i < size; ++i)
                for (int j = 0; j < size; ++j)
                    count += (lightsArray[i, j] ? 1 : 0);

            Console.WriteLine("Puzzle one answer: " + count);
        }

        private static void PuzzleTwo()
        {
            int[,] lightsArray = new int[size, size];

            for (int i = 0; i < size; ++i)
                for (int j = 0; j < size; ++j)
                    lightsArray[i,j] = 0;

            foreach (var line in commands)
            {
                for (int i = line.Item2; i <= line.Item4; ++i)
                {
                    for (int j = line.Item3; j <= line.Item5; ++j)
                    {
                        if (line.Item1 == 0)
                            lightsArray[i, j] += 2;
                        if (line.Item1 == 1)
                            lightsArray[i, j] += 1;
                        if (line.Item1 == -1)
                            lightsArray[i, j] -= (lightsArray[i, j] == 0 ? 0 : 1);
                    }
                }
            }

            int count = 0;
            
            for (int i = 0; i < size; ++i)
                for (int j = 0; j < size; ++j)
                    count += lightsArray[i, j];

            Console.WriteLine("Puzzle two answer: " + count);
        }
    }
}
