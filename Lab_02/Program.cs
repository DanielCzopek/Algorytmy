using System;
namespace Lab_2
{
    // rekurencja i dziel i zwyciężaj
    class Program
    {
        static void Main(string[] args)
        {
            int[] tab = { 2, 2, 3, 2, 5, 5 };
            Console.WriteLine(zadanie1(tab));
            Console.WriteLine(zadanie2(tab, 6, 2));
        }
        static int zadanie1(int[] tab)
        {
            int sum = 0;
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                {
                    sum += tab[i];
                }
            }
            return sum;
        }
        static int zadanie2(int[] tab, int n, int k) // n jest rozmiarem tablicy
        {
            int count = tab[0];
            if (n > 0 && tab[n - 1] == k)
            {
                count++;
                zadanie2(tab, n - 1, k);
            }
            return count;
        }
    }
}