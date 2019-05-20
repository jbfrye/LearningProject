using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_9
{
    // 9.1
    class Staircase
    {
        public Staircase()
        { }

        public static int CountWays(int n, int[] map)
        {
            if (n < 0)
                return 0;
            else if (n == 0)
                return 1;
            else if (map[n-1] > -1)
                return map[n-1];
            else
            {
                map[n-1] = CountWays(n - 1, map)
                    + CountWays(n - 2, map)
                    + CountWays(n - 3, map);
                return map[n-1];
            }
        }

        public static void RunStaircase()
        {
            int n = 3;
            int[] map = new int[n];
            for (int i = 0; i < n; i++)
                map[i] = -1;
            Console.WriteLine(Staircase.CountWays(n, map));
        }
    }
}
