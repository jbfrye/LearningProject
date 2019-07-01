using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.HackerRank
{
    class CountTriplets
    {
        public CountTriplets()
        {

        }

        public static long Count(System.Collections.Generic.List<long> arr, long r)
        {
            Dictionary<long, long> potential = new Dictionary<long, long>();
            Dictionary<long, long> counter = new Dictionary<long, long>();
            long count = 0;

            for (int i = 0; i < arr.Count; i++)
            {
                if (counter.ContainsKey(arr[i]))
                {
                    count += counter[arr[i]];
                }
                if (potential.ContainsKey(arr[i]))
                {
                    if (counter.ContainsKey(arr[i] * r))
                    {
                        counter[arr[i] * r] += potential[arr[i]];
                    }
                    else
                    {
                        counter[arr[i] * r] = potential[arr[i]];
                    }
                }
                if (potential.ContainsKey(arr[i] * r))
                {
                    potential[arr[i] * r]++;
                }
                else
                {
                    potential[arr[i] * r] = 1;
                }
            }

            return count;
        }

        public static void RunCountTriplets()
        {
            System.Collections.Generic.List<long> arr = new System.Collections.Generic.List<long>();
            arr.Add(1);
            arr.Add(2);
            arr.Add(2);
            arr.Add(4);
            Console.WriteLine(CountTriplets.Count(arr, 2));
        }
    }
}
