using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    class DayEight
    {
        private string path = Directory.GetCurrentDirectory();
        private string[] input;
        private bool[][] screen;

        private int rows;
        private int columns;

        public DayEight()
        {
            rows = 6;
            columns = 50;

            path = Path.Combine(path, "..\\..\\");
            path += "DayEightInput.txt";

            input = File.ReadAllLines(path);

            screen = new bool[6][];
            
            for (int i = 0; i < 6; ++i)
            {
                screen[i] = new bool[50];
                for (int j = 0; j < 50; ++j)
                {
                    screen[i][j] = false;
                }
            }
        }

        public DayEight(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;

            screen = new bool[rows][];

            for (int i = 0; i < rows; ++i)
            {
                screen[i] = new bool[columns];
                for (int j = 0; j < columns; ++j)
                {
                    screen[i][j] = false;
                }
            }
        }

        public int puzzleOne()
        {
            int pixelsLit = 0;

            foreach (string line in input)
            {
                if (line.Contains("rect"))
                    rectAxB(screen, line);
                if (line.Contains("row"))
                    shiftRow(screen, line);
                if (line.Contains("column"))
                    shiftColumn(screen, line);
            }

            printArray(screen);

            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    if (screen[i][j] == true)
                        pixelsLit++;
                }
            }

            return pixelsLit;
        }
        
        private void rectAxB(bool[][] array, string command)
        {
            string[] dimensions = new string[2];
            
            command = command.Replace("rect ", string.Empty);
            dimensions = command.Split(new char[] { 'x' }, StringSplitOptions.None);

            for (int i = 0; i < int.Parse(dimensions[0]); ++i)
            {
                for (int j = 0; j < int.Parse(dimensions[1]); ++j)
                {
                    array[j][i] = !array[j][i];
                }
            }
        }

        private void shiftRow(bool[][] array, string command)
        {
            command = command.Replace("rotate row y=", string.Empty);
            int row = int.Parse(command.Split(new string[] { " by " }, StringSplitOptions.None)[0]);
            int shift = int.Parse(command.Split(new string[] { " by " }, StringSplitOptions.None)[1]);
            
            bool[] currentRow = array[row];
            bool[] exceed = currentRow.Skip(currentRow.Length - shift).ToArray();
            bool[] shiftedRow = new bool[currentRow.Length];

            for (int i = 0; i < shift; ++i)
            {
                shiftedRow[i] = exceed[i];
            }

            for (int i = shift; i < currentRow.Length; ++i)
            {
                shiftedRow[i] = currentRow[i - shift];
            }

            for (int i = 0; i < columns; ++i)
            {
                array[row][i] = shiftedRow[i];
            }
        }

        private void shiftColumn(bool[][] array, string command)
        {
            command = command.Replace("rotate column x=", string.Empty);
            int column = int.Parse(command.Split(new string[] { " by " }, StringSplitOptions.None)[0]);
            int shift = int.Parse(command.Split(new string[] { " by " }, StringSplitOptions.None)[1]);

            bool[] currentColumn = new bool[rows];
            for (int i = 0; i < rows; ++i)
            {
                currentColumn[i] = array[i][column];
            }

            bool[] exceed = currentColumn.Skip(currentColumn.Length - shift).ToArray();
            bool[] shiftedRow = new bool[currentColumn.Length];

            for (int i = 0; i < shift; ++i)
            {
                shiftedRow[i] = exceed[i];
            }

            for (int i = shift; i < currentColumn.Length; ++i)
            {
                shiftedRow[i] = currentColumn[i - shift];
            }

            for (int i = 0; i < rows; ++i)
            {
                array[i][column] = shiftedRow[i];
            }
        }

        private void printArray(bool[][] array)
        {
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    if (array[i][j] == true)
                        Console.Write("x ");
                    else
                        Console.Write(". ");
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }
    }
}
