using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    class Day_06
    {
        private static string[] input = System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-06-input.txt");
        const int size = 1000;

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

            foreach (string line in input)
            {
                var matches = Regex.Matches(line, @"\d+");

                for (int i = Convert.ToInt32(matches[0].Value); i <= Convert.ToInt32(matches[2].Value); ++i)
                {
                    for (int j = Convert.ToInt32(matches[1].Value); j <= Convert.ToInt32(matches[3].Value); ++j)
                    {
                        if (line.Contains("toggle"))
                            lightsArray[i, j] = !lightsArray[i, j];
                        if (line.Contains("turn on"))
                            lightsArray[i, j] = true;
                        if (line.Contains("turn off"))
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

            foreach (string s in input)
            {
                var matches = Regex.Matches(s, @"\d+");

                for (int i = Convert.ToInt32(matches[0].Value); i <= Convert.ToInt32(matches[2].Value); ++i)
                {
                    for (int j = Convert.ToInt32(matches[1].Value); j <= Convert.ToInt32(matches[3].Value); ++j)
                    {
                        if (s.Contains("toggle"))
                            lightsArray[i,j] += 2;
                        if (s.Contains("turn on"))
                            lightsArray[i,j] += 1;
                        if (s.Contains("turn off"))
                            lightsArray[i,j] -= (lightsArray[i,j] == 0 ? 0 : 1);
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
