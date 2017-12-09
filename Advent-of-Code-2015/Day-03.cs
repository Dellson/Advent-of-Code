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
            List<Tuple<int, int>> coordinates = new List<Tuple<int, int>>();
            //List<string> coordinates = new List<string>();
            int luckyChildren = 1;

            coordinates.Add(new Tuple<int, int>(0, 0));
            //coordinates.Add("0x0");

            /*for (int i = 0; i < input.Length; ++i)
            {
                //int x = Convert.ToInt32(coordinates[i][0]);
                //int y = Convert.ToInt32(coordinates[i][1]);
                int x = coordinates[coordinates.Count - 1].Item1;
                int y = coordinates[coordinates.Count - 1].Item2;

                //Console.WriteLine(x + " " + y);

                if (input[i] == '^')
                    x++;
                if (input[i] == 'v')
                    x--;
                if (input[i] == '<')
                    y--;
                if (input[i] == '>')
                    y++;

                if (!coordinates.Exists(t => t.Item1 == x && t.Item2 == y))
                    luckyChildren++;

                coordinates.Add(new Tuple<int, int>(x, y));
            }*/
            coordinates.Add(new Tuple<int, int>(0, 0));
            for (int i = 0; i < input.Length; ++i)
            {
                int x = 0;
                int y = 0;

                if (i % 2 == 0)
                {
                    x = coordinates[coordinates.Count - 2].Item1;
                    y = coordinates[coordinates.Count - 2].Item2;
                    Console.WriteLine("SANTA");
                }
                else
                {
                    x = coordinates[coordinates.Count - 2].Item1;
                    y = coordinates[coordinates.Count - 2].Item2;
                    Console.WriteLine("ROBO SANTA");
                }
                

                Console.WriteLine(x + " " + y);

                if (input[i] == '^')
                    x++;
                if (input[i] == 'v')
                    x--;
                if (input[i] == '<')
                    y--;
                if (input[i] == '>')
                    y++;

                if (!coordinates.Exists(t => t.Item1 == x && t.Item2 == y))
                    luckyChildren++;
                Console.WriteLine(x + " " + y);
                coordinates.Add(new Tuple<int, int>(x, y));
            }

            Console.WriteLine(luckyChildren);
        }
    }
}
