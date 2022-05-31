using System;
using System.Collections.Generic;

namespace Lab_10
{
    // Metody przechodzenia po drzewie
    class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
    }
    class Tree<T>
    {
        public Node<T> Root { get; set; }

        // PreOrder
        public void PreOrderTraversal(Action<Node<T>> action)
        {
            PreOrder(Root, action);
        }

        private void PreOrder(Node<T> node, Action<Node<T>> action)
        {
            if (node == null)
            {
                return;
            }
            action.Invoke(node);
            PreOrder(node.Left, action);
            PreOrder(node.Right, action);
        }
        // PostOrder
        public void PostOrderTraversal(Action<Node<T>> action)
        {
            PostOrder(Root, action);
        }
        private void PostOrder(Node<T> node, Action<Node<T>> action)
        {
            if (node == null)
            {
                return;
            }

            PostOrder(node.Left, action);
            PostOrder(node.Right, action);
            action.Invoke(node);
        }
        //InOrder
        public void InOrderTraversal(Action<Node<T>> action)
        {
            InOrder(Root, action);
        }
        private void InOrder(Node<T> node, Action<Node<T>> action)
        {
            if (node == null)
            {
                return;
            }

            InOrder(node.Left, action);
            action.Invoke(node);
            InOrder(node.Right, action);
        }

        //Level
        public void LevelTraversal(Action<Node<T>> action)
        {
            Queue<Node<T>> q = new Queue<Node<T>>();
            q.Enqueue(Root);
            while (q.Count > 0)
            {
                Node<T> node = q.Dequeue();
                action.Invoke(node);
                if (node.Left != null)
                {
                    q.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    q.Enqueue(node.Right);
                }
            }

        }
        public List<T[]> GetPaths()
        {
            Stack<T> stack = new Stack<T>();
            List<T[]> list = new List<T[]>();
            GetPath(Root, stack, list);
            return list;
        }
        private void GetPath(Node<T> node, Stack<T> stack, List<T[]> list)
        {
            stack.Push(node.Value);
            if (node.Left == null && node.Right == null)
            {
                list.Add(stack.ToArray());
                stack.Pop();
                return;
            }

            if (node.Left != null)
            {
                GetPath(node.Left, stack, list);
            }
            if (node.Right != null)
            {
                GetPath(node.Right, stack, list);
            }
            stack.Pop();


        }
    }
    class Expression : Tree<string>
    {
        public double Evaluate()
        {
            return EvaluateNode(Root);
        }
        private double EvaluateNode(Node<String> node)
        {
            switch (node.Value)
            {
                case "+":
                    return EvaluateNode(node.Left) + EvaluateNode(node.Right);
                case "-":
                    return EvaluateNode(node.Left) + EvaluateNode(node.Right);
                case "*":
                    return EvaluateNode(node.Left) + EvaluateNode(node.Right);
                case "/":
                    return EvaluateNode(node.Left) + EvaluateNode(node.Right);
                default:
                    return double.Parse(node.Value);

            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Node<string> node = new Node<string>() { Value = "*" };
            node.Left = new Node<String>() { Value = "+" };
            node.Right = new Node<String>() { Value = "3" };
            node.Left.Left = new Node<string>() { Value = "7" };
            node.Left.Right = new Node<string>() { Value = "8" };

            Expression tree = new Expression { Root = node };
            tree.PreOrderTraversal(node => Console.WriteLine(node.Value));
            Console.WriteLine();
            tree.InOrderTraversal(node => Console.WriteLine(node.Value));
            Console.WriteLine();
            tree.PostOrderTraversal(node => Console.WriteLine(node.Value));
            Console.WriteLine();
            Console.Write(tree.Evaluate());
            Console.WriteLine();
            tree.LevelTraversal(n => Console.WriteLine(n.Value));
            Console.WriteLine();
            List<string[]> paths = tree.GetPaths();
            foreach (var path in paths)
            {
                Console.WriteLine(string.Join(", ", path));
            }
        }
    }
}