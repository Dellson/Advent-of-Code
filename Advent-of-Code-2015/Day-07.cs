using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent_of_Code_2015
{
    class Day_07
    {
        private static string[] input = System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-07-input.txt");
        private static Dictionary<string, Wire> wires = new Dictionary<string, Wire>();

        public static int BothStars()
        {
            List<List<string>> instructions = new List<List<string>>();

            foreach (var command in input)
                instructions.Add(new List<string>(command.Split(' ')));

            foreach (var instruction in instructions)
            {
                foreach (var i in instruction)
                {
                    if (int.TryParse(i, out var n))
                        continue;

                    if (i != "->" && i != "AND" && i != "OR" && i != "NOT" && i != "LSHIFT" && i != "RSHIFT")
                        if (!wires.ContainsKey(i)) { wires.Add(i, new Wire()); }
                }

                if (instruction[1] == "->")
                    try { wires[instruction[2]].parents.Add(wires[instruction[0]]); } catch (KeyNotFoundException) { }

                if (instruction[0] == "NOT")
                    try { wires[instruction[3]].parents.Add(wires[instruction[1]]); } catch (KeyNotFoundException) { }

                if (instruction[1] == "AND" || instruction[0] == "OR" || instruction[1] == "LSHIFT" || instruction[1] == "RSHIFT")
                {
                    try { wires[instruction[4]].parents.Add(wires[instruction[0]]); } catch (KeyNotFoundException) { }
                    try { wires[instruction[4]].parents.Add(wires[instruction[2]]); } catch (KeyNotFoundException) { }
                }
            }
            
            while (Wire.parentsHaveSignal < wires.Count)
            {
                foreach (var instruction in instructions)
                {
                    if (instruction[1] == "->")
                    {
                        if (int.TryParse(instruction[0], out int val))
                        {
                            wires[instruction[2]].value = Convert.ToInt32(instruction[0]);
                            wires[instruction[2]].IncrementParents();
                            instruction.Add("SKIP");
                        }
                        else
                        {
                            if (wires[instruction[0]].myParentsHaveSignal == 1)
                            {
                                wires[instruction[2]].value = wires[instruction[0]].value;
                                wires[instruction[2]].IncrementParents();
                                instruction.Add("SKIP");
                            }
                        }
                    }

                    if (instruction[0] == "NOT")
                    {
                        int val = 0;

                        if (!int.TryParse(instruction[1], out val))
                            val = wires[instruction[1]].value;

                        if (wires[instruction[1]].myParentsHaveSignal == 1)
                        {
                            wires[instruction[3]].value = (~val < 0) ? wires[instruction[3]].value = 65536 + ~val : ~val;
                            wires[instruction[3]].IncrementParents();
                            instruction.Add("SKIP");
                        }
                    }

                    if (instruction[1] == "AND" || instruction[1] == "OR" || instruction[1] == "LSHIFT" || instruction[1] == "RSHIFT")
                    {
                        int val1 = 0;
                        int val2 = 0;

                        if (!int.TryParse(instruction[0], out val1))
                        {
                            val1 = wires[instruction[0]].value;
                            if (wires[instruction[0]].myParentsHaveSignal == 0)
                                continue;
                        }


                        if (!int.TryParse(instruction[2], out val2))
                        {
                            val2 = wires[instruction[2]].value;
                            if (wires[instruction[2]].myParentsHaveSignal == 0)
                                continue;
                        }

                        wires[instruction[4]].IncrementParents();

                        if (instruction[1] == "AND")
                            wires[instruction[4]].value = val1 & val2;
                        if (instruction[1] == "OR")
                            wires[instruction[4]].value = val1 | val2;
                        if (instruction[1] == "LSHIFT")
                            wires[instruction[4]].value = val1 << val2;
                        if (instruction[1] == "RSHIFT")
                            wires[instruction[4]].value = val1 >> val2;

                        instruction.Add("SKIP");
                    }
                }
                //Console.WriteLine(Wire.parentsHaveSignal + " " + wires.Count);
                instructions.RemoveAll(instruction => instruction.Last() == "SKIP");
            }
            Console.WriteLine(wires["a"].value);
            return wires["a"].value;
        }

        public class Wire
        {
            public int myParentsHaveSignal = 0;
            public static int parentsHaveSignal = 0;
            public int value = 0;
            public List<Wire> parents = new List<Wire>();

            public void IncrementParents()
            {
                myParentsHaveSignal++;
                parentsHaveSignal++;
            }
        }
    }
}
