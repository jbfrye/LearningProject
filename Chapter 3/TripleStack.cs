using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_3
{
    // 3.1
    class TripleStack<T>
    {
        const int DEFAULT_SIZE = 60;
        const int STACKONESTART = 0;
        const int STACKTWOSTART = 20;
        const int STACKTHREESTART = 40;
        readonly T[] stack;
        int stackOneIndex = -1, stackTwoIndex = 19, stackThreeIndex = 39;


        public TripleStack()
        {
            stack = new T[DEFAULT_SIZE];
        }

        public static void RunTripleStack()
        {
            TripleStack<int> stack = new TripleStack<int>();
            stack.Push(1, 1);
            stack.Push(2, 1);
            stack.Push(3, 1);
            stack.Push(4, 2);
            stack.Push(5, 2);
            stack.Push(6, 2);
            stack.Push(7, 3);
            stack.Push(8, 3);
            stack.Push(9, 3);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    Console.Write(stack.Pop(j) + " ");
                }
            }
            Console.WriteLine();
        }

        public bool Push(T d, int s)
        {
            switch (s)
            {
                case 1:
                    if (stackOneIndex < STACKTWOSTART)
                    {
                        stackOneIndex++;
                        stack[stackOneIndex] = d;
                        return true;
                    }
                    else
                        return false;
                case 2:
                    if (stackTwoIndex < STACKTHREESTART)
                    {
                        stackTwoIndex++;
                        stack[stackTwoIndex] = d;
                        return true;
                    }
                    else
                        return false;
                case 3:
                    if (stackThreeIndex < DEFAULT_SIZE)
                    {
                        stackThreeIndex++;
                        stack[stackThreeIndex] = d;
                        return true;
                    }
                    else
                        return false;
                default:
                    return false;
            }
        }

        public T Pop(int s)
        {
            T returnData;
            switch (s)
            {
                case 1:
                    returnData = stack[stackOneIndex];
                    stack[stackOneIndex] = default(T);
                    stackOneIndex--;
                    return returnData;
                case 2:
                    returnData = stack[stackTwoIndex];
                    stack[stackTwoIndex] = default(T);
                    stackTwoIndex--;
                    return returnData;
                case 3:
                    returnData = stack[stackThreeIndex];
                    stack[stackThreeIndex] = default(T);
                    stackThreeIndex--;
                    return returnData;
                default:
                    return default(T);
            }
        }

        public T Peek(int s)
        {
            switch (s)
            {
                case 1:
                    return stack[stackOneIndex];
                case 2:
                    return stack[stackTwoIndex];
                case 3:
                    return stack[stackThreeIndex];
                default:
                    return default(T);
            }
        }

        public bool IsEmpty(int s)
        {
            switch (s)
            {
                case 1:
                    if (STACKONESTART == stackOneIndex)
                        return true;
                    else
                        return false;
                case 2:
                    if (STACKTWOSTART == stackTwoIndex)
                        return true;
                    else
                        return false;
                case 3:
                    if (STACKTHREESTART == stackThreeIndex)
                        return true;
                    else
                        return false;
                default:
                    return true;
            }
        }
    }
}