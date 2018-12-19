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
            //PuzzleOne();
            PuzzleTwo();
        }

        private static void PuzzleOne()
        {
            int position = 0;
            int metadataSum = 0;

            HandleNode();
            Console.WriteLine(metadataSum);

            void HandleNode()
            {
                var childs = _input[position++];
                var metadataEntries = _input[position++];

                for (int i = 0; i < childs; i++)
                    HandleNode();
                for (int i = 0; i < metadataEntries; i++)
                    metadataSum += _input[position++];
            }
        }

        private static void PuzzleTwo()
        {
            int position = 0;
            int metadataSum = 0;
            
            Console.WriteLine(HandleNode());

            int HandleNode()
            {
                var childrenCount = _input[position++];
                var metadataEntriesCount = _input[position++];
                var metadataVal = 0;
                var childrenVals = new int[childrenCount];

                if (childrenCount == 0)
                {
                    for (int i = 0; i < metadataEntriesCount; i++)
                        metadataVal += _input[position++];
                }
                else
                {
                    for (int i = 0; i < childrenCount; i++)
                        childrenVals[i] = HandleNode();

                    for (int i = 0; i < metadataEntriesCount; i++)
                    {
                        if (_input[position++] < childrenCount)
                            metadataSum += childrenVals[_input[position - 1] - 1];
                    }
                }
                return metadataVal + metadataSum;
            }
        }
    }
}
