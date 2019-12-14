using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Math;

namespace Advent_of_Code_2019
{
    class Day_14
    {
        private static Dictionary<string, (int outputQuantity, List<(string input, int inputQuantity)>)> reactions = 
            new Dictionary<string, (int, List<(string, int)>)>();
        private static Dictionary<string, (int amount, int ore)> chemicalsStash = new Dictionary<string, (int, int)>();

        private static int oreused = 0;

        static Day_14()
        {
            string[] inputData = File.ReadAllLines(Program.InputFolderPath + "Day-14-input.txt");

            for (int i = 0; i < inputData.Length; i++)
            {
                MatchCollection inputsGeneral = Regex.Matches(inputData[i], @"\d+ \w+(?=\s{1}|,)");
                string outputKey = Regex.Match(inputData[i], @"(?<=\=\>\s{1}\d+ )\w+").Value;
                int outputValue = Convert.ToInt32(Regex.Match(inputData[i], @"(?<=\=\>\s{1})\d+").Value);
                var list = new List<(string, int)>();

                for (int j = 0; j < inputsGeneral.Count; j++)
                {
                    (string input, int inputQuantity) value = (
                        inputsGeneral[j].Value.Split(' ')[1],
                        Convert.ToInt32(inputsGeneral[j].Value.Split(' ')[0]));

                    list.Add(value);
                }

                reactions.Add(outputKey, (outputValue, list));
            }
        }

        public static int Puzzle()
        {
            foreach (var reagent in reactions)
                chemicalsStash.Add(reagent.Key, (0, 0));
            //chemicalsStash.Add("ORE", 0);

            Console.WriteLine(CountOreRequiredForReaction(reactions["FUEL"], reactions["FUEL"].outputQuantity, "FUEL"));
            //Console.WriteLine(oreused + chemicalsStash["ORE"]);
            //Console.WriteLine(oreused);
            Console.WriteLine(oreused);
            return 0;
        }

        // requiredOutputCount: np. potrzeba 7 A
        // quantity - rekacja produkuje 10 A
        // targetCount - reakcja potrzebuje 10 ORE
        // ? - ile ore nam zostanie
        // ? - ile ore naprawdę potrzebujemy
        private static int CountOreRequiredForReaction((int quantity, List<(string name, int targetCount)>) inputReagents, int requiredOutputCount, string parent)
        {
            foreach (var reagent in inputReagents.Item2)
            {                
                if (reagent.name == "B")
                    Console.Write("");

                if (reagent.name == "ORE")
                {
                    while (chemicalsStash[parent].ore < requiredOutputCount)
                    {
                        chemicalsStash[parent] = 
                            (chemicalsStash[parent].amount + reactions[parent].outputQuantity, 
                            chemicalsStash[parent].ore + reagent.targetCount);

                        oreused += reagent.targetCount;
                    }

                    chemicalsStash[parent] = 
                        (chemicalsStash[parent].amount, 
                        chemicalsStash[parent].ore - requiredOutputCount);


                    //chemicalsStash[reagent.name] -= requiredOutputCount;
                }
                //else if (reagent.name == "A")
                //{
                //    while (chemicalsStash[reagent.name] < reagent.targetCount)
                //    {
                //        chemicalsStash[reagent.name] += 10;
                //        CountOreRequiredForReaction(reactions[reagent.name].Item2, reactions[reagent.name].outputQuantity, reagent.name);
                //    }

                //    chemicalsStash[reagent.name] -= reagent.targetCount;
                //}
                else
                {
                    var pr = reactions[parent];

                    while (chemicalsStash[reagent.name].ore < reagent.targetCount)
                    {
                        CountOreRequiredForReaction(reactions[reagent.name], reagent.targetCount, reagent.name);

                        
                    }

                    chemicalsStash[reagent.name] =
                        (chemicalsStash[reagent.name].amount - reagent.targetCount,
                        chemicalsStash[parent].ore);
                }

            }

            return reactions[parent].outputQuantity;
        }
    
    }
}
