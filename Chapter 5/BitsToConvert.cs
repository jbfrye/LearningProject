using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_5
{
    // 5.5

    class BitsToConvert
    {
        public BitsToConvert()
        { }

        public static int BitSwapRequired(int a, int b)
        {
            int count = 0;
            for (int c = a ^ b; c != 0; c = c >> 1)
                count += c & 1;
            return count;
        }

        public static void RunBitsToConvert()
        {
            Console.WriteLine(BitSwapRequired(6, 9));
        }
    }
}
