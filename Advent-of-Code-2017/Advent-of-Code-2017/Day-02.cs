using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2017
{
    class Day_02
    {
        private static string[] input = File.ReadAllLines(Program.InputFolderPath + "Day-02-input.txt");
        private static int[][] inputArray = new int[input.Length][];

        static Day_02()
        {
            for (int i = 0; i < input.Length; ++i)
            {
                var matches = Regex.Matches(input[i], @"\d+");
                inputArray[i] = new int[matches.Count];
                
                for (int j = 0; j < matches.Count; ++j)
                    inputArray[i][j] = Convert.ToInt32(Convert.ToInt32(matches[j].Value));
            }
        }

        public static int PuzzleOneOne()
        {
            int sum = 0;

            foreach (var row in inputArray)
                sum += row.Max() - row.Min();

            return sum;
        }

        public static int PuzzleOneTwo()
        {
            int sum = 0;

            for (int i = 0; i < inputArray.Length; ++i)
                foreach (int value in inputArray[i])
                    foreach (var comparedNum in inputArray[i])
                        if (value != comparedNum && (value % comparedNum == 0))
                            sum += value / comparedNum;

            return sum;
        }
    }
}
