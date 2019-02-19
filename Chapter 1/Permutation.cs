using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_1
{
    // 1.3
    class Permutation
    {
        Permutation()
        { }

        public static void RunPermutation()
        {
            string str1 = "Frye", str2 = "Fyre";
            bool isPer = FindPermutation(str1, str2);

            WriteOutput(str1, str2, isPer);
            Console.WriteLine();
            str1 = "Telephone";
            str2 = "Photograph";
            isPer = FindPermutation(str1, str2);
            WriteOutput(str1, str2, isPer);
        }

        static void WriteOutput(string str1, string str2, bool isPer)
        {
            Console.Write("The strings " + str1 + ", and " + str2 + " are ");
            if (!isPer)
                Console.Write("not ");
            Console.WriteLine("permutations of each other.");
        }

        public static bool FindPermutation(string str1, string str2)
        {
            // Check to see if it's possible to be a permutation
            if (str1.Length != str2.Length)
                return false;
            char[] arrStr1 = str1.ToLower().ToCharArray(), arrStr2 = str2.ToLower().ToCharArray();

            Sort.QuickSort(arrStr1);
            Sort.QuickSort(arrStr2);

            for (int i = 0; i < arrStr1.Length; i++)
            {
                if (arrStr1[i] != arrStr2[i])
                    return false;
            }

            return true;
        }
    }
}
