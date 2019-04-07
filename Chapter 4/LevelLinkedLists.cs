using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_4
{
    // 4.4
    class LevelLinkedLists
    {
        public LevelLinkedLists()
        { }

        public static LinkedList<LinkedList<TreeNode>> CreateLinkedLists(TreeNode root)
        {
            LinkedList<LinkedList<TreeNode>> levels = new LinkedList<LinkedList<TreeNode>>();
            LinkedList<TreeNode> current = new LinkedList<TreeNode>();
            current.AddLast(root);
            while (current.Count > 0
                )
            {
                levels.AddLast(current);
                LinkedList<TreeNode> parent = current;
                current = new LinkedList<TreeNode>();
                foreach (TreeNode node in parent)
                {
                    if (node.leftChild != null)
                        current.AddLast(node.leftChild);
                    if (node.rightChild != null)
                        current.AddLast(node.rightChild);
                }
            }
            return levels;
        }

        public static void RunLevelLinkedLists()
        {
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

            LinkedList<LinkedList<TreeNode>> levels = CreateLinkedLists(parent);
            int level = 1;
            foreach (LinkedList<TreeNode> nodeList in levels)
            {
                Console.Write("Level " + level + ": ");
                foreach(TreeNode node in nodeList)
                {
                    Console.Write(node.value + " ");
                }
                Console.WriteLine();
                level++;
            }
        }
    }
}
