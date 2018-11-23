using System.Linq;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2015
{
    class Day_09
    {
        private static readonly string[] _input = System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-09-input.txt");
        static List<Tuple<string, string, int>> _connections = new List<Tuple<string, string, int>>();

        public static void BothStars()
        {
            List<string> cities = new List<string>();

            foreach (string str in _input)
            {
                var cityA = Regex.Matches(str, @"\w+")[0].Value;
                var cityB = Regex.Matches(str, @"\w+")[2].Value;
                var distance = Convert.ToInt32(Regex.Matches(str, @"\d+")[0].Value);

                if (!cities.Contains(cityA)) cities.Add(cityA);
                if (!cities.Contains(cityB)) cities.Add(cityB);

                _connections.Add(new Tuple<string, string, int>(cityA, cityB, distance));
                _connections.Add(new Tuple<string, string, int>(cityB, cityA, distance));
            }

            List<int> distances = new List<int>();

            foreach (var route in GetPermutations(cities, cities.Count).Select(p => p.ToList()).ToList())
                distances.Add(Enumerable.Range(1, route.Count - 1).ToList()
                    .Sum(i => _connections.First(c => c.Item1 == route[i - 1] && c.Item2 == route[i]).Item3));

            Console.WriteLine($"{distances.Min()}\n{distances.Max()}");
        }

        static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}
