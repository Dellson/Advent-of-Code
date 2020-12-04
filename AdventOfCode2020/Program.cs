using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Console;

namespace AdventOfCode2020
{
    class Program
    {
        public static string InputFolderPath { get; private set; } 

        static Program()
        {
            InputFolderPath = Directory.GetCurrentDirectory();
            InputFolderPath = Path.Combine(InputFolderPath, "Input");
        }

        public static string[] GetTextInputData(string dayNumber)
        {
            return File.ReadAllLines(
                Path.Combine(InputFolderPath, $"Day{dayNumber.PadLeft(2, '0')}.txt"));
        }

        public static List<int> GetNumberInputData(string dayNumber)
        {
            return GetTextInputData(dayNumber)
                .ToList()
                .ConvertAll(Convert.ToInt32);
        }

        public static string[] GetInputDataByRegex()
        {
            throw new NotImplementedException();
        }

        static void Main(string[] args)
        {
            //Day01.Puzzle();
            //Day02.Puzzle();
            //Day03.Puzzle();
            Day04.Puzzle();
            ReadKey();
        }
    }
}
