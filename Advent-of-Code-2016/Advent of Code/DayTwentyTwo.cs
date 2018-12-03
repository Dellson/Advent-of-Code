using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Advent_of_Code
{
    class DayTwentyTwo
    {
        private List<List<Node>> nodes2DArray;
        private int rowIndex;
        private int columnIndex;
        private Node selectedNode;
        private List<Node> accessibleNodes;

        public DayTwentyTwo()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\DayTwentyTwoInput.txt");
            string[] input = File.ReadAllLines(path);

            MatchCollection matches = Regex.Matches(input[input.Length - 1], @"(?<=x|y)\d+");
            rowIndex = int.Parse(matches[0].Value);
            columnIndex = int.Parse(matches[1].Value);

            accessibleNodes = new List<Node>();
            nodes2DArray = new List<List<Node>>();
            for (int i = 0; i <= rowIndex; ++i)
            {
                nodes2DArray.Add(new List<Node>());
                for (int j = 0; j <= columnIndex; ++j)
                    nodes2DArray[i].Add(new Node(input[i * columnIndex + i + j]));
            }
        }
        
        public void puzzle()
        {
            int movesCount = 0;
            Node emptyNode = null;

            foreach (var nodesList in nodes2DArray)
                foreach (Node node in nodesList)
                    if (node.used == 0)
                        emptyNode = node;

            findAccessibleNodes(emptyNode);
            
            selectedNode = nodes2DArray[rowIndex][0];
            NodeSnapshot targetSnapshot = findShortestPathFromSelectedtoXY(0, 0);
            
            selectedNode = emptyNode;
            NodeSnapshot toRowIndexSnapshot = findShortestPathFromSelectedtoXY(targetSnapshot.path[0].x, targetSnapshot.path[0].y);
            selectedNode = toRowIndexSnapshot.path[toRowIndexSnapshot.path.Count - 2];
            movesCount += toRowIndexSnapshot.path.Count - 2;
            
            for (int i = 1; i < targetSnapshot.path.Count; ++i)
            {
                Queue queue = new Queue();
                queue.Enqueue(new NodeSnapshot(selectedNode));
                List<NodeSnapshot> examinedNodes = new List<NodeSnapshot>();
                movesCount++;

                while (queue.Count > 0)
                {
                    NodeSnapshot examinedNodeSnapshot = (NodeSnapshot)queue.Dequeue();
                    Node examinedNode = examinedNodeSnapshot.node;

                    if (examinedNode == targetSnapshot.path[i - 1])
                        continue;

                    if (examinedNode == targetSnapshot.path[i])
                    {
                        movesCount += examinedNodeSnapshot.path.Count - 1;
                        selectedNode = targetSnapshot.path[i - 1];
                        break;
                    }
                    findPossibleMoves(examinedNode, examinedNodes, examinedNodeSnapshot.path, queue);
                }
            }
            Console.WriteLine("movesCount: " + movesCount + "\n");
        }

        private bool nodesComparer(List<Node> list, Node node2)
        {
            return list.Exists(node => node.x == node2.x && node.y == node2.y);
        }
        private bool nodesComparer(List<NodeSnapshot> list, Node node2)
        {
            return list.Exists(node => node.node.x == node2.x && node.node.y == node2.y);
        }

        private NodeSnapshot findShortestPathFromSelectedtoXY(int x, int y)
        {
            Queue queue = new Queue();
            List<NodeSnapshot> examinedNodes = new List<NodeSnapshot>();
            examinedNodes.Add(new NodeSnapshot(selectedNode));
            queue.Enqueue(new NodeSnapshot(selectedNode));

            while (queue.Count > 0)
            {
                NodeSnapshot examinedNodeSnapshot = (NodeSnapshot)queue.Dequeue();
                Node examinedNode = examinedNodeSnapshot.node;

                if (examinedNode.x == x && examinedNode.y == y)
                    return examinedNodeSnapshot;

                findPossibleMoves(examinedNode, examinedNodes, examinedNodeSnapshot.path, queue);
            }
            return null;
        }

        private void findAccessibleNodes(Node node)
        {
            Queue queue = new Queue();
            accessibleNodes.Add(node);
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                Node examinedNode = (Node)queue.Dequeue();
                if (examinedNode.x > 0 && isNodeAccessible(examinedNode, nodes2DArray[examinedNode.x - 1][examinedNode.y]))
                    operateOnNodes(queue, nodes2DArray[examinedNode.x - 1][examinedNode.y]);
                if (examinedNode.x < rowIndex && isNodeAccessible(examinedNode, nodes2DArray[examinedNode.x + 1][examinedNode.y]))
                    operateOnNodes(queue, nodes2DArray[examinedNode.x + 1][examinedNode.y]);
                if (examinedNode.y > 0 && isNodeAccessible(examinedNode, nodes2DArray[examinedNode.x][examinedNode.y - 1]))
                    operateOnNodes(queue, nodes2DArray[examinedNode.x][examinedNode.y - 1]);
                if (examinedNode.y < columnIndex && isNodeAccessible(examinedNode, nodes2DArray[examinedNode.x][examinedNode.y + 1]))
                    operateOnNodes(queue, nodes2DArray[examinedNode.x][examinedNode.y + 1]);
            }
            Console.WriteLine(accessibleNodes.Count - 1);
        }

        private bool isNodeAccessible(Node examinedNode, Node comparedNode)
        {
            return comparedNode.used <= examinedNode.available && comparedNode.used != 0;
        }

        private void operateOnNodes(Queue queue, Node comparedNode)
        {
            comparedNode.used = 0;
            comparedNode.available = comparedNode.size;           
            queue.Enqueue(comparedNode);
            accessibleNodes.Add(comparedNode);
        }

        private void findPossibleMoves(Node examinedNode, List<NodeSnapshot> examinedNodes, List<Node> examinedNodeSnapshotPath, Queue queue)
        {
            if (examinedNode.y > 0
                && nodesComparer(accessibleNodes, nodes2DArray[examinedNode.x][examinedNode.y - 1])
                && !nodesComparer(examinedNodes, nodes2DArray[examinedNode.x][examinedNode.y - 1]))
            {
                queue.Enqueue(new NodeSnapshot(nodes2DArray[examinedNode.x][examinedNode.y - 1], examinedNode, examinedNodeSnapshotPath));
                examinedNodes.Add(new NodeSnapshot(nodes2DArray[examinedNode.x][examinedNode.y - 1]));
            }
            if (examinedNode.y < columnIndex
                && nodesComparer(accessibleNodes, nodes2DArray[examinedNode.x][examinedNode.y + 1])
                && !nodesComparer(examinedNodes, nodes2DArray[examinedNode.x][examinedNode.y + 1]))
            {
                queue.Enqueue(new NodeSnapshot(nodes2DArray[examinedNode.x][examinedNode.y + 1], examinedNode, examinedNodeSnapshotPath));
                examinedNodes.Add(new NodeSnapshot(nodes2DArray[examinedNode.x][examinedNode.y + 1]));
            }
            if (examinedNode.x > 0
                && nodesComparer(accessibleNodes, nodes2DArray[examinedNode.x - 1][examinedNode.y])
                && !nodesComparer(examinedNodes, nodes2DArray[examinedNode.x - 1][examinedNode.y]))
            {
                queue.Enqueue(new NodeSnapshot(nodes2DArray[examinedNode.x - 1][examinedNode.y], examinedNode, examinedNodeSnapshotPath));
                examinedNodes.Add(new NodeSnapshot(nodes2DArray[examinedNode.x - 1][examinedNode.y]));
            }
            if (examinedNode.x < rowIndex
                && nodesComparer(accessibleNodes, nodes2DArray[examinedNode.x + 1][examinedNode.y])
                && !nodesComparer(examinedNodes, nodes2DArray[examinedNode.x + 1][examinedNode.y]))
            {
                queue.Enqueue(new NodeSnapshot(nodes2DArray[examinedNode.x + 1][examinedNode.y], examinedNode, examinedNodeSnapshotPath));
                examinedNodes.Add(new NodeSnapshot(nodes2DArray[examinedNode.x + 1][examinedNode.y]));
            }
        }

        class Node
        {
            public int x;
            public int y;
            public int size;
            public int used;
            public int available;

            public Node(string command)
            {
                MatchCollection matches = Regex.Matches(command, @"\d+"); //przykład: /dev/grid/node-x0-y0     85T   68T    17T   80%
                x = int.Parse(matches[0].Value);
                y = int.Parse(matches[1].Value);
                size = int.Parse(matches[2].Value);
                used = int.Parse(matches[3].Value);
                available = int.Parse(matches[4].Value);
            }

            private Node(int x, int y, int size, int used, int available)
            {
                this.x = x;
                this.y = y;
                this.size = size;
                this.used = used;
                this.available = available;
            }

            public static Node copy(Node node)
            {
                return new Node(node.x, node.y, node.size, node.used, node.available);
            }
        }

        class NodeSnapshot
        {
            public List<Node> path;
            public Node previousNode;
            public Node node;

            public NodeSnapshot(Node node)
            {
                this.path = new List<Node>();
                this.path.Add(node);
                this.node = node;
            }

            public NodeSnapshot(Node node, Node previousNode, List<Node> path)
            {
                this.node = node;
                this.previousNode = previousNode;
                this.path = new List<Node>(path);
                this.path.Add(node);
            }
        }
    }
}