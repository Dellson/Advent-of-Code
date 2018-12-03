using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_of_Code_2018
{
    class Day_01
    {
        private static string[] _input = System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-01-input.txt");
        private static long[] input;

        static Day_01()
        {
            input = new long[_input.Length];

            for (int i = 0; i < _input.Length; i++)
            {
                input[i] = Convert.ToInt64(Regex.Match(_input[i], @"-?\d+").Value);
            }
        }

        public static void Challenge()
        {
            bool isFound = false;
            long sum = 0;
            var collection = new Dictionary<long, short>();

            //for (int i = 0; i <20; i++)
            while(!isFound)
            {
                //foreach (var line in _input)
                for (int j = 0; j < input.Length; j++)
                {
                    sum += input[j];
                    if (collection.ContainsKey(sum))
                    {
                        isFound = true;
                        Console.WriteLine("TWICE " + sum);
                        return;
                    }
                    else
                    {
                        collection.Add(sum, 0);
                    }
                    //Console.WriteLine(sum);

                }
                //Console.WriteLine("DEBUG");
                Console.WriteLine(sum);


                
            }

            /*for (int i = 0; i < collection.Count; i++)
            {
                for (int j = 0; j < collection.Count; j++)
                {
                    if (collection[i] == collection[j] && i != j)
                        Console.WriteLine("RESULT " + collection[i]);
                }
            }

            Console.WriteLine(sum);
            Console.WriteLine("DEBUG");*/
        }
    }
}

/*int sum = 0;
            var collection = new List<int>();

            foreach (var line in _input)
            {
                sum += Convert.ToInt32(Regex.Match(line, @"-?\d+").Value);
                if (collection.Contains(sum))
                {
                    Console.WriteLine(sum);
                }
                
            }
            Console.WriteLine(sum);
*/