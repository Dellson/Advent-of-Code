using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2018
{
    class Day_03
    {
        private static string[] _input = System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-03-input.txt");
        private static List<Tuple<int, int, int, int>> _fabrics = new List<Tuple<int, int, int, int>>();

        static Day_03()
        {
            foreach (var line in _input)
            {
                var matches = Regex.Matches(line, @"\d+");
                _fabrics.Add(new Tuple<int, int, int, int>(
                    Convert.ToInt32(matches[1].Value), 
                    Convert.ToInt32(matches[2].Value), 
                    Convert.ToInt32(matches[3].Value), 
                    Convert.ToInt32(matches[4].Value)));
            }
        }

        public static void Challenge()
        {
            var array = new int[_fabrics.Max(f => f.Item1 + f.Item3), _fabrics.Max(f => f.Item2 + f.Item4)];

            int counter = 0;
            
            foreach (var f in _fabrics)
            { 
                for (int i = f.Item1; i < f.Item1+ f.Item3; i++)
                {
                    for (int j = f.Item2; j < f.Item2 + f.Item4; j++)
                    {
                        if ((++array[i, j]) == 2)
                            counter++;
                    }
                }
            }
            Console.WriteLine(counter);
            
            int k = 0;
            bool hasFailed = true;

            for (k = 0; k < _fabrics.Count && hasFailed; k++)
            {
                hasFailed = false;
                for (int i = _fabrics[k].Item1; i < _fabrics[k].Item1 + _fabrics[k].Item3; i++)
                {
                    for (int j = _fabrics[k].Item2; j < _fabrics[k].Item2 + _fabrics[k].Item4; j++)
                    {
                        if (array[i, j] > 1)
                            hasFailed = true;
                    }
                }
            }
            Console.WriteLine(k);
        }
    }
}
