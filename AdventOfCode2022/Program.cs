using System;
using System.IO;
using AdventOfCode;

namespace AdventOfCode2022
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
            Day02.Puzzle();
            Console.ReadKey();
        }
    }
}
