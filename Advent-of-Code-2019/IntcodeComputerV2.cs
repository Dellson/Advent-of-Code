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
        public int Output => Instructions[0];

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

        public int CalculateOutput()
        {
            for (int pointer = 0; pointer < Instructions.Count && Instructions[pointer] != 99;)
            {
                string opcode = Instructions[pointer].ToString().PadLeft(2, '0');
                int paramOne = Instructions[Instructions[pointer + 1]];
                int paramTwo = Instructions[Instructions[pointer + 2]];

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
                    case "99":
                        break;
                    default:
                        throw new ArgumentException("Invalid opcode value");
                }
            }

            return Output;
        }
    }
}
