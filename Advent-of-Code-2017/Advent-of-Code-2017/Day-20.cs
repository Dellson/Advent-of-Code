using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2017
{
    class Day_20
    {
        private static List<Particle> particles = new List<Particle>();

        static Day_20()
        {
            foreach (string line in File.ReadAllLines(Program.InputFolderPath + "Day-20-input.txt"))
                particles.Add(new Particle(line));
        }

        public static void PuzzleOne()
        {
            Console.WriteLine(particles.FindIndex(particle => particle == particles.
                OrderBy(p => p.a.Sum(i => Math.Abs(i))).
                ThenBy(p => p.p.Sum(i => Math.Abs(i))).ToList()[0]));
        }

        public static void PuzzleTwo()
        {
            for (int i = 0; i < 100; ++i)
            {
                foreach (Particle p1 in particles)
                    foreach (Particle p2 in particles)
                        if (p1 != p2) p1.CompareParticles(p2);

                particles.RemoveAll(p => p.collided);
                particles.ForEach(p => p.Update());
            }
            Console.WriteLine("Particles left: " + particles.Count);
        }

        private class Particle
        {
            public List<int> p;
            public List<int> v;
            public List<int> a;
            public bool collided = false;

            public Particle(string line)
            {
                var matches = Regex.Matches(line, @"\-*\d+");
                p = new List<int>() { Convert.ToInt32(matches[0].Value), Convert.ToInt32(matches[1].Value), Convert.ToInt32(matches[2].Value) };
                v = new List<int>() { Convert.ToInt32(matches[3].Value), Convert.ToInt32(matches[4].Value), Convert.ToInt32(matches[5].Value) };
                a = new List<int>() { Convert.ToInt32(matches[6].Value), Convert.ToInt32(matches[7].Value), Convert.ToInt32(matches[8].Value) };
            }

            public void CompareParticles(Particle particle)
            {
                if (p[0] == particle.p[0] && p[1] == particle.p[1] && p[2] == particle.p[2])
                    collided = true;
            }

            public void Update()
            {
                for (int i = 0; i < 3; ++i)
                    p[i] += (v[i] += a[i]);
            }
        }
    }
}