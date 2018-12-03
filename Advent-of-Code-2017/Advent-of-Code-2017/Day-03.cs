using System;
using System.Linq;
using System.Collections.Generic;

namespace Advent_of_Code_2017
{
    class Day_03
    {
        private static int input = 347991;
        private static int sideLength = Convert.ToInt32(Math.Sqrt(input));
        private static List<Square> squares = new List<Square> { new Square(0, 0, 1), new Square(0, 1, 1) };
        enum Directions { UP, LEFT, DOWN, RIGHT }

        static Day_03() { if (sideLength % 2 == 0) sideLength++; }

        public static int PuzzleOne() { return (sideLength - 1) - (((sideLength * sideLength) - input) % (sideLength - 1)); }

        public static void PuzzleTwo()
        {
            int maxX = 0;
            int maxY = 1;
            int x = 0;
            int y = 1;
            Directions directions = Directions.UP;

            for (int i = 2; i < input + 1 + 1; ++i)
            {
                if (directions == Directions.UP)
                    x++;
                else if (directions == Directions.LEFT)
                    y--;
                else if (directions == Directions.DOWN)
                    x--;
                else if (directions == Directions.RIGHT)
                    y++;

                squares.Add(new Square(x, y));
                CalculateNeighborsSum(squares.Last());

                if (maxX < maxY)
                {
                    directions = (Directions)((int)(directions + 1) % 4);
                    maxX++;
                    continue;
                }
                if (x == -maxX && y == maxY)
                    maxY++;
                if (Math.Abs(x) == maxX && Math.Abs(y) == maxY)
                    directions = (Directions)((int)(directions + 1) % 4);
                if (squares.Last().value > input)
                    break;
            }

            Console.WriteLine(squares.Last().value);
        }

        public class Square
        {
            public int x, y, value = 0;

            public Square(int x, int y, int value = 0)
            {
                this.x = x;
                this.y = y;
                this.value = value;
            }
        }

        private static void CalculateNeighborsSum(Square square) { square.value = squares.FindAll(s => Math.Abs(s.x - square.x) <= 1 && Math.Abs(s.y - square.y) <= 1).Sum(s => s.value); }
    }
}
