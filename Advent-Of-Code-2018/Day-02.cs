using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace Advent_of_Code_2018
{
    public class Day_02
    {
        private static string[] _input = System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-02-input.txt");

        public static void Puzzle()
        {
            WriteLine($"Puzzle two answer: {PuzzleOne()}");
            WriteLine($"Puzzle two answer: {PuzzleTwo()}");
        }

        public static int PuzzleOne()
        {
            return _input.Count(i => CheckRepetitions(i, 2)) * _input.Count(i => CheckRepetitions(i, 3));
        }

        public static string PuzzleTwo()
        {
            foreach (var box in _input)
            {
                foreach (var boxToCompare in _input)
                {
                    StringBuilder sb = new StringBuilder();

                    for (int i = 0; i < box.Length; i++)
                        if (box[i] == boxToCompare[i])
                            sb.Append(box[i]);

                    if (sb.Length == box.Length - 1)
                        return sb.ToString();
                }
            }
            return string.Empty;
        }

        private static bool CheckRepetitions(string boxID, int repetitionCount)
        {
            Dictionary<char, int> letterCount = new Dictionary<char, int>();

            foreach (char character in boxID)
            {
                if (letterCount.ContainsKey(character))
                    ++letterCount[character];
                else
                    letterCount.Add(character, 1);
            }
            return letterCount.ContainsValue(repetitionCount);

        }
    }
}
