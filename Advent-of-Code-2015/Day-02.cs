using System;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2015
{
    class Day_02
    {
        private static string[] input = System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-02-input.txt");

        public static void BothStars()
        {
            int paperNeeded = 0;
            int ribbonNeeded = 0;

            foreach (string str in input)
            {
                var matches = Regex.Matches(str, @"\d+");
                int l = Convert.ToInt32(Convert.ToInt32(matches[0].Value));
                int w = Convert.ToInt32(Convert.ToInt32(matches[1].Value));
                int h = Convert.ToInt32(Convert.ToInt32(matches[2].Value));
                int[] sides = (new int[3] { l, w, h });

                paperNeeded += (2 * l * w) + (2 * w * h) + (2 * h * l);
                ribbonNeeded += l * w * h;

                int maxSide = 0;
                for (int i = 0; i < 3; ++i)
                    if (sides[i] > sides[maxSide])
                        maxSide = i;

                sides[maxSide] = 1;
                paperNeeded += sides[0] * sides[1] * sides[2];

                sides[maxSide] = 0;
                ribbonNeeded += (2 * sides[0]) + (2 * sides[1]) + (2 * sides[2]);
            }

            Console.WriteLine("Paper needed:    " + paperNeeded);
            Console.WriteLine("Ribbon needed:   " + ribbonNeeded);
        }
    }
}
