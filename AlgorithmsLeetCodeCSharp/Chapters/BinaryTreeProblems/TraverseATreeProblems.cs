using System;
using System.Collections.Generic;

namespace AlgorithmsLeetCodeCSharp.Chapters.BinaryTreeProblems
{
	public class TreeNode
	{
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
		{
			this.val = val;
			this.left = left;
			this.right = right;
		}
	}

	public class SetupTraverseATreeProblemsTests
	{
		public void ExecuteTestCases()
		{
			var solution = new TraverseATreeProblems();

			var node6 = new TreeNode(6);
			var node5 = new TreeNode(5, node6);
			var node4 = new TreeNode(4);
			var node3 = new TreeNode(3, node4, node5);
			var node2 = new TreeNode(2, null, null);
			var node1 = new TreeNode(1, node2, node3);

			var preorderTraversal1 = solution.PreorderTraversal(node1);
			if(preorderTraversal1.Count != 6
				|| preorderTraversal1[0] != 1
				|| preorderTraversal1[3] != 4)
			{
				throw new Exception("Failed");
			}

			node6 = new TreeNode(6);
			node5 = new TreeNode(5);
			node4 = new TreeNode(4, node5, node6);
			node3 = new TreeNode(3, node4, null);
			node2 = new TreeNode(2, null, null);
			node1 = new TreeNode(1, node2, node3);
			var inorderTraversal1 = solution.InorderTraversal(node1);
			if(inorderTraversal1.Count != 6
				|| inorderTraversal1[0] != 2
				|| inorderTraversal1[2] != 5)
			{
				throw new Exception("Failed");
			}

			var node9 = new TreeNode(9);
			var node8 = new TreeNode(8, null, node9);
			var node7 = new TreeNode(7);
			node6 = new TreeNode(6);
			node5 = new TreeNode(5, node7, node8);
			node4 = new TreeNode(4, node6, null);
			node3 = new TreeNode(3, null, null);
			node2 = new TreeNode(2, node4, node3);
			node1 = new TreeNode(1, node2, node5); 
			
			var inorderTraversal2 = solution.InorderTraversal(node1);
			if (inorderTraversal2.Count != 9
				|| inorderTraversal2[0] != 6
				|| inorderTraversal2[3] != 3
				|| inorderTraversal2[5] != 7
				|| inorderTraversal2[8] != 9)
			{
				throw new Exception("Failed");
			}
			
			node3 = new TreeNode(3);
			node2 = new TreeNode(2, node3);
			node1 = new TreeNode(1, null, node2);
			var inorderTraversal3 = solution.InorderTraversal(node1);
			if (inorderTraversal3.Count != 3
				 || inorderTraversal3[0] != 1
				 || inorderTraversal3[1] != 3
				 || inorderTraversal3[2] != 2)
			{
				throw new Exception("Failed");
			}
		}
	}

	public class TraverseATreeProblems
	{
		// https://leetcode.com/explore/learn/card/data-structure-tree/134/traverse-a-tree/929/
		// Binary Tree Inorder Traversal
		public IList<int> InorderTraversal(TreeNode root)
		{
			var list = new List<int>();
			if (root == null)
			{
				return list;
			}

			var stack = new Stack<TreeNode>();
			var current = root;
			while (current != null || stack.Count > 0)
			{
				while (current != null)
				{
					stack.Push(current);
					current = current.left;
				}

				current = stack.Pop();
				list.Add(current.val);
				current = current.right;
			}

			return list;

			//var stack = new Stack<TreeNode>();
			//stack.Push(root);
			//var current = root;
			//while (stack.Count > 0 || current != null)
			//{
			//	while (current != null)
			//	{
			//		current = current.left;
			//		if(current != null)
			//		{
			//			stack.Push(current);
			//		}
			//	}

			//	current = stack.Pop();
			//	list.Add(current.val);
			//	current = current.right;
			//	if (current != null)
			//	{
			//		stack.Push(current);
			//	}
			//}

			//return list;

			//var left = InorderTraversal(root.left);
			//if (left != null)
			//{
			//	list.AddRange(left);
			//}

			//list.Add(root.val);
			//var right = InorderTraversal(root.right);
			//if (right != null)
			//{
			//	list.AddRange(right);
			//}

			//return list;
		}


		// https://leetcode.com/explore/learn/card/data-structure-tree/134/traverse-a-tree/928/
		// Binary Tree Preorder Traversal
		public IList<int> PreorderTraversal(TreeNode root)
		{
			if (root == null)
			{
				return new List<int>();
			}

			var list = new List<int>();
			var stack = new Stack<TreeNode>();
			stack.Push(root);
			while (stack.Count > 0)
			{
				var tree = stack.Pop();
				if(tree == null)
				{
					continue;
				}

				list.Add(tree.val);
				var rigth = tree.right;
				if(rigth != null)
				{
					stack.Push(rigth);
				}

				var left = tree.left;
				if(left != null)
				{
					stack.Push(left);
				}
			}

			return list;

			//var listValue = new List<int>();
			//int val = root.val;
			//listValue.Add(val);
			//var preorderLeft = PreorderTraversal(root.left);
			//if (preorderLeft != null)
			//{
			//	listValue.AddRange(preorderLeft);
			//}

			//var preorderRight = PreorderTraversal(root.right);
			//if (preorderRight != null)
			//{
			//	listValue.AddRange(preorderRight);
			//}

			//return listValue;
		}
	}
}
