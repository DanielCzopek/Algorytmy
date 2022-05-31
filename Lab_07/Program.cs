using System;
using System.Collections.Generic;


namespace Lab_7
{
    // Budowa drzewa i stosu 
    class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
        public int Count { get; internal set; }

    }

    class Stack<T>
    {
        private Node<T> _head;

        public void Push(T value)
        {
            Node<T> node = new Node<T> { Value = value };
            node.Next = _head;
            _head = node;
        }

        public bool IsEmpty()
        {
            return _head == null;
        }
        public T Pop()
        {
            if (IsEmpty())
                throw new Exception("Stack is empty!");

            T result = _head.Value;
            _head = _head.Next;
            return result;
        }

        // Zadanie 4

        public bool IsCorrect(string text, string arg = "()[]{}<>")
        {
            List<char> list = new List<char>();
            for (int i = 0; i < text.Length; i++)
            {
                int poz = arg.IndexOf(text[i]);
                if (poz == -1)
                    continue;
                if (poz % 2 == 0)
                {
                    list.Add(arg[poz + 1]);
                }
                else
                {
                    if (list.Count == 0 || list[list.Count - 1] != text[i])
                        return false;
                    list.RemoveAt(list.Count - 1);
                }
            }
            return list.Count == 0;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Node<string> node = new Node<string> { Value = "Adam" };
            node.Next = new Node<string> { Value = "Ewa" };
            node.Next.Next = new Node<string> { Value = "Karol" };
            Node<string> head = node;

            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }

            //////////////////////////////////////////////////
            ///
            Stack<int> stack = new();
            stack.Push(12);
            stack.Push(15);
            stack.Push(5);
            stack.Push(145);
            stack.Push(54);
            stack.Push(19);

            while (!stack.IsEmpty())
            {
                Console.WriteLine(stack.Pop());
            }

            //Test do zad.4

            string a = "(1+x)*{2-6+6-2[a]*2}";
            Console.WriteLine(stack.IsCorrect(a));
        }
    }
}