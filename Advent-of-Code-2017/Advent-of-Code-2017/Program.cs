using static System.Console;

namespace Advent_of_Code_2017
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
            //WriteLine(Day_01.PuzzleOne());
            //WriteLine(Day_01.PuzzleTwo());
            //WriteLine(Day_02.PuzzleOne());
            //WriteLine(Day_02.PuzzleTwo());

            //WriteLine(Day_03.PuzzleOne());
            //Day_03.PuzzleTwo();

            //WriteLine(Day_04.PuzzleOne());
            //WriteLine(Day_04.PuzzleTwo());
            //WriteLine(Day_05.PuzzleOne());
            //WriteLine(Day_05.PuzzleTwo());

            //Day_06.Puzzle();
            //WriteLine(Day_07.PuzzleOne());
            //WriteLine(Day_07.PuzzleTwo());
            //Day_08.Puzzle();
            //Day_09.Puzzle();
            //Day_10.PuzzleOne(); // uruchomienie DayOne zniekształci wynik DayTwo
            //WriteLine(Day_10.PuzzleTwo());

            //Day_11.Puzzle();
            //Day_12.Puzzle();
            //Day_13.PuzzleOne();
            //Day_13.PuzzleTwo();
            //Day_14.Puzzle();
            //Day_15.PuzzleOne();
            //Day_15.PuzzleTwo();

            //Day_16.Puzzle();
            //Day_17.PuzzleOne();
            //Day_17.PuzzleTwo();
            //Day_18.Puzzle();
            //Day_19.Puzzle();
            //Day_20.PuzzleOne();
            //Day_20.PuzzleTwo();

            //Day_21.Puzzle();
            //Day_22.PuzzleOne();
            //Day_22.PuzzleTwo();
            //Day_23.PuzzleOne();
            //Day_23.PuzzleTwo();
            //Day_24.Puzzle();
            Day_25.Puzzle();

            ReadKey();
        }
    }
}
