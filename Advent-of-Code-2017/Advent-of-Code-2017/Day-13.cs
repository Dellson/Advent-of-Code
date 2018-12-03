using System;
using System.Collections.Generic;

namespace Advent_of_Code_2017
{
    class Day_13
    {
        static Scanner[] scanners = new Scanner[100];
        static bool[] validPositions = new bool[100];

        static Day_13()
        {
            List<string> input = new List<string>(System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-13-input.txt"));

            for (int i = 0; i < 100; ++i)
            {
                scanners[i] = new Scanner(-1) { position = -1 };
                validPositions[i] = false;
            }
            for (int i = 0; i < input.Count; ++i)
                scanners[Convert.ToInt32(input[i].Split(':')[0])] = new Scanner(Convert.ToInt32(input[i].Split(':')[1]));
        }

        public static void PuzzleOne()
        {
            int count = 0;

            for (int i = 0; i < 100; ++i)
            {
                if (scanners[i].position == 1)
                    count += (i * scanners[i].range);

                foreach (Scanner scanner in scanners)
                    scanner.Move();
            }
            Console.WriteLine("Puzzle one: " + count);
        }

        public static void PuzzleTwo()
        {
            int startPos = 0;

            for (; !validPositions[99]; ++startPos)
            {
                if (scanners[0].position != 1)
                    validPositions[0] = true;

                for (int j = 99; j > 0; --j)
                {
                    if (validPositions[j - 1])
                    {
                        validPositions[j - 1] = false;
                        validPositions[j] = true;
                    }
                }

                foreach (Scanner scanner in scanners)
                    scanner.Move();

                for (int j = 99; j > 0; --j)
                    if (scanners[j].position == 1)
                        validPositions[j] = false;
            }
            Console.WriteLine("Puzzle two: " + (startPos - validPositions.Length + 1));
        }

        private class Scanner
        {
            public int position;
            public int range;
            public int direction;

            public Scanner(int range)
            {
                position = 1;
                this.range = range;
                direction = 1;
            }

            public void Move()
            {
                if (position == -1)
                    return;
                if (direction == 1 && position == range)
                    direction = -1;
                if (direction == -1 && position == 1)
                    direction = 1;
                position += direction;
            }
        }
    }
}