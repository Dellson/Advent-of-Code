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
        //private static List<Tuple<int, int, int, int, int>> commands = new List<Tuple<int, int, int, int, int>>();
        //const int size = 1000;

        public static void BothStars()
        {
            Dictionary<string, int> output = new Dictionary<string, int>();

            Console.WriteLine(0 >> 2);

            for (int f = 0; f < 50; ++f){
                foreach (var command in input)
                {
                    //string[] instruction = command.Split(' ');

                    var matches = Regex.Matches(command, @"\w+");

                    /*foreach (Match match in matches)
                    {
                        Console.Write(match.Value + " ");
                    }*/

                    foreach (Match i in matches)
                    {
                        if (i.Value != "->" && i.Value != "AND" && i.Value != "OR" && i.Value != "NOT" && i.Value != "LSHIFT" && i.Value != "RSHIFT")
                        {

                            try
                            {
                                Convert.ToInt32(i.Value);
                            }
                            catch (ArgumentException) { }
                            catch (FormatException)
                            { if (!output.ContainsKey(i.Value)) { /*Console.WriteLine(i.Value); */output.Add(i.Value, 0); } }
                        }
                    }

                    string[] instruction = command.Split(' ');


                    if (instruction[1] == "->")
                    {
                        try
                        {
                            output[instruction[2]] = Convert.ToInt32(instruction[0]);
                        }
                        catch (FormatException)
                        {
                            output[instruction[2]] = output[instruction[0]];
                        }

                    }

                    if (instruction[0] == "NOT")
                    {
                        int val1 = 0;
                        int val2 = 0;
                        try
                        {
                            val1 = Convert.ToInt32(instruction[1]);
                        }
                        catch (FormatException)
                        {
                            val1 = output[instruction[1]];
                        }

                        try
                        {
                            val2 = Convert.ToInt32(instruction[3]);
                        }
                        catch (FormatException)
                        {
                            val2 = output[instruction[3]];
                        }


                        output[instruction[3]] = ~val1;
                        // 65535
                        if (~val1 < 0)
                            output[instruction[3]] = 65536 + ~val1;


                        /*output[instruction[3]] = ~output[instruction[1]];
                        // 65535
                        if (~output[instruction[1]] < 0)
                            output[instruction[3]] = 65536 + ~output[instruction[1]];*/
                    }

                    ///

                    /*foreach (var n in instruction)
                        Console.Write(n + " ");
                    Console.WriteLine();*/

                    if (instruction[1] == "AND")
                    {
                        int val1 = 0;
                        int val2 = 0;
                        try
                        {
                            val1 = Convert.ToInt32(instruction[0]);
                        }
                        catch (FormatException)
                        {
                            val1 = output[instruction[0]];
                        }

                        try
                        {
                            val2 = Convert.ToInt32(instruction[2]);
                        }
                        catch (FormatException)
                        {
                            val2 = output[instruction[2]];
                        }


                        output[instruction[4]] = val1 & val2;
                    }
                    // x AND y -> d

                    if (instruction[1] == "OR")
                    {
                        int val1 = 0;
                        int val2 = 0;
                        try
                        {
                            val1 = Convert.ToInt32(instruction[0]);
                        }
                        catch (FormatException)
                        {
                            val1 = output[instruction[0]];
                        }

                        try
                        {
                            val2 = Convert.ToInt32(instruction[2]);
                        }
                        catch (FormatException)
                        {
                            val2 = output[instruction[2]];
                        }


                        output[instruction[4]] = val1 | val2;
                    }

                    if (instruction[1] == "LSHIFT")
                    {
                        int val1 = 0;
                        int val2 = 0;
                        try
                        {
                            val1 = Convert.ToInt32(instruction[0]);
                        }
                        catch (FormatException)
                        {
                            val1 = output[instruction[0]];
                        }

                        try
                        {
                            val2 = Convert.ToInt32(instruction[2]);
                        }
                        catch (FormatException)
                        {
                            val2 = output[instruction[2]];
                        }


                        output[instruction[4]] |= val1 << val2;
                    }

                    if (instruction[1] == "RSHIFT")
                    {
                        int val1 = 0;
                        int val2 = 0;
                        try
                        {
                            val1 = Convert.ToInt32(instruction[0]);
                        }
                        catch (FormatException)
                        {
                            val1 = output[instruction[0]];
                        }

                        try
                        {
                            val2 = Convert.ToInt32(instruction[2]);
                        }
                        catch (FormatException)
                        {
                            val2 = output[instruction[2]];
                        }


                        output[instruction[4]] |= val1 >> val2;
                    }

                    /*foreach (string s in instruction)
                    {
                        if (s[1] == "->")
                    }*/

                }
            }
            


            foreach (var item in output)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
            Console.WriteLine(0 << 2);
            //Console.WriteLine(output["a"]);
        }
    }
}
