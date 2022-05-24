using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_11
{
    interface Igraph
    {
        bool AddDirectoryEdge(int source, int target, int weight);
        bool AddUndirectedEdge(int source, int target, int weight);
        void Traversal(int start, Action<int> action);
    }
    class AdMatrixGraph : Igraph
    {
        private int[,] matrix;

        public AdMatrixGraph(int size)
        {
            matrix = new int[size, size];
        }

        public bool AddDirectoryEdge(int source, int target, int weight)
        {
            if (source >= 0 && source < matrix.GetLength(0) &&
                target >= 0 && target < matrix.GetLength(1))
            {
                matrix[source, target] = weight;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddUndirectedEdge(int source, int target, int weight)
        {
            return AddDirectoryEdge(source, target, weight) && AddDirectoryEdge(target, source, weight);
        }

        public void Traversal(int start, Action<int> action)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sb.Append($"wierzchołek { row} ma krawędzie z: ");
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    
                    if (matrix[row, col] != 0)
                    {
                        sb.Append(col + " ");
                    }
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }

    /////////////////////////////////////////
    ///
    record Edge
    {
        public int Target { get; set; }
        public int Weight { get; set; }
    }
    class AddListGraph : Igraph
    {
        private Dictionary<int, HashSet<Edge>> edges = new Dictionary<int, HashSet<Edge>>();


        public bool AddDirectoryEdge(int source, int target, int weight)
        {
            if (!edges.ContainsKey(source))
            {
                edges.Add(source, new HashSet<Edge>());
            }
            if (!edges.ContainsKey(target))
            {
                edges.Add(target, new HashSet<Edge>());
            }
            edges[source].Add(new Edge() { Target = target, Weight = weight });
            return true;
        }

        public bool AddUndirectedEdge(int source, int target, int weight)
        {
            return AddDirectoryEdge(source, target, weight) && AddDirectoryEdge(target, source, weight);
        }

        public void Traversal(int start, Action<int> action)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in edges)
            {
                sb.Append($"wierzchołek { item.Key} ma krawędzie z: ");
                foreach(var edge in item.Value)
                {
                    sb.Append($"{edge.Target} ({edge.Weight}) ");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Igraph graph = new AddListGraph();
            graph.AddDirectoryEdge(0, 1, 3);
            graph.AddDirectoryEdge(1, 2, 2);
            graph.AddUndirectedEdge(2, 0, 8);
            graph.AddDirectoryEdge(3, 3, 1);
            Console.WriteLine(graph.ToString());



        }
    }
}
