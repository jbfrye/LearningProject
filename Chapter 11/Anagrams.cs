using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_11
{
    // 11.2
    class Anagrams
    {
        public Anagrams()
        { }

        public static string[] SortArray(string[] arr)
        {
            Dictionary<string, LinkedList<string>> anagrams = new Dictionary<string, LinkedList<string>>();

            foreach (string str in arr)
            {
                char[] strArr = str.ToCharArray();
                Array.Sort(strArr);
                String sortStr = new String(strArr);
                if (!anagrams.ContainsKey(sortStr))
                    anagrams.Add(sortStr, new LinkedList<string>());
                LinkedList<string> list = anagrams[sortStr];
                list.AddLast(str);
            }

            int index = 0;
            foreach (string key in anagrams.Keys)
            {
                LinkedList<string> list = anagrams[key];
                foreach (string str in list)
                {
                    arr[index] = str;
                    index++;
                }
            }
            return arr;
        }

        public static void RunAnagrams()
        {
            string[] arr = new string[] { "state", "arc", "cat", "car", "elbow", "act", "below", "taste" };
            string[] result = Anagrams.SortArray(arr);
            Console.WriteLine("Original Array:");
            foreach (string str in result)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine("\nSorted Aray:");
            foreach (string str in result)
            {
                Console.WriteLine(str);
            }
        }
    }
}
