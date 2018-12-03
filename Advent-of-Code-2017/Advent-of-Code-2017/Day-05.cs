using System.IO;

namespace Advent_of_Code_2017
{
    class Day_05
    {
        private static string[] rawInput = File.ReadAllLines(Program.InputFolderPath + "Day-05-input.txt");
        private static int[] input = new int[rawInput.Length];

        public static int PuzzleOne(bool partTwo = false)
        {
            for (int j = 0; j < input.Length; ++j)
                input[j] = System.Convert.ToInt32(rawInput[j]);

            int i = 0, steps = 0, offset = 0;
            
            while (i < input.Length)
            {
                offset = input[i];

                if (partTwo && offset >= 3)
                    input[i]--;
                else
                    input[i]++;

                i += offset;
                steps++;
            }

            return steps;
        }

        public static int PuzzleTwo() { return PuzzleOne(true); }
    }
}
