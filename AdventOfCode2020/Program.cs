﻿using AdventOfCode;
using System;
using System.IO;

namespace AdventOfCode2020
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
            //Day01.Puzzle();
            //Day02.Puzzle();
            //Day03.Puzzle();
            //Day04.Puzzle();
            //Day05.Puzzle();
            Day13.Puzzle();
            Console.ReadKey();
        }
    }
}
