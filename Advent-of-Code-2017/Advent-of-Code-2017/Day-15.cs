namespace Advent_of_Code_2017
{
    class Day_15
    {
        private static long genA = 591;
        private static long genB = 393;
        private static int count = 0;

        public static void PuzzleOne()
        {
            for (int i = 0; i < 40000000; ++i)
            {
                genA = ((genA * 16807)) % int.MaxValue;
                genB = ((genB * 48271)) % int.MaxValue;

                count += genA << 48 == genB << 48 ? 1 : 0;
            }
            System.Console.WriteLine(count);
        }

        public static void PuzzleTwo()
        {
            for (int i = 0; i < 5000000; ++i)
            {
                do { genA = ((genA * 16807)) % int.MaxValue; }
                while (genA % 4 != 0);

                do { genB = ((genB * 48271)) % int.MaxValue; }
                while (genB % 8 != 0);

                count += genA << 48 == genB << 48 ? 1 : 0;
            }
            System.Console.WriteLine(count);
        }
    }
}
