using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    class Day02
    {
        static string[] Input;

        public static void Puzzle()
        {
            Input = Program.GetTextInputData("2");

            Puzzle1();
            Puzzle2();
        }

        private static void Puzzle1()
        {
            int validPasses = 0;
            foreach (var policy in Input)
            {
                var (range, letter, investigated) = TranslatePolicy(policy);
                int count = investigated.Count(c => c == letter);

                if (count >= range.min && count <= range.max)
                    validPasses++;
            }
            Console.WriteLine(validPasses);
        }

        private static void Puzzle2()
        {
            int validPasses = 0;
            foreach (var policy in Input)
            {
                var (range, letter, investigated) = TranslatePolicy(policy);
                bool firstPos = investigated[range.min - 1] == letter;
                bool secondPos = investigated[range.max - 1] == letter;

                if (firstPos ^ secondPos)
                    validPasses++;
            }
            Console.WriteLine(validPasses);
        }

        private static ((int min, int max) range, char letter, string investigated) TranslatePolicy(string policy)
        {
            var range_matches = Regex.Matches(policy, @"\d+");
            var range = (Convert.ToInt32(range_matches[0].Value), Convert.ToInt32(range_matches[1].Value));
            char letter = Regex.Match(policy, @"\w:").Value.First();
            string investigatedPassword = Regex.Match(policy, @"\w+$").Value;

            return (range, letter, investigatedPassword);
        }
    }
}