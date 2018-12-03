using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent_of_Code_2017
{
    class Day_24
    {
        private static List<Tuple<int, int>> components = new List<Tuple<int, int>>();
        private static List<List<Tuple<int, int>>> bridges = new List<List<Tuple<int, int>>>();

        static Day_24()
        {
            foreach (var line in System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-24-input.txt"))
            {
                string[] s = line.Split('/');
                int i1 = Convert.ToInt32(s[0]);
                int i2 = Convert.ToInt32(s[1]);

                components.Add(new Tuple<int, int>(i1, i2));

                if (!components.Exists(t => t.Item1 == i2 && t.Item2 == i1))
                    components.Add(new Tuple<int, int>(i2, i1));
            }
        }

        public static void Puzzle()
        {
            int max = 0;
            int maxLength = 0;

            foreach (var component in components.FindAll(c => c.Item1 == 0))
            {
                bridges.Add(new List<Tuple<int, int>>());
                bridges.Last().Add(component);
                BuildBridge(bridges.Last());
            }

            max = bridges.Max(list => list.Sum(b => b.Item1 + b.Item2));
            Console.WriteLine("The strongest bridge:\t\t\t" + max);

            maxLength = bridges.Max(list => list.Count);
            max = bridges.FindAll(b => b.Count == maxLength).Max(list => list.Sum(b => b.Item1 + b.Item2));
            Console.WriteLine("The strongest of the longest bridges:\t" + max);
        }

        private static void BuildBridge(List<Tuple<int, int>> bridge)
        {
            foreach (var component in components.FindAll(c => c.Item1 == bridge.Last().Item2))
            {
                List<Tuple<int, int>> tempBridge = new List<Tuple<int, int>>(bridge);
                if (tempBridge.Contains(component) || tempBridge.Exists(c => c.Item1 == component.Item2 && c.Item2 == component.Item1))
                    continue;
                tempBridge.Add(component);
                bridges.Add(tempBridge);
                BuildBridge(tempBridge);
            }
        }
    }
}
