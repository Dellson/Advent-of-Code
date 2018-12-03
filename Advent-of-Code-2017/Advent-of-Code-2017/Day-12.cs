using System.Linq;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2017
{
    class Day_12
    {
        private static List<string> rawInput = new List<string>(System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-12-input.txt"));
        private static Dictionary<int, List<int>> villages = new Dictionary<int, List<int>>();
        private static List<List<int>> neighbourGroups = new List<List<int>>();
        
        public static void Puzzle()
        {
            rawInput.ForEach(line => { List<int> lineMembers = Regex.Matches(line, @"\d+").Cast<Match>().ToList().ConvertAll(m => Convert.ToInt32(m.Value));
                villages.Add(lineMembers[0], lineMembers.GetRange(1, lineMembers.Count - 1)); });

            while (villages.Count > 0)
            {
                   neighbourGroups.Add(new List<int>());
                FindConnections(villages.First().Value);
            }
            Console.WriteLine("Connections from village 0: " + neighbourGroups.Find(group => group.Contains(0)).Count);
            Console.WriteLine("Number of groups:           " + neighbourGroups.Count);
        }

        private static void FindConnections(List<int> neighbours)
        {
            neighbours.ForEach(neighbour => {
                if (!neighbourGroups.Last().Contains(neighbour))
                {
                    neighbourGroups.Last().Add(neighbour);
                    FindConnections(villages[neighbour]);
                    villages.Remove(neighbour);
                }
            });
        }
    }
}
