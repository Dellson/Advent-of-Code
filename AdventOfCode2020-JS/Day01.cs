using System;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class Day01
    {
        static List<int> Input;

        public static void Puzzle()
        {
            Input = Program.GetNumberInputData("1");

            Puzzle1();
            Puzzle2();
        }

        private static void Puzzle1(int target = 2020)
        {
            for (int i = 0; i < Input.Count; i++)
            {
                for (int j = 0; j < Input.Count; j++)
                {
                    if (i != j && Input[i] + Input[j] == target)
                    {
                        Console.WriteLine(Input[i] * Input[j]);
                        return;
                    }
                }
            }
        }

        private static void Puzzle2(int target = 2020)
        {
            for (int i = 0; i < Input.Count; i++)
            {
                for (int j = 0; j < Input.Count; j++)
                {
                    for (int k = 0; k < Input.Count; k++)
                    {
                        if (i != j && Input[i] + Input[j] + Input[k] == target)
                        {
                            Console.WriteLine(Input[i] * Input[j] * Input[k]);
                            return;
                        }
                    }
                    
                }
            }
        }
    }
}