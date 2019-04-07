using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_4
{
    // 4.3
    class CreateBinarySearchTree
    {
        public TreeNode root;
        public CreateBinarySearchTree()
        {
            root = null;
        }

        public CreateBinarySearchTree(int[] numArray)
        {
            root = CreateMinimalBST(numArray);
        }

        TreeNode CreateMinimalBST(int[] arr, int start, int end)
        {
            if (end < start)
                return null;
            int mid = (start + end) / 2;
            TreeNode n = new TreeNode(arr[mid]);
            TreeNode left = CreateMinimalBST(arr, start, mid - 1);
            TreeNode right = CreateMinimalBST(arr, mid + 1, end);
            if (left != null)
                n.AddLeftChild(left);
            if (right != null)
                n.AddRightChild(right);
            return n;
        }

        public TreeNode CreateMinimalBST(int[] arr)
        {
            return CreateMinimalBST(arr, 0, arr.Length - 1);
        }

        // Failed attempt
        private void BuildTree(int[] numArray)
        {
            int centerIndex = numArray.Length / 2;
            root = new TreeNode(numArray[centerIndex]);
            for (int i = centerIndex - 1; i >= 0; i--)
                AddNode(root, numArray[i]);
            for (int i = centerIndex + 1; i < numArray.Length; i++)
                AddNode(root, numArray[i]);
        }

        private void AddNode(TreeNode node, int v)
        {
            if (node.value >= v)
            {
                if (node.leftChild != null)
                    AddNode(node.leftChild, v);
                else
                    node.AddLeftChild(new TreeNode(v));
            }
            else if (node.value < v)
            {
                if (node.rightChild != null)
                    AddNode(node.rightChild, v);
                else
                    node.AddRightChild(new TreeNode(v));
            }

        }

        public static void RunCreateBinarySearchTree()
        {
            int[] numberArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            CreateBinarySearchTree binaryTree = new CreateBinarySearchTree(numberArray);
            binaryTree.root.PrintTree();
        }
    }
}
