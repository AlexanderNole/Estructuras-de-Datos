using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Colas;

namespace Grafos
{
    class Edge
    {
        public int coste;
        public Node? Destination;
        public Edge? Next;
    }
    class Node
    {
        public int Data;
        public bool IsVisited;
        public Node? Next;
        public Edge? Adjacent;

        public Node()
        {
            this.IsVisited = false;
        }
    }
    class Graph
    {
        private Node? start;
        public Graph()
        {
            start = null;
        }
        private Node getNode(int value)
        {
            Node node = start;
            while (node != null && node.Data != value)
                node = node.Next;

            return node;
        }
        private Edge getEdge(Node origin, Node destination)
        {
            Edge edge = origin.Adjacent;
            while (edge != null && edge.Destination != destination)
                edge = edge.Next;

            return edge;
        }
        public void AddNode(int value)
        {
            Node newNode, lastNode;
            if (getNode(value) == null) {
                newNode = new Node();
                newNode.Data = value;
                newNode.Next = null;
                newNode.Adjacent = null;

                if (start == null)
                    start = newNode;
                else {
                    lastNode = start;
                    while (lastNode.Next != null)
                        lastNode = lastNode.Next;
                    lastNode.Next = newNode;
                }
            }
        }
        public void AddEdge(int origin, int destination, int coste)
        {
            Edge newEdge, lastEdge;
            Node nodeOrigin, nodeDestination;
            nodeOrigin = getNode(origin);

            if (nodeOrigin != null) {
                nodeDestination = getNode(destination);
                if (nodeDestination != null) {
                    if (getEdge(nodeOrigin, nodeDestination) == null) {
                        newEdge = new Edge();
                        newEdge.Destination = nodeDestination;
                        newEdge.coste = coste;
                        newEdge.Next = null;

                        if (nodeOrigin.Adjacent == null)
                            nodeOrigin.Adjacent = newEdge;
                        else {
                            lastEdge = nodeOrigin.Adjacent;
                            while (lastEdge.Next != null)
                                lastEdge = lastEdge.Next;

                            lastEdge.Next = newEdge;
                        }
                    }
                }
            }
        }
        public void ShowGraph()
        {
            Node nodeCurrent = start;
            Edge edgeCurrent;
            while (nodeCurrent != null) {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{nodeCurrent.Data} -> ");
                edgeCurrent = nodeCurrent.Adjacent;
                while (edgeCurrent != null) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"costo {edgeCurrent.coste} ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"valor {edgeCurrent.Destination.Data} ");
                    edgeCurrent = edgeCurrent.Next;
                }
                Console.WriteLine();
                nodeCurrent = nodeCurrent.Next;
            }
            Console.WriteLine();
        }
        private void DeleteEdge(int origin, int destination)
        {
            Node nodeOrigin;
            Edge edgePrevious = null, edgeCurrent;
            nodeOrigin = getNode(origin);

            if (nodeOrigin != null && nodeOrigin.Adjacent != null) {
                edgeCurrent = nodeOrigin.Adjacent;

                while (edgeCurrent != null && edgeCurrent.Destination.Data != destination) {
                    edgePrevious = edgeCurrent;
                    edgeCurrent = edgeCurrent.Next;
                }

                if (edgeCurrent != null) {
                    if (edgePrevious == null)
                        nodeOrigin.Adjacent = nodeOrigin.Adjacent.Next;
                    else
                        edgePrevious.Next = edgeCurrent.Next;
                }
            }
        }
        public void DeleteNode(int value)
        {
            Node nodePrevious = null, nodeCurrent, nodeOrigin = start;
            Edge adjacencies;

            while (nodeOrigin != null && nodeOrigin.Data != value) {
                nodePrevious = nodeOrigin;
                nodeOrigin = nodeOrigin.Next;
            }

            if (nodeOrigin != null) {
                nodeCurrent = start;
                while (nodeCurrent != null) {
                    DeleteEdge(nodeCurrent.Data, value);
                    nodeCurrent = nodeCurrent.Next;
                }
                adjacencies = nodeOrigin.Adjacent;

                while (adjacencies != null) {
                    adjacencies = adjacencies.Next;
                }

                if (nodePrevious == null)
                    start = start.Next;
                else
                    nodePrevious.Next = nodeOrigin.Next;
            }
        }
        public void BFS(int origin)
        {
            Colas.Queue queue = new Colas.Queue();
            Node nodeOrigin, nodeDestination;
            Edge adjacencies;
            int value;
            nodeOrigin = getNode(origin);
            if (nodeOrigin != null) {
                nodeOrigin.IsVisited = true;
                queue.Enqueue(nodeOrigin.Data);

                while (queue != null) {
                    value = queue.Dequeue();
                    if (value == int.MinValue)
                        return;
                    Console.Write($"{value} ");
                    nodeOrigin = getNode(value);
                    adjacencies = nodeOrigin.Adjacent;

                    while (adjacencies != null) {
                        nodeDestination = adjacencies.Destination;

                        if (!nodeDestination.IsVisited) {
                            nodeDestination.IsVisited = true;
                            queue.Enqueue(nodeDestination.Data);
                        }

                        adjacencies = adjacencies.Next;
                    }
                }
            }
        }
        private void visit(Node origin)
        {
            Edge adjacencies;

            origin.IsVisited = true;
            Console.Write($"{origin.Data} ");

            adjacencies = origin.Adjacent;
            while (adjacencies != null) {
                if (!adjacencies.Destination.IsVisited)
                    visit(adjacencies.Destination);

                adjacencies = adjacencies.Next;
            }
        }
        public void DFS()
        {
            Node nodeCurrent = start;

            while (nodeCurrent != null) {
                if (!nodeCurrent.IsVisited)
                    visit(nodeCurrent);

                nodeCurrent = nodeCurrent.Next;
            }
        }

    }
}
