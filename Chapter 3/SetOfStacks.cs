using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_3
{
    class SetOfStacks
    {
        const int CAPACITY = 3;
        const int DEFAULT_SIZE = 10;
        int stackPTR, size;
        Stack<int>[] stacks;

        public SetOfStacks()
        {
            stackPTR = -1;
            size = DEFAULT_SIZE;
            stacks = new Stack<int>[DEFAULT_SIZE];
        }

        public void Push(int d)
        {
            if (stackPTR == -1)
            {
                stackPTR = 0;
                stacks[stackPTR] = new Stack<int>();
                stacks[stackPTR].Push(d);
            }
            else if (AtCapacity(stacks[stackPTR]))
            {
                stackPTR++;
                if (stackPTR >= size)
                    IncreaseSize();
                stacks[stackPTR] = new Stack<int>();
                stacks[stackPTR].Push(d);
            }
            else
            {
                stacks[stackPTR].Push(d);
            }
        }

        public int Pop()
        {
            if (stackPTR == -1)
                return -1;
            else
            {
                if (IsEmpty(stacks[stackPTR]))
                {
                    return -1;
                }
                else
                {
                    int result = stacks[stackPTR].Pop();
                    if (IsEmpty(stacks[stackPTR]))
                    {
                        stacks[stackPTR] = null;
                        stackPTR--;
                    }
                    return result;
                }
            }
        }

        public int Peek()
        {
            return stacks[stackPTR].Peek();
        }

        public int PopAt(int s)
        {
            int popStack = s - 1;
            if (!IsEmpty(stacks[popStack]))
            {
                if (popStack == stackPTR)
                    return this.Pop();
                else
                {
                    int returnVal = stacks[popStack].Pop();
                    for (int i = popStack + 1; i <= stackPTR; i++)
                    {
                        Shift(i);
                    }
                    if (IsEmpty(stacks[stackPTR]))
                        stackPTR--;
                    return returnVal;
                }
            }
            else
                return -1;
        }

        void Shift(int s)
        {
            // Pop the item out of the stack and Recurse until base case is hit
            int item = stacks[s].Pop();
            if (!IsEmpty(stacks[s]))
                Shift(s);

            // If there is space in the preceding stack, push the item on
            if (!AtCapacity(stacks[s - 1]))
                stacks[s - 1].Push(item);
            else
                stacks[s].Push(item);
        }

        public int Size()
        {
            int count = 0;
            for (int i = 0; i <= stackPTR; i++)
                count += stacks[i].Count;
            return count;
        }

        bool AtCapacity(Stack<int> s)
        {
            if (s.Count >= CAPACITY)
                return true;
            else
                return false;
        }

        bool IsEmpty(Stack<int> s)
        {
            if (s.Count <= 0)
                return true;
            else
                return false;
        }

        void IncreaseSize()
        {
            size = size * 2;
            Stack<int>[] temp = new Stack<int>[size];
            stacks.CopyTo(temp, 0);
            stacks = new Stack<int>[size];
            temp.CopyTo(stacks, 0);
        }

        public static void RunSetOfStacks()
        {
            SetOfStacks stacks = new SetOfStacks();
            for (int i = 1; i <= 10; i++)
                stacks.Push(i);
            Console.WriteLine(stacks.PopAt(2));
            Console.WriteLine(stacks.PopAt(1));
            Console.WriteLine(stacks.PopAt(3));
            int size = stacks.Size();
            for (int i = 0; i < size; i++)
                Console.Write(stacks.Pop() + " ");
        }
    }
}
