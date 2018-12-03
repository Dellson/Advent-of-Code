using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Advent_of_Code_2015
{
    class Day_12
    {
        private static string _input = System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-12-input.txt")[0];

        public static void Challenge()
        {
            StringBuilder sb = new StringBuilder();
            int sum = 0;

            for (int i = 0; i < _input.Length - 2; i++)
            {
                if (_input[i] == '{')
                {
                    i++;
                    //sum += RecursivelySum(ref i);
                }
            }
            Console.WriteLine(sum);
        }
        //Console.WriteLine(15 - sum);
        // 91488 - too low
        // 102840 - too high
    }
}