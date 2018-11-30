using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace Advent_of_Code_2015
{
    class Day_12
    {
        private static string _input = System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-12-input.txt")[0];

        public static void Challenge()
        {
            dynamic inputJson = JObject.Parse(_input);

            string name = inputJson.Name;
            string address = inputJson.Address.City;

            StringBuilder sb = new StringBuilder();
            int sum = 0;

            for (int i = 0; i < _input.Length - 2; i++)
            {
                if (_input[i] == '{')
                {
                    i++;
                    sum += RecursivelySum(ref i);
                }
            }

            /*var matches = Regex.Matches(_input, @"\d+");
            var matches2 = Regex.Matches(_input, @"-?\d+");

            int sum = 0;

            foreach (var match in matches2)
            {
                sum += Convert.ToInt32(match.ToString());
            }*/

            //Console.WriteLine(sum);
        }

        private static int RecursivelySum(ref int i)
        {
            int sum = 0;
            while (_input[i] != '}')
            {
                if ()
            }
            return 0;
        }
    }
}
