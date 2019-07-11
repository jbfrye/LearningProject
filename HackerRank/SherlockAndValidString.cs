using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.HackerRank
{
    class SherlockAndValidString
    {
        static string isValid(string s)
        {
            if (s.Length <= 1)
                return "YES";

            int[] alphabet = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                alphabet[s[i] - 'a']++;
            }

            Dictionary<int, int> freq = new Dictionary<int, int>();
            for (int i = 0; i < 26; i++)
            {
                if (alphabet[i] > 0)
                {
                    if (freq.ContainsKey(alphabet[i]))
                        freq[alphabet[i]]++;
                    else
                        freq.Add(alphabet[i], 1);
                }
            }

            if (freq.Count > 2)
                return "NO";
            else if (freq.Count <= 1)
                return "YES";
            else
            {
                bool works = false;
                int[] seq = new int[2];
                int count = 0;
                foreach (KeyValuePair<int, int> pair in freq)
                {
                    if (pair.Value == 1)
                        works = true;
                    seq[count] = pair.Key;
                    count++;
                }
                Array.Sort(seq);
                if (seq[1] - seq[0] != 1)
                    if (freq[seq[0]] != 1)
                        works = false;
                if (works)
                    return "YES";
                else
                    return "NO";
            }
        }

        public static void Run()
        {
            Console.WriteLine(isValid("aaaaabc"));
        }
    }
}
