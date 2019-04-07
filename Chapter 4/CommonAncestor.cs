using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_4
{
    // 4.7
    class CommonAncestor
    {
        public CommonAncestor()
        { }

        public static Result CommonAncestorHelper(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
                return new Result(null, false);
            if (root == p && root == q)
                return new Result(root, true);

            Result rx = CommonAncestorHelper(root.leftChild, p, q);
            if (rx.isAncestor)
                return rx;

            Result ry = CommonAncestorHelper(root.rightChild, p, q);
            if (ry.isAncestor)
                return ry;

            // This is the common ancestor
            if (rx.node != null && ry.node != null)
                return new Result(root, true);
            // If we're currently at p or q, and we also found one of those nodes in a subtree,
            // then this is truly an ancestor and the flag should be true.
            else if (root == p || root == q)
            {
                bool isAncestor = rx.node != null || ry.node != null ? true : false;
                return new Result(root, isAncestor);
            }
            else
                return new Result(rx.node != null ? rx.node : ry.node, false);
        }

        public static TreeNode FindCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            Result r = CommonAncestorHelper(root, p, q);
            if (r.isAncestor)
                return r.node;
            return null;
        }

        public static void RunCommonAncestor()
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
            Console.WriteLine(FindCommonAncestor(parent, leaf1l, leaf2r2).value);
            parent.PrintTree();
        }
    }

    public class Result
    {
        public TreeNode node;
        public bool isAncestor;

        public Result(TreeNode n, bool isAnc)
        {
            node = n;
            isAncestor = isAnc;
        }
    }
}
