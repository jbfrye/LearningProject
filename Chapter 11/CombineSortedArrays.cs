using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_11
{
    // 11.1
    class CombineSortedArrays
    {
        public CombineSortedArrays()
        { }

        public static int[] Combine(int[] arr1, int[] arr2)
        {
            int total = arr1.Length + arr2.Length;
            int[] results = new int[total];
            int i = 0, j = 0, count = 0;
            while (count < total)
            {
                if (i >= arr1.Length)
                    results[count] = arr2[j];
                else if (j >= arr2.Length)
                    results[count] = arr1[i];
                else
                {
                    if (arr1[i] >= arr2[j])
                    {
                        results[count] = arr2[j];
                        j++;
                    }
                    else
                    {
                        results[count] = arr1[i];
                        i++;
                    }
                }
                count++;
            }
            return results;
        }

        public static void RunCombineSortedArrays()
        {
            int[] arr1 = new int[] { 1, 3, 6, 10, 15 };
            int[] arr2 = new int[] { 3, 5, 7, 8, 12 };

            int[] results = CombineSortedArrays.Combine(arr1, arr2);
            for (int i = 0; i < results.Length; i++)
            {
                Console.WriteLine(results[i]);
            }
        }
    }
}
