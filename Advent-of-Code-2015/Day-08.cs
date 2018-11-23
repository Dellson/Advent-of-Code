using System;

namespace Advent_of_Code_2015
{
    class Day_08
    {
        private static readonly string[] input = System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-08-input.txt");

        public static void RemoveSpecialChars()
        {
            int counter = 0;
            int counter2 = 0;
            foreach (var line in input)
            {
                counter2 += line.Length;
                for (int i = 1; i < line.Length-1; i++)
                {
                    if (line[i] == '\\')
                    {
                        i++;
                        if (line[i] == 'x')
                        {
                            i += 2;
                        }
                    }
                    counter++;
                }
            }
            Console.WriteLine(counter2 - counter);
        }
    }
}
