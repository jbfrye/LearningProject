using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_4
{
    // 4.9

    class BinaryTreeSum
    {
        public BinaryTreeSum()
        { }

        public static void FindSum(TreeNode node, int sum, int[] path, int level)
        {
            // Null Base Case
            if (node == null)
                return;
            // Insert current node into a path
            path[level] = node.value;
            // Look for paths with a sum that ends at this node
            int t = 0;
            for (int i = level; i >= 0; i--)
            {
                t += path[i];
                if (t == sum)
                    Print(path, i, level);
            }
            // Search the child nodes
            FindSum(node.leftChild, sum, path, level + 1);
            FindSum(node.rightChild, sum, path, level + 1);
            // Remove the current node from path
            path[level] = int.MinValue;
        }

        public static void FindSum(TreeNode node, int sum)
        {
            int depth = Depth(node);
            int[] path = new int[depth];
            FindSum(node, sum, path, 0);
        }

        public static void Print(int[] path, int start, int end)
        {
            for (int i = start; i <= end; i++)
                Console.Write(path[i] + " ");
            Console.WriteLine();
        }

        public static int Depth(TreeNode node)
        {
            if (node == null)
                return 0;
            else
                return 1 + Math.Max(Depth(node.leftChild), Depth(node.rightChild));
        }

        public static void RunBinaryTreeSum()
        {
            int[] numberArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            CreateBinarySearchTree binaryTree = new CreateBinarySearchTree(numberArray);
            LinkedList<LinkedList<TreeNode>> levels = LevelLinkedLists.CreateLinkedLists(binaryTree.root);
            int level = 1;
            foreach (LinkedList<TreeNode> nodeList in levels)
            {
                Console.Write("Level " + level + ": ");
                foreach (TreeNode node in nodeList)
                {
                    Console.Write(node.value + " ");
                }
                Console.WriteLine();
                level++;
            }
            Console.WriteLine();
            FindSum(binaryTree.root, 9);
        }
    }
}
