using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Advent_of_Code
{
    class DayTwentyOne
    {
        private string path = Directory.GetCurrentDirectory();
        private string toScramble;
        private StringBuilder strBuilder;
        private string[] input;

        public DayTwentyOne()
        {
            path = Path.Combine(path, "..\\..\\");
            path += "DayTwentyOneInput.txt";
            input = File.ReadAllLines(path);
        }

        public void puzzle()
        {
            partOne();
            Console.WriteLine("puzzle one: " + strBuilder.ToString());

            partTwo();
            Console.WriteLine("puzzle two: " + strBuilder.ToString());
        }

        private void partOne()
        {
            toScramble = "abcdefgh";
            strBuilder = new StringBuilder(toScramble);

            foreach (string command in input)
            {
                if (command.Contains("swap position"))
                {
                    MatchCollection pos = Regex.Matches(command, @"\d+");
                    swapPositionXY(int.Parse(pos[0].Value), int.Parse(pos[1].Value));
                }
                if (command.Contains("swap letter"))
                {
                    MatchCollection letters = Regex.Matches(command, @"(?<=letter ).");
                    swapXY(char.Parse(letters[0].Value), char.Parse(letters[1].Value));
                }
                if (command.Contains("step"))
                {
                    Match match = Regex.Match(command, "(left|right) (\\d)");
                    rotateXsteps(match.Groups[1].Value, int.Parse(match.Groups[2].Value));
                }
                if (command.Contains("based on"))
                {
                    Match index = Regex.Match(command, @"(?<=rotate based on position of letter )\w"); //(?<=BookTitle)
                    rotateBasedOnX(char.Parse(index.Value));
                }
                if (command.Contains("reverse positions"))
                {
                    MatchCollection positions = Regex.Matches(command, @"\d+");
                    reverseXthroughY(int.Parse(positions[0].Value), int.Parse(positions[1].Value));
                }
                if (command.Contains("move position"))
                {
                    MatchCollection positions = Regex.Matches(command, @"\d+");
                    moveXtoPositionY(int.Parse(positions[0].Value), int.Parse(positions[1].Value));
                }
            }
        }

        private void partTwo()
        {
            toScramble = "fbgdceah";
            strBuilder = new StringBuilder(toScramble);
            List<string> reversedInput = input.Reverse().ToList();

            foreach (string command in reversedInput)
            {
                if (command.Contains("swap position"))
                {
                    MatchCollection pos = Regex.Matches(command, @"\d+");
                    swapPositionXY(int.Parse(pos[1].Value), int.Parse(pos[0].Value));
                }
                if (command.Contains("swap letter"))
                {
                    MatchCollection letters = Regex.Matches(command, @"(?<=letter ).");
                    swapXY(char.Parse(letters[1].Value), char.Parse(letters[0].Value));
                }
                if (command.Contains("step"))
                {
                    Match match = Regex.Match(command, "(left|right) (\\d)");
                    string direction = match.Groups[1].Value == "left" ? "right" : "left";

                    rotateXsteps(direction, int.Parse(match.Groups[2].Value));
                }
                if (command.Contains("based on"))
                {
                    Match index = Regex.Match(command, @"(?<=rotate based on position of letter )\w"); //(?<=BookTitle)
                    unscrambleRotateBasedOnX(char.Parse(index.Value));
                }
                if (command.Contains("reverse positions"))
                {
                    MatchCollection positions = Regex.Matches(command, @"\d+");
                    reverseXthroughY(int.Parse(positions[0].Value), int.Parse(positions[1].Value));
                }
                if (command.Contains("move position"))
                {
                    MatchCollection positions = Regex.Matches(command, @"\d+");
                    unscrambleMoveXtoPositionY(int.Parse(positions[0].Value), int.Parse(positions[1].Value));
                }
            }
        }

        private void swapPositionXY(int indexX, int indexY)
        {
            char x = strBuilder[indexX];
            char y = strBuilder[indexY];

            strBuilder[indexX] = y;
            strBuilder[indexY] = x;
        }

        private void swapXY(char x, char y)
        {
            for (int i = 0; i < strBuilder.Length; ++i)
            {
                if (strBuilder[i].Equals(x))
                    strBuilder[i] = '1';
                if (strBuilder[i].Equals(y))
                    strBuilder[i] = '2';
            }

            for (int i = 0; i < strBuilder.Length; ++i)
            {
                if (strBuilder[i].Equals('1'))
                    strBuilder[i] = y;
                if (strBuilder[i].Equals('2'))
                    strBuilder[i] = x;
            }
        }

        private void rotateXsteps(string direction, int numberOfSteps)
        {
            string remains = "";
            numberOfSteps %= strBuilder.Length;

            if (direction.Equals("right"))
            {
                for (int i = strBuilder.Length - numberOfSteps; i < strBuilder.Length; ++i)
                {
                    remains += strBuilder[i];
                }
                strBuilder = strBuilder.Remove(strBuilder.Length - numberOfSteps, numberOfSteps);
                strBuilder.Insert(0, remains);
            }
            if (direction.Equals("left"))
            {
                for (int i = 0; i < numberOfSteps; ++i)
                {
                    remains += strBuilder[i];
                }
                strBuilder = strBuilder.Remove(0, numberOfSteps);
                strBuilder.Append(remains);
            }
        }

        private void rotateBasedOnX(char x)
        {
            int position = 0;

            for (int i = 0; i < toScramble.Length; ++i)
            {
                if (strBuilder[i].Equals(x))
                    position = i;
            }

            if (position >= 4)
                position++;
            position++;

            rotateXsteps("right", position);
        }

        private void unscrambleRotateBasedOnX(char x)
        {
            string original = strBuilder.ToString();

            for (int i = 1; i <= 10; ++i)
            {
                rotateXsteps("left", i);
                rotateBasedOnX(x);

                if (strBuilder.ToString().Equals(original))
                {
                    rotateXsteps("left", i);
                    break;
                }
                else
                    strBuilder = new StringBuilder(original);
            }
        }

        private void reverseXthroughY(int x, int y)
        {
            string line = "";

            for (int i = x; i <= y; ++i)
            {
                line += strBuilder[i];
            }

            int startIndex = x < y ? x : y;
            int endIndex = x > y ? x : y;

            strBuilder.Remove(startIndex, endIndex - startIndex + 1);

            string reversed = "";
            foreach (var element in line.Reverse())
                reversed += element;

            strBuilder.Insert(startIndex, reversed);
        }

        private void moveXtoPositionY(int x, int y)
        {
            string wanderingLetter = strBuilder[x].ToString();
            strBuilder.Replace(strBuilder[x].ToString(), string.Empty);
            strBuilder.Insert(y, wanderingLetter);
        }

        private void unscrambleMoveXtoPositionY(int x, int y)
        {
            string original = strBuilder.ToString();

            for (int i = 0; i < strBuilder.Length; ++i)
            {
                for (int j = 0; j < strBuilder.Length; ++j)
                {
                    moveXtoPositionY(i, j);
                    moveXtoPositionY(x, y);

                    if (strBuilder.ToString().Trim().Equals(original))
                    {
                        moveXtoPositionY(i, j);
                        return;
                    }
                    else
                        strBuilder = new StringBuilder(original);
                }
            }
        }
    }
}