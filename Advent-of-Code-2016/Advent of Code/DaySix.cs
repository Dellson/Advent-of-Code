using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class DaySix
    {
        private string path = Directory.GetCurrentDirectory();
        private string[] input;

        public DaySix()
        {
            path = Path.Combine(path, "..\\..\\");
            path += "DaySixInput.txt";

            input = System.IO.File.ReadAllLines(path);
        }

        public string puzzleOne()
        {
            string correctedMessage = "";
            int messageLength = input[0].Length;
            
            Dictionary<char, int>[] letters = new Dictionary<char, int>[messageLength];

            for (int i = 0; i < messageLength; ++i)
            {
                letters[i] = new Dictionary<char, int>();
            }

            foreach (string repetition in input)
            {
                for (int i = 0; i < messageLength; ++i)
                {
                    if (!letters[i].ContainsKey(repetition[i]))
                    {
                        letters[i].Add(repetition[i], 1);
                    }
                    else
                    {
                        letters[i][repetition[i]] += 1;
                    }
                }
            }

            for (int i = 0; i < messageLength; ++i)
            {
                int highestValue = 0;
                char letter = ' ';

                foreach (char key in letters[i].Keys)
                {
                    if (letters[i][key] > highestValue)
                    {
                        highestValue = letters[i][key];
                        letter = key;
                    } 
                }
                correctedMessage += letter;
            }

            return correctedMessage;
        }

        public string puzzleTwo()
        {
            string correctedMessage = "";
            int messageLength = input[0].Length;

            Dictionary<char, int>[] letters = new Dictionary<char, int>[messageLength];

            for (int i = 0; i < messageLength; ++i)
            {
                letters[i] = new Dictionary<char, int>();
            }

            foreach (string repetition in input)
            {
                for (int i = 0; i < messageLength; ++i)
                {
                    if (!letters[i].ContainsKey(repetition[i]))
                    {
                        letters[i].Add(repetition[i], 1);
                    }
                    else
                    {
                        letters[i][repetition[i]] += 1;
                    }
                }
            }

            for (int i = 0; i < messageLength; ++i)
            {
                int lowestValue = -1;
                char letter = ' ';

                foreach (char key in letters[i].Keys)
                {
                    if (letters[i][key] < lowestValue || lowestValue == -1)
                    {
                        lowestValue = letters[i][key];
                        letter = key;
                    }
                }

                correctedMessage += letter;
            }

            return correctedMessage;
        }
    }
}
