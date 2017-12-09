using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    class Day_03
    {
        private static string input = System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-03-input.txt")[0];

        public static void BothStars()
        {
            PuzzleOne();
            PuzzleTwo();
        }

        private static void PuzzleOne()
        {
            List<Tuple<int, int>> coordinates = new List<Tuple<int, int>>() { new Tuple<int, int>(0, 0) };
            int luckyChildren = 1;

            for (int i = 0; i < input.Length; ++i)
            {
                int x = coordinates[coordinates.Count - 1].Item1;
                int y = coordinates[coordinates.Count - 1].Item2;

                if (input[i] == '^') x++;
                if (input[i] == 'v') x--;
                if (input[i] == '<') y--;
                if (input[i] == '>') y++;

                if (!coordinates.Exists(t => t.Item1 == x && t.Item2 == y))
                    luckyChildren++;

                coordinates.Add(new Tuple<int, int>(x, y));
            }
            Console.WriteLine(luckyChildren);
        }

        private static void PuzzleTwo()
        {
            List<Tuple<int, int>> coordinates = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(0, 0)
            };

            int luckyChildren = 1;
            for (int i = 0; i < input.Length; ++i)
            {                
                int x = coordinates[coordinates.Count - 2].Item1;
                int y = coordinates[coordinates.Count - 2].Item2;

                if (input[i] == '^') x++;
                if (input[i] == 'v') x--;
                if (input[i] == '<') y--;
                if (input[i] == '>') y++;

                if (!coordinates.Exists(t => t.Item1 == x && t.Item2 == y))
                    luckyChildren++;

                coordinates.Add(new Tuple<int, int>(x, y));
            }
            Console.WriteLine(luckyChildren);
        }
    }
}
