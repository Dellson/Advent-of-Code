using System.Linq;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2015
{
    class Day_09
    {
        private static readonly string[] _input = System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-09-input.txt");

        public static void BothStars()
        {
            int counter = 1;
            Dictionary<string, int> cities = new Dictionary<string, int>();

            foreach (string str in _input)
            {
                var cityA = Regex.Matches(str, @"\w+")[0].Value;
                var cityB = Regex.Matches(str, @"\w+")[2].Value;
                var distance = Regex.Matches(str, @"\d+")[0].Value;

                if (!cities.ContainsKey(cityA)) cities.Add(cityA, counter++);
                if (!cities.ContainsKey(cityB)) cities.Add(cityB, counter++);
            }

            //cities.Values.ToList().ForEach(c => Console.WriteLine(c));
            var conns = GetKCombs(cities.Values.ToList(), 2);
            var connections = new List<List<int>>();

            foreach (var c in conns)
            {
                var comb = c.ToList();
                connections.Add(comb);
                comb.Reverse();
                connections.Add(comb);
            }

            foreach (var c in conns)
            {
                var comb = c.ToList();
                connections.Add(comb);
                comb.Reverse();
                connections.Add(comb);
            }

            connections.ForEach(c => Console.WriteLine(c));

            List<string> route = new List<string>();
            List<List<string>> routes = new List<List<string>>();

            /*foreach (var conn in connections)
            {
                route.Add(string.Join(" ", conn.ToArray()));
            }
            var r = GetKCombs(route, 2);

            foreach (var c in r)
            {
                var comb = c.ToList();
                Console.WriteLine($"{comb[0]} {comb[1]}");
            }*/

            /*foreach (var c in conns)
            {
                var comb = c.ToList();
                Console.WriteLine($"{comb[0]} {comb[1]}");
            }*/
        }

        private static void GetScenarios()
        {

        }

        private static IEnumerable<IEnumerable<T>> GetKCombs<T>(IEnumerable<T> list, int length) where T : IComparable
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetKCombs(list, length - 1)
                .SelectMany(t => list.Where(o => o.CompareTo(t.Last()) > 0),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}
