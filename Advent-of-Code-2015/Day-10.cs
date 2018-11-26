using System;
using System.Text;

namespace Advent_of_Code_2015
{
    class Day_10
    {
        public static void ElvesLookElvesSay()
        {
            int count = 0;
            StringBuilder sb = new StringBuilder("1321131112");

            for (int j = 0; j < 50; j++)
            {
                string input = sb.ToString();
                sb = new StringBuilder();
                char current = input[0];

                for (int i = 0; i < input.Length; i++)
                {
                    while (i < input.Length && current == input[i])
                    {
                        i++;
                        count++;
                    }
                    sb.Append(count);
                    sb.Append(current);

                    count = 0;

                    if (i == input.Length)
                        break;

                    current = input[i];
                    i--;
                }
            }
            Console.WriteLine(sb.ToString().Length);
        }
    }
}
