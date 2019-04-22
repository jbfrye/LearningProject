using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_5
{
    // 5.3

    class NextBinaryNumber
    {
        public NextBinaryNumber()
        { }

        public static int GetNext(int n)
        {
            // Compute c0 and c1
            int c = n, c0 = 0, c1 = 0;
            while (((c & 1) == 0) && (c != 0))
            {
                c0++;
                c >>= 1;
            }

            while ((c & 1) == 1)
            {
                c1++;
                c >>= 1;
            }

            // There is no larger number with the same number of 1s
            if (c0 + c1 == 31 || c0 + c1 == 0)
                return -1;

            // Compute the position of the rightmost non-trailing zero
            int p = c0 + c1;

            n |= (1 << p); // Flip rightmost non-trailing zero
            n &= ~((1 << p) - 1); // Clear all bits to the right of p
            n |= (1 << (c1 - 1)) - 1; // Insert (c1-1) ones on the right
            return n;
        }

        public static int GetPrev(int n)
        {
            int temp = n, c0 = 0, c1 = 0;
            while ((temp & 1) == 1)
            {
                c1++;
                temp >>= 1;
            }

            if (temp == 0)
                return -1;

            while (((temp & 1) == 0) && (temp != 0))
            {
                c0++;
                temp >>= 1;
            }

            int p = c0 + c1; // Position of rightmost non-trailing one
            n &= ((~0) << (p + 1)); // Clears from bit p onwards

            int mask = (1 << (c1 + 1)) - 1; // Sequence of (c1+1) ones
            n |= mask << (c0 - 1);

            return n;
        }

        public static void RunNextBinaryNumber()
        {
            int num = 77, nextNum = GetNext(num), prevNum = GetPrev(num);

            Console.WriteLine("Original: " + Convert.ToString(num, 2) + " = " + num);
            Console.WriteLine("Greater: " + Convert.ToString(nextNum, 2) + " = " + nextNum);
            Console.WriteLine("Smaller: " + Convert.ToString(prevNum, 2) + " = " + prevNum);
        }
    }
}
