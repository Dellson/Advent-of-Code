using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent_of_Code_2019
{
    class Day_08
    {
        private static List<string> oneDimLayers = new List<string>();
        const int maxWidth = 25;
        const int maxHeight = 6;

        static Day_08()
        {
            string inputData = File.ReadAllLines(Program.InputFolderPath + "Day-08-input.txt")[0];

            for (int i = 0; i < inputData.Length; i += maxHeight * maxWidth)
                oneDimLayers.Add(inputData.Substring(i, maxHeight * maxWidth));
        }

        public static void Puzzle()
        {
            Func<string, char, int> digitCounter = (layer, target) => layer.Count(c => c == target);            
            int maxval = oneDimLayers.Min(layer => digitCounter(layer, '0'));
            string matchingLayer = oneDimLayers.Find(layer => digitCounter(layer, '0') == maxval);

            Console.WriteLine($"Puzzle one answer: {digitCounter(matchingLayer, '1') * digitCounter(matchingLayer, '2')}");
            Console.WriteLine($"\nPuzzle two answer:");
            
            string image = FlattenMessage(oneDimLayers);

            for (int i = 0; i < image.Length; i++)
            {
                if (i % maxWidth == 0)
                    Console.WriteLine();

                Console.Write((image[i] == '1') ? "[]" : "  ");
            }
        }

        private static string FlattenMessage(List<string> layers)
        {
            char[] destLayer = layers[0].ToCharArray();

            foreach (string layer in layers)
            {
                for (int i = 0; i < layer.Length; i++)
                {
                    if (destLayer[i] == '2')
                        destLayer[i] = layer[i];
                }
            }

            return new string(destLayer);
        }
    }
}