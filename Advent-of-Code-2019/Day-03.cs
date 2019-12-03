using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2019
{
    class Day_03
    {
        static Dictionary<(int x, int y), int> usedPositionsPipeline1 = new Dictionary<(int x, int y), int>();
        static Dictionary<(int x, int y), int> usedPositionsPipeline2 = new Dictionary<(int x, int y), int>();

        public static void Puzzle()
        {
            var list = File.ReadAllLines(Program.InputFolderPath + "Day-03-input.txt");

            GeneratePipeline(list[0], usedPositionsPipeline1);
            GeneratePipeline(list[1], usedPositionsPipeline2);

            var intersections = usedPositionsPipeline1.Keys.Intersect(usedPositionsPipeline2.Keys);

            var puzzleOneAnswer = intersections
                .Select(d => Math.Abs(d.x) + Math.Abs(d.y))
                .Min();
            var puzzleTwoAnswer = intersections
                .Select(key => usedPositionsPipeline1[key] + usedPositionsPipeline2[key])
                .Min();

            Console.WriteLine($"Puzzle one answer: {puzzleOneAnswer}");
            Console.WriteLine($"Puzzle two answer: {puzzleTwoAnswer}");
        }

        static private void GeneratePipeline(string list, Dictionary<(int x, int y), int> pipeline)
        {
            int number;
            int steps = 0;
            (int x, int y) = (0, 0);

            foreach (Match element in Regex.Matches(list, @"(L|R|U|D)\d+"))
            {
                number = Convert.ToInt32(Regex.Match(element.Value, @"\d+").Value);

                switch (element.Value[0])
                {
                    case 'L':
                        GenerateLine(-1, ref x);
                        break;
                    case 'R':
                        GenerateLine(1, ref x);
                        break;
                    case 'D':
                        GenerateLine(-1, ref y);
                        break;
                    case 'U':
                        GenerateLine(1, ref y);
                        break;
                    default:
                        break;
                }
            }

            void GenerateLine(int sign, ref int position)
            {
                for (int i = 1; i <= number; i++)
                {
                    steps++;
                    position += sign;
                    
                    if (!pipeline.ContainsKey((x, y)))
                        pipeline.Add((x, y), steps);
                }
            }
        }
    }
}