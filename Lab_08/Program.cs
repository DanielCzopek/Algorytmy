using System;
using System.Collections.Generic;

namespace Lab_8
{
    // Algorytmy szukające w drzewach
    record Student(string Name, int Ects); //  to są rekordy - klasa która ma tylko konstruktor, ma metodę to String i equalis = klasa z tym wszystkim

    class TreeNode<T>
    {
        public T Value { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 4, 7, 1, 2, 4, 6, 8, 5, 3 };
            Array.Sort(arr); // sortuje tablice
            int i = Array.BinarySearch(arr, 5); // zwraca indeks szukanego elementu (5), jeśli i jest ujemne to znaczy że nie ma takiej wartości
            if (i >= 0)
            {
                Console.WriteLine("5 znajduje się pod indeksem " + i); // tablica jest posortowana więc się zgadza
            }
            else
            {
                Console.WriteLine("Brak 5 w tablicy");
            }

            Student[] students =
            {
                new Student("Ewa", 15),
                new Student("Adam", 20),
                new Student("Janusz", 20),
                new Student("Karol", 19),
                new Student("Ola", 12),
                new Student("Dawid", 20),
                new Student("Karolina", 11),
                new Student("Bartek", 29),
            };

            Array.Sort(students, new StudentComparator());
            Console.WriteLine(string.Join<Student>("\n", students));
            int std = Array.BinarySearch<Student>(students, new Student("Ewa", 15), new StudentComparator()); // zwraca idenks studenta
            Console.WriteLine("Szukany student jest pod indeksem " + std);

            TreeNode<int> root = new TreeNode<int>() { Value = 16 };
            root.Left = new TreeNode<int>() { Value = 10 };
            root.Right = new TreeNode<int>() { Value = 20 };
            root.Left.Left = new TreeNode<int>() { Value = 5 };
            root.Left.Right = new TreeNode<int>() { Value = 12 };
            root.Right.Left = new TreeNode<int>() { Value = 17 };
            root.Right.Right = new TreeNode<int>() { Value = 29 };

            BST<int> tree = new BST<int>() { Root = root };
            Console.WriteLine(tree.Contains(12));
            Console.WriteLine(tree.Contains(13));
        }
    }
    class BST<T> where T : IComparable<T>
    {
        public TreeNode<T> Root { get; init; } // init znaczy że można tylko raz ustawić a później tylko odczytywać

        public bool Contains(T value)
        {
            TreeNode<T> node = Root;

            while (node != null)
            {
                //ASprawdza czy node.Value jest równe value
                if (node.Value.CompareTo(value) == 0)
                {
                    return true;
                }
                if (node.Value.CompareTo(value) > 0)
                {
                    node = node.Left;
                }
                if (node.Value.CompareTo(value) < 0)
                {
                    node = node.Right;
                }
            }
            return false;
        }

    }
    class StudentComparator : IComparer<Student>
    {
        public int Compare(Student s1, Student s2)
        {
            int compare = -s1.Ects.CompareTo(s2.Ects);
            if (compare == 0)
            {
                return s1.Name.CompareTo(s2.Ects);
            }
            // compare = 0 - s1 identyczne z s2
            //compare < 0 - s1 mniejsze od s2
            //compare > 0 - s1 większe od s2
            return compare;
        }
    }
}