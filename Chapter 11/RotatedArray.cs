using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_11
{
    // 11.3
    class RotatedArray
    {
        public RotatedArray()
        { }

        static int FindNumber(int[] arr, int start, int end, int k)
        {
            int mid = (start + end) / 2;
            if (k == arr[mid]) // Element found
            return mid;
            if (end < start) // k isn't here
            return -1;

            /* Either the left or right half must be normally ordered. Find out
            * which side is normally ordered, and then use the normally ordered
            * half to figure out which side to search to find x. */
            if (arr[start] < arr[mid]) // Left is normally ordered
            {
                if (k >= arr[start] && k <= arr[mid])
                    return FindNumber(arr, start, mid - 1, k); // Search left
                else
                    return FindNumber(arr, mid + 1, end, k); // Search right
            }
            else if (arr[mid] < arr[start]) // Right is normally ordered
            {
                if (k >= arr[mid] && k <= arr[end])
                    return FindNumber(arr, mid + 1, end, k); // Search right
                else
                    return FindNumber(arr, start, mid - 1, k); // Search left
            }
            else if (arr[start] == arr[mid]) // Left half is all repeats
            {
                if (arr[mid] != arr[end]) // If right is different, search it
                    return FindNumber(arr, mid + 1, end, k); // Search right
                else // Otherwise, we have to search both halves
                {
                    int result = FindNumber(arr, start, mid - 1, k); // Search left
                    if (result == -1)
                        return FindNumber(arr, mid + 1, end, k); // Search right
                    else
                        return result;
                }
            }
            return -1;
        }

        public static int FindNumber(int[] arr, int k)
        {
            return FindNumber(arr, 0, arr.Length-1, k);
        }

        public static void RunRotatedArray()
        {
            int[] arr1 = new int[] { 10, 15, 20, 0, 5 };
            int[] arr2 = new int[] { 50, 5, 20, 30, 40 };
            Console.WriteLine(RotatedArray.FindNumber(arr1, 0));
            Console.WriteLine(RotatedArray.FindNumber(arr2, 20));
        }
    }
}
