using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_9
{
    // 9.8
    class Cents
    {
        public Cents()
        { }

        public static int MakeChange(int n, int denom)
        {
            int nextDenom = 0;

            switch (denom)
            {
                case 25:
                    nextDenom = 10;
                    break;
                case 10:
                    nextDenom = 5;
                    break;
                case 5:
                    nextDenom = 1;
                    break;
                case 1:
                    return 1;
            }

            int ways = 0;
            for (int i = 0; i * denom <= n; i++)
                ways += MakeChange(n - i * denom, nextDenom);
            return ways;
        }

        public static void RunCents()
        {
            Console.WriteLine(Cents.MakeChange(10, 25));
        }
    }
}
