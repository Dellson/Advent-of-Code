using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace AdventOfCode2020
{
    class Day04
    {
        static string[] Input;

        public static void Puzzle()
        {
            Input = Program.GetTextInputData("4");

            Puzzle1();
            Puzzle2();
        }

        private static void Puzzle1()
        {
            var validations = new Dictionary<string, string>
            {
                { "byr", @"byr:" },
                { "iyr", @"iyr:" },
                { "eyr", @"eyr:" },
                { "hgt", @"hgt:" },
                { "hcl", @"hcl:" },
                { "ecl", @"ecl:" },
                { "pid", @"pid:" }
                //,{ "cid", ":" }
            };

            Console.WriteLine(
                ScannerWithValidation(validations));
        }

        private static void Puzzle2()
        {
            var validations = new Dictionary<string, string>
            {
                { "byr", @"byr:(19[2-9][0-9]|200[0-2])\s+" },
                { "iyr", @"iyr:(201[0-9]|2020)\s+" },
                { "eyr", @"eyr:(202[0-9]|2030)\s+" },
                { "hgt", @"hgt:((1[5-8][0-9]|19[0-3])cm|(59|6[0-9]|7[0-6])in)\s+" },
                { "hcl", @"hcl:#([a-f]|[0-9]){6}\s+" },
                { "ecl", @"ecl:(amb|blu|brn|gry|grn|hzl|oth)\s+" },
                { "pid", @"pid:\d{9}\s+" }
                //,{ "cid", ":" }
            };

            Console.WriteLine(
                ScannerWithValidation(validations));
        }

        private static int ScannerWithValidation(Dictionary<string, string> validations)
        {
            int validatedPasswords = 0;
            int i = 0;

            while (i < Input.Length)
            {
                StringBuilder data = new StringBuilder(" ");

                while (i < Input.Length && Input[i].Length != 0)
                    data.Append(Input[i++]).Append(" ");

                if (validations.All(entry => Regex.Matches(data.ToString(), entry.Value).Count == 1))
                    validatedPasswords++;

                i++;
            }

            return validatedPasswords;
        }
    }
}