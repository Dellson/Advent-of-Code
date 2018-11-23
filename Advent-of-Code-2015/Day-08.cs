using System;
using System.Linq;

namespace Advent_of_Code_2015
{
    class Day_08
    {
        private static readonly string[] input = System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-08-input.txt");

        public static void BothStars()
        {
            int firstStarCounter = 0;
            int secondStarCounter = 0;

            foreach (var line in input)
            {
                secondStarCounter += 4;

                for (int i = 1; i < line.Length-1; i++, firstStarCounter++)
                {
                    if (line[i] == '\\' || line[i] == '\"')
                    {
                        i++;
                        secondStarCounter += 2;

                        if (line[i] == 'x')
                        {
                            i += 2;
                            secondStarCounter--;
                        } 
                    }
                }
            }
            Console.WriteLine(input.Sum(l => l.Length) - firstStarCounter);
            Console.WriteLine(secondStarCounter);
        }
    }
}
