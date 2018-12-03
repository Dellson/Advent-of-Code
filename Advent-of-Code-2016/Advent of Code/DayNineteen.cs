using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    class DayNineteen
    {
        private Queue elfQueue = new Queue();
        List<int> elfList = new List<int>();
        private static int elvesChecked = 0;

        public DayNineteen()
        {
            for (int i = 1; i <= 3005290; ++i)
            {
                elfQueue.Enqueue(new Tuple<int, int>(i, 1));
                elfList.Add(i);
            }
        }

        public void puzzleOne()
        {
            Tuple<int, int> elf;

            while (elfQueue.Count > 1)
            {
                elf = (Tuple<int, int>)elfQueue.Dequeue();
                if (elf.Item2 > 0)
                {
                    Tuple<int, int> theElfThatLostGifts = (Tuple<int, int>)elfQueue.Dequeue();
                    Tuple<int, int> theElfThatHasStolenGifts = new Tuple<int, int>(elf.Item1, theElfThatLostGifts.Item2);
                    elfQueue.Enqueue(theElfThatHasStolenGifts);
                }
            }
            Console.WriteLine("Part 1: Elf that has all of the gifts: " + ((Tuple<int, int>)elfQueue.Dequeue()).Item1);
        }

        public void puzzleTwo()
        {
            while (elfList.Count > 1)
            {
                elvesChecked++;
                elfList[elfList.Count - ((elfList.Count - elvesChecked) / 2 - (elvesChecked - 1)) - 1] = 0;

                if (elvesChecked * 2 >= (elfList.Count - elvesChecked - 1))
                {
                    List<int> temp = new List<int>();
                    for (int i = elvesChecked; i < elfList.Count; ++i)
                    {
                        if (elfList[i] != 0)
                            temp.Add(elfList[i]);
                    }
                    temp.AddRange(elfList.Take(elvesChecked));
                    elfList = new List<int>(temp);
                    
                    elvesChecked = 0;
                }
            }
            Console.WriteLine("Part 2: Elf that has all of the gifts: " + elfList[0]);
        }
    }
}
