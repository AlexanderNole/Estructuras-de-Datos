using System.Reflection.Metadata.Ecma335;

namespace Grafos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Grafos");
            Graph graph = new Graph();
            graph.AddNode(1);
            graph.AddNode(2);
            graph.AddNode(3);
            graph.AddNode(4);
            graph.AddNode(5);
            graph.AddNode(6);
            graph.AddNode(7);
            graph.AddNode(8);
            graph.AddNode(9);
            graph.AddNode(10);

            graph.AddEdge(1, 2, 10);
            graph.AddEdge(2, 1, 23);
            graph.AddEdge(3, 7, 4);
            graph.AddEdge(4, 5, 3);
            graph.AddEdge(5, 1, 6);
            graph.AddEdge(6, 9, 11);
            graph.AddEdge(7, 10, 35);
            graph.AddEdge(8, 10, 24);
            graph.AddEdge(9, 10, 5);
            graph.AddEdge(10, 6, 1);

            graph.ShowGraph();
            graph.BFS(9);
        }
    }
}