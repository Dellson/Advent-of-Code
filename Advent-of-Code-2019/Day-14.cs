using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2019
{
    class Day_14
    {
        private static readonly Dictionary<string, ReactionFormulae> _reactionsFormulaes = new Dictionary<string, ReactionFormulae>();
        private static readonly Dictionary<string, int> _reagentsRequiredStorage = new Dictionary<string, int>();
        private static Dictionary<string, int> _reagentsRequiredOperational = new Dictionary<string, int>();
        private static readonly Dictionary<string, int> _leftoverReagents = new Dictionary<string, int>();
        private const string BasicReagentKey = "ORE";

        static Day_14()
        {
            string[] inputReactions = File.ReadAllLines(Program.InputFolderPath + "Day-14-input.txt");

            foreach (var reaction in inputReactions)
            {
                Dictionary<string, int> parsedReagents = new Dictionary<string, int>();
                int productQuantity =
                    Convert.ToInt32(Regex.Match(reaction, @"(?<=\=\>\s{1})\d+").Value);
                string productKey = Regex.Match(reaction, @"(?<=\=\>\s{1}\d+ )\w+").Value;

                foreach (Match reagentsRaw in Regex.Matches(reaction, @"\d+ \w+(?=\s{1}|,)"))
                {
                    string[] reagents = reagentsRaw.Value.Split(' ');
                    parsedReagents.Add(reagents[1], Convert.ToInt32(reagents[0]));
                }

                _reactionsFormulaes.Add(productKey, new ReactionFormulae(parsedReagents, productQuantity));
                _reagentsRequiredStorage.Add(productKey, 0);
                _leftoverReagents.Add(productKey, 0);
            }
        }

        public static void Puzzle()
        {
            double totalCount = 0;
            int fuelAmount = 0;


            //CalculateAmountOfReagentsRequiredForGivenProduct(_reactionsFormulaes["FUEL"], 1);

            //int totalCount = _reagentsRequired
            //    .Where(reagent => _reactionsFormulaes[reagent.Key].Reagents.ContainsKey(BasicReagentKey))
            //    .Sum(r => _reagentsRequired[r.Key] * _reactionsFormulaes[r.Key].Reagents[BasicReagentKey]);

            //Console.WriteLine(totalCount);

            // PART 2

            for (; totalCount < 1000000000000; fuelAmount++)
            {
                _reagentsRequiredOperational = new Dictionary<string, int>(_reagentsRequiredStorage);

                CalculateAmountOfReagentsRequiredForGivenProduct(_reactionsFormulaes["FUEL"], 1);

                totalCount += _reagentsRequiredOperational
                    .Where(reagent => _reactionsFormulaes[reagent.Key].Reagents.ContainsKey(BasicReagentKey))
                    .Sum(r => _reagentsRequiredOperational[r.Key] * _reactionsFormulaes[r.Key].Reagents[BasicReagentKey]);
            }

            Console.WriteLine(totalCount);
            Console.WriteLine(fuelAmount);
        }

        private static void CalculateAmountOfReagentsRequiredForGivenProduct(ReactionFormulae formulae, int requestsCount)
        {
            foreach (var reagent in formulae.Reagents.Where(r => r.Key != BasicReagentKey))
            {
                int requestedReagentAmount = requestsCount * reagent.Value;

                if (requestedReagentAmount >= _leftoverReagents[reagent.Key])
                {
                    requestedReagentAmount -= _leftoverReagents[reagent.Key];
                    _leftoverReagents[reagent.Key] = 0;
                }
                else
                {
                    _leftoverReagents[reagent.Key] -= requestedReagentAmount;
                    requestedReagentAmount = 0;
                }

                int reagentsProducedPerReaction = _reactionsFormulaes[reagent.Key].Product;
                int numberOfReactionsRequired = (int)Math.Ceiling(requestedReagentAmount / (double)reagentsProducedPerReaction);
                int resultingNumberOfProducts = numberOfReactionsRequired * reagentsProducedPerReaction;
                _leftoverReagents[reagent.Key] += (resultingNumberOfProducts - requestedReagentAmount);
                _reagentsRequiredOperational[reagent.Key] += numberOfReactionsRequired;
                //     THESE TWO ARE EQUAL     //
                //int numberOfReactionsRequired = (int)Math.Ceiling(requestedReagentAmount / (double)_reactionsFormulaes[reagent.Key].Product);
                //_leftoverReagents[reagent.Key] += (numberOfReactionsRequired * _reactionsFormulaes[reagent.Key].Product) - requestedReagentAmount;
                //_reagentsRequired[reagent.Key] += numberOfReactionsRequired;

                if (!_reactionsFormulaes[reagent.Key].Reagents.ContainsKey(BasicReagentKey))
                    CalculateAmountOfReagentsRequiredForGivenProduct(_reactionsFormulaes[reagent.Key], numberOfReactionsRequired);
            }
        }
        
        private class ReactionFormulae
        {
            public Dictionary<string, int> Reagents = new Dictionary<string, int>();
            public readonly int Product;

            public ReactionFormulae(Dictionary<string, int> reagents, int product)
            {
                Reagents = reagents;
                Product = product;
            }
        }
    }
}
