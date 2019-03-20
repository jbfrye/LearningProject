using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_4
{
    // 4.1
    class BinaryTreeBalanced
    {
        public BinaryTreeBalanced()
        {

        }

        public static bool IsBalancedBinaryTree(TreeNode root)
        {
            if (CheckHeight(root) == -1)
                return false;
            else
                return true;
        }

        public static int CheckHeight(TreeNode root)
        {
            if (root == null)
                return 0;

            int leftHeight = CheckHeight(root.leftChild);
            if (leftHeight == -1)
                return -1;

            int rightHeight = CheckHeight(root.rightChild);
            if (rightHeight == -1)
                return -1;

            int heightDiff = leftHeight - rightHeight;
            if (Math.Abs(heightDiff) > 1)
                return -1;
            else
                return Math.Max(leftHeight, rightHeight) + 1;
        }

        public static void RunBinaryTreeBalanced()
        {
            TreeNode parent = new TreeNode(69);
            TreeNode leaf1l = new TreeNode(42);
            TreeNode leaf1r = new TreeNode(39);
            TreeNode leaf2l = new TreeNode(72);
            TreeNode leaf2r = new TreeNode(28);
            TreeNode leaf2l2 = new TreeNode(14);
            TreeNode leaf2r2 = new TreeNode(17);
            TreeNode unbalanced = new TreeNode(999);
            TreeNode unbalanced2 = new TreeNode(1000);

            parent.AddLeftChild(leaf1l);
            parent.AddRightChild(leaf1r);
            leaf1l.AddLeftChild(leaf2l);
            leaf1l.AddRightChild(leaf2r);
            leaf1r.AddLeftChild(leaf2l2);
            leaf1r.AddRightChild(leaf2r2);
            leaf2l.AddLeftChild(unbalanced);
            unbalanced.AddLeftChild(unbalanced2);

            parent.PrintTree();

            Console.WriteLine();
            Console.WriteLine(BinaryTreeBalanced.IsBalancedBinaryTree(parent));
        }
    }

    class TreeNode
    {
        public TreeNode parent, leftChild, rightChild;
        public int value;

        public TreeNode(int v)
        {
            parent = null;
            leftChild = null;
            rightChild = null;
            value = v;
        }
        public TreeNode(TreeNode p, int v)
        {
            parent = p;
            leftChild = null;
            rightChild = null;
            value = v;
        }

        public void AddLeftChild(TreeNode node)
        {
            if (leftChild == null)
            {
                node.parent = this;
                leftChild = node;
            }
        }

        public void AddRightChild(TreeNode node)
        {
            if (rightChild == null)
            {
                node.parent = this;
                rightChild = node;
            }
        }

        public void PrintTree()
        {
            if (leftChild != null)
                leftChild.PrintTree();
            Console.WriteLine(value);
            if (rightChild != null)
                rightChild.PrintTree();
        }
    }
}
