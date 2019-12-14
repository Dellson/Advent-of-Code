using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Math;

namespace Advent_of_Code_2019
{
    class Day_10
    {
        private static List<Asteroid> stationCandidates = new List<Asteroid>();

        static Day_10()
        {
            string[] inputData = File.ReadAllLines(Program.InputFolderPath + "Day-10-input.txt");

            for (int x = 0; x < inputData[0].Length; x++)
            {
                for (int y = 0; y < inputData.Length; y++)
                {
                    if (inputData[x][y] == '#')
                        stationCandidates.Add(new Asteroid(x, y, 0, 0, 0, 0));
                }
            }
        }

        public static void Puzzle()
        {
            foreach (Asteroid candidate in stationCandidates)
            {
                foreach (Asteroid asteroid in stationCandidates)
                {
                    FindNearestAsteroidsUsingNormalizedCoordinates(candidate, asteroid);
                }
            }

            int maxVisibleAsteroids = stationCandidates.Max(candidate => candidate.monitoredCoords.Count);
            var bestCandidate = stationCandidates.Find(c => c.monitoredCoords.Count == maxVisibleAsteroids);

            Console.WriteLine($"Puzzle one answer: {bestCandidate.monitoredCoords.Sum(bc => bc.x + bc.y)}");
            Console.WriteLine($"Puzzle one answer: {maxVisibleAsteroids - 1}");

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

        private static void FindNearestAsteroidsUsingNormalizedCoordinates(Asteroid candidate, Asteroid asteroid)
        {
            (int x, int y) nCoords = NormalizeCoordinates(asteroid.x - candidate.x, asteroid.y - candidate.y);
            asteroid.nx = nCoords.x;
            asteroid.ny = nCoords.y;
            Predicate<Asteroid> predicate = (a => a.nx == nCoords.x && a.ny == nCoords.y);

            if (!candidate.monitoredCoords.Exists(predicate))
                candidate.monitoredCoords.Add(new Asteroid(asteroid.x, asteroid.y, asteroid.x - candidate.x, asteroid.y - candidate.y, asteroid.nx, asteroid.ny));
            else if (Abs(asteroid.rx) < Abs(candidate.monitoredCoords.Find(a => a.nx == asteroid.nx && a.ny == asteroid.ny).rx)
                && Abs(asteroid.ry) < Abs(candidate.monitoredCoords.Find(a => a.nx == asteroid.nx && a.ny == asteroid.ny).ry))
            {
                Asteroid asteroidToReplace = candidate.monitoredCoords.Find(predicate);
                asteroidToReplace.x = asteroid.x;
                asteroidToReplace.y = asteroid.y;
            }
        }

        /// <summary>
        /// Model of an asteroid
        /// </summary>
        private class Asteroid
        {
            public int x { get; set; }
            public int y { get; set; }
            public int rx { get; set; }
            public int ry { get; set; }

            public int nx { get; set; }
            public int ny { get; set; }
            public List<Asteroid> monitoredCoords = new List<Asteroid>();

            public Asteroid(int x, int y, int rx, int ry, int nx, int ny)
            {
                this.x = x; 
                this.y = y;
                this.rx = rx;
                this.ry = ry;
                this.nx = nx;
                this.ny = ny;
            }
        }
    }
}
