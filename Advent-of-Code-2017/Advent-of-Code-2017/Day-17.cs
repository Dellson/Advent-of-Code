using System.Collections.Generic;

namespace Advent_of_Code_2017
{
    class Day_17
    {
        private static int currentPosition = 0;
        private static int steps = 394;
        private static List<int> spinLock = new List<int> { 0 };

        public static void PuzzleOne()
        {
            for (int j = 1; j < 2018; ++j)
            {
                currentPosition = ((currentPosition + steps) % spinLock.Count) + 1;
                if (currentPosition + 1 > spinLock.Count)
                    spinLock.Add(j);
                else
                    spinLock.Insert(currentPosition, j);
            }
            System.Console.WriteLine(spinLock[spinLock.IndexOf(2017) + 1]);
        }

        public static void PuzzleTwo()
        {
            int spinLockCount = 1;
            int firstIndex = 0;

            for (int j = 1; j < 50000000; ++j, spinLockCount++)
            {
                currentPosition = ((currentPosition + steps) % spinLockCount) + 1;
                if (currentPosition == 1)
                    firstIndex = j;
            }
            System.Console.WriteLine(firstIndex);
        }
    }
}
