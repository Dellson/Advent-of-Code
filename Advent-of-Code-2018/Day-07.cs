using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Console;

namespace Advent_of_Code_2018
{
    class Day_07
    {
        private static string[] _rawInput = System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-07-input.txt");
        private static Dictionary<string, List<string>> _steps = new Dictionary<string, List<string>>();

        static Day_07()
        {
            foreach (var line in _rawInput)
            {
                var words = Regex.Matches(line, @"\w+");

                if (!_steps.ContainsKey(words[7].Value))
                    _steps.Add(words[7].Value, new List<string> { words[1].Value });
                else
                    _steps[words[7].Value].Add(words[1].Value);

                if (!_steps.ContainsKey(words[1].Value))
                    _steps.Add(words[1].Value, new List<string>());
            }
        }

        public static void Puzzle()
        {
            List<string> result = new List<string>();
            int len = _steps.Count;
            var startSteps = _steps.Where(v => v.Value.Count == 0).OrderBy(e => e.Key);
            int time = 0;
            List<Worker> workers = new List<Worker> { new Worker(), new Worker(), new Worker(), new Worker(), new Worker() };

            foreach (var task in startSteps)
                TryAssigningTaskToWorker(task.Key);

            for (; result.Count < len; time++)
            {
                var next = _steps.Where(step => step.Value.All(
                    s => result.Contains(s))).ToList();

                for (int i = 0; i < next.Count; i++)
                    TryAssigningTaskToWorker(next[i].Key);

                for (int j = 0; j < workers.Count; j++)
                    if (workers[j].Time > 0 && --workers[j].Time == 0)
                        result.Add(workers[j].CurrentTask);
            }

            Write("Puzzle one answer: ");
            result.ForEach(s => Write(s));
            WriteLine("\nPuzzle two answer: " + time);

            void TryAssigningTaskToWorker(string task)
            {
                var workerIndex = workers.FindIndex(w => w.Time == 0);

                if (workerIndex != -1)
                {
                    _steps.Remove(task);
                    workers[workerIndex].CurrentTask = task;
                    workers[workerIndex].Time = Convert.ToInt32(task[0]) - 4;
                }
            }
        }

        class Worker
        {
            public string CurrentTask = string.Empty;
            public int Time = 0;
        }
    }
}