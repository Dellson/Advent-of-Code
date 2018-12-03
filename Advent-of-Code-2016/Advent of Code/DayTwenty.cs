using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    class DayTwenty
    {
        List<Tuple<uint, uint>> allowedValues = new List<Tuple<uint, uint>>();
        private string path = Directory.GetCurrentDirectory();
        static uint count = 0;
        static uint min = 0;
        static uint max = 0;

        public DayTwenty()
        {
            path = Path.Combine(path, "..\\..\\");
            path += "DayTwentyInput.txt";

            foreach (string range in File.ReadAllLines(path))
            {
                var matches = Regex.Matches(range, @"(\d+)");
                allowedValues.Add(new Tuple<uint, uint>(UInt32.Parse(matches[0].Value), UInt32.Parse(matches[1].Value)));
            }
        }

        public void puzzle()
        {
            foreach (var tuple in allowedValues)
                if (tuple.Item1 == 0 && tuple.Item2 > min)
                    min = tuple.Item2 + 1;

            ///// zadanie 1
            nestedLoop();
            Console.WriteLine("Puzzle One, MIN: " + min);

            //// zadanie 2
            while (min != 0)
            {
                nestedLoop();
                List<uint> minValues = new List<uint>();

                foreach (var tuple in allowedValues)
                    if (tuple.Item1 >= min)
                        minValues.Add(tuple.Item1);

                uint minVal = minValues.Min();
                count += minVal - min;
                min = minVal;
            }
            uint max = 0;
            allowedValues.ForEach(tuple => { if (tuple.Item2 > max) max = tuple.Item2; });
            count += uint.MaxValue - max;
            Console.WriteLine("Puzzle Two, COUNT: " + count);
        }

        private void nestedLoop()
        {
            var tuples = allowedValues.FindAll(x => x.Item1 <= min && x.Item2 > min);
            foreach (var tuple in tuples)
            {
                if (tuple.Item2 > max)
                {
                    max = tuple.Item2;
                    min = max + 1;
                    nestedLoop();
                }
            }
        }
    }
}