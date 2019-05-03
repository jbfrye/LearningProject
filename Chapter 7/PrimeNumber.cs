using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_7
{
    // 7.7
    class PrimeNumber
    {
        public PrimeNumber()
        { }

        public static int GetKthMagicNumber(int k)
        {
            if (k < 0)
                return 0;

            int val = 0;
            Queue<int> queue3 = new Queue<int>();
            Queue<int> queue5 = new Queue<int>();
            Queue<int> queue7 = new Queue<int>();
            queue3.Enqueue(1);

            // Include 0th through kth iteration
            for (int i = 0; i <= k; i++)
            {
                int v3 = queue3.Count() > 0 ? queue3.Peek() : int.MaxValue;
                int v5 = queue5.Count() > 0 ? queue5.Peek() : int.MaxValue;
                int v7 = queue7.Count() > 0 ? queue7.Peek() : int.MaxValue;

                val = Math.Min(v3, Math.Min(v5, v7));
                if (val == v3) // Enqueue into queue 3, 5, and 7
                {
                    queue3.Dequeue();
                    queue3.Enqueue(3 * val);
                    queue5.Enqueue(5 * val);
                }
                else if (val == v5) // Enqueue into queue 5 and 7
                {
                    queue5.Dequeue();
                    queue5.Enqueue(5 * val);
                }
                else if (val == v7) // Enqueue into 7
                    queue7.Dequeue();
                queue7.Enqueue(7 * val); // Always enqueue into 7
            }

            return val;
        }

        public static void RunPrimeNumber()
        {
            int k = 12;
            Console.WriteLine(GetKthMagicNumber(k));
        }
    }
}
