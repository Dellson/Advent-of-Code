using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Math;

namespace Advent_of_Code_2019
{
    class Day_10
    {
        private static List<(int x, int y, List<(int x, int y, int nx, int ny)> monitoredAsteroidsCoords)> stationCandidates = 
            new List<(int, int, List<(int, int, int, int)>)>();

        static Day_10()
        {
            string[] inputData = File.ReadAllLines(Program.InputFolderPath + "Day-10-input.txt");

            for (int x = 0; x < inputData[0].Length; x++)
            {
                for (int y = 0; y < inputData.Length; y++)
                {
                    if (inputData[x][y] == '#')
                        stationCandidates.Add((x, y, new List<(int, int, int, int)>()));
                }
            }
        }

        public static void Puzzle()
        {
            foreach (var candidate in stationCandidates)
            {
                foreach (var asteroid in stationCandidates)
                {
                    (int x, int y) normalizedCoords = NormalizeCoordinates(asteroid.x - candidate.x, asteroid.y - candidate.y);
                    
                    if (!candidate.monitoredAsteroidsCoords.Exists(c => c.nx == normalizedCoords.x && c.ny == normalizedCoords.y))
                        candidate.monitoredAsteroidsCoords.Add((asteroid.x, asteroid.y, normalizedCoords.x, normalizedCoords.y));
                }
            }

            Console.WriteLine($"Puzzle one answer: {stationCandidates.Max(candidate => candidate.monitoredAsteroidsCoords.Count) - 1}");
        }

        private static (int x, int y) NormalizeCoordinates(int x, int y)
        {
            if (x == 0 || y == 0)
            {
                return (
                    x == 0 ? 0 : Sign(x),
                    y == 0 ? 0 : Sign(y));

            }

            int xcopy = x * Sign(x);
            int ycopy = y * Sign(y);

            while (xcopy != 0 && ycopy != 0)
            {
                if (xcopy >= ycopy)
                    xcopy %= ycopy;
                else
                    ycopy %= xcopy;
            }

            return (xcopy == 0 ?
                (x / ycopy, y / ycopy) :
                (x / xcopy, y / xcopy));
        }
    }
}