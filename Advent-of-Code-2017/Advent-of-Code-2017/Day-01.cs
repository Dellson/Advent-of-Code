using System;
using System.IO;
using System.Text;

namespace Advent_of_Code_2017
{
    class Day_01
    {
        private static StringBuilder input = new StringBuilder(File.ReadAllLines(Program.InputFolderPath + "Day-01-input.txt")[0]);

        public static int PuzzleOneOne()
        {
            var modifiedInput =  new StringBuilder(input.ToString()).Append(input[0]);
            int sum = 0;

            for (int i = 1; i < modifiedInput.Length; ++i)
                if (modifiedInput[i - 1] == modifiedInput[i])
                    sum += (int)Char.GetNumericValue(modifiedInput[i - 1]);
            
            return sum;
        }

        public static int PuzzleOneTwo()
        {
            int sum = 0;

            for (int i = 0; i < input.Length; ++i)
                if (input[i] == input[(i + (input.Length / 2)) % input.Length])
                    sum += (int)Char.GetNumericValue(input[i]);

            return sum;
        }
    }
}
