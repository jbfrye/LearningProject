using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_11
{
    // 11.8
    class TrackTree
    {
        private static RankNode root = null;
        public TrackTree()
        { }

        public static void Track(int num)
        {
            if (root == null)
                root = new RankNode(num);
            else
                root.Insert(num);
        }

        public static int GetRankOfNumber(int num)
        {
            return root.GetRank(num);
        }

        public static void RunTrackTree()
        {
            TrackTree.Track(5);
            TrackTree.Track(10);
            TrackTree.Track(13);
            TrackTree.Track(15);
            TrackTree.Track(20);
            TrackTree.Track(23);
            TrackTree.Track(24);
            TrackTree.Track(25);

            Console.WriteLine(TrackTree.GetRankOfNumber(24));
        }
    }

    public class RankNode
    {
        public int left_size = 0;
        public RankNode left, right;
        public int data = 0;

        public RankNode (int d)
        {
            data = d;
        }

        public void Insert(int d)
        {
            if (d <= data)
            {
                if (left != null)
                    left.Insert(d);
                else
                    left = new RankNode(d);
                left_size++;
            }
            else
            {
                if (right != null)
                    right.Insert(d);
                else
                    right = new RankNode(d);
            }
        }

        public int GetRank(int d)
        {
            if (d == data)
                return left_size;
            else if (d < data)
            {
                if (left == null)
                    return -1;
                else
                    return left.GetRank(d);
            }
            else
            {
                int right_rank = right == null ? -1 : right.GetRank(d);
                if (right_rank == -1)
                    return -1;
                else
                    return left_size + 1 + right_rank;
            }
        }
    }
}
