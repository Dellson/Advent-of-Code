using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2019
{
    public class IntcodeComputerV2
    {
        public List<long> Ints;
        private long output = -1;
        private int ptr = 0;
        private int relativeBase = 0;

        public IntcodeComputerV2(string fileName)
        {
            string rawInput =
                File.ReadAllLines(Program.InputFolderPath + fileName)[0];

            long[] arrOriginal = Regex.Matches(rawInput, @"-?\d+")
                .Cast<Match>()
                .Select(number => Convert.ToInt64(number.Value))
                .ToArray();

            Ints = new List<long>(arrOriginal);
        }

        public long CalculateOutput(params long[] inputParams)
        {
            IEnumerable<long> input = inputParams.ToList();
            var enumerator = input.GetEnumerator();

            for (; ptr < Ints.Count;)
            {
                string cmd = Ints[ptr].ToString().PadLeft(4, '0');
                string opcode = cmd.Substring(cmd.Length - 2, 2);

                long paramOne = 0;
                long paramTwo = 0;

                if (opcode != "03" && opcode != "04" && opcode != "09" && opcode != "99")
                {
                    paramOne = GetParamByMode(cmd[1], 1);
                    paramTwo = GetParamByMode(cmd[0], 2);
                }

                switch (opcode)
                {
                    case "01":
                        Ints[(int)Ints[ptr + 3]] = paramOne + paramTwo;
                        ptr += 4;
                        break;

                    case "02":
                        Ints[(int)Ints[ptr + 3]] = paramOne * paramTwo;
                        ptr += 4;
                        break;

                    case "03":
                        enumerator.MoveNext();
                        Ints[(int)Ints[ptr + 1]] = enumerator.Current;
                        ptr += 2;
                        break;

                    case "04":
                        output = GetParamByMode(cmd[1], 1);
                        ptr += 2;
                        return output;

                    case "05":
                        ptr = (paramOne != 0) ? (int)paramTwo : ptr + 3;
                        break;

                    case "06":
                        ptr = (paramOne == 0) ? (int)paramTwo : ptr + 3;
                        break;

                    case "07":
                        Ints[(int)Ints[ptr + 3]] = (paramOne < paramTwo) ? 1 : 0;
                        ptr += 4;
                        break;

                    case "08":
                        Ints[(int)Ints[ptr + 3]] = (paramOne == paramTwo) ? 1 : 0;
                        ptr += 4;
                        break;

                    case "09":
                        relativeBase += (int)GetParamByMode(cmd[1], 1);
                        break;

                    case "99":
                        return -1;

                    default:
                        throw new ArgumentException("Invalid opcode value");
                }
            }

            return output;
        }
    
        private long GetParamByMode(char mode, int argPos)
        {
            long param;

            switch (mode)
            {
                case '0':   // positional
                    param = Ints[
                        (int)Ints[ptr + argPos]]; 
                    break;

                case '1':   // immediate
                    param = Ints[ptr + argPos];
                    break;

                case '2':   // relative
                    param = Ints[
                        (int)Ints[ptr + argPos + relativeBase]];
                    break;

                default:
                    throw new ArgumentException("Invalid mode");
            }
            return param;
        }
    }
}
