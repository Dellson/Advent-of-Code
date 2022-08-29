using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2021
{
    class Day04
    {
        const int bingoBoardSideLength = 5;
        static readonly List<int> _inputNumbers = new List<int>();
        static readonly List<BingoBoard> bingoBoards = new List<BingoBoard>();

        public static void Puzzle()
        {
            var std = Program.GetTextInputData("4").ToList();
            var rawInput = new List<string>();

            foreach (var line in std)
            {
                rawInput.Add(line);
            }

            foreach (var number in rawInput[0].Split(','))
            {
                _inputNumbers.Add(Convert.ToInt32(number));
            }

            for (int i = 2; i < rawInput.Count; i+=6)
            {
                Regex rg = new Regex(@"\d+");
                Func<int, List<int>> getMatchesByIndex = i => rg.Matches(rawInput[i]).Select(m => Convert.ToInt32(m.Value)).ToList();

                bingoBoards.Add(new BingoBoard(
                    new List<List<int>> {
                        getMatchesByIndex(i),
                        getMatchesByIndex(i+1),
                        getMatchesByIndex(i+2),
                        getMatchesByIndex(i+3),
                        getMatchesByIndex(i+4)
                    }
                ));
            }

            Puzzle1();
            Puzzle2();
        }

        private static void Puzzle1()
        {
            foreach (var number in _inputNumbers)
            {
                bingoBoards.ForEach(bb => bb.TryCrossOutNumber(number));

                if (bingoBoards.Any(bb => bb.VictoryScore != -1))
                {
                    Console.WriteLine($"Puzzle 1 answer: {bingoBoards.First(bb => bb.VictoryScore != -1).VictoryScore}");
                    break;
                }
            }
        }

        private static void Puzzle2()
        {
            var lastNumber = -1;

            foreach (var number in _inputNumbers)
            {
                bingoBoards.ForEach(bb => bb.TryCrossOutNumber(number));

                if (bingoBoards.Any(bb => bb.VictoryScore != -1))
                {
                    lastNumber = bingoBoards.Select(bb => bb.VictoryScore).Last(vs => vs != -1);
                    bingoBoards.RemoveAll(bb => bb.VictoryScore != -1);
                }
            }

            Console.WriteLine($"Puzzle 2 answer: {lastNumber}");
        }

        private class BingoBoard
        {
            public int VictoryScore { get; private set; } = -1;
            private readonly List<List<int>> rows;
            private readonly List<List<bool>> crossedOut;

            public BingoBoard(List<List<int>> rows)
            {
                this.rows = new List<List<int>>(rows);
                var falses = new List<bool>
                {
                    false, false, false, false, false
                };
                this.crossedOut = new List<List<bool>>()
                {
                    new List<bool>(falses),
                    new List<bool>(falses),
                    new List<bool>(falses),
                    new List<bool>(falses),
                    new List<bool>(falses)
                };
            }

            public void TryCrossOutNumber(int number)
            {
                var (x, y) = GetNumbersIndices(number);
                if (x != -1 && y != -1)
                {
                    crossedOut[x][y] = true;
                }

                if (CheckIfVictoryAchieved())
                {
                    VictoryScore = GetScore(number);
                }
            }

            private int GetScore(int number)
            {
                int sum = 0;

                for (int i = 0; i < bingoBoardSideLength; i++)
                {
                    for (int j = 0; j < bingoBoardSideLength; j++)
                    {
                        if (!crossedOut[i][j])
                        {
                            sum += rows[i][j];
                        }
                    }
                }

                return sum * number;
            }

            private (int x, int y) GetNumbersIndices(int number)
            {
                for (int i = 0; i < bingoBoardSideLength; i++)
                {
                    for (int j = 0; j < bingoBoardSideLength; j++)
                    {
                        if (rows[i][j] == number) return (i, j);
                    }
                }

                return (-1, -1);
            }

            private bool CheckIfVictoryAchieved()
            {
                for (int i = 0; i < bingoBoardSideLength; i++)
                {
                    if (crossedOut[i].All(n => n) ||
                        crossedOut.Select(n => n[i]).All(n => n))
                    {
                        return true;
                    }
                }

                return false;
            }
        }
    }
}
