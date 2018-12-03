using System;
using System.IO;
using System.Text;

namespace Advent_of_Code_2017
{
    class Day_09
    {
        private static StringBuilder input = new StringBuilder(
            File.ReadAllLines(Program.InputFolderPath + "Day-09-input.txt")[0]);

        public static void Puzzle()
        {            
            int openingBracketPos = -1;
            int closingBracketPos = -1;
            int score = 0;
            int baseScore = 0;
            int count = 0;

            for (int i = 0; i < input.Length; ++i)
            {
                if (input[i] == '!')
                    input = input.Replace(input[i + 1], '~', i + 1, 1);

                if (openingBracketPos == -1 && input[i] == '<')
                    openingBracketPos = i;

                if (closingBracketPos == -1 && input[i] == '>')
                    closingBracketPos = i;

                if (closingBracketPos > openingBracketPos)
                {
                    StringBuilder s2 = new StringBuilder();

                    for (int j = openingBracketPos; j <= closingBracketPos; ++j)
                    {
                        if (input[j] != '~' && input[j] != '!')
                            count++;
                        input = input.Replace(input[j], '~', j, 1);
                    }
                        
                    openingBracketPos = -1;
                    closingBracketPos = -1;
                    count -= 2;
                }
            }

            for (int i = 0; i < input.Length; ++i)
            {
                if (input[i] == '{')
                    baseScore++;
                if (input[i] == '}')
                {
                    score += baseScore;
                    baseScore--;
                }
            }
            Console.WriteLine("Score:                       " + score);
            Console.WriteLine("Garbage characters count:    " + count);
        }
    }
}
