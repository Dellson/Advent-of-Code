using System;
using System.Linq;

namespace Advent_of_Code_2017
{
    class Day_14
    {
        private static bool[,] array = new bool[128, 128];

        public static void Puzzle()
        {
            int count = 0;
            int groups = 0;

            for (int i = 0; i < 128; ++i)
            {
                Day_10.Initialize("oundnydw-" + i);

                string binarystring = String.Join(String.Empty,
                    Day_10.PuzzleTwo().Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));

                for (int j = 0; j < 128; ++j)
                    if (binarystring[j] == '1')
                        array[i, j] = true;
            }

            for (int i = 0; i < 128; ++i)
                for (int j = 0; j < 128; ++j)
                    if (array[i, j]) count++;

            for (int i = 0; i < 128; ++i)
                for (int j = 0; j < 128; ++j)
                    groups += FindGroups(i, j);

            
            Console.WriteLine("Puzzle one: " + count);
            Console.WriteLine("Puzzle two: " + groups);
        }

        private static int FindGroups(int i, int j)
        {
            if (!array[i, j])
                return 0;

            array[i, j] = false;

            if (i > 0 && array[i - 1, j])
            {                
                FindGroups(i - 1, j);
                array[i - 1, j] = false;
            }
            if (j > 0 && array[i, j - 1])
            {                
                FindGroups(i, j - 1);
                array[i, j - 1] = false;
            }
            if (i < 127 && array[i + 1, j])
            {                
                FindGroups(i + 1, j);
                array[i + 1, j] = false;
            }
            if (j < 127 && array[i, j + 1])
            {                
                FindGroups(i, j + 1);
                array[i, j + 1] = false;
            }

            return 1;
        }
    }
}
