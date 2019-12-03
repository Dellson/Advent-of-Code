using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2019
{
    class Day_03
    {
        const int constant = 1000;
        static string[,] array = new string[constant, constant];
        static (int x, int y) currentPos = (constant/2, constant/2);
        static List<int> distances = new List<int>();

        static Day_03()
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = "_";
                }
            }

            array[currentPos.x, currentPos.y] = "o";
        }

        public static void Puzzle()
        {
            var list =
                File.ReadAllLines(Program.InputFolderPath + "Day-03-input.txt");


            GetSomething(list[0]);
            currentPos = (constant/2, constant/2);

            GetSomething(list[1]);

            distances.Select(x => Math.Abs(x) - constant).ToList().Sort();

            for (int i = 0; i < array.GetLength(0); i++)
            //{
            //    Console.WriteLine();
            //    for (int j = 0; j < array.GetLength(1); j++)
            //    {
            //        Console.Write(array[j,i] + " ");
            //    }
            //}

            Console.WriteLine(distances[0] - constant);
        }

        static private void GetSomething(string list)
        {
            foreach (Match element in Regex.Matches(list, @"(L|R|U|D)\d+"))
            {
                var number = Convert.ToInt32(Regex.Match(element.Value, @"\d+").Value);

                if (element.Value[0] == 'L')
                {
                    for (int i = currentPos.x - 1; i >= currentPos.x - number; i--)
                    {
                        if (array[i, currentPos.y] == ".")
                            distances.Add(currentPos.y + i);
                        else
                            array[i, currentPos.y] = ".";
                    }

                    currentPos.x -= number;
                }
                if (element.Value[0] == 'R')
                {
                    for (int i = currentPos.x + 1; i <= currentPos.x + number; i++)
                    {
                        if (array[i, currentPos.y] == ".")
                            distances.Add(currentPos.y + i);
                        else
                            array[i, currentPos.y] = ".";
                    }

                    currentPos.x += number;
                }
                if (element.Value[0] == 'D')
                {
                    //499
                    //3
                    //497
                    for (int i = currentPos.y - 1; i >= currentPos.y - number; i--)
                    {
                        if (array[currentPos.x, i] == ".")
                            distances.Add(currentPos.x + i);
                        else
                            array[currentPos.x, i] = ".";
                    }

                    currentPos.y -= number;
                }
                if (element.Value[0] == 'U')
                {
                    for (int i = currentPos.y + 1; i <= currentPos.y + number; i++)
                    {
                        if (array[currentPos.x, i] == ".")
                            distances.Add(currentPos.x + i);
                        //array[currentPos.x, i] = "x";
                        else
                            array[currentPos.x, i] = ".";
                    }

                    currentPos.y += number;
                }

                //for (int i = 0; i < array.GetLength(0); i++)
                //{
                //    Console.WriteLine();
                //    for (int j = 0; j < array.GetLength(1); j++)
                //    {
                //        Console.Write(array[j, i] + " ");
                //    }
                //}
            }
        }

        static private int GetManhattanDistance(int x, int y)
        {
            x = Math.Abs(x - (constant / 2));
            y = Math.Abs(y - (constant / 2));

            return x + y;
        }
    }
}