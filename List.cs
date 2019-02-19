using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject
{
    public class List<T>
    {
        Node<T> head = null;
        public List()
        { }

        public void Add(T d)
        {
            Node<T> newNode = new Node<T>(d);
            if (head == null)
                head = newNode;
            else
            {
                Node<T> n = head;
                while (n.next != null)
                    n = n.next;
                n.next = newNode;
            }
        }

        public void Add(Node<T> n)
        {
            if (head == null)
                head = n;
            else
            {
                Node<T> temp = head;
                while (temp.next != null)
                    temp = temp.next;
                temp.next = n;
            }
        }

        public bool DeleteNode(T d)
        {
            Node<T> tempNode = head;
            // Check if the head is the node to delete
            if (Object.Equals(head.data, d))
            {
                head = head.next;
                return true;
            }

            // Check the List for the node to delete and return true if it's found
            while (tempNode.next != null)
            {
                if (Object.Equals(tempNode.next.data, d))
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
            Node<T> n = head;
            while (n != null)
            {
                Console.Write(n.data + " ");
                n = n.next;
            }
            Console.WriteLine();
        }

        public Node<T> GetHead()
        {
            return head;
        }

        public void SetHead(Node<T> n)
        {
            head = n;
        }
    }

    public class Node<T>
    {
        public Node<T> next = null;
        public T data;

        public Node(T d)
        {
            data = d;
        }
    }
}
