using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_9
{
    // 9.4
    class AllSubsets
    {
        public AllSubsets()
        { }

        public static ArrayList GetSubsets(ArrayList set, int index)
        {
            ArrayList allSubsets;
            if (set.Count == index) // Base case - add empty set
            {
                allSubsets = new ArrayList();
                allSubsets.Add(new ArrayList()); // Empty set
            }
            else
            {
                allSubsets = GetSubsets(set, index + 1);
                int item = (int)set[index];
                ArrayList moreSubsets = new ArrayList();
                foreach (ArrayList subset in allSubsets)
                {
                    ArrayList newSubset = new ArrayList();
                    newSubset.Add(subset.Clone());
                    newSubset.Add(item);
                    moreSubsets.Add(newSubset);
                }
                allSubsets.Add(moreSubsets.Clone());
            }
            return allSubsets;
        }

        public static ArrayList GetSubsets2(ArrayList set)
        {
            ArrayList allSubset = new ArrayList();
            int max = 1 << set.Count; // Compute 2^n
            for (int k = 0; k < max; k++)
            {
                ArrayList subset = AllSubsets.ConvertIntToSet(k, set);
                allSubset.Add(subset);
            }
            return allSubset;
        }

        static ArrayList ConvertIntToSet(int x, ArrayList set)
        {
            ArrayList subset = new ArrayList();
            int index = 0;
            for (int k = x; k > 0; k >>= 1)
            {
                if ((k & 1) == 1)
                    subset.Add(set[index]);
                index++;
            }
            return subset;
        }

        public static void RunAllSubsets()
        {
            ArrayList set = new ArrayList();
            for (int i = 1; i <= 3; i++)
                set.Add(i);

            ArrayList results = AllSubsets.GetSubsets(set, 0);
            foreach (ArrayList list in results)
            {
                if (list.Count > 0)
                {
                    //foreach (var value in list)
                        //Console.WriteLine(value);
                }
                
            }

            ArrayList results2 = AllSubsets.GetSubsets2(set);
            foreach (ArrayList list in results2)
            {
                if (list.Count > 0)
                {
                    foreach (var value in list)
                        Console.Write(value + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
