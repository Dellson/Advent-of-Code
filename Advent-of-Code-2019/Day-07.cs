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
                //IEnumerable<int> innerArray = new List<int> { 4, 3, 2, 1, 0 };

                inputsArraysAndCorrespondingOutputs.Add(
                    (inputArray.ToArray(), 
                    GetOutputForGivenInputPhasesSet(new IntcodeComputer(), inputReference, inputArray.ToArray())));
            }

            var result = inputsArraysAndCorrespondingOutputs.Max(iaco => iaco.Item2);

            Console.WriteLine(result);

            //}
        }

        private static int GetOutputForGivenInputPhasesSet(IntcodeComputer ic, List<int> inputInstructionsCopy, int[] _phaseValues)
        {
            var phaseValues = _phaseValues.ToList();
            List<int> amplifierOutputs = new List<int>();
            var currentInstruction = new List<int>(inputInstructionsCopy);
            var input = ic.CalculateOutput(ref currentInstruction, 0, phaseValues[0]);
            phaseValues.RemoveAt(0);

            foreach (int phaseValue in phaseValues)
            {
                ic = new IntcodeComputer();
                input = ic.CalculateOutput(ref currentInstruction, input, phaseValue);
                amplifierOutputs.Add(input);
                currentInstruction = ic.inputData;
            }

            if (phaseValues[0] == 4 &&
                phaseValues[1] == 3 &&
                phaseValues[2] == 2 &&
                phaseValues[3] == 4 &&
                phaseValues[4] == 3)
            {
                Console.WriteLine();
            }


            return amplifierOutputs.Last();
        }
    }
}