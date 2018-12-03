using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2017
{
    class Day_10
    {
        private static List<int> input = new List<int>();
        private static List<int> byteInput = new List<int>();
        private static List<int> circularList = new List<int>();

        static Day_10() { Initialize(System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-10-input.txt")[0]); }      
        
        public static void Initialize(string rawInput)
        {
            byteInput.Clear();
            circularList.Clear();

            var matches = Regex.Matches(rawInput, @"\d+");

            for (int j = 0; j < matches.Count; ++j)
                input.Add(Convert.ToInt32(Convert.ToInt32(matches[j].Value)));

            for (int i = 0; i < rawInput.Length; ++i)
                byteInput.Add(rawInput[i]);
            byteInput.AddRange(new int[5] { 17, 31, 73, 47, 23 });

            for (int i = 0; i < 256; ++i)
                circularList.Add(i);
        }

        public static void PuzzleOne()
        {
            ReverseLists(input);
            Console.WriteLine(circularList[0] * circularList[1]);
        }

        public static string PuzzleTwo()
        {
            StringBuilder finalHex = new StringBuilder();
            
            ReverseLists(byteInput, 64);

            for (int i = 0; i < 256; i += 16)
            {
                int blockOutput = circularList[i];

                for (int blockNumber = 1; blockNumber < 16; ++blockNumber)
                    blockOutput ^= circularList[i + blockNumber];
                
                if (blockOutput < 16) //hex length
                    finalHex.Append("0");
                finalHex.Append(blockOutput.ToString("X"));
            }
            return finalHex.ToString();
        }

        private static void ReverseLists(List<int> input, int rounds = 1)
        {
            int skip = 0;
            int currentPosition = 0;

            for (int round = 0; round < rounds; ++round)
            {
                for (int i = 0; i < input.Count; ++i)
                {
                    int firstSublistLength = (circularList.Count - currentPosition < input[i]) ? circularList.Count - currentPosition : input[i];
                    List<int> sublist = circularList.GetRange(currentPosition, firstSublistLength);
                    sublist.AddRange(circularList.GetRange(0, input[i] - firstSublistLength));

                    List<int> sublistReversed = new List<int>(sublist);
                    sublistReversed.Reverse();

                    for (int j = 0; j < circularList.Count; ++j)
                    {
                        int index = sublist.IndexOf(circularList[j]);

                        if (index != -1)
                            circularList[j] = sublistReversed[index];
                    }

                    currentPosition = (currentPosition + input[i] + skip) % 256;
                    skip++;
                }
            }
        }

    }
}
