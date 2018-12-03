using System;
using System.IO;
using System.Collections.Generic;

namespace Advent_of_Code_2017
{
    class Day_19
    {
        private static string[] area = File.ReadAllLines(Program.InputFolderPath + "Day-19-input.txt");
        private enum Directions { LEFT, DOWN, RIGHT, UP }
        private static Directions directions = Directions.DOWN;
        
        public static void Puzzle()
        {
            List<char> letters = new List<char>();
            int x = 0;
            int y = 1;
            int count = 0;

            while (true)
            {
                count++;

                if (directions == Directions.DOWN)
                    x++;
                if (directions == Directions.UP)
                    x--;
                if (directions == Directions.RIGHT)
                    y++;
                if (directions == Directions.LEFT)
                    y--;

                if (area[x][y] == '+')
                {
                    count++;

                    if (directions == Directions.UP || directions == Directions.DOWN)
                    {
                        if (area[x][--y] != ' ')
                            directions = Directions.LEFT;
                        else
                        {
                            y += 2;
                            directions = Directions.RIGHT;
                        }
                    }
                    else if (directions == Directions.LEFT || directions == Directions.RIGHT)
                    {
                        if (area[--x][y] != ' ')
                            directions = Directions.UP;
                        else
                        {
                            x += 2;
                            directions = Directions.DOWN;
                        }
                    }
                    continue;
                }
                if (area[x][y] == ' ')
                    break;
                if (area[x][y] != '|' && area[x][y] != '-')
                    letters.Add(area[x][y]);
            }

            foreach (var c in letters)
                Console.Write(c);
            Console.WriteLine("\n" + count);
        }
    }
}
