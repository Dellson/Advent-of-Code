using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2019
{
    class Day_05
    {
        static int input = 5;
        static List<int> outputs = new List<int>();

        public static void Puzzle()
        {
            var list =
                File.ReadAllLines(Program.InputFolderPath + "Day-05-input.txt")[0];

            var arrOriginal = Regex.Matches(list, @"-?\d+")
                .Cast<Match>()
                .Select(number => Convert.ToInt32(number.Value))
                .ToArray();

            int[] arr = new int[arrOriginal.Length];
            arrOriginal.CopyTo(arr, 0);

            Console.WriteLine($"Puzzle one answer {CalculateOutput(arrOriginal)}");
        }

        private static int CalculateOutput(int[] array)
        {
            for (int i = 0; i < array.Length && array[i] != 99;)
            {
                if (array[i] == 99)
                    break;

                int increment = 0;
                string code = array[i].ToString().PadLeft(4, '0');
                int pointer = code.Length - 2;
                string opcode = code.Substring(pointer);
                int mode1 = Convert.ToInt32(code[--pointer].ToString());
                int mode2 = Convert.ToInt32(code[--pointer].ToString());

                if (opcode == "01")
                {
                    int firstVal = mode1 == 0 ? array[array[i + 1]] : array[i + 1];
                    int secondVal = mode2 == 0 ? array[array[i + 2]] : array[i + 2];

                    array[array[i + 3]] = firstVal + secondVal;

                    increment = 4;
                }
                else if (opcode == "02")
                {
                    int firstVal = mode1 == 0 ? array[array[i + 1]] : array[i + 1];
                    int secondVal = mode2 == 0 ? array[array[i + 2]] : array[i + 2];

                    array[array[i + 3]] = firstVal * secondVal;

                    increment = 4;
                }
                else if (opcode == "03")
                {
                    array[array[i + 1]] = input;

                    increment = 2;
                }
                else if (opcode == "04")
                {
                    outputs.Add(array[array[i + 1]]);

                    increment = 2;
                }
                else if (opcode == "05")
                {
                    int firstVal = mode1 == 0 ? array[array[i + 1]] : array[i + 1];
                    int secondVal = mode2 == 0 ? array[array[i + 2]] : array[i + 2];

                    if (firstVal != 0)
                        i = secondVal;
                    else
                        increment = 3;
                }
                else if (opcode == "06")
                {
                    int firstVal = mode1 == 0 ? array[array[i + 1]] : array[i + 1];
                    int secondVal = mode2 == 0 ? array[array[i + 2]] : array[i + 2];

                    if (firstVal == 0)
                        i = secondVal;
                    else
                        increment = 3;
                }
                else if (opcode == "07")
                {
                    int firstVal = mode1 == 0 ? array[array[i + 1]] : array[i + 1];
                    int secondVal = mode2 == 0 ? array[array[i + 2]] : array[i + 2];

                    array[array[i + 3]] = (firstVal < secondVal) ? 1 : 0;

                    increment = 4;
                }
                else if (opcode == "08")
                {
                    int firstVal = mode1 == 0 ? array[array[i + 1]] : array[i + 1];
                    int secondVal = mode2 == 0 ? array[array[i + 2]] : array[i + 2];

                    array[array[i + 3]] = (firstVal == secondVal) ? 1 : 0;

                    increment = 4;
                }

                i += increment;
            }

            return outputs.Last();
        }
    }
}