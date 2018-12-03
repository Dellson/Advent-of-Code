using System;
using System.Collections.Generic;
using System.IO;

namespace Advent_of_Code
{
    class DayTwentyFive : DayTwelve
    {
        private new  List<Instruction> commands = new List<Instruction>();
        private string signalSent = "";

        public DayTwentyFive()
        {
            path = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\DayTwentyFiveInput.txt");

            foreach (string command in File.ReadAllLines(path))
                commands.Add(new Instruction(command));
        }

        public new void puzzle()
        {
            int i = 0;
            string searchedSignal = "01010101";

            while (true)
            {
                registers = new Dictionary<string, int>()
                {
                    { "a", i }, {"b", 0 }, { "c", 0 }, { "d", 0 }
                };

                for (int inputIndex = 0; inputIndex < commands.Count; inputIndex++)
                {
                    processInstruction(ref inputIndex);
                    if (signalSent.Length == searchedSignal.Length) break;
                }
                //Console.WriteLine(signalSent);
                if (signalSent.Equals(searchedSignal))
                    break;
                i++;
                signalSent = "";
            }
            Console.WriteLine(i);
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
            else if (command.type.Equals("out"))
                out_(command);
            return;
        }

        private void out_(Instruction command)
        {
            int value = -1;
            if (!int.TryParse(command.value1, out value))
                signalSent += registers[command.value1];
            else
                signalSent += value;
        }
    }
}