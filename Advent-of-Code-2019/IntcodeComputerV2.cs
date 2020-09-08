using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2019
{
    public class IntcodeComputerV2
    {
        public List<long> Instructions;
        private long output = -1;
        private int pointer = 0;

        public IntcodeComputerV2(string fileName)
        {
            string rawInput =
                File.ReadAllLines(Program.InputFolderPath + fileName)[0];

            long[] arrOriginal = Regex.Matches(rawInput, @"-?\d+")
                .Cast<Match>()
                .Select(number => Convert.ToInt64(number.Value))
                .ToArray();

            Instructions = new List<long>(arrOriginal);
        }

        public long CalculateOutput(params long[] inputParams)
        {
            IEnumerable<long> input = inputParams.ToList();
            var enumerator = input.GetEnumerator();

            for (; pointer < Instructions.Count;)
            {
                string command = Instructions[pointer].ToString().PadLeft(4, '0');
                string opcode = command.Substring(command.Length - 2, 2);

                long paramOne = 0;
                long paramTwo = 0;

                if (opcode != "03" && opcode != "04" && opcode != "99")   // TODO code smell
                {
                    paramOne = command[1] == '0' ? Instructions[(int)Instructions[pointer + 1]] : Instructions[pointer + 1];
                    paramTwo = command[0] == '0' ? Instructions[(int)Instructions[pointer + 2]] : Instructions[pointer + 2];
                }

                switch (opcode)
                {
                    case "01":
                        Instructions[(int)Instructions[pointer + 3]] = paramOne + paramTwo;
                        pointer += 4;
                        break;

                    case "02":
                        Instructions[(int)Instructions[pointer + 3]] = paramOne * paramTwo;
                        pointer += 4;
                        break;

                    case "03":
                        enumerator.MoveNext();
                        Instructions[(int)Instructions[pointer + 1]] = enumerator.Current;
                        pointer += 2;
                        break;

                    case "04":
                        output = command[1] == '0' ? Instructions[(int)Instructions[pointer + 1]] : Instructions[pointer + 1];
                        pointer += 2;
                        return output;

                    case "05":  
                        pointer = (paramOne != 0) ? (int)paramTwo : pointer + 3;
                        break;

                    case "06":
                        pointer = (paramOne == 0) ? (int)paramTwo : pointer + 3;
                        break;

                    case "07":
                        Instructions[(int)Instructions[pointer + 3]] = (paramOne < paramTwo) ? 1 : 0;
                        pointer += 4;
                        break;

                    case "08":
                        Instructions[(int)Instructions[pointer + 3]] = (paramOne == paramTwo) ? 1 : 0;
                        pointer += 4;
                        break;

                    case "99":
                        return -1;

                    default:
                        throw new ArgumentException("Invalid opcode value");
                }
            }

            return output;
        }
    }
}
