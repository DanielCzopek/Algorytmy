
using Lab_12;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lab_12
{
    // Kruskal, klasa graph
    class Edge : IComparable<Edge>
    {
        public int Node { get; set; }
        public int Node2 { get; set; }
        public double Weight { get; set; }

        public Edge(int Node, int Node2, double Weight)
        {
            this.Node = Node;
            this.Node2 = Node2;
            this.Weight = Weight;
        }

       

        public int CompareTo(Edge other)
        {
            return Weight.CompareTo(other.Weight);
        }
    }

    class Graph
    {
        public Dictionary<int, List<Edge>> Edges = new Dictionary<int, List<Edge>>();

        public void AddDirectedEdge(int source, int destination, int destination2, double weight)
        {
            if (!Edges.ContainsKey(source))
            {
                Edges.Add(source, new List<Edge>());
            }
            if (!Edges.ContainsKey(destination))
            {
                Edges.Add(destination, new List<Edge>());
            }
            if (!Edges.ContainsKey(destination2))
            {
                Edges.Add(destination2, new List<Edge>());
            }

            Edges[source].Add(new Edge() { Node = destination, Node2 = destination2, Weight = weight });
        }

        public void AddUndirectedEdge(int source, int destination, int destination2, double weight)
        {
            AddDirectedEdge(source, destination, destination2, weight);
            AddDirectedEdge(destination, destination2, source, weight);
        }

       

        public void BFTraversal(int start, Action<int> action)
        {
            Queue<int> queue = new Queue<int>();
            ISet<int> visited = new HashSet<int>();
            queue.Enqueue(start);
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                if (visited.Contains(node))
                {
                    continue;
                }
                action.Invoke(node);
                visited.Add(node);
                List<Edge> children = Edges[node];
                foreach (Edge child in children)
                {
                    queue.Enqueue(child.Node);
                }
            }
        }

      
    }
}


// Algorytm:

class Kruskal
{
    public Edge[] Wynik { get; private set; }
    public double Zakres { get; private set; }
    public Kruskal(Point[] points)
    {
        int Arr_Length = 0;
        for (int i = points.Length - 1; i > 0; i--)
            Arr_Length += i;
        Edge[] edges = new Edge[Arr_Length];

        for (int i = 0, index = 0; i < points.Length; i++)
            for (int j = i + 1; j < points.Length; j++)
            {
                int dx = points[i].X - points[j].X;
                int dy = points[i].Y - points[j].Y;
                edges[index] = new Edge(i, j, Math.Sqrt(dx*dx + dy * dy));
                index++;
            }

        var sortEdges = edges.OrderBy(other => other.Weight);
        
        int[] sets = new int[points.Length];
        Wynik = new Edge[points.Length - 1];
        int processedEdges = 0;
        foreach (var edge in sortEdges)
        {
            
            if (processedEdges == points.Length - 1)
                break;

            if (sets[edge.Node] == 0 || sets[edge.Node] != sets[edge.Node2])
            {
                Wynik[processedEdges] = edge;
                Zakres += edge.Weight;
                processedEdges++;

                if (sets[edge.Node] != 0 || sets[edge.Node2] != 0)
                {

                    int set1 = sets[edge.Node];
                    int set2 = sets[edge.Node2];

                    for (int i = 0; i < points.Length; i++)
                        if (sets[i] != 0 && (sets[i] == set1 || sets[i] == set2))
                            sets[i] = processedEdges;
                }

                sets[edge.Node] = processedEdges;
                sets[edge.Node2] = processedEdges;
            }
        }
    }
}

