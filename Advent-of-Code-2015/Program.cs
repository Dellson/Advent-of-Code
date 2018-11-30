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
            //Day_02.BothStars();
            //Day_03.BothStars();
            //Day_04.BothStars();
            //Day_05.BothStars();
            //Day_06.BothStars();
            //Day_07.BothStars();
            //Day_08.BothStars();
            //Day_09.BothStars();
            //Day_10.ElvesLookElvesSay();
            //Day_11.Challenge();
            Day_12.Challenge();
            ReadKey();
        }
    }
}
