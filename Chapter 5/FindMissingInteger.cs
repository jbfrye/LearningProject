using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_5
{
    // 5.7

    class FindMissingInteger
    {
        public FindMissingInteger()
        { }
    
        public static int FindMissing(ArrayList array)
        {
            return FindMissing(array, 0);
        }

        public static int FindMissing(ArrayList input, int column)
        {
            if (column >= 32)
                return 0;

            ArrayList oneBits = new ArrayList(input.Count / 2);
            ArrayList zeroBits = new ArrayList(input.Count / 2);

            foreach (int num in input)
            {
                if ((num & (1 << column)) == 0)
                    zeroBits.Add(num);
                else
                    oneBits.Add(num);
            }

            if (zeroBits.Count <= oneBits.Count)
            {
                int v = FindMissing(zeroBits, column + 1);
                return (v << 1) | 0;
            }
            else
            {
                int v = FindMissing(oneBits, column + 1);
                return (v << 1) | 1;
            }
        }

        public static void RunFindMissingInteger()
        {
            ArrayList input = new ArrayList();
            for (int i = 0; i < 10; i++)
            {
                if (i != 2)
                    input.Add(i);
            }

            Console.WriteLine(FindMissing(input));
        }
    }
}
