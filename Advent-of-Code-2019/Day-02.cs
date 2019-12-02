using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2019
{
    class Day_02
    {
        public static void Puzzle()
        {
            var list =
                File.ReadAllLines(Program.InputFolderPath + "Day-02-input.txt")[0];

            var arrOriginal = Regex.Matches(list, @"-?\d+")
                .Cast<Match>()
                .Select(number => Convert.ToInt32(number.Value))
                .ToArray();

            int[] arr = new int[arrOriginal.Length];
            arrOriginal.CopyTo(arr, 0);

            Console.WriteLine($"Puzzle one answer {CalculateOutput(arrOriginal, 12, 2, 12, 2)}");
            Console.WriteLine($"Puzzle two answer {CalculateOutput(arrOriginal, 0, 0, arrOriginal.Length - 1, arrOriginal.Length - 1)}");
        }

        private static int CalculateOutput(int[] originalArray, int valueOneStart, int valueTwoStart, int valueOneMax, int valueTwoMax)
        {
            int[] array = new int[originalArray.Length];

            for (int j = valueOneStart; j <= valueOneMax; j++)
            {
                for (int k = valueTwoStart; k <= valueTwoMax; k++)
                {
                    originalArray.CopyTo(array, 0);
                    array[1] = j;
                    array[2] = k;

                    for (int i = 0; i < array.Length && array[i] != 99; i+=4)
                    {
                        if (array[i] == 1)
                            array[array[i + 3]] = array[array[i + 1]] + array[array[i + 2]];

                        else if (array[i] == 2)
                            array[array[i + 3]] = array[array[i + 1]] * array[array[i + 2]];
                    }

                    if (array[0] == 19690720)
                        return (j * 100 + k);
                }
            }

            return array[0];
        }
    }
}