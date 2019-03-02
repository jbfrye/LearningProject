using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_3
{
    // 3.5
    class MyQueue
    {
        Stack<int> stackNew, stackOld;

        public MyQueue()
        {
            stackNew = new Stack<int>();
            stackOld = new Stack<int>();
        }

        public void EnQueue(int d)
        {
            stackNew.Push(d);
        }

        public int Dequeue()
        {
            shiftStack();
            return stackOld.Pop();
        }

        public int Peek()
        {
            shiftStack();
            return stackOld.Peek();
        }

        void shiftStack()
        {
            if (stackOld.Count <= 0)
            {
                while (stackNew.Count > 0)
                    stackOld.Push(stackNew.Pop());
            }
        }

        public int Size()
        {
            return stackNew.Count + stackOld.Count;
        }

        public static void RunMyQueue()
        {
            MyQueue q = new MyQueue();
            q.EnQueue(23);
            q.EnQueue(312);
            q.EnQueue(21);
            q.EnQueue(54);
            Console.WriteLine(q.Dequeue());
            q.EnQueue(345);
            q.EnQueue(32);
            Console.WriteLine(q.Peek());
            q.EnQueue(64);
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Peek());
        }
    }
}
