using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Advent_of_Code_2017
{
    class Day_21
    {
        private static List<string[]> rules = new List<string[]>();
        private static List<StringBuilder> images = new List<StringBuilder> { new StringBuilder(".#."), new StringBuilder("..#"), new StringBuilder("###") };
        /**/
        public static void Puzzle()
        {
            int count = 0;

            foreach (string rule in File.ReadAllLines(Program.InputFolderPath + "Day-21-input.txt"))
                rules.Add(new string[2] { rule.Replace(" => ", ":").Split(':')[0], rule.Replace(" => ", ":").Split(':')[1]});

            for (int i = 0; i < 18; ++i)
            {
                List<StringBuilder> tempImages = new List<StringBuilder>();
                int length = images[0].ToString().Length % 2 == 0 ? 2 : 3;

                for (int j = 0; j < images[0].ToString().Length; j += length)
                {
                    for (int h = 0; h < length; ++h)
                        tempImages.Add(new StringBuilder());
                    tempImages.Add(new StringBuilder());

                    for (int h = 0; h < images[0].ToString().Length; h += length)
                    {
                        StringBuilder currentItem = new StringBuilder();
                        for (int k = 0; k < length; ++k)
                            currentItem.Append(images[j + k].ToString().Substring(h, length) + "/");

                        List<string> expanded = FindMatchingRule(currentItem.ToString().TrimEnd('/'));

                        for (int k = 0; k < expanded.Count; ++k)
                            tempImages[tempImages.Count - expanded.Count + k].Append(expanded[k]);
                    }
                }
                images = tempImages;
            }
            foreach (var block in images)
                foreach (char c in block.ToString())
                    if (c == '#')
                        count++;

            Console.WriteLine(count);
        }
        /**/
        private static List<string> FindMatchingRule(string tempImage)
        {
            foreach (var value in Permutate(tempImage.Split('/').ToList()))
            {
                string valueToString = string.Join("/", value);

                foreach (var rule in rules)
                    if (valueToString == rule[0])
                        return rule[1].Split('/').ToList();
            }
            return null;
        }
        /**/
        public static List<string> RotateArrayByNinetyDegree(List<string> input)
        {
            char[][] output = new char[input.Count][];
            List<string> listOutput = new List<string>();

            for (int i = 0; i < input.Count; i++)
            {
                int k = 0;
                output[i] = new char[input.Count];
                for (int j = input.Count - 1; j >= 0; j--, k++)
                    output[i][k] = input[j][i];
            }
            for (int i = 0; i < input.Count; i++)
                listOutput.Add(new string(output[i]));

            return listOutput;
        }
        /**/
        private static List<List<string>> Permutate(List<string> input)
        {
            List<List<string>> possibilites = new List<List<string>> { input, input.ToArray().Reverse().ToList() };

            for (int i = 0; i < 3; ++i)
            {
                possibilites.Add(RotateArrayByNinetyDegree(possibilites[possibilites.Count - 1]).ToList());
                possibilites.Add(RotateArrayByNinetyDegree(possibilites[possibilites.Count - 2]).ToList());
            }
            return possibilites;
        }
    }
}
