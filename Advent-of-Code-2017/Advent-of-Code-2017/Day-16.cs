using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code_2017
{
    class Day_16
    {
        private static string[] input = File.ReadAllLines(Program.InputFolderPath + "Day-16-input.txt")[0].Split(',');
        static StringBuilder programs = new StringBuilder("abcdefghijklmnop");
        static List<string> permutations = new List<string>();

        public static void Puzzle()
        {
            int i = 0;
            int index = -1;
            for (; i < 1000000000 && index == -1; ++i)
            {
                foreach (string command in input)
                {
                    var match = command.Substring(1);
                    if (command[0] == 's')
                        Spin(Convert.ToInt32(match));
                    if (command[0] == 'x')
                        Swap(Convert.ToInt32(match.Split('/')[0]), Convert.ToInt32(match.Split('/')[1]));
                    if (command[0] == 'p')
                        SwapChar(command[1], command[3]);
                }
                index = permutations.IndexOf(programs.ToString());
                permutations.Add(programs.ToString());  
            }
            Console.WriteLine("Puzzle one: " + permutations[0]);
            Console.WriteLine("Puzzle two: " + permutations[1000000000 % (permutations.Count - 1) - 1]);
        }

        private static void Spin(int x) { programs.Insert(0, programs.ToString().Substring(programs.Length - x)).Remove(16, x); }
        private static void Swap(int x, int y)
        {
            char temp = programs[y];
            programs[y] = programs[x];
            programs[x] = temp;
        }
        private static void SwapChar(char x, char y) { Swap(programs.ToString().ToList().FindIndex(c => c == x), programs.ToString().ToList().FindIndex(c => c == y)); }
    }
}
