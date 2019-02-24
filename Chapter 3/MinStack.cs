using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_3
{
    // 3.2
    class MinStack : Stack<int>
    {
        Stack<int> minStack;

        public MinStack() : base()
        {
            minStack = new Stack<int>();
        }

        public static void RunMinStack()
        {
            MinStack stack = new MinStack();
            stack.Push(5);
            Console.WriteLine("Push 5. Min is: " + stack.Min());
            stack.Push(6);
            Console.WriteLine("Push 6. Min is: " + stack.Min());
            stack.Push(3);
            Console.WriteLine("Push 3. Min is: " + stack.Min());
            stack.Push(7);
            Console.WriteLine("Push 7. Min is: " + stack.Min());
            stack.Pop();
            Console.WriteLine("Pop. Min is: " + stack.Min());
            stack.Pop();
            Console.WriteLine("Pop. Min is: " + stack.Min());
        }

        public new void Push(int d)
        {
            base.Push(d);
            if (d <= Min())
                minStack.Push(d);
        }

        public new int Pop()
        {
            int data = base.Pop();
            if (data == minStack.Peek())
                minStack.Pop();
            return data;
        }

        public int Min()
        {
            if (minStack.Count == 0)
                return int.MaxValue;
            else
                return minStack.Peek();
        }
    }
}
