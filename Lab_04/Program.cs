using System;

namespace Zad_04
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 10, 4, 7, 2, 5, 1, 6, 8, 3, 9 };
            int n = 10, i;

            quickSort(arr, 0, arr.Length - 1);
            for (i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
        static public int Pomoc(int[] arr, int left, int right)
        {
            int piv;
            piv = arr[left];
            while (true)
            {
                while (arr[left] < piv)
                {
                    left++;
                }
                while (arr[right] > piv)
                {
                    right--;
                }
                if (left < right)
                {
                    int temp = arr[right];
                    arr[right] = arr[left];
                    arr[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
        static public void quickSort(int[] arr, int left, int right)
        {
            int piv;
            if (left < right)
            {
                piv = Pomoc(arr, left, right);
                if (piv > 1)
                {
                    quickSort(arr, left, piv - 1);
                }
                if (piv + 1 < right)
                {
                    quickSort(arr, piv + 1, right);
                }
            }
        }
    }
}