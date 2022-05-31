using System;
using System.Collections.Generic;

namespace Lab_13
{
    class Program
    {
        static void Main(string[] args)
        {
            int points = 0;
            if (
                IsPalindrome("a")
                && IsPalindrome("aaa")
                && IsPalindrome("")
                && IsPalindrome("zakaz")
                && IsPalindrome("ZaKAZ")
                && IsPalindrome("KamilŚlimak")
                && !IsPalindrome("abc")
                )
            {
                Console.WriteLine("Zadanie 1: ok");
                points += 1;
            }
            if (
                IsAnagrams("abcd", "bcda")
                && IsAnagrams("aa", "aa")
                && !IsAnagrams("AA", "aa")
                && IsAnagrams("", "")
                && !IsAnagrams("abc", "abca")
                )
            {
                Console.WriteLine("Zadanie 2: ok");
                points += 1;
            }
            if (
                LongestIdenticalString("aaaa").Equals("aaaa")
                && LongestIdenticalString("abcddddaaddd").Equals("dddd")
                && LongestIdenticalString("abcd").Equals("a")
                && LongestIdenticalString("abbcdd").Equals("bb")
                )
            {
                Console.WriteLine("Zadanie 3: ok");
                points += 2;
            }
        }


        //czy input jest palindromem
        public static bool IsPalindrome(string input)
        {
            if (String.IsNullOrEmpty(input))
                return false;
            input = input
                          .Replace(" ", "")
                          .ToLower();

            int length = input.Length;

            for (int i = 0; i < length / 2; i++)
            {
                if (input[i] != input[length - i - 1])
                    return false;
            }
            return true;
        }

        //czy łańcuchy są anagramami
        public static bool IsAnagrams(string a, string b)
        {
            if (a.Length != b.Length)
                return false;

            if (a == b)
                return true;//or false: Don't know whether a string counts as an anagram of itself

            Dictionary<char, int> pool = new Dictionary<char, int>();
            foreach (char element in a.ToCharArray()) //fill the dictionary with that available chars and count them up
            {
                if (pool.ContainsKey(element))
                    pool[element]++;
                else
                    pool.Add(element, 1);
            }
            foreach (char element in b.ToCharArray()) //take them out again
            {
                if (!pool.ContainsKey(element)) //if a char isn't there at all; we're out
                    return false;
                if (--pool[element] == 0) //if a count is less than zero after decrement; we're out
                    pool.Remove(element);
            }
            return pool.Count == 0;
        }


        //zwróć pierwszy najdłuższy fragment złożony z powtarzających się znaków wejścia
        public static string LongestIdenticalString(string input)
        {
            return "";
        }

    }
}


