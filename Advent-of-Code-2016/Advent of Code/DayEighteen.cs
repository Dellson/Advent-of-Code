using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advent_of_Code
{
    class DayEighteen
    {
        private const string input = ".^..^....^....^^.^^.^.^^.^.....^.^..^...^^^^^^.^^^^.^.^^^^^^^.^^^^^..^.^^^.^^..^.^^.^....^.^...^^.^.";
        private const int numberOfRows = 400000;

        public void puzzle()
        {
            List<string> result = new List<string>();
            result.Add(input);
            int safeTiles = 0;

            for (int i = 0; i < numberOfRows - 1; ++i)
            {
                result.Add(revealRow(result[result.Count - 1]));
            }

            result.ForEach(x =>
            {
                //Console.Write(x + "\n");
                safeTiles += x.Count(c => c == '.');
            });

            Console.WriteLine("Safe tiles: " + safeTiles);
        }

        private string revealRow(string row)
        {
            StringBuilder sBuilder = new StringBuilder();
            row = "." + row + ".";

            for (int i = 0; i < row.Length - 2; ++i)
            {
                if (row[i] == row[i + 2])
                    sBuilder.Append(".");
                else
                    sBuilder.Append("^");
            }

            return sBuilder.ToString();
        }
    }
}
