using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    class Day_01
    {
        private static string input = File.ReadAllLines(Program.InputFolderPath + "Day-01-input.txt")[0];

        public static void BothStars()
        {
            int floor = 0;
            int position = -1;

            for (int i = 0; i < input.Length; ++i)
            {
                if (input[i] == '(')
                    floor++;
                if (input[i] == ')')
                {
                    floor--;
                    if (position == -1 && floor < 0)
                        position = i + 1;
                }
            }

            Console.WriteLine(floor);
            Console.WriteLine(position);
        }
    }
}
