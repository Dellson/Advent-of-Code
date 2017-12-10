using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    class Day_07
    {
        private static string[] input = System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-07-input.txt");
        private static List<Wire> wires = new List<Wire>();
        public static void BothStars()
        {
            
            foreach (var command in input)
            {
                var matches = Regex.Matches(command, @"\w+");

                foreach (Match i in matches)
                {
                    if (i.Value != "->" && i.Value != "AND" && i.Value != "OR" && i.Value != "NOT" && i.Value != "LSHIFT" && i.Value != "RSHIFT")
                    {
                        try { Convert.ToInt32(i.Value); }
                        catch (FormatException)
                        { if (!wires.Exists(w => w.name == i.Value)) { wires.Add(new Wire(i.Value)); } }
                    }
                }
            }

            List<List<string>> instructions = new List<List<string>> ();
            foreach (var command in input)
                instructions.Add(new List<string> (command.Split(' ')));


            foreach (var instruction in instructions)
            {
                if (instruction[1] == "->")
                {
                    try
                    {
                        wires.Find(w => w.name == instruction[2]).value = Convert.ToInt32(instruction[0]);
                    }
                    catch (FormatException)
                    {
                        wires.Find(w => w.name == instruction[2]).parents.Add(wires.Find(w => w.name == instruction[0]));
                    }                    
                }

                if (instruction[0] == "NOT")
                {
                    try
                    {
                        Convert.ToInt32(instruction[1]);
                    }
                    catch (FormatException)
                    {
                        wires.Find(w => w.name == instruction[3]).parents.Add(wires.Find(w => w.name == instruction[1]));
                    }
                }

                if (instruction[1] == "AND" || instruction[0] == "OR" || instruction[1] == "LSHIFT" || instruction[1] == "RSHIFT")
                {
                    try { Convert.ToInt32(instruction[0]); }
                    catch (FormatException) { wires.Find(w => w.name == instruction[4]).parents.Add(wires.Find(w => w.name == instruction[0])); }
                    try { Convert.ToInt32(instruction[2]); }
                    catch (FormatException) { wires.Find(w => w.name == instruction[4]).parents.Add(wires.Find(w => w.name == instruction[2])); }
                }

                //wires.Find(w => w.name == instruction[2])
            }

            while (Wire.parentsHaveSignal < wires.Count)
            {
                foreach (var instruction in instructions)
                {
                    //if (instruction[instruction.Count - 1] == "SKIP")
                      //  continue;

                    if (instruction[1] == "->")
                    {
                        Wire wire = wires.Find(w => w.name == instruction[2]);
                        try { wire.value = Convert.ToInt32(instruction[0]); wire.IncrementParents(); instruction.Add("SKIP"); }
                        catch (FormatException)
                        {
                            Wire otherWire = wires.Find(w => w.name == instruction[0]);
                            if (otherWire.myParentsHaveSignal == 1)
                            {
                                wire.value = otherWire.value;
                                wire.IncrementParents();
                                
                                instruction.Add("SKIP");
                            }
                        }
                        Console.WriteLine(wire.myParentsHaveSignal);
                    }

                    if (instruction[0] == "NOT")
                    {
                        int val1 = 0;
                        try { val1 = Convert.ToInt32(instruction[1]); }
                        catch (FormatException) { val1 = wires.Find(w => w.name == instruction[1]).value; }

                        if (wires.Find(w => w.name == instruction[1]).myParentsHaveSignal == 1)
                        {
                            wires.Find(w => w.name == instruction[3]).value = ~val1;
                            if (~val1 < 0)
                                wires.Find(w => w.name == instruction[3]).value = 65536 + ~val1;
                            wires.Find(w => w.name == instruction[3]).IncrementParents();
                            instruction.Add("SKIP");
                        }
                    }

                    if (instruction[1] == "AND" || instruction[1] == "OR" || instruction[1] == "LSHIFT" || instruction[1] == "RSHIFT")
                    {
                        int val1 = 0;
                        int val2 = 0;
                        try { val1 = Convert.ToInt32(instruction[0]); }
                        catch (FormatException) { val1 = wires.Find(w => w.name == instruction[0]).value; if (wires.Find(w => w.name == instruction[0]).myParentsHaveSignal == 0)
                                continue;
                        }
                        try { val2 = Convert.ToInt32(instruction[2]); }
                        catch (FormatException) { val2 = wires.Find(w => w.name == instruction[2]).value; if (wires.Find(w => w.name == instruction[2]).myParentsHaveSignal == 0)
                            {
                                continue;
                            }
                            
                        }
                        //Console.WriteLine("X"+instruction[1] + "X");
                        wires.Find(w => w.name == instruction[4]).IncrementParents();

                        if (instruction[1] == "AND")
                            wires.Find(w => w.name == instruction[4]).value = val1 & val2;
                        if (instruction[1] == "OR")
                            wires.Find(w => w.name == instruction[4]).value = val1 | val2;
                        if (instruction[1] == "LSHIFT")
                            wires.Find(w => w.name == instruction[4]).value = val1 << val2;                            
                        if (instruction[1] == "RSHIFT")
                            wires.Find(w => w.name == instruction[4]).value = val1 >> val2;

                        instruction.Add("SKIP");
                    }
                }
                
                instructions.RemoveAll(instruction => instruction.Last() == "SKIP");
            }

            Console.WriteLine(wires.Find(w => w.name == "a").value);
        }

        public class Wire
        {
            public int myParentsHaveSignal = 0;
            public static int parentsHaveSignal = 0;
            public string name;
            public int value = 0;
            public List<Wire> parents = new List<Wire>();

            public Wire(string name) { this.name = name; }
            public void IncrementParents()
            {
                myParentsHaveSignal++;
                parentsHaveSignal++;
            }
        }
    }
}
