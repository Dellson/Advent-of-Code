﻿using System;
using System.IO;
using AdventOfCode;

namespace AdventOfCode2021
{
    class Program : BaseProgram
    {
        static Program()
        {
            InputFolderPath = Directory.GetCurrentDirectory();
            InputFolderPath = Path.Combine(InputFolderPath, "Input");
        }

        static void Main(string[] args)
        {
            Day04.Puzzle();
            Console.ReadKey();
        }
    }
}
