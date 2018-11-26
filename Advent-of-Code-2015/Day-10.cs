using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    class Day_10
    {
        public static void ElvesLookElvesSay()
        {
            string inp = "21";
            char current = inp[0];
            int count = 0;
            StringBuilder sb;

            for (int j = 0; j < 1; j++)
            {
                string input = inp;
                sb = new StringBuilder();

                for (int i = 0; i < input.Length; i++)
                {
                    while (i < input.Length && current == input[i])
                    {
                        i++;
                        count++;
                    }
                    sb.Append(count);
                    sb.Append(current);

                    if (i == input.Length)
                        break;

                    current = input[i];
                    count = 0;
                    i--;
                }
                inp = sb.ToString();
            }

            Console.WriteLine(inp.ToString());
        }
    }
}
