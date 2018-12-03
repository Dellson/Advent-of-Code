using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    class DayThirteen
    {
        
        private List<List<bool>> buildingCrossSection = new List<List<bool>>(); //listy kolumn przechowują wiersze
        private List<Tuple<int, int, int>> nodeDistance = new List<Tuple<int, int, int>>();
        Queue<Tuple<int, int>> nodes = new Queue<Tuple<int, int>>();

        private const int designersFavoriteNumber = 1362; //1362
        private Tuple<int, int> solution;
        
        public DayThirteen()
        {
            solution = new Tuple<int, int>(31, 39); //(7, 4) (31, 39)

            for (int i = 0; i < 50; ++i)
            {
                buildingCrossSection.Add(new List<bool>());

                for (int j = 0; j < 50; ++j)
                {
                    buildingCrossSection[i].Add(determineSpaceType(j, i));
                }
            }
            //printMap();
        }

        public void puzzleOne()
        {
            findShortestPath();

            //printMap();
        }

        public void puzzleTwo()
        {
            int pathsShorterThen51 = 0;
            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 0; i < 50; ++i)
            {
                for (int j = 0; j < 50; ++j)
                {
                    if ((i + j) < 51)
                    {
                        //Console.WriteLine(i + " " + j);
                        if (findShortestPath(new Tuple<int, int>(i, j)) < 51)
                            pathsShorterThen51++;
                    }
                }
                //Console.WriteLine("Zadanie 2: " + pathsShorterThen51);
            }
            sw.Stop();

            Console.WriteLine("Zadanie 2: " + pathsShorterThen51 + ", czas: " + sw.Elapsed);
        }

        //zadanie jeden
        private void findShortestPath()
        {
            nodes.Enqueue(new Tuple<int, int>(1, 1));
            nodeDistance.Add(new Tuple<int, int, int>(1, 1, 0));

            while (nodes.Count > 0)
            {
                var node = nodes.Dequeue();
                
                if (node.Item1 == solution.Item1 && node.Item2 == solution.Item2)
                {
                    Console.WriteLine(solution.Item1 + ", " + solution.Item2);

                    var previousTuple = nodeDistance.Find(item =>
                        item.Item1 == node.Item1 &&
                        item.Item2 == node.Item2 ? true : false);

                    //Console.WriteLine("distance " + previousTuple.Item3 + " " + nodeDistance.Count);
                    Console.WriteLine("Zadanie 1: " + previousTuple.Item3);

                    return;
                }

                foreach (var neighboor in findNeighboors(node.Item1, node.Item2))
                {
                    if (!nodes.Contains(neighboor))
                    {
                        nodes.Enqueue(neighboor);

                        var previousTuple = nodeDistance.Find(item =>
                        item.Item1 == node.Item1 &&
                        item.Item2 == node.Item2 ? true : false);


                        nodeDistance.Add(new Tuple<int, int, int>(neighboor.Item1, neighboor.Item2, previousTuple.Item3 + 1));
                    } 
                }
            }

            nodeDistance.Clear();
            nodes.Clear();
        }

        //zadanie dwa
        private int  findShortestPath(Tuple<int, int> coordinates)
        {
            int loopsSinceLastUpdate = 0;
            solution = new Tuple<int, int>(coordinates.Item1, coordinates.Item2);
            nodes.Enqueue(new Tuple<int, int>(1, 1));
            nodeDistance.Add(new Tuple<int, int, int>(1, 1, 0));

            if (!buildingCrossSection[coordinates.Item2][coordinates.Item1])
                return 51;

            while (nodes.Count > 0)
            {
                var node = nodes.Dequeue();

                if (nodeDistance.Find(item =>
                    item.Item1 == node.Item1 &&
                    item.Item2 == node.Item2 ? true : false).Item3 >= 51)
                {
                    continue;
                }

                if (node.Item1 == solution.Item1 && node.Item2 == solution.Item2)
                {
                    //Console.WriteLine("Znaleziono trafienie dla współrzędnych (" + solution.Item1 + ", " + solution.Item2 + ")");

                    var previousTuple = nodeDistance.Find(item =>
                        item.Item1 == node.Item1 &&
                        item.Item2 == node.Item2 ? true : false);

                    return previousTuple.Item3;
                }

                foreach (var neighboor in findNeighboors(node.Item1, node.Item2))
                {
                    if (!nodes.Contains(neighboor))
                    {
                        nodes.Enqueue(neighboor);

                        var previousTuple = nodeDistance.Find(item =>
                        item.Item1 == node.Item1 &&
                        item.Item2 == node.Item2 ? true : false);

                        if (!nodeDistance.Exists(p => p.Item1 == neighboor.Item1 && p.Item2 == neighboor.Item2))
                        {
                            nodeDistance.Add(new Tuple<int, int, int>(neighboor.Item1, neighboor.Item2, previousTuple.Item3 + 1));
                            loopsSinceLastUpdate = 0;
                        }
                    }
                }

                if (loopsSinceLastUpdate >= nodeDistance.Count)
                    return 51;

                loopsSinceLastUpdate++;
            }

            return 51;
        }
        
        private bool determineSpaceType(int x, int y)
        {
            int sum = (x * x) + (3 * x) + (2 * x * y) + y + (y * y) + designersFavoriteNumber;
            string binary = Convert.ToString(sum, 2).Replace("0", string.Empty);

            return binary.Length % 2 == 0 ? true : false;
        }

        private List<Tuple<int, int>> findNeighboors(int x, int y)
        {
            List<Tuple<int, int>> neighboors = new List<Tuple<int, int>>();
            
            if (x - 1 >= 0 && buildingCrossSection[y][x - 1] == true)
                neighboors.Add(new Tuple<int, int>(x - 1, y));
            if (y - 1 >= 0 && buildingCrossSection[y - 1][x] == true)
                neighboors.Add(new Tuple<int, int>(x, y - 1));
            if (x + 1 < buildingCrossSection[0].Count && buildingCrossSection[y][x + 1] == true)
                neighboors.Add(new Tuple<int, int>(x + 1, y));
            if (y + 1 < buildingCrossSection.Count && buildingCrossSection[y + 1][x] == true)
                neighboors.Add(new Tuple<int, int>(x, y + 1));

            return neighboors;
        }

        private void printMap()
        {
            for (int i = 0; i < 40; ++i)
            {
                for (int j = 0; j < 40; ++j)
                {
                    if (buildingCrossSection[i][j])
                    {
                        if (nodeDistance.Exists(p => p.Item1 == j && p.Item2 == i))
                        {
                            Console.Write(nodeDistance.Find(p => p.Item1 == j && p.Item2 == i).Item3);
                            if (nodeDistance.Find(p => p.Item1 == j && p.Item2 == i).Item3.ToString().Length == 1)
                                Console.Write(". ");
                            else
                                Console.Write(" ");
                        }
                        else
                            Console.Write(".. ");
                    }
                    else
                        Console.Write("## ");
                }
            }
        }
    }
}
