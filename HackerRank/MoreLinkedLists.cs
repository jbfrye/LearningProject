using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.HackerRank
{
    class MoreLinkedLists
    {
        public MoreLinkedLists()
        { }

        public static MoreNode removeDuplicates(MoreNode head)
        {
            if (head == null)
                return null;

            Dictionary<int, int> map = new Dictionary<int, int>();
            MoreNode thisNode = head, prevNode = null;
            while (thisNode != null)
            {
                if (map.ContainsKey(thisNode.data))
                {
                    prevNode.next = thisNode.next;
                    thisNode = thisNode.next;
                }
                else
                {
                    map.Add(thisNode.data, 1);
                    prevNode = thisNode;
                    thisNode = thisNode.next;
                }
            }
            return head;
        }

        public static MoreNode insert(MoreNode head, int data)
        {
            MoreNode p = new MoreNode(data);


            if (head == null)
                head = p;
            else if (head.next == null)
                head.next = p;
            else
            {
                MoreNode start = head;
                while (start.next != null)
                    start = start.next;
                start.next = p;

            }
            return head;
        }
        public static void display(MoreNode head)
        {
            MoreNode start = head;
            while (start != null)
            {
                Console.Write(start.data + " ");
                start = start.next;
            }
        }

        public static void RunMoreLinkedLists()
        {
            MoreNode head = null;
            int T = Int32.Parse(Console.ReadLine());
            while (T-- > 0)
            {
                int data = Int32.Parse(Console.ReadLine());
                head = insert(head, data);
            }
            head = removeDuplicates(head);
            display(head);
        }
    }

    class MoreNode
    {
        public int data;
        public MoreNode next;
        public MoreNode(int d)
        {
            data = d;
            next = null;
        }
    }
}
