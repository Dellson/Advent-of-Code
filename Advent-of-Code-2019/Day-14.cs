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

            ExecuteFormulae(formulaes["FUEL"], 1);

            foreach (var reagent in new Dictionary<string, int>(reagentNeeded))
            {
                while (reagentNeeded[reagent.Key] > 0)
                {
                    var currentFormulae = formulaes[reagent.Key];
                    int x = currentFormulae.InputMinerals.Where(m => m.name == "ORE").First().quantity;
                    reagentNeeded[reagent.Key] -= currentFormulae.OutputQuantity;
                    totalCount += x;
                }
            }

            return totalCount;
        }

        private static int ExecuteFormulae(Formulae formulae, int outputTargetQuantity)
        {
            foreach (var (inputName, inputQuantity) in formulae.InputMinerals)
            {
                if (formulaes[inputName].InputMinerals.Exists(m => m.name == "ORE"))
                    reagentNeeded[inputName] += (inputQuantity * outputTargetQuantity);

                else
                    ExecuteFormulae(formulaes[inputName], inputQuantity);
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
