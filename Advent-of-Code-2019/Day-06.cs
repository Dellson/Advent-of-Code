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

            foreach (var gravitationalPullSource in objectsDescendants)
            {
                FindAscendants(gravitationalPullSource.Value);
            }

            Console.WriteLine(count);

            //inputInstructions.CopyTo(copiedInstructions, 0);
            //Console.WriteLine($"Puzzle one answer {IntcodeComputer.CalculateOutput(copiedInstructions, 1)}");

            //inputInstructions.CopyTo(copiedInstructions, 0);
            //Console.WriteLine($"Puzzle two answer {IntcodeComputer.CalculateOutput(copiedInstructions, 5)}");
        }

        private static int FindAscendants(List<string> orbiters)
        {
            foreach (var orbiter in orbiters)
            {
                count++;

                if (objectsDescendants.ContainsKey(orbiter))
                    FindAscendants(objectsDescendants[orbiter]);
            }

            return count;
        }
    }
}