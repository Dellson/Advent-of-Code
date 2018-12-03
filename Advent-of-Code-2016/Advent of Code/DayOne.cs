using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class DayOne
    {
        private string path = Directory.GetCurrentDirectory();
        private string[] actions;

        public DayOne()
        {
            path = Path.Combine(path, "..\\..\\");
            path += "DayOneInput.txt";

            string[] input = System.IO.File.ReadAllLines(path);
            foreach (string line in input)
            {
                actions = line.Split(new string[] { ", " }, StringSplitOptions.None);
            }

            /*foreach (string action in actions)
                System.Console.WriteLine(action);*/
        }

        public int PuzzleOne()
        {
            string currentDirection = "N";
            string[] directions = new string[4] { "W", "N", "E", "S" };

            Dictionary<string, int> directionDistance = new Dictionary<string, int>();
            directionDistance.Add("W", 0);
            directionDistance.Add("N", 0);
            directionDistance.Add("E", 0);
            directionDistance.Add("S", 0);

            foreach (string action in actions)
            {
                if (action.Contains("L"))
                {
                    try
                    {
                        currentDirection = directions[Array.FindIndex(directions, s => s == currentDirection) - 1];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        currentDirection = directions[3];
                    }
                }
                if (action.Contains("R"))
                {
                    try
                    {
                        currentDirection = directions[Array.FindIndex(directions, s => s == currentDirection) + 1];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        currentDirection = directions[0];
                    }
                }

                directionDistance[currentDirection] += Int32.Parse(action.Remove(0, 1));
            }

            return Math.Abs(directionDistance["N"] - directionDistance["S"])
                 + Math.Abs(directionDistance["E"] - directionDistance["W"]);
        }

        public int PuzzleTwo()
        {
            string currentDirection = "N";
            string[] directions = new string[4] { "W", "N", "E", "S" };

            List<int[]> coordinates = new List<int[]>();
            coordinates.Add(new int[2] { 0, 0 });

            foreach (string action in actions)
            {
                if (action.Contains("L"))
                {
                    try
                    {
                        currentDirection = directions[Array.FindIndex(directions, s => s == currentDirection) - 1];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        currentDirection = directions[3];
                    }
                }
                if (action.Contains("R"))
                {
                    try
                    {
                        currentDirection = directions[Array.FindIndex(directions, s => s == currentDirection) + 1];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        currentDirection = directions[0];
                    }
                }

                int currentDistance = Int32.Parse(action.Remove(0, 1));

                for (int i = 0; i < currentDistance; ++i)
                {

                    if (currentDirection == "N")
                        coordinates.Add(new int[2] { coordinates[coordinates.Count - 1][0], coordinates[coordinates.Count - 1][1] + 1 } );
                    if (currentDirection == "S")
                        coordinates.Add(new int[2] { coordinates[coordinates.Count - 1][0], coordinates[coordinates.Count - 1][1] - 1 });
                    if (currentDirection == "E")
                        coordinates.Add(new int[2] { coordinates[coordinates.Count - 1][0] + 1, coordinates[coordinates.Count - 1][1] });
                    if (currentDirection == "W")
                        coordinates.Add(new int[2] { coordinates[coordinates.Count - 1][0] - 1, coordinates[coordinates.Count - 1][1] });

                    for (int j = 0; j < (coordinates.Count - 1); ++j)
                    {
                        if (coordinates[j][0] == coordinates[coordinates.Count - 1][0] &&
                            coordinates[j][1] == coordinates[coordinates.Count - 1][1])
                        {
                            return Math.Abs(coordinates[coordinates.Count - 1][0]) + Math.Abs(coordinates[coordinates.Count - 1][1]);
                        }
                    }
                }
            }
            return 0;
        }
    }
}
