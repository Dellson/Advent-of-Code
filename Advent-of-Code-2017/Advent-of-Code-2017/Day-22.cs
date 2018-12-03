using System;
using System.Collections.Generic;
using System.IO;

namespace Advent_of_Code_2017
{
    class Day_22
    {
        private static string[] rawInput = File.ReadAllLines(Program.InputFolderPath + "Day-22-input.txt");
        private static Dictionary<string, States> grid = new Dictionary<string, States>();
        private enum Directions { UP, RIGHT, DOWN, LEFT }
        private enum States { CLEAN, WEAKENED, INFECTED, FLAGGED }
        private static Directions curDirection;
        private static int virusXposition;
        private static int virusYPosition;
        private static int count;

        public static void PuzzleOne()
        {
            Initialize();
            for (int k = 0; k < 10000; ++k)
            {
                string key = virusXposition.ToString() + " " + virusYPosition.ToString();

                if (!grid.ContainsKey(key)) { grid.Add(key, States.CLEAN); }
                if (grid[key] == States.CLEAN)
                {
                    curDirection = (Directions)((int)(curDirection + 3) % 4);
                    grid[key] = States.INFECTED;
                    count++;
                }
                else if (grid[key] == States.INFECTED)
                {
                    curDirection = (Directions)((int)(curDirection + 1) % 4);
                    grid[key] = States.CLEAN;
                }
                MoveVirus();
            }
            Console.WriteLine("Puzzle one answer: " + count);
        }

        public static void PuzzleTwo()
        {
            Initialize();
            for (int k = 0; k < 10000000; ++k)
            {
                string key = virusXposition.ToString() + " " + virusYPosition.ToString();

                if (!grid.ContainsKey(key)) { grid.Add(key, States.CLEAN); }
                if (grid[key] == States.CLEAN)
                {
                    curDirection = (Directions)((int)(curDirection + 3) % 4);
                    grid[key] = States.WEAKENED;
                }
                else if (grid[key] == States.WEAKENED)
                {
                    grid[key] = States.INFECTED;
                    count++;
                }
                else if ((grid[key] == States.INFECTED))
                {
                    curDirection = (Directions)((int)(curDirection + 1) % 4);
                    grid[key] = States.FLAGGED;
                }
                else if ((grid[key] == States.FLAGGED))
                {
                    curDirection = (Directions)((int)(curDirection + 2) % 4);
                    grid[key] = States.CLEAN;
                }
                MoveVirus();
            }
            Console.WriteLine("Puzzle two answer: " + count);
        }

        private static void Initialize()
        {
            curDirection = Directions.UP;
            virusXposition = 0;
            virusYPosition = 0;
            count = 0;
            grid.Clear();
            int length = rawInput.Length;
            int boundary = (length - 1) / 2;

            for (int i = 0; i < length; ++i)
                for (int j = 0; j < length; ++j)
                    grid.Add((i - boundary).ToString() + " " + (j - boundary).ToString(),
                        rawInput[i][j] == '.' ? States.CLEAN : States.INFECTED);
        }

        private static void MoveVirus()
        {
            if (curDirection == Directions.UP) virusXposition--;
            if (curDirection == Directions.DOWN) virusXposition++;
            if (curDirection == Directions.LEFT) virusYPosition--;
            if (curDirection == Directions.RIGHT) virusYPosition++;
        }
    }
}
