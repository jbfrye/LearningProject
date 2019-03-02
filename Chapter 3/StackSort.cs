using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_3
{
    // 3.6
    class StackSort
    {
        Stack<int> oStack, tempStack;

        public StackSort(Stack<int> s)
        {
            oStack = s;
        }

        public void StartSort()
        {
            tempStack.Clear();
            Sort(oStack.Pop(), int.MinValue);
            oStack = new Stack<int>(tempStack);
        }

        public void Sort(int e, int c)
        {
            if (e >= c)
            {
                tempStack.Push(e);
                if (oStack.Count > 0)
                    Sort(oStack.Pop(), tempStack.Peek());
            }
            else
            {
                oStack.Push(tempStack.Pop());
                if (tempStack.Count > 0)
                    Sort(e, tempStack.Peek());
                else
                {
                    tempStack.Push(e);
                    Sort(oStack.Pop(), tempStack.Peek());
                }
            }
        }

        public void PrintStack()
        {
            tempStack = new Stack<int>(oStack);
            int count = tempStack.Count;
            for (int i = 0; i < count; i++)
            {
                Console.Write(tempStack.Pop());
                if (i < count - 1)
                    Console.Write(", ");
            }
            Console.WriteLine();
        }

        public static void RunStackSort()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(8);
            stack.Push(38);
            stack.Push(2);
            stack.Push(28);
            stack.Push(92);
            stack.Push(7);
            stack.Push(29);
            stack.Push(16);
            stack.Push(89);
            StackSort sortedStack = new StackSort(stack);
            sortedStack.PrintStack();
            sortedStack.StartSort();
            sortedStack.PrintStack();
        }
    }
}
