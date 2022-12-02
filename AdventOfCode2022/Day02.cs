using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022
{
    class Day02
    {
        static string[] _input;
        readonly static Dictionary<char, (char win, char lose)> Shapes = new Dictionary<char, (char win, char lose)>()
        {
            ['A'] = ('C', 'B'),
            ['B'] = ('A', 'C'),
            ['C'] = ('B', 'A')
        };
        readonly static Dictionary<char, int> ShapePoints = new Dictionary<char, int>()
        {
            ['A'] = 1,
            ['B'] = 2,
            ['C'] = 3
        };
        readonly static Dictionary<char, int> victoryPoints = new Dictionary<char, int>()
        {
            ['X'] = 0,
            ['Y'] = 3,
            ['Z'] = 6
        };


        public static void Puzzle()
        {
            _input = Program.GetTextInputData("2");

            Console.WriteLine(Puzzle1().Sum());
            Console.WriteLine(Puzzle2().Sum());
        }

        private static IEnumerable<int> Puzzle1()
        {
            foreach (var item in _input)
            {
                var bets = item.Replace('X', 'A').Replace('Y', 'B').Replace('Z', 'C');
                char result = 'Y';

                if (bets[0] == Shapes[bets[2]].win) result = 'Z';
                else if (bets[0] == Shapes[bets[2]].lose) result = 'X';

                yield return ShapePoints[bets[2]] + victoryPoints[result];
            }
        }

        private static IEnumerable<int> Puzzle2()
        {
            foreach (var item in _input)
            {
                char shape = item[0];

                if (item[2] == 'X') shape = Shapes[item[0]].win;
                else if (item[2] == 'Z') shape = Shapes[item[0]].lose;

                yield return ShapePoints[shape] + victoryPoints[item[2]];
            }
        }
    }
}
