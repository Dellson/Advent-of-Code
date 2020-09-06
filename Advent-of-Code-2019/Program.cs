using System.IO;
using static System.Console;

namespace Advent_of_Code_2019
{
    class Program
    {
        public static string InputFolderPath { get; private set; }

        static Program()
        {
            InputFolderPath = Directory.GetCurrentDirectory();
            InputFolderPath = Path.Combine(InputFolderPath, "..\\..\\InputFiles\\");
        }

        static void Main(string[] args)
        {
            //Day_01.Puzzle();
            Day_02.Puzzle();
            //Day_03.Puzzle();
            //Day_04.Puzzle();
            //Day_05.Puzzle();
            //Day_06.Puzzle();
            //Day_07.Puzzle();
            //Day_08.Puzzle();
            //Day_10.Puzzle();
            //Day_14.Puzzle();
            ReadKey();
        }
    }
}
