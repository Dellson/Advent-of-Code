using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class DayThree
    {
        private string path = Directory.GetCurrentDirectory();
        private string[] input;

        public DayThree()
        {
            path = Path.Combine(path, "..\\..\\");
            path += "DayThreeInput.txt";

            input = File.ReadAllLines(path);
        }

        public int puzzleOne()
        {
            List<string[]> trianglesSides = new List<string[]>();

            foreach (string triangle in input)
            {
                trianglesSides.Add(triangle.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            }

            return trianglesSides.FindAll(triangle =>
            {
                List<int> sides = new List<int>();

                foreach (string side in triangle)
                {
                    sides.Add(Int32.Parse(side));
                }
                Console.WriteLine(sides.Max() + " " + sides.Sum());

                return 2 * sides.Max() < sides.Sum();
            }).Count;
        }

        public int puzzleTwo()
        {
            List<string[]> trianglesSides = new List<string[]>();
            List<int> verticalTriangleSidesColumnOne = new List<int>();
            List<int> verticalTriangleSidesColumnTwo = new List<int>();
            List<int> verticalTriangleSidesColumnThree = new List<int>();
            List<int[]> verticalTriangleSides = new List<int[]>();

            foreach (string triangle in input)
            {
                trianglesSides.Add(triangle.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            }

            foreach (string[] triangle in trianglesSides)
            {
                verticalTriangleSidesColumnOne.Add(int.Parse(triangle[0]));
                verticalTriangleSidesColumnTwo.Add(int.Parse(triangle[1]));
                verticalTriangleSidesColumnThree.Add(int.Parse(triangle[2]));
            }

            for (int i = 2; i < verticalTriangleSidesColumnOne.Count; i += 3)
            {
                verticalTriangleSides.Add(new int[3] { verticalTriangleSidesColumnOne[i - 2], verticalTriangleSidesColumnOne[i - 1], verticalTriangleSidesColumnOne[i] });
                verticalTriangleSides.Add(new int[3] { verticalTriangleSidesColumnTwo[i - 2], verticalTriangleSidesColumnTwo[i - 1], verticalTriangleSidesColumnTwo[i] });
                verticalTriangleSides.Add(new int[3] { verticalTriangleSidesColumnThree[i - 2], verticalTriangleSidesColumnThree[i - 1], verticalTriangleSidesColumnThree[i] });
            }

            return verticalTriangleSides.FindAll(triangle =>
            {
                Console.WriteLine(triangle.Max() + " " + triangle.Sum());

                return 2 * triangle.Max() < triangle.Sum();
            }).Count;
        }
    }
}
