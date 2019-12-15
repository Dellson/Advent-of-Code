using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using static System.Math;

namespace Advent_of_Code_2019
{
    class Day_14
    {
        private static Dictionary<string, Formulae> formulaes = new Dictionary<string, Formulae>();
        private static Dictionary<string, int> reagentNeeded = new Dictionary<string, int>();

        static Day_14()
        {
            string[] inputData = File.ReadAllLines(Program.InputFolderPath + "Day-14-input.txt");

            for (int i = 0; i < inputData.Length; i++)
            {
                MatchCollection inputsGeneral = Regex.Matches(inputData[i], @"\d+ \w+(?=\s{1}|,)");
                string outputKey = Regex.Match(inputData[i], @"(?<=\=\>\s{1}\d+ )\w+").Value;
                int outputQuantity = Convert.ToInt32(Regex.Match(inputData[i], @"(?<=\=\>\s{1})\d+").Value);
                List<(string, int)> ingredients = new List<(string, int)>();

                for (int j = 0; j < inputsGeneral.Count; j++)
                {
                    var value = (inputsGeneral[j].Value.Split(' ')[1],
                        Convert.ToInt32(inputsGeneral[j].Value.Split(' ')[0]));

                    ingredients.Add(value);
                }

                formulaes.Add(outputKey, new Formulae(ingredients, outputKey, outputQuantity));
            }
        }

        public static int Puzzle()
        {
            int totalCount = 0;

            foreach (var formulae in formulaes)
                reagentNeeded.Add(formulae.Key, 0);

            CountUsage(formulaes["FUEL"], 1);

            foreach (var reagent in new Dictionary<string, int>(reagentNeeded))
            {
                var currentFormulae = formulaes[reagent.Key];

                if (currentFormulae.InputMinerals[0].name != "ORE")
                    continue;

                while (reagentNeeded[reagent.Key] > 0)
                {
                    reagentNeeded[reagent.Key] -= currentFormulae.OutputQuantity;
                    totalCount += currentFormulae.InputMinerals[0].quantity;
                }
            }

            Console.WriteLine(totalCount);

            return totalCount;
        }

        private static int CountUsage(Formulae formulae, int multiplier)
        {
            foreach (var (inputName, inputQuantity) in formulae.InputMinerals)
            {
                if (inputName == "ORE")
                    continue;

                reagentNeeded[inputName] += (multiplier * inputQuantity);

                CountUsage(formulaes[inputName], ((int)Ceiling(multiplier * inputQuantity / (double)formulaes[inputName].OutputQuantity)));
            }

            return 0;
        }
        
        private class Formulae
        {
            public List<(string name, int quantity)> InputMinerals;
            public readonly string OutputMineral;
            public readonly int OutputQuantity;

            public Formulae(List<(string, int)> im, string om, int oq)
            {
                InputMinerals = im;
                OutputMineral = om;
                OutputQuantity = oq;
            }
        }
    }
}
