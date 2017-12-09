using static System.Console;

namespace Advent_of_Code_2015
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
            //Day_01.BothStars();
            Day_02.BothStars();

            ReadKey();
        }
    }
}
