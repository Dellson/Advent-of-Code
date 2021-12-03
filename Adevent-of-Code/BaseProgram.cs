using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class BaseProgram
    {
        public static string InputFolderPath { get; protected set; }

        public static string[] GetTextInputData(string dayNumber)
        {
            return File.ReadAllLines(
                Path.Combine(InputFolderPath, $"Day{dayNumber.PadLeft(2, '0')}.txt"));
        }

        public static List<int> GetNumberInputData(string dayNumber)
        {
            return GetTextInputData(dayNumber)
                .ToList()
                .ConvertAll(Convert.ToInt32);
        }

        public static string[] GetInputDataByRegex()
        {
            throw new NotImplementedException();
        }
    }
}
