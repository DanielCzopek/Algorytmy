using System;

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
            return false;
        }

        //czy łańcuchy są anagramami
        public static bool IsAnagrams(string a, string b)
        {
            return false;
        }


        //zwróć pierwszy najdłuższy fragment złożony z powtarzających się znaków wejścia
        public static string LongestIdenticalString(string input)
        {
            return "";
        }

    }
}


