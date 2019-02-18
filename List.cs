using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject
{
    public class List
    {
        Node head = null;
        public List()
        { }

        public void Add(int d)
        {
            Node newNode = new Node(d);
            if (head == null)
                head = newNode;
            else
            {
                Node n = head;
                while (n.next != null)
                {
                    n = n.next;
                }
                n.next = newNode;
            }
        }

        public bool DeleteNode(int d)
        {
            Node tempNode = head;
            // Check if the head is the node to delete
            if (head.data == d)
            {
                head = head.next;
                return true;
            }

            // Check the List for the node to delete and return true if it's found
            while (tempNode.next != null)
            {
                if (tempNode.next.data == d)
                {
                    tempNode.next = tempNode.next.next;
                    return true;
                }
                tempNode = tempNode.next;

            }

            // Return false if the node to delete is not found
            return false;
        }

        public void PrintList()
        {
            Node n = head;
            while (n != null)
            {
                Console.Write(n.data + " ");
                n = n.next;
            }
            Console.WriteLine();
        }

        public Node Head()
        {
            return head;
        }
    }

    public class Node
    {
        public Node next = null;
        public int data;

        public Node(int d)
        {
            data = d;
        }
    }
}
