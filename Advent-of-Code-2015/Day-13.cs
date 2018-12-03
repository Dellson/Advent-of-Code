using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2015
{
    class Day_13
    {
        private static string[] _input = System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-13-input.txt");
        private static Dictionary<string, Guest> _guests = new Dictionary<string, Guest>();

        static Day_13()
        {
            foreach (var line in _input)
            {
                var words = Regex.Matches(line, @"\w+");
                if (!_guests.ContainsKey(words[0].Value))
                    _guests.Add(words[0].Value, new Guest(words[0].Value));
            }

            foreach (var line in _input)
            {
                int modifier = 1;
                var words = Regex.Matches(line, @"\w+");
                var happiness = Convert.ToInt32(Regex.Match(line, @"\d+").Value);

                if (words[2].Value == "lose")
                    modifier = -1;

                _guests[words[0].Value].HappinnesFactor.Add(words[10].Value, happiness * modifier);
            }

            foreach (var guest in _guests.Values)
            {
                Console.WriteLine(guest.Name);
                foreach (var n in guest.HappinnesFactor)
                    Console.WriteLine($"{n.Key} {n.Value}");
                Console.WriteLine();
            }

            // zadanie 2
            foreach (var guest in _guests.Values)
                guest.HappinnesFactor.Add("Pablo", 0);

            _guests.Add("Pablo", new Guest("Pablo"));

            foreach (var guest in _guests.Keys)
                _guests["Pablo"].HappinnesFactor.Add(guest, 0);


        }
        public static void Puzzle()
        {
            int maxVal = 0;
            var permutations = GetPermutations(_guests.Keys, _guests.Count);

            foreach (var p in permutations)
            {
                int currentSum = 0;
                var permutation = p.ToList();

                permutation.Insert(0, permutation.Last());
                permutation.Add(permutation[1]);

                for (int i = 1; i < permutation.Count - 1; i++)
                {
                    currentSum += _guests[permutation[i]].HappinnesFactor[permutation[i - 1]];
                    currentSum += _guests[permutation[i]].HappinnesFactor[permutation[i + 1]];
                }

                if (currentSum > maxVal)
                    maxVal = currentSum;
            }
            Console.WriteLine(maxVal);
        }

        static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        class Guest
        {
            public string Name { get; }
            public Dictionary<string, int> HappinnesFactor = new Dictionary<string, int>(); 

            public Guest(string name) => Name = name;
        }
    }
}