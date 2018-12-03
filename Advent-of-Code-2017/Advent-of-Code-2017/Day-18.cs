using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent_of_Code_2017
{
    class Day_18
    {
        private static Dictionary<string, long>[] regs = new Dictionary<string, long>[2];
        private static List<string[]> input = new List<string[]>();

        static Day_18()
        {
            regs[0] = new Dictionary<string, long> { { "a", 0 }, { "b", 0 }, { "i", 0 }, { "l", 0 }, { "f", 0 }, { "p", 0 } };
            regs[1] = new Dictionary<string, long> { { "a", 0 }, { "b", 0 }, { "i", 0 }, { "l", 0 }, { "f", 0 }, { "p", 1 } };
            System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-18-input.txt").ToList().
                ForEach(line => input.Add((line.Split(' '))));
        }

        public static void Puzzle()
        {
            Queue<long>[] queue = new Queue<long>[2];
            queue[0] = new Queue<long>();
            queue[1] = new Queue<long>();

            int cur = 0;
            int count = 0;
            long[] i = new long[2] { 0, 0 };
            bool[] isWaiting = new bool[2] { false, false };

            while (!(queue[0].Count == 0 && queue[1].Count == 0 && isWaiting[0] && isWaiting[1]))
            {
                string[] line = input[(int)i[cur]];
                long read = 0;

                if (queue[cur].Count == 0 && line[0] == "rcv")
                {
                    isWaiting[cur] = true;
                    cur = Math.Abs(cur - 1);
                        continue;
                }

                if (line.Length > 2)
                    if (!long.TryParse(line[2], out read))
                        read = regs[cur][line[2]];

                if (line[0] == "snd")
                {
                    if (cur == 1)
                        count++;
                    queue[Math.Abs(cur - 1)].Enqueue(regs[cur][line[1]]);
                }
                else if (line[0] == "set")
                    regs[cur][line[1]] = read;
                else if (line[0] == "add")
                    regs[cur][line[1]] += read;
                else if (line[0] == "mul")
                    regs[cur][line[1]] *= read;
                else if (line[0] == "mod")
                    regs[cur][line[1]] %= read;
                else if (line[0] == "rcv")
                {
                    isWaiting[cur] = false;
                    regs[cur][line[1]] = queue[cur].Dequeue();
                }
                else if (line[0] == "jgz")
                {
                    if (!long.TryParse(line[1], out long jump))
                        jump = regs[cur][line[1]];
                    if (jump > 0 && read > 0)
                        i[cur] += read - 1;
                    else if (jump > 0 && read <= 0)
                        i[cur] += read - 1;
                }
                i[cur]++;
                cur = Math.Abs(cur - 1);

            }
            Console.WriteLine("Puzzle two answer: " + count);
        }
    }
}