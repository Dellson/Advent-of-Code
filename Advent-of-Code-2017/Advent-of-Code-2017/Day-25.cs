using System.Linq;

namespace Advent_of_Code_2017
{
    class Day_25
    {
        public static void Puzzle()
        {
            byte[] values = new byte[2 * 12172063];
            char state = 'A';
            int pos = 12172063;

            for (int i = 0; i < 12172063; ++i)
            {
                switch (state)
                {
                    case 'A':
                        if (values[pos] == 0)
                        {
                            values[pos] = 1;
                            pos++;
                            state = 'B';
                        }
                        else
                        {
                            values[pos] = 0;
                            pos--;
                            state = 'C';
                        }
                        
                        break;
                    case 'B':
                        if (values[pos] == 0)
                        {
                            values[pos] = 1;
                            pos--;
                            state = 'A';
                        }
                        else
                        {
                            values[pos] = 1;
                            pos--;
                            state = 'D';
                        }
                        break;
                    case 'C':
                        if (values[pos] == 0)
                        {
                            values[pos] = 1;
                            pos++;
                            state = 'D';
                        }
                        else
                        {
                            values[pos] = 0;
                            pos++;
                            state = 'C';
                        }
                        break;
                    case 'D':
                        if (values[pos] == 0)
                        {
                            values[pos] = 0;
                            pos--;
                            state = 'B';
                        }
                        else
                        {
                            values[pos] = 0;
                            pos++;
                            state = 'E';
                        }
                        break;
                    case 'E':
                        if (values[pos] == 0)
                        {
                            values[pos] = 1;
                            pos++;
                            state = 'C';
                        }
                        else
                        {
                            values[pos] = 1;
                            pos--;
                            state = 'F';
                        }
                        break;
                    case 'F':
                        if (values[pos] == 0)
                        {
                            values[pos] = 1;
                            pos--;
                            state = 'E';
                        }
                        else
                        {
                            values[pos] = 1;
                            pos++;
                            state = 'A';
                        }
                        break;
                    default:
                        break;
                }
            }
            System.Console.WriteLine(values.Count(v => v == 1));
        }
    }
}