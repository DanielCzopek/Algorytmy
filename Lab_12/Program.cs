
using Lab_12;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lab_12
{
    class Edge : IComparable<Edge>
    {
        public int Node { get; set; }
        public double Weight { get; set; }

        public int CompareTo(Edge other)
        {
            return Weight.CompareTo(other.Weight);
        }
    }

    class Graph
    {
        public Dictionary<int, List<Edge>> Edges = new Dictionary<int, List<Edge>>();

        public void AddDirectedEdge(int source, int destination, double weight)
        {
            if (!Edges.ContainsKey(source))
            {
                Edges.Add(source, new List<Edge>());
            }
            if (!Edges.ContainsKey(destination))
            {
                Edges.Add(destination, new List<Edge>());
            }
            Edges[source].Add(new Edge() { Node = destination, Weight = weight });
        }

        public void AddUndirectedEdge(int source, int destination, double weight)
        {
            AddDirectedEdge(source, destination, weight);
            AddDirectedEdge(destination, source, weight);
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
                edges[index] = new Edge(i, j);
                index++;
            }

        var sortEdges = edges.OrderBy(a => a.Length);
        //definiuje istniejące zbiory, dodana krawędź nie może tworzyć cyklu
        //cykl pojawia się, gdy obie krawędzie należą do tego samego zbioru
        int[] sets = new int[points.Length];
        Wynik = new Edge[points.Length - 1];
        int processedEdges = 0;
        foreach (var edge in sortEdges)
        {
            //Znaleziono N-1 niecyklicznych krawędzi
            //Całe drzewo rozpinające jest wyliczone
            if (processedEdges == points.Length - 1)
                break;

            //Jest pięć możliwości:
            // 0-0 nie należą do zbioru
            // 0-X pierwszy węzeł nie należy do zbioru
            // X-0 drugi węzeł nie należy do zbioru
            // X-X oba węzły należą do jednego zbioru - CYKL!
            // X-Y węzły należą do różnych zbiorów
            // Pomijamy zatem te węzły, których zbiory się różnią
            // Lub jedna z krawędzi (np. pierwsza, jak niżej) nie należy do zbioru
            if (sets[edge.Point1] == 0 || sets[edge.Point1] != sets[edge.Point2])
            {
                Wynik[processedEdges] = edge;
                Zakres += edge.Length;
                processedEdges++;
                //Jeżeli krawędź nie należy do żadnego zbioru, pomiń
                //Krawędź nie należy do żadnego zbioru, jeżeli oba znaczniki są równe 0
                if (sets[edge.Point1] != 0 || sets[edge.Point2] != 0)
                {
                    //To te zbiory będą łączone w jeden
                    int set1 = sets[edge.Point1];
                    int set2 = sets[edge.Point2];
                    //Zdefiniuj nowy zbiór składający się z dwóch łączonych zbiorów
                    //0 oznacza brak zbioru, jest pomijane na tym etapie
                    for (int i = 0; i < points.Length; i++)
                        if (sets[i] != 0 && (sets[i] == set1 || sets[i] == set2))
                            sets[i] = processedEdges;
                }
                //Oznacz końce krawędzi jako element nowego zbioru
                //To tutaj dołączane są punkty spoza oznaczonych zbiorów
                sets[edge.Point1] = processedEdges;
                sets[edge.Point2] = processedEdges;
            }
        }
    }
}

