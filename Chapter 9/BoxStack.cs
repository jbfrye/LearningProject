using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_9
{
    // 9.10
    class BoxStack
    {
        ArrayList boxes;

        public BoxStack()
        {
            boxes = new ArrayList();
        }

        public void AddBox(int w, int h, int d)
        {
            boxes.Add(new Box(w, h, d));
        }

        ArrayList StackBoxes(Box[] boxes, Box bottom, Dictionary<Box, ArrayList> stack_map)
        {
            if (bottom != null && stack_map.ContainsKey(bottom))
                return stack_map[bottom];

            int max_height = 0;
            ArrayList max_stack = null;
            for (int i = 0; i < boxes.Length; i++)
            {
                if (boxes[i].CanBeAbove(bottom))
                {
                    ArrayList new_stack = StackBoxes(boxes, boxes[i], stack_map);
                    int new_height = StackHeight(new_stack);
                    if (new_height > max_height)
                    {
                        max_stack = new_stack;
                        max_height = new_height;
                    }
                }
            }

            if (max_stack == null)
                max_stack = new ArrayList();
            if (bottom != null)
                max_stack.Insert(0, bottom);
            stack_map.Add(bottom, max_stack);

            return (ArrayList)max_stack.Clone();
        }

        public int StackHeight(ArrayList stack)
        {
            int height = 0;
            foreach (Box box in stack)
            {
                height += box.Depth;
            }
            return height;
        }

        public ArrayList[] StackBoxes()
        {
            Box[] boxesLeft = new Box[boxes.Count];
            int count = 0;
            foreach (Box box in boxes)
            {
                boxesLeft[count] = box;
                count++;
            }
            Dictionary<Box, ArrayList> stack_map = new Dictionary<Box, ArrayList>();

            //return StackBoxes(boxesLeft, boxesLeft[0], stack_map);
            ArrayList[] results = new ArrayList[boxes.Count];

            for (int i = 0; i < boxes.Count; i++)
            {
                results[i] = StackBoxes(boxesLeft, boxesLeft[i], stack_map);
            }
            return results;
        }

        public static void RunBoxStack()
        {
            BoxStack boxStack = new BoxStack();
            boxStack.AddBox(25, 25, 25);
            boxStack.AddBox(10, 10, 10);
            boxStack.AddBox(20, 20, 20);
            boxStack.AddBox(50, 50, 50);
            boxStack.AddBox(35, 35, 35);

            /*
            ArrayList result = boxStack.StackBoxes();
            Console.WriteLine("Stack height: " + boxStack.StackHeight(result));
            foreach (Box box in result)
                Console.Write(box.PrintBox() + " ");
            Console.WriteLine();
            */

            ArrayList[] result = boxStack.StackBoxes();
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine("Stack Height: " + boxStack.StackHeight(result[i]));
                foreach (Box box in result[i])
                    Console.Write(box.PrintBox() + " ");
                Console.WriteLine();
            }
        }
    }

    class Box
    {
        public int Width { get; }
        public int Height { get; }
        public int Depth { get; }

        public Box(int w, int h, int d)
        {
            Width = w;
            Height = h;
            Depth = d;
        }

        public bool CanBeAbove(Box box)
        {
            if (box.Width > Width && box.Height > Height && box.Depth > Depth)
                return true;
            else
                return false;
        }

        public string PrintBox()
        {
            return "(" + Width + ", " + Height + ", " + Depth + ")";
        }
    }
}
