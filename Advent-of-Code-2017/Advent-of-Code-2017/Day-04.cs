using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2017
{
    class Day_04
    {
        private static string[] rawInput = File.ReadAllLines(Program.InputFolderPath + "Day-04-input.txt");
        private static string[][] input = new string[rawInput.Length][];

        static Day_04()
        {
            for (int i = 0; i < input.Length; ++i)
            {
                var matches = Regex.Matches(rawInput[i], @"\w+");
                input[i] = new string[matches.Count];

                for (int j = 0; j < matches.Count; ++j)
                    input[i][j] = matches[j].Value;
            }
        }

        public static int PuzzleOne(bool partTwo = false)
        {
            int sum = 0;

            foreach (var row in input)
            {
                List<string> temp = new List<string>();

                foreach (var word in row)
                {
                    if (temp.Contains(word) || (partTwo && IsAnagram(temp, word)))
                    {
                        sum++;
                        break;
                    }
                    temp.Add(word);
                }
            }
            return input.Length - sum;
        }

        public static int PuzzleTwo() { return PuzzleOne(true); }

        private static bool IsAnagram(List<string> wordsToCheck, string word)
        {
            foreach (var wordToCheck in wordsToCheck)
                if (String.Concat(word.OrderBy(c => c)) == String.Concat(wordToCheck.OrderBy(c => c)))
                    return true;

            return false;
        }
    }
}
