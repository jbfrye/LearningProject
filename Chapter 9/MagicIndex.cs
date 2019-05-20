using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_9
{
    // 9.3
    class MagicIndex
    {
        public MagicIndex()
        { }

        public static int FindMagicIndex(int[] array, int start, int end)
        {
            if (end < start || start < 0 || end >= array.Length)
                return -1;
            int mid = (start + end) / 2;
            if (array[mid] == mid)
                return mid;
            else if (array[mid] > mid)
                return FindMagicIndex(array, start, mid - 1);
            else
                return FindMagicIndex(array, mid + 1, end);
        }

        public static int FindMagicIndexImproved(int[] array, int start, int end)
        {
            if (end < start || start < 0 || end >= array.Length)
                return -1;
            int midIndex = (start + end) / 2;
            int midValue = array[midIndex];
            if (midValue == midIndex)
                return midIndex;

            // Search left
            int leftIndex = Math.Min(midIndex - 1, midValue);
            int left = FindMagicIndexImproved(array, start, leftIndex);
            if (left >= 0)
                return left;

            // Search right
            int rightIndex = Math.Max(midIndex + 1, midValue);
            int right = FindMagicIndexImproved(array, rightIndex, end);

            return right;
        }

        public static void RunMagicIndex()
        {
            int[] arrDistinct = new int[] { -40, -20, -1, 1, 2, 3, 5, 7, 9, 12, 13 };
            int[] arrNotDistinct = new int[] { -10, -5, 2, 2, 2, 3, 4, 7, 9, 12, 13 };
            Console.WriteLine(MagicIndex.FindMagicIndex(arrDistinct, 0, arrDistinct.Length - 1));
            Console.WriteLine(MagicIndex.FindMagicIndexImproved(arrNotDistinct, 0, arrNotDistinct.Length - 1));
        }
    }
}
