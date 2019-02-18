using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_2
{
    // 2.3
    class DeleteListNodeWithoutHead
    {
        public DeleteListNodeWithoutHead()
        { }

        public static void RunDeleteListNodeWithoutHead()
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
            Node node = list.Head();
            for (int i = 0; i < 8; i++)
                node = node.next;
            DeleteNode(node); // Delete 2
            list.PrintList();
        }

        public static void DeleteNode(Node n)
        {
            n.data = n.next.data;
            n.next = n.next.next;
        }
    }
}
