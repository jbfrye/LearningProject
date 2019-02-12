using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_1
{
    // 1.2
    class Reverse
    {
        public Reverse()
        { }

        public static void RunReverse()
        {
            string input = "See Spot Run!";
            char[] str = input.ToCharArray();

            Console.WriteLine("Initial String: " + input);

            ReverseStr(str);

            String converted = new string(str);
            Console.WriteLine("Reversed String: " + converted);
        }

        public static void ReverseStr(char[] str)
        {
            int start = 0, end = str.Length - 1;
            char temp;

            // Leave the loop whenever all the elements are swapped
            while (start <= end)
            {
                // Swap the two elements
                temp = str[start];
                str[start] = str[end];
                str[end] = temp;

                // Move to the next elements
                start++;
                end--;
            }
        }
    }
}
