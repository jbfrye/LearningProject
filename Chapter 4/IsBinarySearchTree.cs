using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_4
{
    // 4.5
    class IsBinarySearchTree
    {
        public static int lastValue = int.MinValue;

        public IsBinarySearchTree()
        { }

        public static bool CheckBinaryTree(TreeNode n)
        {
            if (n == null)
                return true;
            if (!CheckBinaryTree(n.leftChild))
                return false;
            if (n.value <= lastValue)
                return false;
            lastValue = n.value;
            if (!CheckBinaryTree(n.rightChild))
                return false;
            return true;
        }

        public static void RunIsBinarySearchTree()
        {
            int[] numberArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            CreateBinarySearchTree binaryTree = new CreateBinarySearchTree(numberArray);
            Console.WriteLine(CheckBinaryTree(binaryTree.root));
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

            TreeNode parent = new TreeNode(69);
            TreeNode leaf1l = new TreeNode(42);
            TreeNode leaf1r = new TreeNode(39);
            TreeNode leaf2l = new TreeNode(72);
            TreeNode leaf2r = new TreeNode(28);
            TreeNode leaf2l2 = new TreeNode(14);
            TreeNode leaf2r2 = new TreeNode(17);

            parent.AddLeftChild(leaf1l);
            parent.AddRightChild(leaf1r);
            leaf1l.AddLeftChild(leaf2l);
            leaf1l.AddRightChild(leaf2r);
            leaf1r.AddLeftChild(leaf2l2);
            leaf1r.AddRightChild(leaf2r2);
            Console.WriteLine(CheckBinaryTree(parent));
            parent.PrintTree();
        }
    }
}
