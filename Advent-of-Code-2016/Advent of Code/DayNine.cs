using System.IO;

namespace Advent_of_Code
{
    class DayNine
    {
        private string input;

        public DayNine()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\DayNineInput.txt");
            input = File.ReadAllLines(path)[0].Trim(' ');
        }

        public long puzzleOne()
        {
            long output = 0;
            for (int i = 0; i < input.Length; ++i)
            {
                if (input[i] == '(')
                {
                    int[] storage = examinateMarker(ref i);
                    output += storage[0] * storage[1];
                    i += storage[0] - 1;
                }
                else
                    output++;
            }
            return output;
        }

        public long puzzleTwo()
        {
            int i = 0;
            return countCharactersRecurrently(ref i, input.Length);
        }

        private int[] examinateMarker(ref int i)
        {
            string marker = "";
            i++;

            while (input[i] != ')')
            {
                marker += input[i];
                i++;
            }
            i++;
            
            int markedCharacters = int.Parse(marker.Split(new char[] { 'x' })[0]);
            int repeatCount = int.Parse(marker.Split(new char[] { 'x' })[1]);

            return new int[3] { markedCharacters, repeatCount, marker.Length + 2 };
        }

        private long countCharactersRecurrently(ref int i, int stringLength, int repeatCount = 1)
        {
            long output = 0;

            while (i < input.Length && stringLength > 0)
            {
                if (input[i] == '(')
                {
                    int[] storage = examinateMarker(ref i);
                    output += countCharactersRecurrently(ref i, storage[0], storage[1]);
                    stringLength -= (storage[0] + storage[2]);
                }
                else
                    output++;
                stringLength--;
                i++;
            }
            i--;

            return output * repeatCount;
        }
    }
}