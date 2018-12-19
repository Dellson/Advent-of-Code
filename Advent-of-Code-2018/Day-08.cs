using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2018
{
    class Day_08
    {
        private static string _rawInput = System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-08-input.txt")[0];
        private static int[] _input;


        static Day_08()
        {
            var vals = Regex.Matches(_rawInput, @"\d+");
            _input = new int[vals.Count];

            for (int i = 0; i < vals.Count; i++)
                _input[i] = Convert.ToInt32(vals[i].Value);
        }

        public static void Puzzle()
        {
            PuzzleOne();
        }

        private static void PuzzleOne()
        {
            int position = 0;
            int metadataSum = 0;

            HandleNode();
            Console.WriteLine(metadataSum);

            int HandleNode()
            {
                var childs = _input[position++];
                var metadataEntries = _input[position++];

                for (int i = 0; i < childs; i++)
                    HandleNode();
                for (int i = 0; i < metadataEntries; i++)
                    metadataSum += _input[position++];

                return 0;
            }
        }
    }
}
