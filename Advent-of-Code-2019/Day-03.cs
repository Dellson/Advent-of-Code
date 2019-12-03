using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2019
{
    class Day_03
    {
        static (int x, int y) currentPos = (0, 0);
        static List<(int x, int y)> usedPositionsPipeline1 = new List<(int x, int y)>();
        static List<(int x, int y)> usedPositionsPipeline2 = new List<(int x, int y)>();
        
        public static void Puzzle()
        {
            var list = File.ReadAllLines(Program.InputFolderPath + "Day-03-input.txt");

            GeneratePipeline(list[0], usedPositionsPipeline1);
            currentPos = (0,0);
            GeneratePipeline(list[1], usedPositionsPipeline2);

            var CommonList = usedPositionsPipeline1.Intersect(usedPositionsPipeline2);

            var flattened = CommonList.Select(d => Math.Abs(d.x) + Math.Abs(d.y)).ToList();
            Console.WriteLine(flattened.Min());
        }

        static private void GeneratePipeline(string list, List<(int, int)> pipeline)
        {
            int number;

            foreach (Match element in Regex.Matches(list, @"(L|R|U|D)\d+"))
            {
                number = Convert.ToInt32(Regex.Match(element.Value, @"\d+").Value);

                switch (element.Value[0])
                {
                    case 'L':
                        GenerateLine(-1, ref currentPos.x);
                        break;
                    case 'R':
                        GenerateLine(1, ref currentPos.x);
                        break;
                    case 'D':
                        GenerateLine(-1, ref currentPos.y);
                        break;
                    case 'U':
                        GenerateLine(1, ref currentPos.y);
                        break;
                    default:
                        break;
                }
            }

            void GenerateLine(int sign, ref int position)
            {
                for (int i = 1; i <= number; i++)
                {
                    position += sign;
                    pipeline.Add((currentPos.x, currentPos.y));
                }
            }
        }
    }
}