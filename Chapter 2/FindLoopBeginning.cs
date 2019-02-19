using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_2
{
    // 2.6
    class FindLoopBeginning
    {
        public FindLoopBeginning()
        { }

        public static void RunFindLoopBeginning()
        {
            List<int> loopList = new List<int>();
            Node<int> a1 = new Node<int>(5);
            Node<int> a2 = new Node<int>(6);
            Node<int> a3 = new Node<int>(2);
            Node<int> a4 = new Node<int>(7);
            Node<int> a5 = new Node<int>(4);
            Node<int> a6 = new Node<int>(3);
            Node<int> a7 = new Node<int>(2);
            loopList.Add(a1);
            loopList.Add(a2);
            loopList.Add(a3);
            loopList.Add(a4);
            loopList.Add(a5);
            loopList.Add(a6);
            loopList.Add(a7);
            loopList.Add(a4);
            //loopList.PrintList(); // Creates an infinite loop (LOL)
            Node<int> loopNode = DetectLoop(loopList);
            Console.WriteLine("The beginning of the loop is: " + loopNode.data);
        }

        public static Node<int> DetectLoop(List<int> li)
        {
            Node<int> slowPTR = li.GetHead(), fastPTR = li.GetHead();

            // Run through the loop until they overlap or there is no loop
            while (fastPTR != null && fastPTR.next != null)
            {
                slowPTR = slowPTR.next;
                fastPTR = fastPTR.next.next;
                if (slowPTR == fastPTR)
                    break;
            }

            if (slowPTR != fastPTR)
                return null;

            slowPTR = li.GetHead();
            while (slowPTR != fastPTR)
            {
                slowPTR = slowPTR.next;
                fastPTR = fastPTR.next;
            }

            return fastPTR;
        }
    }
}
