using Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using static Helpers.Helpers;

namespace Advent_of_Code_2019
{
    public static class Day_07
    {
         
        // phase == input
        private static int[] phaseValues;
        private const int numberOfAmplifiers = 5;
        private static int[] inputInstructions;
        static private List<int> currentResults = new List<int>();
        private static List<(int[], int)> inputsArraysAndCorrespondingOutputs = new List<(int[], int)>();

        static Day_07()
        {
            phaseValues = new int[] { 0, 1, 2, 3, 4 };
            var inputData = File.ReadAllLines(Program.InputFolderPath + "Day-07-input.txt")[0];

            inputInstructions = Regex.Matches(inputData, @"-?\d+")
                .Cast<Match>()
                .Select(number => Convert.ToInt32(number.Value))
                .ToArray();
        }
            
        public static void Puzzle()
        {
            

            var combinations = GetPermutations(new int[] { 0, 1, 2, 3, 4 }, 5);
            //IntcodeComputer ic = new IntcodeComputer();
            //inputsArraysAndCorrespondingOutputs.Add((new int[] { 0, 1, 2, 3, 4 }, GetOutputForGivenInputValuesSet(ic, ref inputInstructions, new int[] { 0, 1, 2, 3, 4 })));
            //inputsArraysAndCorrespondingOutputs.Add((new int[] { 0, 4, 4, 3, 4 }, GetOutputForGivenInputValuesSet(ic, ref inputInstructions, new int[] { 0, 4, 4, 3, 4 })));

            foreach (var inputArray in combinations)
            {
                //int[] instructionsCopy = new int[inputInstructions.Length];
                //Array.Copy(inputInstructions, instructionsCopy, inputInstructions.Length);
                var inputReference = inputInstructions.ToList();

                inputsArraysAndCorrespondingOutputs.Add(
                    (inputArray.ToArray(), 
                    GetOutputForGivenInputValuesSet(new IntcodeComputer(), inputReference, inputArray.ToArray())));

            }


            //var amplifierOutputs = GetOutputForGivenInputValuesSet(ic, instructionsCopy, iputValues).ToList();
            //var maxOutput = amplifierOutputs.Max(ao => ao.Item2);
            //int maxResultsIndex = amplifierOutputs.Where(
            //    ao => ao.Item2 == maxOutput).sele

            //currentResults.Add(maxOutput);
            //}

            //var maxval =  .Max(a => a.Item2);
            //inputsArraysAndCorrespondingOutputs.First(a => a.Item2 == maxval).Item1.ToList().ForEach(i => Console.Write(i));

            var result = inputsArraysAndCorrespondingOutputs.Max(iaco => iaco.Item2);

    Console.WriteLine();

            //int amplifierMaxValue = currentResults.Max();

            //for (int i = 0; i < currentResults.Count; i++)
            //{
            //    Console.Write(currentResults[i] + " ");
            //}
        }

        //private static int VVVV => return;

        private static int GetOutputForGivenInputValuesSet(IntcodeComputer ic, List<int> inputInstructionsCopy, int[] iputValues)
        {
            List<int> amplifierOutputs = new List<int>();
            var currentInstruction = new List<int>(inputInstructionsCopy);
            var data = ic.CalculateOutput(currentInstruction, 0);
            foreach (int input in iputValues)
            {
                ic.CalculateOutput(currentInstruction, input);
                data = ic.CalculateOutput(currentInstruction, data);
                amplifierOutputs.Add(data);
                currentInstruction = ic.inputData;
            }

            if (iputValues[0] == 4 &&
                iputValues[1] == 3 &&
                iputValues[2] == 2 &&
                iputValues[3] == 4 &&
                iputValues[4] == 3)
            {
                Console.WriteLine();
            }


            return amplifierOutputs.Last();
        }
    }
}