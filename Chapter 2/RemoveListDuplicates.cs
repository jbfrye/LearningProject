using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_2
{
    // 2.1
    class RemoveListDuplicates
    {
        public RemoveListDuplicates()
        { }

        public static void RunRemoveListDuplicates()
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
            //RemoveDuplicates(list);
            RemoveDuplicatesLessData(list);
            list.PrintList();
        }

        public static void RemoveDuplicates(List<int> list)
        {
            Map entries = new Map();

            Node<int> n = list.GetHead();
            Node<int> prev = null;
            while (n != null)
            {
                if (entries.Get(n.data.ToString()) != -1)
                {
                    prev.next = n.next;
                }
                else
                {
                    entries.Put(n.data.ToString(), 1);
                    prev = n;
                }
                n = n.next;
            }
        }

        public static void RemoveDuplicatesLessData(List<int> list)
        {
            Node<int> n = list.GetHead();
            Node<int> run = null;
            while (n != null)
            {
                run = n;
                while (run.next != null)
                {
                    if (run.next.data == n.data)
                        run.next = run.next.next;
                    else
                        run = run.next;
                }
                n = n.next;
            }
        }
    }
}
