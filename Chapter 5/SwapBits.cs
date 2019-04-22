using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_5
{
    // 5.6

    class SwapBits
    {
        public SwapBits()
        { }

        public static uint Swap(uint n)
        {
            // Swap all the even and odd bits
            return ((n & 0xaaaaaaaa) >> 1) | ((n & 0x55555555) << 1);
        }

        public static void RunSwapBits()
        {
            Console.WriteLine(Swap(12));
        }
    }
}
