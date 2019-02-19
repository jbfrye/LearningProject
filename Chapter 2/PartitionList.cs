using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_2
{
    // 2.4
    class PartitionList
    {
        public PartitionList()
        { }

        public static void RunPartitionList()
        {
            List<int> list = new List<int>();
            list.Add(3);
            list.Add(3);
            list.Add(2);
            list.Add(6);
            list.Add(7);
            list.Add(2);
            list.Add(5);
            list.Add(5);
            list.Add(2);
            list.Add(7);
            list.Add(8);
            list.Add(9);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(3);
            list.Add(5);
            list.Add(3);
            list.PrintList();
            SortListPartition(list, 4);
            list.PrintList();
            Sort.MergeSort(list);
            list.PrintList();
        }

        public static List<int> SortListPartition(List<int> list, int part)
        {
            Node<int> n = list.GetHead();
            Node<int> rightFront = null, leftFront = null, rightEnd = null, leftEnd = null;
            Node<int> middleFront = null, middleEnd = null;

            while (n != null)
            {
                if (n.data < part)
                {
                    if (leftFront == null)
                    {
                        leftFront = n;
                        leftEnd = n;
                        n = n.next;
                        leftFront.next = null;
                        leftEnd.next = null;
                    }
                    else
                    {
                        leftEnd.next = n;
                        if (leftFront.next == null)
                            leftFront.next = leftEnd;
                        leftEnd = leftEnd.next;
                        n = n.next;
                        leftEnd.next = null;
                    }
                }
                else if (n.data > part)
                {
                    if (rightFront == null)
                    {
                        rightFront = n;
                        rightEnd = n;
                        n = n.next;
                        rightFront.next = null;
                        rightEnd.next = null;
                    }
                    else
                    {
                        rightEnd.next = n;
                        if (rightFront.next == null)
                            rightFront.next = rightEnd;
                        rightEnd = rightEnd.next;
                        n = n.next;
                        rightEnd.next = null;
                    }
                }
                else
                {
                    if (middleFront == null)
                    {
                        middleFront = n;
                        middleEnd = n;
                        n = n.next;
                        middleFront.next = null;
                        middleEnd.next = null;
                    }
                    else
                    {
                        middleEnd.next = n;
                        if (middleFront.next == null)
                            middleFront.next = middleEnd;
                        middleEnd = middleEnd.next;
                        n = n.next;
                        middleEnd.next = null;
                    }
                }
            }

            leftEnd.next = middleFront;
            middleEnd.next = rightFront;
            List<int> newList = new List<int>();
            newList.SetHead(leftFront);
            return newList;
        }
    }
}
