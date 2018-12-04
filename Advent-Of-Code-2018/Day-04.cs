using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Console;

namespace Advent_of_Code_2018
{
    class Day_04
    {
        private static string[] _input = System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-04-input.txt");
        private static Dictionary<int, Guard> guards = new Dictionary<int, Guard>();

        static Day_04()
        {
            var set = _input.ToList();
            for (int i = 0; i < _input.Length; i++)
            {
                set.Sort((x, y) => string.Compare(x, y));
                //var id = Convert.ToInt32(Regex.Matches(_input[i], @"\d+").Value);
            }


            /*var myList = new List<Guard>();
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
            }*/
                //_input[i] = Convert.ToInt32(Regex.Match(rawInput[i], @"-?\d+").Value);


            //myList.Sort((x, y) => DateTime.Compare(x.timestamp, y.timestamp));

            var id = 0;

            foreach (var line in set)
            {
                var digits = Regex.Matches(line, @"\d+");
                var currentid = Convert.ToInt32(digits[digits.Count - 1].Value);
                //Console.WriteLine(currentid);
                if (line.Contains("Guard") && !guards.ContainsKey(id) && digits.Count == 6)
                {
                    // 6
                    //Console.WriteLine("   " + digits.Count);
                    id = currentid;
                    guards.Add(id, new Guard(id));
                    
                }
                
                DateTime myDate = DateTime.ParseExact(line.Substring(1,16), "yyyy-MM-dd HH:mm",
                                       System.Globalization.CultureInfo.InvariantCulture);

                guards[id].desc.Add(new Tuple<DateTime, string>(myDate, line.Substring(19)));
            }

            foreach (var guard in guards)
	        {
                Console.WriteLine(guard.Key);

                foreach (var item in guard.Value.desc)
                {
                    //Console.WriteLine(item.Item1 + " " + item.Item2);
                }
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
            public readonly int Id;
            //public readonly DateTime Timestamp;
            //public readonly string FullDescription;
            //public Dictionary<string> desc;
            public List<Tuple<DateTime, string>> desc = new List<Tuple<DateTime, string>>();

            public Guard(int Id){
                Id = Id;
}
        }
    }
}
