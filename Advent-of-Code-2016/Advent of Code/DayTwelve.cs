using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Advent_of_Code
{
    class DayTwelve
    {
        protected string path = Directory.GetCurrentDirectory();
        protected Dictionary<string, int> registers = new Dictionary<string, int>();
        protected List<Instruction> commands = new List<Instruction>();

        public DayTwelve()
        {
            path = Path.Combine(path, "..\\..\\DayTwelveInput.txt");

            registers.Add("a", 0);
            registers.Add("b", 0);
            registers.Add("c", 1);
            registers.Add("d", 0);

            foreach (string command in File.ReadAllLines(path))
                commands.Add(new Instruction(command));
        }

        public void puzzle()
        {
            for (int inputIndex = 0; inputIndex < commands.Count; inputIndex++)
                processInstruction(ref inputIndex);
            printRegisters();
        }

        protected void processInstruction(ref int commandIndex)
        {
            Instruction command = commands[commandIndex];

            if (command.type.Equals("cpy"))
                cpy(command);
            else if (command.type.Equals("inc"))
                inc(command);
            else if (command.type.Equals("dec"))
                dec(command);
            else if (command.type.Equals("jnz"))
                jnz(command, ref commandIndex);
            return;
        }

        protected void cpy(Instruction command)
        {
            if (registers.ContainsKey(command.value1))
                registers[command.value2] = registers[command.value1];
            else
                registers[command.value2] = int.Parse(command.value1);
        }

        protected void inc(Instruction command)
        {
            registers[command.value1]++;
        }

        protected void dec(Instruction command)
        {
            registers[command.value1]--;
        }

        protected void jnz(Instruction command, ref int commandIndex)
        {
            if ((registers.ContainsKey(command.value1) && registers[command.value1] == 0) || command.value1 == "0") return;

            int jumpVal = 0;
            if (!int.TryParse(command.value2, out jumpVal))
                jumpVal = registers[command.value2];
            commandIndex += jumpVal - 1;
        }

        protected void printRegisters()
        {
            Console.WriteLine("REGISTERS");
            foreach (string key in registers.Keys)
            {
                Console.WriteLine("registers[" + key + "]: " + registers[key]);
            }
        }

        protected class Instruction
        {
            public string type = "";
            public string value1 = "";
            public string value2 = "";

            public Instruction(string command)
            {
                var matches = Regex.Matches(command, @"(\w+|[+-]?\d+)");
                if (matches[0].Value.Contains("cpy") || matches[0].Value.Contains("jnz"))
                {
                    type = matches[0].Value;
                    value1 = matches[1].Value;
                    value2 = matches[2].Value;
                }
                else if (matches[0].Value.Contains("inc") || matches[0].Value.Contains("dec") || matches[0].Value.Contains("tgl") || matches[0].Value.Contains("out"))
                {
                    type = matches[0].Value;
                    value1 = matches[1].Value;
                }
            }
        }
    }
}