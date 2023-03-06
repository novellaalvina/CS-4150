using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        string nk_str;
        nk_str = Console.ReadLine();

        while (nk_str == "")
        {
            Console.WriteLine("Please input some n and k");
            nk_str = Console.ReadLine();
        }

        string[] nk_str_sp = nk_str.Split();

        int[] nk = Array.ConvertAll(nk_str_sp, int.Parse);

        int n = nk[0];
        int k = nk[1];

       HashSet<string> words_dict = new HashSet<string>();
       List<string> words_sol = new List<string>();
       List<string> words_rej = new List<string>();

       for (int i = 1; i <= n; i++)
       {
           words_dict.Add(Console.ReadLine());
       }

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

       Console.WriteLine(words_sol.Count);
   }
}
