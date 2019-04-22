using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_5
{
    // 5.1

    class BitInsertion
    {
        public BitInsertion()
        { }

        public static int UpdateBits(int n, int m, int i, int j)
        {
            // Create a mask to clear bits i through j in n
            // EXAMPLE: i = 2, j = 4. Result should be 11100011
            // For simplicity, we'll use just 8 bits for the example

            // Will create a sequence of all 1s
            int allOnes = ~0;

            // 1s before position j, then 0s. left = 11100000
            int left = allOnes << (j + 1);

            // 1s after position i. right = 00000011
            int right = ((1 << i) - 1);

            // All 1s, except for 0s between i and j. mask = 11100011
            int mask = left | right;

            // Clear bits j through i, then put m in there
            int n_cleared = n & mask; // Clear bits j through i
            int m_shifted = m << i; // Move m into correct position

            return n_cleared | m_shifted;
        }

        public static void RunBitInsertion()
        {
            
            Console.WriteLine(Convert.ToString(UpdateBits(Convert.ToInt32("01100010", 2), Convert.ToInt32("1011", 2), 2, 4), 2));
        }
    }
}
