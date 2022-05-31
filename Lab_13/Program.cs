using System;
using System.Collections.Generic;
using System.Linq;

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
            string text = input.ToLower();
            char[] letters = text.ToCharArray(0, text.Length);
            int j = letters.Length - 1;
            for (int i = 0; i < letters.Length; i++)
            {
                if (letters[i] != letters[j])
                {
                    return false;
                }
                j--;
            }
            return true;
        }

        //czy łańcuchy są anagramami
        public static bool IsAnagrams(string a, string b)
        {
            if (a.Length != b.Length)
                return false;

            if (a == b)
                return true;

            Dictionary<char, int> text = new Dictionary<char, int>();
            foreach (char letters in a.ToCharArray())
            {
                if (text.ContainsKey(letters))
                    text[letters]++;
                else
                    text.Add(letters, 1);
            }
            foreach (char Text in b.ToCharArray())
            {
                if (!text.ContainsKey(Text))
                    return false;
                if (--text[Text] == 0)
                    text.Remove(Text);
            }
            return text.Count == 0;
        }


        //zwróć pierwszy najdłuższy fragment złożony z powtarzających się znaków wejścia
        public static string LongestIdenticalString(string input)
        {
            return new string(input.Select((c, index) => input.Substring(index).TakeWhile(e => e == c))
                                   .OrderByDescending(e => e.Count())
                                   .First().ToArray()); ;
        }

    }
}


