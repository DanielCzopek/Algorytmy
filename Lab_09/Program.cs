using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab_9
{
    class HashTable<T> : IEnumerable<T>
    {

        private List<T>[] values;

        private int HashCode(T value)
        {
            return Math.Abs(value.GetHashCode()) % values.Length;
        }


        public HashTable(int n)
        {
            values = new List<T>[n];
        }
        public bool Add(T value)
        {
            int index = HashCode(value);
            Console.WriteLine("Index " + index);
            if (values[index] == null)
            {
                values[index] = new List<T>();
            }
            if (values[index].Contains(value))
            {
                return false;
            }
            values[index].Add(value);
            return true;
        }
        public bool Remove(T value)
        {
            int index = HashCode(value);

            if (values[index] == null)
            {
                return false;
            }
            return values[index].Remove(value);
        }
        public bool Contains(T value)
        {
            int index = HashCode(value);
            if (values[index] == null)
            {
                return false;
            }
            return values[index].Contains(value);

        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (List<T> item in values)
                if (item != null)
                {
                    yield return item;
                }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            HashTable<string> names = new HashTable<string>(11);
            names.Add("Ala");
            names.Add("Ola");
            names.Add("Adam");
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}