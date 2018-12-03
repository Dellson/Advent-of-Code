using System;
using System.Collections.Generic;
using System.IO;

namespace Advent_of_Code
{
    class DayTwentyThree : DayTwelve
    {
        private new List<Instruction> commands = new List<Instruction>();

        public DayTwentyThree()
        {
            path = Directory.GetCurrentDirectory();
            path = Path.Combine(path, "..\\..\\DayTwentyThreeInput.txt");

            registers["a"] = 12;
            registers["b"] = 0;
            registers["c"] = 0;
            registers["d"] = 0;

            commands.Clear();

            foreach (string command in File.ReadAllLines(path))
                commands.Add(new Instruction(command));
        }

        public new void puzzle()
        {
            for (int inputIndex = 0; inputIndex < commands.Count; inputIndex++)
            { 
                // cheat do części nr 2
                if (inputIndex == 4)
                {
                    registers["a"] = registers["b"] * registers["d"];
                    registers["c"] = 0;
                    registers["d"] = 0;
                        inputIndex = 10;
                }
                ///////////////////////
                processInstruction(ref inputIndex);
            }
            printRegisters();
        }

        private new void processInstruction(ref int commandIndex)
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
            else if (command.type.Equals("tgl"))
                toggle(command, commandIndex);
            return;
        }

        private void toggle(Instruction command, int commandIndex)
        {
            int distance = commandIndex + registers[command.value1];
            string newCommand = "";
            try
            {
                if (commands[distance].type.Equals("inc"))
                    newCommand = "dec";
                else if (commands[distance].type.Equals("dec") || (commands[distance].type.Equals("tgl")))
                    newCommand = "inc";
                else if (commands[distance].type.Equals("cpy"))
                    newCommand = "jnz";
                else if (commands[distance].type.Equals("jnz"))
                    newCommand = "cpy";

                commands[distance].type = newCommand;
            }
            catch (ArgumentOutOfRangeException) { }
        }
    }
}