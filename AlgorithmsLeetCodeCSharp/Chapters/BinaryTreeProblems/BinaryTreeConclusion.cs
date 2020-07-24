namespace AlgorithmsLeetCodeCSharp.Chapters.BinaryTreeProblems
{
	public class SetupBinaryTreeConclusion
	{
		public void ExecuteTestCases()
		{
			var solution = new BinaryTreeConclusion();

			var inorderIP1 = new int[] { 9, 3, 15, 20, 7 };
			var postorderIP1 = new int[] { 9, 15, 7, 20, 3 };
			/*
			 *  3
			   / \
			  9  20
				/  \
			   15   7
			*/
			//var buildTreeIP1 = solution.BuildTreeIP(inorderIP1, postorderIP1);

		}
	}

	public class BinaryTreeConclusion
	{
		// https://leetcode.com/explore/learn/card/data-structure-tree/133/conclusion/942/
		// Construct Binary Tree from Inorder and Postorder Traversal
		public TreeNode BuildTreeIP(int[] inorder, int[] postorder)
		{
			int i = 0;
			while(inorder[i] == postorder[i])
			{
				i++;
			}

			var treeNode = new TreeNode(postorder[postorder.Length - 1]);
			return treeNode;
		}

		private TreeNode BuildLeftTreeIP(int[] inorder, int indexTo, int indexFrom)
		{
			TreeNode leftTreeNode = null;

			if (leftTreeNode == null)
			{
				leftTreeNode = new TreeNode(inorder[inorder.Length - indexFrom]);
			}

			leftTreeNode.left = BuildLeftTreeIP(inorder, indexTo, inorder.Length - indexFrom);
			leftTreeNode.right = BuildLeftTreeIP(inorder, indexTo, inorder.Length - indexFrom - 1);

			return leftTreeNode;
		}

		private TreeNode BuildRightTreeIP(int[] postorder, int indexTo, int indexFrom)
		{
			TreeNode rightTreeNode = null;

			if (rightTreeNode == null)
			{
				rightTreeNode = new TreeNode(postorder[postorder.Length - indexFrom]);
			}

			rightTreeNode.left = BuildRightTreeIP(postorder, indexTo, postorder.Length - indexFrom - 1);
			rightTreeNode.right = BuildRightTreeIP(postorder, indexTo, postorder.Length - indexFrom);

			return rightTreeNode;
		}
	}
}
