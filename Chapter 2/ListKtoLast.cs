using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_2
{
    // 2.2
    class ListKtoLast
    {
        public ListKtoLast()
        { }

        public static void RunListKtoLast()
        {
            List list = new List();
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
            //Console.WriteLine("The 6th element from the end is: " + GetKtoLastElement(list, 6));
            Console.WriteLine("The 6th element from the end is: " + GetKtoLastElementEfficient(list, 6));
        }

        public static int GetKtoLastElement(List list, int k)
        {
            Node n = list.Head();
            Node end = null;
            for (int i = 0; i < k; i++)
            {
                while (n.next != end)
                {
                    n = n.next;
                }
                end = n;
                n = list.Head();
            }

            return end.data;
        }

        public static int GetKtoLastElementEfficient(List list, int k)
        {
            Node n = list.Head();
            Node m = list.Head();

            for (int i = 0; i < k; i++)
            {
                n = n.next;
            }

            while (n != null)
            {
                n = n.next;
                m = m.next;
            }

            return m.data;
        }
    }
}
