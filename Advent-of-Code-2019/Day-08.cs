using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent_of_Code_2019
{
    class Day_08
    {
        static List<List<List<int>>> layers = new List<List<List<int>>>();
        static List<string> oneDimLayers = new List<string>();
        const int maxWidth = 25;
        const int maxHeight = 6;

        public static void Puzzle()
        {
            var inputData = File.ReadAllLines(Program.InputFolderPath + "Day-08-input.txt")[0];

            for (int i = 0; i < inputData.Length; i+= (maxHeight * maxWidth))
                oneDimLayers.Add(inputData.Substring(i, (maxHeight * maxWidth)));

            var maxval = oneDimLayers.Min(layer => layer.Count(c => c == '0'));
            var matchingLayer = oneDimLayers.Find(layer => layer.Count(c => c == '0') == maxval);

            Console.WriteLine($"Puzzle one answer: {matchingLayer.Count(l => l == '1') * matchingLayer.Count(l => l == '2')}");
        }
    }
}