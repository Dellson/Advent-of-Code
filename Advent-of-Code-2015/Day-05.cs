namespace Advent_of_Code_2015
{
    class Day_05
    {
        private static string[] rawInput = System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-05-input.txt");

        public static void BothStars()
        {
            PuzzleOne();
            PuzzleTwo();
        }

        private static void PuzzleOne()
        {
            int count = 0;
            foreach (string input in rawInput)
            {
                int vowels = 0;

                foreach (char cc in input)
                    foreach (char c in "aeiou")
                        if (c == cc)
                            vowels++;

                if (input.Contains("ab") || input.Contains("cd") || input.Contains("pq") || input.Contains("xy")
                    || vowels < 3)
                    continue;

                for (int i = 1; i < input.Length; ++i)
                    if (input[i - 1] == input[i])
                    {
                        count++;
                        break;
                    }
            }
            System.Console.WriteLine("Puzzle one answer: " + count);
        }

        private static void PuzzleTwo()
        {
            int count = 0;

            foreach (string input in rawInput)
            {
                System.Collections.Generic.List<string> pairs = new System.Collections.Generic.List<string>();
                bool passed = false;
                for (int i = 1; i < input.Length; ++i)
                {
                    string substring = input.Substring(i - 1, 2);
                    
                    if (substring[0] == substring[1] && i < input.Length - 1 && substring[0] == input[i + 1])
                        continue;
                    pairs.Add(substring);
                }
                
                for (int j = 0; j < pairs.Count; ++j)
                    for (int h = 0; h < pairs.Count; ++h)
                        if (pairs[j] == pairs[h] && j != h) passed = true;
                
                if (!passed)
                    continue;

                for (int i = 2; i < input.Length; ++i)
                    if (input[i] == input[i - 2])
                    {
                        count++;
                        break;
                    }
            }
            System.Console.WriteLine("Puzzle two answer: " + count);
        }
    }
}
