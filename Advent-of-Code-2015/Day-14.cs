using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2015
{
    class Day_14
    {
        private static string[] _input = System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-14-input.txt");
        private static List<Tuple<int, int, int>> _reindeers = new List<Tuple<int, int, int>>();

        static Day_14()
        {
            foreach (var line in _input)
            {
                var matches = Regex.Matches(line, @"\d+");
                _reindeers.Add(new Tuple<int, int, int>(
                    Convert.ToInt32(matches[0].Value),
                    Convert.ToInt32(matches[1].Value),
                    Convert.ToInt32(matches[2].Value)));
            }
        }

        public static void Puzzle()
        {
            //_reindeers.
            //Console.WriteLine(GetReindeerDist(_reindeers[0], 1000));
        }

        public static int GetReindeerDist(Tuple<int, int, int> reindeer, int time)
        {

            int t = 0;
            int distance = 0;

            while (t < time)
            {
                distance += reindeer.Item1 * reindeer.Item2;
                t += reindeer.Item2 + reindeer.Item3;
            }

            if (t - reindeer.Item3 > time)
            {
                t -= reindeer.Item3;

                t -= time;
                distance -= (t * reindeer.Item1);
            }

            return distance;
        }
    }
}
