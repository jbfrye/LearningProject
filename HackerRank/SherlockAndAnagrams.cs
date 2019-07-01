using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.HackerRank
{
    class SherlockAndAnagrams
    {
        public SherlockAndAnagrams()
        {

        }

        public static int Anagrams(string s)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();
            int total = 0;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 1; j <= s.Length - i; j++)
                {
                    string sub = s.Substring(i, j);
                    sub = SherlockAndAnagrams.SortString(sub);

                    if (map.ContainsKey(sub))
                    {
                        total += map[sub];
                        map[sub]++;
                    }
                    else
                    {
                        map.Add(sub, 1);
                    }
                }
            }
            return total;
        }

        static string SortString(string input)
        {
            char[] characters = input.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }

        public static void RunSherlockAndAnagrams()
        {
            Console.WriteLine(SherlockAndAnagrams.Anagrams("cdcd"));
        }
    }
}
