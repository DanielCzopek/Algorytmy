

using Microsoft.VisualBasic;
using System;
using System.Linq;

class App
{
    public static void Main(string[] args)
    {

        int[] arr = { 1, 2, 3, 4 };
        MergeSortInPLace.Sort(arr);
    }
}
//Cwiczenie 1
//4 punkty
public class StringMergeSort
{
    public static string[] Sort(string[] arr)
    {
        return StringSortArray(arr, 0, arr.Length - 1);
    }
    private static string[] StringSortArray(string[] arr, int left, int right)
    {
        if (left == right)
        {
            return new[] { arr[left] };
        }
        if (left + 1 == right)
        {

            //zaimplementuj ten fragment algorytmu, aby zwracał tablicę z  łańcuchami arr[left] i arr[right] w odpowiedniej kolejności
            byte[] arry = arr.Select(left => byte.Parse(left)).ToArray();
            byte[] arry2 = arr.Select(right => byte.Parse(right)).ToArray();
            return new[] { Math.Min(arry2[left], arry2[right]), Math.Max(arry[left], arry2[right]) };
        }
        var mid = (left + right) / 2;
        var leftArr = StringSortArray(arr, left, mid);
        var rightArr = StringSortArray(arr, mid + 1, right);
        var res = StringMerge(leftArr, rightArr);
        return res;
    }

    private static string[] StringMerge(string[] arr1, string[] arr2)
    {
        var result = new string[arr1.Length + arr2.Length];
        for (int i = 0, j1 = 0, j2 = 0; i < result.Length; i++)
        {
            if (j1 < arr1.Length && j2 < arr2.Length)
            {
                if (arr1[j1] < arr2[j2])
                {
                    result[i] = arr1[j1++];
                }
                else
                {
                    result[i] = arr2[j2++];
                }
                continue;
                //wybierz, który z łańcuchów arr1[j1] i arr2[j2] jest mniejszy i przypisz do result[i]
                //Napisz kod, który odpowiadałby poniższemu zapisowi
                //result[i] = arr1[j1] < arr2[j2] ? arr1[j1++] : arr2[j2++];

            }
            if (j1 < arr1.Length)
            {
                result[i] = arr1[j1++];
                continue;
            }
            if (j2 < arr2.Length)
            {
                result[i] = arr2[j2++];
            }
        }
        return result;
    }
}
//Cwiczenie 2
//Zaimplementuj metodę wykonującą scalanie w miejscu
//4 punkty
public class MergeSortInPLace
{
    public static void Sort(int[] arr)
    {
        SortArray(arr, 0, arr.Length - 1);
    }
    private static void SortArray(int[] arr, int left, int right)
    {
        if (left == right)
        {
            return;
        }
        if (left + 1 == right)
        {
            if (arr[left] > arr[right])
            {
                (arr[left], arr[right]) = (arr[right], arr[left]);
            }
        }
        var mid = (left + right) / 2;
        SortArray(arr, left, mid);
        SortArray(arr, mid + 1, right);
        Merge(arr, left, mid, right);
    }
    //zaimplementuj tę metodę, tak, aby wykonać scalanie w miejscu
    //left  - indeks pierwszego elementu pierwszej podtablicy
    //mid   - indeks ostatniego elementu pierwszej podtablicy
    //right - indeks ostatniego elementu drugiej podtablicy
    //Przykład
    //arr   => {2, 4, 6, 3, 5, 8, 11, 7}
    //left  => 0
    //mid   => 2
    //right => 5
    //po wykonaniu scalania tablica arr powinna mieć postać:
    //arr => {2, 3, 4, 5, 6, 8, 11, 7}
    private static void Merge(int[] arr, int left, int mid, int right)
    {

    }
}
//Cwiczenie 3
//8 punktów
//Zaimplementuj klasę do sortowania pozycyjnego liczb szesnastkowych zapisanych w łańcuchach 
//Przykładowa tablica do posortowania
//string[] HexNumbers = {"AF3", "12D", "236", "120"};
//talica po posortowania
//{"120", "12D", "236", "AF3"}

class StringHexPositionSort
{
    //Zadeklaruj tablicę kolejek dla każdej cyfry szestnastkowej
    //Każda kolejka jest typu string

    private void Init()
    {
        //zaimplementuj zainicjowanie tablicy kolejek
        throw new NotImplementedException();
    }

    private void Dequeue(string[] arr)
    {
        //zaimplementuje pobieranie z kolejek łańcuchów z liczbami i umieszczanie ich w tablicy arr
        throw new NotImplementedException();

    }

    //Zaimplementuj metodę, aby zwracała liczbę równą cyfrze szesnastkowej na podanej pozycji (position) w łańcuchu str
    //Pozycja jest numerowana od prawej do lewej
    // np. dla łańcucha "AB12"
    // cyfra na pozycji 0 to 2,
    // cyfra na pozycji 2 to 11,
    // cyfra na pozycji 8 to 0
    private int ExtractDigit(string str, uint position)
    {
        throw new NotImplementedException();
    }
    //zaimplementuj umieszczanie liczb łacuchów z liczbami hex w kolejce odpowiadającej cyfrze na podanej pozycji
    private void Enqueue(string[] arr, uint position)
    {

        throw new NotImplementedException();
    }
    //Tej metody nie zmieniaj!!!
    public void Sort(string[] arr, int d)
    {
        Init();
        for (uint position = 0; position < d; position++)
        {
            Enqueue(arr, position);
            Dequeue(arr);
        }
    }
}