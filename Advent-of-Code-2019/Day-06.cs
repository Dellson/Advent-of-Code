using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent_of_Code_2019
{
    class Day_06
    {
        static Dictionary<string, List<string>> objectsHierarchy = new Dictionary<string, List<string>>();
        static Dictionary<string, List<string>> objectsFullDescendants = new Dictionary<string, List<string>>();
        private static int count = 0;

        public static void Puzzle()
        {
            var mapData =
                File.ReadAllLines(Program.InputFolderPath + "Day-06-input.txt");

            foreach (string orbitData in mapData)
            {
                (string ascendant, string descendant) =
                    (orbitData.Split(')')[0], orbitData.Split(')')[1]);

                if (!objectsHierarchy.ContainsKey(ascendant))
                    objectsHierarchy.Add(ascendant, new List<string>());

                objectsHierarchy[ascendant].Add(descendant);
            }

            foreach (var descendant in objectsHierarchy)
                objectsFullDescendants.Add(descendant.Key, FindDescendants(descendant.Value));

            Console.WriteLine($"Puzzle one answer: {count}");
            Console.WriteLine($"Puzzle two answer: {GetMinimumOrbitalTransfersForTwoObjects("YOU", "SAN")}");
        }

        private static List<string> FindDescendants(List<string> orbiters)
        {
            List<string> descendants = new List<string>();

            foreach (var orbiter in orbiters)
            {
                count++;
                descendants.Add(orbiter);

                if (objectsHierarchy.ContainsKey(orbiter))
                    descendants.AddRange(FindDescendants(objectsHierarchy[orbiter]));
            }

            return descendants;
        }

        private static int GetMinimumOrbitalTransfersForTwoObjects(string descendant1, string descendant2)
        {
            List<string> descendant1Ascendants = GetAscendants(descendant1);
            List<string> descendant2Ascendants = GetAscendants(descendant2);

            var commonNodes = descendant1Ascendants.Intersect(descendant2Ascendants);
            var finalNode = commonNodes
                .Where(node => objectsFullDescendants[node].Intersect(commonNodes).Count() == 0
                && objectsFullDescendants[node].Intersect(commonNodes).Count() == 0);

            return (descendant1Ascendants.Count - commonNodes.Count()) + (descendant2Ascendants.Count - commonNodes.Count());
        }

        private static List<string> GetAscendants(string descendant) =>
            objectsFullDescendants
                .Where(ascendant => ascendant.Value.Contains(descendant))
                .Select(ascendant => ascendant.Key).ToList();
    }
}