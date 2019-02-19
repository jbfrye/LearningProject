using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_2
{
    // 2.7
    class ListPalindrome
    {
        public ListPalindrome()
        { }

        public static void RunListPalindrome()
        {
            List<char> list = new List<char>();
            /*
            list.Add('m');
            list.Add('a');
            list.Add('d');
            list.Add('a');
            list.Add('m');
            */
            /*
            list.Add('a');
            list.Add('b');
            list.Add('u');
            list.Add('t');
            list.Add('t');
            list.Add('u');
            list.Add('b');
            list.Add('a');
            */
            list.Add('j');
            list.Add('e');
            list.Add('r');
            list.Add('e');
            list.Add('m');
            list.Add('y');
            bool isPal = IsPalindrome(list);

            Node<char> n = list.GetHead();
            string listStr = "";
            while (n != null)
            {
                listStr += n.data;
                n = n.next;
            }
            Console.WriteLine(listStr + " is a Palindrome: " + isPal);
        }

        public static bool IsPalindrome(List<char> li)
        {
            Node<char> fastPTR = li.GetHead(), slowPTR = li.GetHead();
            Node<char> startPTR = li.GetHead();
            Stack<int> stack = new Stack<int>();
            int counter = 0;

            // Find the middle Node and the size of the list
            while (fastPTR != null)
            {
                fastPTR = fastPTR.next;
                counter++;
                if (fastPTR != null)
                {
                    stack.Push(slowPTR.data);
                    fastPTR = fastPTR.next;
                    slowPTR = slowPTR.next;
                    counter++;
                }
            }
            if (counter % 2 == 1)
                stack.Push(slowPTR.data);
            while (slowPTR != fastPTR)
            {
                if (slowPTR.data != stack.Pop())
                    return false;
                slowPTR = slowPTR.next;
            }

            return true;
        }
    }
}
