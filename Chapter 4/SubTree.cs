using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_4
{
    // 4.8

    class SubTree
    {
        public SubTree()
        { }

        public static bool FindSubTree(TreeNode r1, TreeNode r2)
        {
            // Base case if the node is null
            if (r2 == null)
                return true;
            if (r1 == null)
                return false;
            // If the Nodes match, check if the subtrees match
            if (r1.value == r2.value)
                if (MatchTree(r1, r2))
                    return true;
            // Check the left child
            if (FindSubTree(r1.leftChild, r2))
                return true;
            // Check the right child
            if (FindSubTree(r1.rightChild, r2))
                return true;
            // If no sub tree match is found return false
            return false;
        }

        public static bool MatchTree(TreeNode r1, TreeNode r2)
        {
            // If they are null but still the same
            if (r1 == null && r2 == null)
                return true;
            // If one of them is null and they don't match
            if ((r1 == null && r2 != null) || (r1 != null && r2 == null))
                return false;
            // If the nodes don't match it's not a sub tree
            if (r1.value != r2.value)
                return false;
            bool isSubTree = true;
            // Check if the left children match
            if (!MatchTree(r1.leftChild, r2.leftChild))
                isSubTree = false;
            // Check if the right children match
            if (!MatchTree(r1.rightChild, r2.rightChild))
                isSubTree = false;
            return isSubTree;
        }

        public static void RunSubTree()
        {
            TreeNode r1 = new TreeNode(10);
            TreeNode r1Left = new TreeNode(5);
            TreeNode r1Right = new TreeNode(15);
            TreeNode r1RightRight = new TreeNode(20);
            r1.AddLeftChild(r1Left);
            r1.AddRightChild(r1Right);
            r1Right.AddRightChild(r1RightRight);

            TreeNode r2 = new TreeNode(10);
            TreeNode r2Left = new TreeNode(5);
            TreeNode r2Right = new TreeNode(15);

            Console.WriteLine(FindSubTree(r1, r2Left));
        }
    }
}
