using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_2
{
    // 2.4
    class PartitionList
    {
        public PartitionList()
        { }

        public static void RunPartitionList()
        {
            List list = new List();
            list.Add(3);
            list.Add(3);
            list.Add(2);
            list.Add(6);
            list.Add(7);
            list.Add(2);
            list.Add(5);
            list.Add(5);
            list.Add(2);
            list.Add(7);
            list.Add(8);
            list.Add(9);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(3);
            list.Add(5);
            list.Add(3);
            list.PrintList();
            SortListPartition(list, 5);
            list.PrintList();
        }

        public static void SortListPartition(List list, int part)
        {

        }
    }
}
