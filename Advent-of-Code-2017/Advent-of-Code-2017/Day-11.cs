using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent_of_Code_2017
{
    class Day_11
    {
        private static string input = File.ReadAllLines(Program.InputFolderPath + "Day-11-input.txt")[0];

        public static void Puzzle()
        {
            List<string> directions = new List<string>(input.Split(','));
            int x = 0;
            int y = 0;
            int z = 0;

            List<int> dists = new List<int>();

            foreach (var direction in directions)
            {
                if (direction == "n")
                {
                    y++;
                    z--;
                }
                else if (direction == "s")
                {
                    y--;
                    z++;
                }
                else if (direction == "ne")
                {
                    x++;
                    z--;
                }
                else if (direction == "sw")
                {
                    x--;
                    z++;
                }
                else if (direction == "nw")
                {
                    y++;
                    x--;
                }
                else if (direction == "se")
                {
                    y--;
                    x++;
                }
                dists.Add((Math.Abs(x) + Math.Abs(y) + Math.Abs(z)) / 2);
            }
            Console.WriteLine("Puzzle one " + (Math.Abs(x) + Math.Abs(y) + Math.Abs(z)) / 2);
            Console.WriteLine("Puzzle two " + dists.Max());
        }
    }
}
