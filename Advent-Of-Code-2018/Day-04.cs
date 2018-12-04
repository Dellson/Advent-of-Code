using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Console;

namespace Advent_of_Code_2018
{
    class Day_04
    {
        private static string[] _input = System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-04-input.txt");
        private static Dictionary<int, List<int>> guards = new Dictionary<int, List<int>>();

        static Day_04()
        {
            var sortedInput = _input.ToList();
            sortedInput.Sort();

            int currentId = 0;
            int aslept = 0;
            int timeAslept = 0;

            foreach (var line in sortedInput)
            {
                if (line.Contains("Guard"))
                {
                    currentId = Convert.ToInt32(Regex.Match(line, @"#\d+").Value.Substring(1));

                    if (!guards.ContainsKey(currentId))
                        guards.Add(currentId, new List<int>());
                    continue;
                }
                if (line.Contains("falls asleep"))
                {
                    aslept = Convert.ToInt32(line.Substring(15, 2));
                }
                if (line.Contains("wakes up"))
                {
                    var curTime = Convert.ToInt32(line.Substring(15, 2));
                    var diff = curTime - aslept;
                    guards[currentId].Add(diff);
                }
            }
             
            //return;
        }

        public static void Puzzle()
        {
            var max = guards.Values.Max(v => v.Sum());
            WriteLine(max);
            var key = guards.Where(g => g.Value.Sum() == max).First().Key;
            WriteLine(key);
            WriteLine(key * guards[key].Max());
           
        }

        class Guard
        {
            public DateTime timestamp;
            public string desc;
        }
    }
}
