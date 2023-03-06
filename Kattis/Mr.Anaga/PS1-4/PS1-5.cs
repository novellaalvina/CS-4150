using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections;

public class Anagram
{
    public static void CountNonAnagram(int n, int k, HashSet<string> words_dict)
    {

        List<string> words_sol = new List<string>();
        List<string> words_rej = new List<string>();

        foreach (string w in words_dict)
        {
            char[] chars = w.ToCharArray();
            Array.Sort(chars);
            string sortedword = new string(chars);

            if (words_sol.Contains(sortedword))
            {
                words_sol.Remove(sortedword);
                words_rej.Add(sortedword);
            }
            else if (!words_rej.Contains(sortedword))
            {
                words_sol.Add(sortedword);
            }
        }

        //Console.WriteLine(words_sol.Count);

    }

    public static HashSet<string> RandomWordsListGenerator(int n, int k)
    {
        Dictionary<int, char> alphabet = new Dictionary<int, char>();
        HashSet<string> words_dict = new HashSet<string>();

        for (char c = 'a'; c <= 'z'; c++)
        {
            int key = c - 'a' + 1;
            alphabet.Add(key, c);
        }

        foreach (int i in Enumerable.Range(1, n))
        {
            string word = "";

            foreach (int j in Enumerable.Range(1, k))
            {
                Random rnd = new Random();
                int num = rnd.Next(1,27);

                word += alphabet[num];
            }

            words_dict.Add(word);
        }

        while (words_dict.Count != n)
        {
            string word = "";

            foreach (int j in Enumerable.Range(1, k))
            {
                Random rnd = new Random();
                int num = rnd.Next(1, 27);

                word += alphabet[num];
            }

            words_dict.Add(word);

        }

        return words_dict;
    }

    public static void Main()
    {



        //int n = 2000;
        int k = 5;

        for (int n = 1000; n <= 64000; n *= 2)
        {

            HashSet<string> words_dict = RandomWordsListGenerator(n, k);

            int x = 250;

            Stopwatch timer = new Stopwatch();
            timer.Start();

            for (int i = 0; i < x; i++)
            {
                //Console.WriteLine(i);
                CountNonAnagram(n, k, words_dict);
            }
            timer.Stop();

            Stopwatch timerOverhead = new Stopwatch();
            timerOverhead.Start();

            for (int i = 0; i < x; i++)
            {
                //Console.WriteLine(i);
                //CountNonAnagram(n, k, words_dict);
            }
            timerOverhead.Stop();

            Console.WriteLine("n = " + n + ", k = " + k + " | time per 1 anagram runs {0}", (timer.ElapsedMilliseconds - timerOverhead.ElapsedMilliseconds) / x);
        }
    }
}

//words_dict.Add("akeak");
//words_dict.Add("emeor");
//words_dict.Add("toutr");
//words_dict.Add("angle");
//words_dict.Add("outrt");
//words_dict.Add("tasty");
//words_dict.Add("routt");
//words_dict.Add("smart");
//words_dict.Add("tempt");
//words_dict.Add("kaaek");
//words_dict.Add("emore");

