using System.Collections.Generic;
using System.Linq;

namespace Advent_of_Code_2019
{
    public class IntcodeComputer
    {
        private static List<int> outputs = new List<int>();

        public static int CalculateOutput(int[] array, int input)
        {
            for (int i = 0; i < array.Length && array[i] != 99;)
            {
                string code = array[i].ToString().PadLeft(4, '0');
                int pointer = code.Length - 2;
                string opcode = code.Substring(pointer);

                int firstVal = 0;
                int secondVal = 0;

                if (opcode == "03")
                {
                    array[array[i + 1]] = input;

                    i += 2;
                }
                else if (opcode == "04")
                {
                    outputs.Add(array[array[i + 1]]);

                    i += 2;
                }
                else
                {
                    firstVal = (code[--pointer] == '0')
                        ? array[array[i + 1]] : array[i + 1];

                    secondVal = (code[--pointer] == '0')
                        ? array[array[i + 2]] : array[i + 2];
                }

                if (opcode == "01")
                {
                    array[array[i + 3]] = firstVal + secondVal;

                    i += 4;
                }
                else if (opcode == "02")
                {
                    array[array[i + 3]] = firstVal * secondVal;

                    i += 4;
                }
                else if (opcode == "05")
                    i = (firstVal != 0) ? secondVal : i + 3;

                else if (opcode == "06")
                    i = (firstVal == 0) ? secondVal : i + 3;

                else if (opcode == "07")
                {
                    array[array[i + 3]] = (firstVal < secondVal) ? 1 : 0;

                    i += 4;
                }
                else if (opcode == "08")
                {
                    array[array[i + 3]] = (firstVal == secondVal) ? 1 : 0;

                    i += 4;
                }
            }

            return outputs.Last();
        }

        public static int CalculateOutput(List<int> array, int input)
        {
            return CalculateOutput(array.ToArray(), input);
        }
    }
}
