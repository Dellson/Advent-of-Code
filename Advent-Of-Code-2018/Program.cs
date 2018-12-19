using static System.Console;

namespace Advent_of_Code_2018
{
    class Program
    {
        public static string InputFolderPath { get; private set; }

        static Program()
        {
            InputFolderPath = System.IO.Directory.GetCurrentDirectory();
            InputFolderPath = System.IO.Path.Combine(InputFolderPath, "..\\..\\");
        }

        static void Main(string[] args)
        {
            //Day_01.Puzzle();
            //Day_02.Puzzle();
            //Day_03.Puzzle();
            //Day_04.Puzzle();
            //Day_05.Puzzle();
            //Day_07.Puzzle();
            Day_08.Puzzle();
            ReadKey();
        }
    }
}
