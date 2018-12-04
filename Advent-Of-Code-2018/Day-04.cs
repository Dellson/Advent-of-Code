using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static System.Console;

namespace Advent_of_Code_2018
{
    class Day_04
    {
        private static string[] _input = System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-04-input.txt");
        private List<Guard> guards = new List<Guard>();

        static Day_04()
        {
            for (int i = 0; i < _input.Length; i++)
            {
                //var id = Convert.ToInt32(Regex.Matches(_input[i], @"\d+").Value);
            }


            var myList = new List<Guard>();
            for (int i = 0; i < _input.Length; i++)
            {
                // 1518-10-08 00:16
                DateTime myDate = DateTime.ParseExact(_input[i].Substring(1,16), "yyyy-MM-dd HH:mm",
                                       System.Globalization.CultureInfo.InvariantCulture);

                Guard g = new Guard();
                g.timestamp = myDate;
                g.desc = _input[i].Substring(18);
                myList.Add(g);
                //Console.WriteLine("DEBUG");
            }
                //_input[i] = Convert.ToInt32(Regex.Match(rawInput[i], @"-?\d+").Value);


            myList.Sort((x, y) => DateTime.Compare(x.timestamp, y.timestamp));

            foreach (var line in myList)
            {
                Console.WriteLine(line.timestamp.ToString() + " " + line.desc);
            }
        }

        public static void Puzzle()
        {
            //int sum = 0;
            //var collection = new HashSet<int>();

            WriteLine();
        }

        class Guard
        {
            public DateTime timestamp;
            public string desc;
        }
    }
}
