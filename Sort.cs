using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject
{
    class Sort
    {
        public Sort()
        { }

        public void QuickSort(char[] arr)
        {
            QuickSortAction(arr, 0, arr.Length - 1);
        }

        void QuickSortAction(char[] arr, int low, int high)
        {
            if (low < high)
            {
                // pi is partitioning index, arr[pi] is now at right place
                int pi = Partition(arr, low, high);

                // Recursively sort elements before partition and after partition
                QuickSortAction(arr, low, pi - 1);
                QuickSortAction(arr, pi + 1, high);
            }
        }

        int Partition(char[] arr, int low, int high)
        {
            int pivot = arr[high];

            // index of the smaller element
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                // If current element is smaller than or equal to pivot
                if (arr[j] <= pivot)
                {
                    i++;

                    // swap str[i] and str[j]
                    char temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            // swamp arr[i+1] and arr[high] (or pivot)
            char temp2 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp2;

            return i + 1;
        }
    }
}