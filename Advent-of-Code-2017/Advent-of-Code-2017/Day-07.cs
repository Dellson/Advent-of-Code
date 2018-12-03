using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2017
{
    class Day_07
    {
        private static string[] rawInput = File.ReadAllLines(Program.InputFolderPath + "Day-07-input.txt");
        private static List<Disc> discs = new List<Disc>();
        private static int balancedWeight = -1;

        static Day_07()
        {
            foreach (var i in rawInput)
                discs.Add(new Disc(i));

            foreach (var disc in discs)
                foreach (var inner_disc in discs)
                    if (inner_disc.childNames.Contains(disc.name))
                        inner_disc.discs.Add(disc);
        }

        public static string PuzzleOne()
        {
            int max = 0;
            string currentDisc = discs.Find(d => d.discs.Count == 0).name;

            for (; discs.Find(d => d.childNames.Contains(currentDisc)) != null; max++)
                currentDisc = discs.Find(d => d.childNames.Contains(currentDisc)).name;

            return currentDisc;
        }

        public static int PuzzleTwo()
        {
            Recursive(new List<Disc>() { discs.Find(d => d.name == PuzzleOne()) });
            return balancedWeight;
        }

        private static int Recursive(List<Disc> children)
        {
            foreach (Disc child in children)
                child.weight += Recursive(child.discs);

            var childrenWeight = children.Select(d => d.weight);

            if (childrenWeight.Distinct().Count() == 2)
            {
                int max = childrenWeight.Max();
                int min = childrenWeight.Min();
                if (balancedWeight == -1)
                    balancedWeight = children.Find(dd => dd.weight == max).originalWeight - (max - min);
            }
            return childrenWeight.Sum();
        }

        public class Disc
        {
            public string name;
            public List<string> childNames = new List<string>();
            public List<Disc> discs = new List<Disc>();
            public int originalWeight = 0;
            public int weight;

            public Disc(string line)
            {
                weight = Convert.ToInt32(Regex.Match(line, @"\d+").Value);
                originalWeight = weight;
                childNames = Regex.Replace(line, @"[^a-z]+", "_").Split('_').ToList();

                name = childNames[0];
                childNames.RemoveAt(0);
            }
        }
    }
}
