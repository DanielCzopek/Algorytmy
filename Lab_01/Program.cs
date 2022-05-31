using System;
namespace Zad_1
{
    // przesukiwanie tablic
    class Program
    {
        static void Main(string[] args)
        {
            //ZADANIE 1 (1) Szukanie indeksu najmniejszej liczby dwucyfrowej np. dla 
            // tablicy = [234, 1, 23, 56, 1234, 67] wynik to 2(indeks liczby 23).
            int[] arr = { 224, 1, 23, 56, 1234, 67 };
            Console.WriteLine(findIndex(arr));
        }
        static int findIndex(int[] arr)
        {
            int index = -1;
            int min = int.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (min > arr[i] && arr[i].ToString().Length == 2)
                {
                    min = arr[i];
                    index = i;
                }
            }
            return index;
        }
        /**********************************************/
        static void Main2(string[] args)
        {
            /*ZADANIE 2(2) Obliczanie sumy wszystkich liczb k - cyfrowych, mniejszych 
           od średniej wszystkich liczb np.
            dla tablicy = [1, 234, 2345, 2] i k = 3 wynik to 234, gdyż tylko 234 < 
           (1 + 234 + 2345 + 2) / 4. (1) */
            int[] tab = { 1, 234, 2345, 2 };
            Console.WriteLine(abc(tab, 3));
        }
        static int abc(int[] tab, int k)
        {
            float avr = 0.0f;
            int sum = 1;
            for (int i = 0; i < tab.Length; i++)
            {
                sum += tab[i];
            }
            avr = (float)sum / tab.Length;
            sum = 0;
            for (int i = 0; i < tab.Length; i++)
                if (tab[i] < avr)
                {
                    sum += tab[i];
                }
            return sum;
        }
        /*******************************************/
        static void Main3(string[] args)
        {
            /*ZADANIE 3 (2) Szukanie k-tej w porządku rosnącym wartości w tablicy, 
           która zawiera liczby w zakresie od 0 do 10_000 np.
            dla tablicy = [1, 2, 4, 2, 4] i k=2 wynik to 2, gdyż jest drugą w 
           kolejności rosnącej liczbą w tablicy (1, 2, 4). */
            int[] tab = { 1, 2, 4, 2, 4 };
            Console.WriteLine(Sortowanie(tab, 2));
        }
        static int Sortowanie(int[] tab, int k)
        {
            for (int i = 0; i < tab.Length - 1; i++)
                for (int j = 0; j < tab.Length - 1; j++)
                    if (tab[j] > tab[j + 1])
                    {
                        int sorting = tab[j];
                        tab[j] = tab[j + 1];
                        tab[j + 1] = sorting;
                    }
            int[] sort = new int[tab.Length];
            for (int i = 0; i < tab.Length; i++)
            {
                sort = tab.Distinct().ToArray();
            }
            return sort[k - 1];
        }
        /***********************************************/
        static void Main6(string[] args)
        {
            /* ZADANIE 6(3) Obliczanie największej liczby powtórzeń, np. dla tablicy = 
           [1, 2, 5, 3, 2, 3, 8, 2] wynik wynosi 3,
            gdyż 2 występuje 3 razy, więcej niż pozostałe. W tablicy wejściowej mogą 
           występować tylko liczby całkowite w zakresie od
            - 100 do 100. */
            int[] tab = { 1, 2, 5, 3, 2, 3, 8, 2 };
            Console.WriteLine(dominanta(tab));
        }
        static int min(int[] tab) // funkcja sprawdzająca maximum
        {
            int min = tab[0];
            for (int i = 1; i < tab.Length; i++)
                if (tab[i] < min)
                {
                    min = tab[i];
                }
            return min;
        }
        static int max(int[] tab) // funkcja sprawdzająca minimum
        {
            int max = tab[0];
            for (int i = 0; i < tab.Length; i++)
                if (tab[i] > max)
                {
                    max = tab[i];
                }
            return max;
        }
        static int dominanta(int[] tab) // funkcja sprawdzająca która wartość najczęściej występuje
        {
            int mini = min(tab);
            int maxi = max(tab);
            int[] pomoc = new int[maxi - mini + 1];
            for (int i = 0; i < tab.Length; i++)
            {
                pomoc[tab[i] - mini]++; // odejmuje minimum by indeksy nie były ujemne
            }
            int wystapienia = max(pomoc);
            return wystapienia;
        }
    }
}