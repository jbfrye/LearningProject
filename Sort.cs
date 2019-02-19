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

        // Quick Sort functions
        public static void QuickSort(char[] arr)
        {
            QuickSortAction(arr, 0, arr.Length - 1);
        }

        static void QuickSortAction(char[] arr, int low, int high)
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

        static int Partition(char[] arr, int low, int high)
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

        // Merge Sort functions
        public static void MergeSort(List<int> li)
        {
            li.SetHead(MergeSortAction(li.GetHead()));
        }

        public static Node<int> MergeSortAction(Node<int> n)
        {
            // Base Case
            if (n == null || n.next == null)
                return n;

            Node<int> mid = GetMiddle(n);
            Node<int> midNext = mid.next;

            mid.next = null;

            Node<int> left = MergeSortAction(n);
            Node<int> right = MergeSortAction(midNext);

            Node<int> sortedList = SortedMerge(left, right);
            return sortedList;
        }

        static Node<int> GetMiddle(Node<int> n)
        {
            // Base Case
            if (n == null)
                return n;

            Node<int> fastPTR = n.next;
            Node<int> slowPTR = n;
            while (fastPTR != null)
            {
                fastPTR = fastPTR.next;
                if (fastPTR != null)
                {
                    slowPTR = slowPTR.next;
                    fastPTR = fastPTR.next;
                }
            }
            return slowPTR;
        }

        static Node<int> SortedMerge(Node<int> a, Node<int> b)
        {
            Node<int> result = null;
            // Base Cases
            if (a == null)
                return b;
            if (b == null)
                return a;

            if (a.data <= b.data)
            {
                result = a;
                result.next = SortedMerge(a.next, b);
            }
            else
            {
                result = b;
                result.next = SortedMerge(a, b.next);
            }
            return result;
        }
    }
}