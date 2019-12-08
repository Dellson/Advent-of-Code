using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent_of_Code_2019
{
    public class IntcodeComputer
    {
        private List<int> outputs;
        public List<int> inputData { get; private set; }

        public int CalculateOutput(List<int> list, int input)
        {
            inputData = list;
            outputs = new List<int>();

            for (int i = 0; i < list.Count && list[i] != 99;)
            {
                string code = list[i].ToString().PadLeft(4, '0');
                int pointer = code.Length - 2;
                string opcode = code.Substring(pointer);

                int firstVal = 0;
                int secondVal = 0;

                if (opcode == "03")
                {
                    list[list[i + 1]] = input;

                    i += 2;
                }
                else if (opcode == "04")
                {
                    outputs.Add(list[list[i + 1]]);

                    i += 2;
                }
                else
                {
                    firstVal = (code[--pointer] == '0')
                        ? list[list[i + 1]] : list[i + 1];

                    secondVal = (code[--pointer] == '0')
                        ? list[list[i + 2]] : list[i + 2];
                }

                if (opcode == "01")
                {
                    list[list[i + 3]] = firstVal + secondVal;

                    i += 4;
                }
                else if (opcode == "02")
                {
                    list[list[i + 3]] = firstVal * secondVal;

                    i += 4;
                }
                else if (opcode == "05")
                    i = (firstVal != 0) ? secondVal : i + 3;

                else if (opcode == "06")
                    i = (firstVal == 0) ? secondVal : i + 3;

                else if (opcode == "07")
                {
                    list[list[i + 3]] = (firstVal < secondVal) ? 1 : 0;

                    i += 4;
                }
                else if (opcode == "08")
                {
                    list[list[i + 3]] = (firstVal == secondVal) ? 1 : 0;

                    i += 4;
                }
            }

            return outputs.Last();
        }

        //public int CalculateOutput(List<int> array, int input)
        //{
        //    var inputArray = array.ToArray();
        //    return CalculateOutput(ref inputArray, input);
        //}

        internal int CalculateOutput(List<int> list, List<int> x, int input)
        {
            throw new NotImplementedException();
        }
    }
}
