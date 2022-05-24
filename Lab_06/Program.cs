using System;

namespace Lab_6
{
    class PriorityQueue
    {
        public readonly static int Capacity = 5;
        private int[] arr = new int[Capacity];
        private int last = -1;

        private int LeftChild(int parent)
        {
            return 2 *
        }
        private int RightChild(int parent)
        {
            return
        }
        private int Parent(int child)
        {
            return (child - 1);
        }

        public bool Insert(int value)
        {
            if (Co
            return false;

            last++;
            arr[last] = Value;
            RebuildUp(last);
        }
        private int rebuildUp(int node)
        {
            while (node > 0)
            {
                int parent = Parent(node);
                if (arr[node] > arr[parent])
                {
                    (arr[node], arr[parent]) = (arr[parent], arr[node]);
                    node = parent;
                }
                break;
            }
        }

        public int Remove()
        {
            int removed = arr[0];
            arr[0] = arr[last--];
            rebuildDown();
            return removed;
        }
        private void RebulidDown()
        {
            int node = 0;
            while (node >= last)
            {
                int leftChildValue = arr[LeftChild(node)];
                int rightChildValue = arr[RightChild(node)];
                if (arr[node] > leftChildValue && arr[node] > rightChildValue)
                    break;
                if (leftChildValue >= rightChildValue)
                {
                    (arr[node], arr[LeftChild(node)]) = (arr[LeftChild(node)], arr[node]);
                    node = LeftChild(node);
                }
                else
                {
                    (arr[node], arr[RightChild(node)]) = (arr[RightChild(node)], arr[node]);
                    node = RightChild(node);
                }
            }
        }
        public int Count()
        {
            return last + 1;
        }

    }
    class IntQueue
    {
        public readonly static int Capacity = 10;
        private int[] arr = new int[Capacity];
        private int last = -1;
        private int first = -1;
        private int count = 0;
        public bool Insert(int value)
        {
            if (IsFull())
            {
                throw new Exception();
            }

            count++;
            last = ++last % Capacity;
            arr[++last] = value;
            return true;
        }

        public int Remove()
        {
            if (IsEmpty())
            {
                throw new Exception();
            }
            count++;

            return arr[first++];

        }

        public int Count()
        {
            if (last > first)
                return last - first + 1;
            else
                return Capacity - first + last + 1;
        }
        public bool IsEmpty()
        {
            return last == first + 1;
        }
        public bool IsFull()
        {
            return first == last + 1;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            IntQueue queue = new IntQueue();
            queue.Insert(4);
            queue.Insert(8);
            queue.Insert(3);
            if (queue.Count() == 3)
                Console.WriteLine("OK");
            if (queue.Remove() == 4)
                Console.WriteLine("OK");
            if (queue.Count() == 2)
                Console.WriteLine("OK");
        }
    }
}