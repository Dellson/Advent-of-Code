using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Advent_of_Code
{
    class DayEleven
    {
        static HashSet<int>[] usedCombinations = new HashSet<int>[4];
        List<List<int>> floorsStart;
        static Queue nodes = new Queue();

        public DayEleven()
        {
            floorsStart = new List<List<int>>();
            floorsStart.Add(new List<int>());
            floorsStart.Add(new List<int>());
            floorsStart.Add(new List<int>());
            floorsStart.Add(new List<int>());

            usedCombinations[0] = new HashSet<int>();
            usedCombinations[1] = new HashSet<int>();
            usedCombinations[2] = new HashSet<int>();
            usedCombinations[3] = new HashSet<int>();

            floorsStart[0].Add(70);
            floorsStart[0].Add(71);
            floorsStart[0].Add(60);
            floorsStart[0].Add(61);

            floorsStart[0].Add(10);
            floorsStart[0].Add(11);

            floorsStart[1].Add(20);
            floorsStart[1].Add(30);
            floorsStart[1].Add(40);
            floorsStart[1].Add(50);

            floorsStart[2].Add(21);
            floorsStart[2].Add(31);
            floorsStart[2].Add(41);
            floorsStart[2].Add(51);
        }

        public void puzzle()
        {
            Stopwatch sw = Stopwatch.StartNew();
            nodes.Enqueue(new Snapshot(0, floorsStart, 0));

            while (nodes.Count > 0)
            {
                Snapshot node = (Snapshot)nodes.Dequeue();
                foreach (var possibility in findScenarios(node))
                {
                    nodes.Enqueue(possibility);

                    if (possibility.floors[3].Count == 14)
                    {
                        Console.WriteLine("ilośc kroków: " + possibility.steps);
                        printFloors(possibility);

                        sw.Stop();
                        Console.WriteLine(sw.Elapsed);
                        return;
                    }
                }
            }

            sw.Stop();
            Console.WriteLine("FAILED " + sw.Elapsed);
        }
        /**/
        private HashSet<Snapshot> findScenarios(Snapshot snapshot)
        {
            HashSet<Snapshot> correctCombinations = new HashSet<Snapshot>();
            var acceptablePossibilities = Combinations(snapshot.floors[snapshot.currentFloor]);

            foreach (var item in acceptablePossibilities)
            {
                var currentElements = item.ToList();

                if (!willTheyPrevail(currentElements))
                    continue;
                Snapshot newSnapshot = null;

                if (snapshot.currentFloor != 3)
                {
                    newSnapshot =
                        MoveElements(snapshot.currentFloor + 1,
                        currentElements, snapshot);
                }
                if (newSnapshot != null)
                    correctCombinations.Add(newSnapshot);
                ////////////////////////////////////////
                if (snapshot.currentFloor != 0)
                {
                    newSnapshot =
                        MoveElements(snapshot.currentFloor - 1,
                        currentElements, snapshot);
                }
                if (newSnapshot != null)
                    correctCombinations.Add(newSnapshot);
            }
            return correctCombinations;
        }
        /**/
        private Snapshot MoveElements(int destination, List<int> elements, Snapshot snapshot1)
        {
            Snapshot snapshot = snapshot1.copy();

            snapshot.floors[destination].AddRange(elements);
            if (!willTheyPrevail(snapshot.floors[destination]))
                return null;

            snapshot.floors[snapshot.currentFloor].RemoveAll(x => elements.Contains(x));
            if (!willTheyPrevail(snapshot.floors[snapshot1.currentFloor]))
                return null;

            int stamp = generateNumericStamp(snapshot, destination);
            if (usedCombinations[destination].Contains(stamp))
                return null;
            else
                usedCombinations[destination].Add(stamp);

            Snapshot newSnapshot = new Snapshot(destination, snapshot.floors, snapshot.steps + 1);

            return newSnapshot;
        }
        /**/
        private bool willTheyPrevail(List<int> elements)
        {
            if (elements.Count == 1)
                return true;

            List<int> tempElements = new List<int>(elements);
            tempElements.Sort();
            for (int i = 0; i < tempElements.Count;)
            {
                if (i < tempElements.Count - 1 && tempElements[i] / 10 == tempElements[i + 1] / 10)
                {
                    tempElements[i] = 9;
                    tempElements[i + 1] = 9;
                    i += 2;
                }
                else
                    i++;
            }

            if (elements.Exists(x => x % 10 == 0) &&
                tempElements.Exists(x => x % 10 == 1))
                return false;

            return true;
        }
        /**/
        private void printFloors(Snapshot snapshot)
        {
            for (int i = 0; i < 4; ++i)
            {
                Console.WriteLine("Floor " + i + ": ");
                foreach (var reactor in snapshot.floors[i])
                    Console.WriteLine("\t" + reactor);
                Console.WriteLine();
            }
        }
        /**/
        public int generateNumericStamp(Snapshot snapshot, int floor)
        {
            int stamp = 0;
            for (int i = 0; i < 4; ++i)
            {
                snapshot.floors[i].Sort();
                foreach (int item in snapshot.floors[i])
                    stamp += i * 1000 + item * i;
            }
            return stamp;
        }
        /**/
        public static List<List<int>> Combinations(List<int> elements)
        {
            List<List<int>> temp = new List<List<int>>();

            for (int i = elements.Count - 1; i >= 0; --i)
            {
                temp.Add(new List<int>());
                temp[temp.Count - 1].Add(elements[i]);
                for (int j = i - 1; j >= 0; --j)
                {
                    temp.Add(new List<int>());
                    temp[temp.Count - 1].Add(elements[i]);
                    temp[temp.Count - 1].Add(elements[j]);

                }
            }
            return temp;
        }
    }

    class Snapshot
    {
        public List<List<int>> floors;
        public int currentFloor;
        public int steps;

        public Snapshot(int currentFloor, List<List<int>> floors, int steps)
        {
            this.currentFloor = currentFloor;
            this.floors = floors;
            this.steps = steps;
        }

        public Snapshot copy()
        {
            var floors = new List<List<int>>();
            foreach (var floor in this.floors)
                floors.Add(new List<int>(floor));

            return new Snapshot(currentFloor, floors, steps);
        }
    }
}