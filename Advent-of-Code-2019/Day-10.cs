using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent_of_Code_2019
{
    class Day_10
    {
        private static List<(int x, int y, List<(int x, int y)> visibleAsteroidsNormalizedCoordinates)> stationCandidates = new List<(int, int, List<(int, int)>)>();

        static Day_10()
        {
            string[] inputData = File.ReadAllLines(Program.InputFolderPath + "Day-10-input.txt");

            for (int x = 0; x < inputData[0].Length; x++)
            {
                for (int y = 0; y < inputData.Length; y++)
                {
                    if (inputData[x][y] == '#')
                        stationCandidates.Add((x, y, new List<(int, int)>()));
                }
            }

            Puzzle();
            var bestCandidate = stationCandidates.Max(candidate => candidate.visibleAsteroidsNormalizedCoordinates.Count);

            Console.WriteLine($"coord: {bestCandidate}");

            //foreach (var candidate in stationCandidates)
            //    Console.WriteLine($"({candidate.x}, {candidate.y}) = {candidate.visibleAsteroidsNormalizedCoordinates.Count}");

            //foreach (var asteroid in stationCandidates.Find(c => c.visibleAsteroidsNormalizedCoordinates.Count == bestCandidate).visibleAsteroidsNormalizedCoordinates)
            //    Console.WriteLine($"({asteroid.x}, {asteroid.y})");

            //foreach (var candidate in stationCandidates)
            //{
            //    Console.WriteLine($"\nx = {candidate.x}, y = {candidate.y}");
            //}
        }

        public static string Puzzle()
        {
            foreach (var candidate in stationCandidates)
            {
                foreach (var asteroid in stationCandidates)
                {
                    //(int x, int y) normalizedCoords = NormalizeCoordinates(3,7);
                    (int x, int y) normalizedCoords = NormalizeCoordinates(asteroid.x - candidate.x, asteroid.y - candidate.y);
                    
                    if (!candidate.visibleAsteroidsNormalizedCoordinates.Exists(c => c.x == normalizedCoords.x && c.y == normalizedCoords.y))
                        candidate.visibleAsteroidsNormalizedCoordinates.Add(normalizedCoords);
                }
            }

            return string.Empty;
        }

        private static (int x, int y) NormalizeCoordinates(int x, int y)
        {
            //if (x == 1 && y == 2)
            //    Console.WriteLine("x == 1, y == 2");
            int xcopy = x;// Math.Abs(x);
            int ycopy = y;// Math.Abs(y);

            if (x == 0 && y == 0)
                return (0, 0);
            else if (x == 0 && y != 0)
                return (0, Math.Sign(y));
            else if (x != 0 && y == 0)
                return (Math.Sign(x), 0);

            if (xcopy < 0)
                xcopy = -xcopy;
            if (ycopy < 0)
                ycopy = -ycopy;

            while (xcopy != 0 && ycopy != 0)
            {
                if (xcopy >= ycopy)
                    xcopy %= ycopy;
                else
                    ycopy %= xcopy;
            }

            if (xcopy == 0)
                return (x / ycopy, y / ycopy);
            else
                return (x / xcopy, y / xcopy);
        }
    }
}