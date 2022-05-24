using System;
using System.Text;

namespace Lab_11
{
    interface Igraph
    {
        bool AddDirectoryEdge(int source, int target, int weight);
        bool AddUndirectoryEdge(int source, int target, int weight);
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

        public bool AddUndirectoryEdge(int source, int target, int weight)
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
    class Program
    {
        static void Main(string[] args)
        {
            Igraph graph = new AdMatrixGraph(4);
            graph.AddDirectoryEdge(0, 1, 3);
            graph.AddDirectoryEdge(1, 2, 2);
            graph.AddDirectoryEdge(2, 0, 8);
            graph.AddDirectoryEdge(3, 3, 1);
            Console.WriteLine(graph.ToString());



        }
    }
}
