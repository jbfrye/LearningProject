using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_9
{
    // 9.5
    class StringPermutations
    {
        public StringPermutations()
        { }

        public static ArrayList GetPerms(string str)
        {
            if (str == null)
                return null;
            ArrayList permutations = new ArrayList();
            if (str.Length == 0)
            {
                permutations.Add("");
                return permutations;
            }

            char first = str[0]; // Get the first character
            string remainder = str.Substring(1); // Remove the first character
            ArrayList words = GetPerms(remainder);
            foreach (string word in words)
            {
                for (int j = 0; j <= word.Length; j++)
                {
                    string s = InsertCharAt(word, first, j);
                    permutations.Add(s);
                }
            }
            return permutations;
        }

        public static string InsertCharAt(string word, char c, int i)
        {
            string start = word.Substring(0, i);
            string end = word.Substring(i);
            return start + c + end;
        }

        public static void RunStringPermutations()
        {
            string str = "fun";
            ArrayList perms = GetPerms(str);

            foreach (string word in perms)
            {
                Console.WriteLine(word);
            }
        }
    }
}
