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
        private static Dictionary<int, Dictionary<int, int>> guards = new Dictionary<int, Dictionary<int, int>>();

        static Day_04()
        {
            var sortedInput = _input.ToList();
            sortedInput.Sort();

            int currentId = 0;
            int aslept = 0;

            foreach (var line in sortedInput)
            {
                if (line.Contains("Guard"))
                {
                    currentId = Convert.ToInt32(Regex.Match(line, @"#\d+").Value.Substring(1));

                    if (!guards.ContainsKey(currentId))
                        guards.Add(currentId, new Dictionary<int, int>());
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

                    for (int i = aslept; i < curTime; i++)
                    {
                        if (!guards[currentId].ContainsKey(i))
                            guards[currentId].Add(i, 1);
                        else
                            guards[currentId][i]++;
                    }
                }
            }
        }

        public static void Puzzle()
        {
            int minute = 0;
            int repetitions = 0;
            int max = 0;
            int gu = 0;
            
            foreach (var guard in guards)
            {
                if (guard.Value.Values.Count == 0)
                    continue;
                int mostOftenMinuteCount = guard.Value.Values.Max();
                int mostOftenMinute = guard.Value.Where(v => v.Value == mostOftenMinuteCount).First().Key;
                Console.WriteLine("DEBUG " + mostOftenMinute);

                if (mostOftenMinuteCount > repetitions)
                {
                    repetitions = mostOftenMinuteCount;
                    minute = mostOftenMinute;
                    gu = guard.Key;
                }
                    

                /*minute = guard.Value.Where(v => v.Value == maxVal).First().Key;
                if (minute > max)
                {
                    max = minute;
                    gu = guard.Key;
                }*/
                    
            }
            Console.WriteLine(minute);
            Console.WriteLine(gu);
            Console.WriteLine(minute * gu);
            // 4972 too low
            
        }

        public static void Puzzle2()
        {
            int minute = 0;
            int max = 0;
            int gu = 0;

            foreach (var guard in guards)
            {
                //Console.WriteLine(guard.Key);
                int cur = 0;

                foreach (var item in guard.Value)
                {
                    cur += item.Value;
                }
                if (cur > max)
                {
                    max = cur;
                    int maxVal = guard.Value.Values.Max();
                    minute = guard.Value.Where(v => v.Value == maxVal).First().Key;
                    gu = guard.Key;
                }
            }
            Console.WriteLine(minute * gu);
        }
    }
}
