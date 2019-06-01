using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_11
{
    // 11.5
    class StringSearch
    {
        public StringSearch()
        { }

        static int FindString(string[] arr, string str, int first, int last)
        {
            if (first > last)
                return -1;
            int mid = (first + last) / 2;
            while (arr[mid] == "" && mid >= first)
                mid--;
            if (arr[mid] == "") // The entire left side is the empty string
            {
                mid = (first + last) / 2;
                while (arr[mid] == "" && mid <= last)
                    mid++;
                if (arr[mid] == "")
                    return -1; // The array is all empty strings
                else
                {
                    if (arr[mid] == str)
                        return mid;
                    else if (string.Compare(arr[mid], str) < 0)
                        return FindString(arr, str, mid + 1, last); // Search right
                    else if (string.Compare(arr[mid], str) > 0)
                        return FindString(arr, str, first, mid - 1); // Search left
                }
            }
            else
            {
                if (arr[mid] == str)
                    return mid;
                else if (string.Compare(arr[mid], str) < 0)
                    return FindString(arr, str, mid + 1, last); // Search right
                else if (string.Compare(arr[mid], str) > 0)
                    return FindString(arr, str, first, mid - 1); // Search left
            }
            return -1;
        }

        public static int FindString(string[] arr, string str)
        {
            return FindString(arr, str, 0, arr.Length - 1);
        }

        public static void RunStringSearch()
        {
            string[] arr = new string[] { "", "a", "b", "", "c", "", "", "d", "e", "", "f" };
            int result = StringSearch.FindString(arr, "a");
            Console.WriteLine(result);
        }
    }
}
