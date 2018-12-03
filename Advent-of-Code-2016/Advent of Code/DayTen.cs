using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent_of_Code
{
    class DayTen
    {
        private string path = Directory.GetCurrentDirectory();
        private string[] input;
        private Dictionary<int, List<int>> bots = new Dictionary<int, List<int>>();
        private Dictionary<int, List<int>> outputs = new Dictionary<int, List<int>>();

        public DayTen()
        {
            path = Path.Combine(path, "..\\..\\DayTenInput.txt");
            input = File.ReadAllLines(path);

            createBots();
            createOutputs();

            foreach (string command in input)
            {
                Match value = Regex.Match(command, @"value (?<value>\d+)");

                if (value.Success)
                {
                    int botNumber = int.Parse(Regex.Match(command, @"bot (?<bot>\d+)").Groups["bot"].Value);
                    bots[botNumber].Add(int.Parse(value.Groups["value"].Value));
                }
            }
        }
        
        public void puzzle()
        {
            while(bots.Where(x => x.Value.Count == 2).Any())
            {
                foreach (string command in input)
                {
                    if (command.Contains("value"))
                        continue;
                    else
                        botLogic(command);
                }
            }

            foreach (int key in outputs.Keys)
            {
                Console.Write("\nOutput " + key + ": ");
                foreach (int chip in outputs[key])
                    Console.Write(chip + " ");
            }

            Console.WriteLine("\n\nElements of outputs 0, 1 and 2, multiplied: " + (outputs[0][0] * outputs[1][0] * outputs[2][0]));
        }

        private void botLogic(string command)
        {
            int currentBot = int.Parse(Regex.Match(command, @"bot (?<bot>\d+)").Groups["bot"].Value);

            if (bots[currentBot].Count < 2)
                return;

            if (bots[currentBot].Contains(61) && bots[currentBot].Contains(17))
                Console.WriteLine("Bot nr " + currentBot + " compares 61 and 17!");

            foreach (Match destination in Regex.Matches(command, @"(low|high) to \w+ \d+"))
            {
                int value = int.Parse(Regex.Match(destination.Value, @"\d+").Value);

                if (destination.Value.Contains("low"))
                {
                    if (destination.Value.Contains("bot"))
                        bots[value].Add(bots[currentBot].Min());

                    if (destination.Value.Contains("output"))
                        outputs[value].Add(bots[currentBot].Min());

                    bots[currentBot].Remove(bots[currentBot].Min());
                }
                if (destination.Value.Contains("high"))
                {
                    if (destination.Value.Contains("bot"))
                        bots[value].Add(bots[currentBot].Max());

                    if (destination.Value.Contains("output"))
                        outputs[value].Add(bots[currentBot].Max());

                    bots[currentBot].Remove(bots[currentBot].Max());
                }
            }
        }
        
        private void createBots()
        {
            foreach (string command in input)
            {
                foreach (Match botNumber in Regex.Matches(command, @"bot (?<number>\d+)"))
                {
                    try
                    {
                        string name = botNumber.Groups["number"].Value;
                        bots.Add(int.Parse(name), new List<int>());
                    }
                    catch (ArgumentException) { };
                }
            }
        }

        private void createOutputs()
        {
            foreach (string command in input)
            {
                foreach (Match outputNumber in Regex.Matches(command, @"output (?<number>\d+)"))
                {
                    string name = outputNumber.Groups["number"].Value;
                    outputs.Add(int.Parse(name), new List<int>());
                }
            }
        }
    }
}