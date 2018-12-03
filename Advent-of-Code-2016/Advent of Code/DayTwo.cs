using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class DayTwo
    {
        private string path = Directory.GetCurrentDirectory();
        private string[] input;

        public DayTwo()
        {
            path = Path.Combine(path, "..\\..\\");
            path += "DayTwoInput.txt";

            input = File.ReadAllLines(path);

            /*foreach (string i in input)
                System.Console.WriteLine(i);*/
        }

        public int PuzzleOne()
        {
            int code = 0;
            int[] currentPosition = new int[2] { 2, 2 };
            string[,] keypad = new string[5,5] { { "", "", "", "", "" },
                                                 { "", "1", "2", "3", "" },
                                                 { "", "4", "5", "6", "" },
                                                 { "", "7", "8", "9", "" },
                                                 { "", "", "", "", "" }};

            foreach (string line in input)
            {
                foreach (char command in line)
                {
                    //Console.WriteLine(command);

                    if (command == 'L')
                    {
                        if (keypad[currentPosition[0], currentPosition[1] - 1] != "")
                        {
                            currentPosition[1] -= 1;
                        }
                    }
                    if (command == 'R')
                    {
                        if (keypad[currentPosition[0], currentPosition[1] + 1] != "")
                        {
                            currentPosition[1] += 1;
                        }
                    }
                    if (command == 'U')
                    {
                        if (keypad[currentPosition[0] - 1, currentPosition[1]] != "")
                        {
                            currentPosition[0] -= 1;
                        }
                    }
                    if (command == 'D')
                    {
                        if (keypad[currentPosition[0] + 1, currentPosition[1]] != "")
                        {
                            currentPosition[0] += 1;
                        }
                    }
                }

                code = code * 10 + Int32.Parse(keypad[currentPosition[0], currentPosition[1]]);
            }

            return code;
        }

        public string PuzzleTwo()
        {
            string code = "";
            int[] currentPosition = new int[2] { 3, 1 };
            string[,] keypad = new string[7, 7] { { "", "", "", "", "", "", "" },
                                                  { "", "", "", "1", "", "", "" },
                                                  { "", "", "2", "3", "4", "", "" },
                                                  { "", "5", "6", "7", "8", "9", "" },
                                                  { "", "", "A", "B", "C", "", "" },
                                                  { "", "", "", "D", "", "", "" },
                                                  { "", "", "", "", "", "", "" }};

            foreach (string line in input)
            {
                foreach (char command in line)
                {
                    //Console.WriteLine(command);

                    if (command == 'L')
                    {
                        if (keypad[currentPosition[0], currentPosition[1] - 1] != "")
                        {
                            currentPosition[1] -= 1;
                        }
                    }
                    if (command == 'R')
                    {
                        if (keypad[currentPosition[0], currentPosition[1] + 1] != "")
                        {
                            currentPosition[1] += 1;
                        }
                    }
                    if (command == 'U')
                    {
                        if (keypad[currentPosition[0] - 1, currentPosition[1]] != "")
                        {
                            currentPosition[0] -= 1;
                        }
                    }
                    if (command == 'D')
                    {
                        if (keypad[currentPosition[0] + 1, currentPosition[1]] != "")
                        {
                            currentPosition[0] += 1;
                        }
                    }
                }

                code += keypad[currentPosition[0], currentPosition[1]];
            }

            return code;
        }
    }
}
