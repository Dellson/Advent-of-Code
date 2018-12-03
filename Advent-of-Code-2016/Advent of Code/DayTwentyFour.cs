using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent_of_Code
{
    class DayTwentyFour
    {
        private string path = Directory.GetCurrentDirectory();
        private List<Node> nodes = new List<Node>();
        private string[] input;
        private List<int[]> possiblePermutations = new List<int[]>();

        public DayTwentyFour()
        {
            path = Path.Combine(path, "..\\..\\DayTwentyFourInput.txt");
            input = File.ReadAllLines(path);

            for (int i = 0; i < input.Length; ++i)
                for (int j = 0; j < input[i].Length; ++j)
                    nodes.Add(new Node(i, j, input[i][j]));

            foreach (Node node in nodes)
                node.addNeighboors(nodes);
        }

        public void puzzle()
        {
            List<int> values = new List<int>();
            List<List<int>> links = new List<List<int>>(); //każdy link ma format [start, end, distance]

            foreach (Node node in nodes)
                if (node.value != '#' && node.value != '.')
                    values.Add(node.value);
            
            foreach (IEnumerable combination in GetKCombs(values, 2))
            {
                links.Add(new List<int>());
                foreach (int value in combination)
                    links[links.Count - 1].Add(value);
                links[links.Count - 1].Add(findShortestPath(findNode(links[links.Count - 1][0]), findNode(links[links.Count - 1][1])));
            }

            values.Remove(0);
            findPossiblePermutations(values.ToArray(), 0);

            int minCount = int.MaxValue;
            foreach (int[] permutation in possiblePermutations)
            {
                int count = 0;

                for (int i = 1; i < permutation.Length; ++i)
                    count += links.Find(pair => (pair[0] == permutation[i - 1] && pair[1] == permutation[i])
                                             || (pair[1] == permutation[i - 1] && pair[0] == permutation[i]))[2];
                if (count < minCount)
                    minCount = count;
            }
            Console.WriteLine("Count: " + minCount);
        }

        private int findShortestPath(Node startNode, Node destination)
        {
            Queue queue = new Queue();
            queue.Enqueue(new Tuple<Node, int>(startNode, 0));
            List<Node> visitedNodes = new List<Node>();
            visitedNodes.Add(startNode);
            int count = 0;

            while (queue.Count > 0)
            {
                Tuple<Node, int> currentTuple = (Tuple<Node, int>)queue.Dequeue();
                Node currentNode = currentTuple.Item1;

                if (currentNode.value == destination.value)
                    count = currentTuple.Item2;

                foreach (Node neighboor in currentNode.neighboors)
                {
                    if (!visitedNodes.Contains(neighboor))
                    {
                        visitedNodes.Add(neighboor);
                        queue.Enqueue(new Tuple<Node, int>(neighboor, currentTuple.Item2 + 1));
                    }
                }
            }
            return count;
        }

        private Node findNode(int value)
        {
            return nodes.Find(node => node.value == value);
        }

        private IEnumerable<IEnumerable<T>> GetKCombs<T>(IEnumerable<T> list, int length) where T : IComparable
        {
            if (length == 1) return list.Select(t => new T[] { t });
            return GetKCombs(list, length - 1)
                .SelectMany(t => list.Where(o => o.CompareTo(t.Last()) > 0),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        public void findPossiblePermutations(int[] arr, int k)
        {
            if (k >= arr.Length)
            {
                int[] array = new int[arr.Length + 2];
                for (int i = 0; i < arr.Length; ++i)
                    array[i + 1] = arr[i];
                possiblePermutations.Add(array);
            }
            else
            {
                findPossiblePermutations(arr, k + 1);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    findPossiblePermutations(arr, k + 1);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        private void Swap<T>(ref T item1, ref T item2)
        {
            T temp = item1;
            item1 = item2;
            item2 = temp;
        }

        private class Node
        {
            public int x;
            public int y;
            public int value;
            public List<Node> neighboors { get; private set; }

            public Node(int x, int y, char value)
            {
                neighboors = new List<Node>();
                this.x = x;
                this.y = y;
                if (value == '#' || value == '.')
                    this.value = value;
                else
                    this.value = int.Parse(value.ToString());
            }

            public void addNeighboors(List<Node> nodes)
            {
                foreach (Node neighboor in nodes)
                    if ((neighboor.value != '#') && (value != '#') &&
                       ((neighboor.x == x + 1 && neighboor.y == y) || (neighboor.x == x - 1 && neighboor.y == y) ||
                        (neighboor.x == x && neighboor.y == y + 1) || (neighboor.x == x && neighboor.y == y - 1)))
                        neighboors.Add(neighboor);
            }
        }
    }
}