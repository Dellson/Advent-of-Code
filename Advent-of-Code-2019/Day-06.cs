using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2019
{
    class Day_06
    {
        static Dictionary<string, List<string>> objectsDescendants = new Dictionary<string, List<string>>();
        static Dictionary<string, List<string>> objectsFullDescendants = new Dictionary<string, List<string>>();
        private static int count = 0;

        public static void Puzzle()
        {
            var inputList =
                File.ReadAllLines(Program.InputFolderPath + "Day-06-input.txt");

            // initial fill: save map data to dicts
            foreach (string objectToAnalyze in inputList)
            {
                (string gravitationalPullSource, string orbitingObject) = 
                    (objectToAnalyze.Split(')')[0], objectToAnalyze.Split(')')[1]);

                if (!objectsDescendants.ContainsKey(gravitationalPullSource))
                    objectsDescendants.Add(gravitationalPullSource, new List<string>());

                objectsDescendants[gravitationalPullSource].Add(orbitingObject);
            }

            // part one
            foreach (var gravitationalPullSource in objectsDescendants)
                objectsFullDescendants.Add(gravitationalPullSource.Key, FindDescendants(gravitationalPullSource.Value));

            Console.WriteLine($"Puzzle one answer: {count}");

            // part two
            var r = FindFirstCommonAscendant("YOU", "SAN");
            Console.WriteLine($"Puzzle two answer: {r}");
            //inputInstructions.CopyTo(copiedInstructions, 0);
            //Console.WriteLine($"Puzzle two answer {IntcodeComputer.CalculateOutput(copiedInstructions, 5)}");
        }

        private static List<string> FindDescendants(List<string> orbiters)
        {
            List<string> descendants = new List<string>();

            foreach (var orbiter in orbiters)
            {
                count++;
                descendants.Add(orbiter);

                if (objectsDescendants.ContainsKey(orbiter))
                    descendants.AddRange(FindDescendants(objectsDescendants[orbiter]));
            }

            return descendants;
        }

        private static int FindFirstCommonAscendant(string descendant1, string descendant2)
        {
            List<string> descendant1Ascendants = objectsFullDescendants
                .Where(v => v.Value.Contains(descendant1))
                .Select(w => w.Key).ToList();

            List<string> descendant2Ascendants = objectsFullDescendants
                .Where(v => v.Value.Contains(descendant2))
                .Select(w => w.Key).ToList();

            //int desc1count = descendant1Ascendants.Count;
            //int desc2count = descendant2Ascendants.Count;

            var commonNodes = descendant1Ascendants.Intersect(descendant2Ascendants);
            var finalNode = commonNodes
                .Where(node => objectsFullDescendants[node].Intersect(commonNodes).Count() == 0
                && objectsFullDescendants[node].Intersect(commonNodes).Count() == 0);

            return (descendant1Ascendants.Count - commonNodes.Count()) + (descendant2Ascendants.Count - commonNodes.Count());
        }
    }
}