using System;

namespace AdventOfCode2020
{
    class Day03
    {
        static string[] Input;

        public static void Puzzle()
        {
            Input = Program.GetTextInputData("3");

            Puzzle1();
            Puzzle2();
        }

        private static void Puzzle1()
        {
            int treesHit = GetNumberOfTreesHit(3, 1);

            Console.WriteLine(treesHit);
        }

        private static void Puzzle2()
        {
            int treesHitMultiplied =
                GetNumberOfTreesHit(1, 1) * 
                GetNumberOfTreesHit(3, 1) * 
                GetNumberOfTreesHit(5, 1) * 
                GetNumberOfTreesHit(7, 1) * 
                GetNumberOfTreesHit(1, 2);

            Console.WriteLine(treesHitMultiplied);
        }

        private static int GetNumberOfTreesHit(int rightShift, int downShift)
        {
            int horizontalPosition = 0;
            int verticalPosition = 0;
            int treesHit = 0;

            for (; verticalPosition < Input.Length; verticalPosition += downShift)
            {
                if (Input[verticalPosition][horizontalPosition % Input[0].Length] == '#')
                    treesHit++;

                horizontalPosition += rightShift;
            }

            return treesHit;
        }
    }
}