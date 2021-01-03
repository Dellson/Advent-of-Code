using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace AdventOfCode2020
{
    class Day13
    {
        static string[] Input;
        static List<(int offset, int line, int currentOffset)> Buses = new List<(int offset, int line, int currentOffset)>();
        static int maxIter = 0;

        static Day13()
        {
            Input = Program.GetTextInputData("13");
            string[] arrivals = Input[1].Split(',');

            for (int i = 0; i < arrivals.Length; i++)
            {
                if (arrivals[i] != "x")
                {
                    Buses.Add((
                        i, 
                        Convert.ToInt32(arrivals[i]),
                        i));
                }
            }
        }

        public static void Puzzle()
        {
            //Puzzle1();
            Puzzle2();
        }

        private static void Puzzle1()
        {

        }

        private static void Puzzle2()
        {
            maxIter = Buses.Aggregate((result, bus) => (1, result.line * bus.line, 1)).line;
            Buses = Buses.OrderBy(Bus => Bus.line).ToList();
            int index = Buses.Count - 1;
            //int timestamp = 0;

            //Console.Write(maxIter);

            for (long timestamp = Buses[index].line; true; timestamp += Buses[index].line)
            {
                bool busesOk = true;

                //if (timestamp == 3420)
                //{
                //    //Console.WriteLine("debug");
                //}

                for (int b = 0; b <= index; b++)
                {
                    if (!((timestamp + Buses[b].offset - Buses[index].offset) % Buses[b].line == 0))
                    {
                        //Console.WriteLine(timestamp);
                        busesOk = false;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }

                if (busesOk)
                {
                    Console.WriteLine($"timestamp: {timestamp - Buses[index].offset}");
                    break;
                }
            }
            Console.WriteLine("finished");
        }

        private static int GetTimestamp(int index, int timestamp)
        {
            for (int i = Buses[index].offset; i < maxIter; i += Buses[index].line)
            {
                if ((i - Buses[index].offset) % Buses[index].line == 0)
                {
                    if (Buses[index] == Buses.Last())
                    {
                        return i;
                    }
                    else
                    {
                        return GetTimestamp(index + 1, i);
                    }
                }
            }

            throw new InvalidOperationException();
        }
    }
}