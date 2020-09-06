using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2019
{
    public class IntcodeComputerV2
    {
        public List<int> Instructions;
        private int output = -1;

        public IntcodeComputerV2(string fileName)
        {
            string rawInput =
                File.ReadAllLines(Program.InputFolderPath + fileName)[0];

            int[] arrOriginal = Regex.Matches(rawInput, @"-?\d+")
                .Cast<Match>()
                .Select(number => Convert.ToInt32(number.Value))
                .ToArray();

            Instructions = new List<int>(arrOriginal);
        }

        public int CalculateOutput(params int[] inputParams)
        {
            IEnumerable<int> input = inputParams.ToList();
            var enumerator = input.GetEnumerator();

            for (int pointer = 0; pointer < Instructions.Count && Instructions[pointer] != 99;)
            {
                string command = Instructions[pointer].ToString().PadLeft(4, '0');
                string opcode = command.Substring(command.Length - 2, 2);

                int paramOne = 0;
                int paramTwo = 0;

                if (opcode != "03" && opcode != "04")   // TODO code smell
                {
                    paramOne = command[1] == '0' ? Instructions[Instructions[pointer + 1]] : Instructions[pointer + 1];
                    paramTwo = command[0] == '0' ? Instructions[Instructions[pointer + 2]] : Instructions[pointer + 2];
                }

                switch (opcode)
                {
                    case "01":
                        Instructions[Instructions[pointer + 3]] = paramOne + paramTwo;
                        pointer += 4;
                        break;

                    case "02":
                        Instructions[Instructions[pointer + 3]] = paramOne * paramTwo;
                        pointer += 4;
                        break;

                    case "03":
                        enumerator.MoveNext();
                        Instructions[Instructions[pointer + 1]] = enumerator.Current;
                        pointer += 2;
                        break;

                    case "04":
                        output = Instructions[Instructions[pointer + 1]];
                        pointer += 2;
                        break;

                    case "05":  
                        pointer = (paramOne != 0) ? paramTwo : pointer + 3;
                        break;

                    case "06":
                        pointer = (paramOne == 0) ? paramTwo : pointer + 3;
                        break;

                    case "07":
                        Instructions[Instructions[pointer + 3]] = (paramOne < paramTwo) ? 1 : 0;
                        pointer += 4;
                        break;

                    case "08":
                        Instructions[Instructions[pointer + 3]] = (paramOne == paramTwo) ? 1 : 0;
                        pointer += 4;
                        break;

                    case "99":
                        break;

                    default:
                        throw new ArgumentException("Invalid opcode value");
                }
            }

            return output;
        }
    }
}
