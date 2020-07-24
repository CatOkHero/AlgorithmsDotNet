using System;
using System.Collections.Generic;

namespace AlgorithmsLeetCodeCSharp.Chapters.BinaryTreeProblems
{
	public class TraverseATreeProblems
	{
		// https://leetcode.com/explore/learn/card/data-structure-tree/134/traverse-a-tree/931/
		// Binary Tree Level Order Traversal
		public IList<IList<int>> LevelOrder(TreeNode root)
		{
			IList<IList<int>> list = new List<IList<int>>();
			if (root == null)
			{
				return list;
			}

			Queue<TreeNode> treeNodesQueue = new Queue<TreeNode>();

			treeNodesQueue.Enqueue(root);
			while (treeNodesQueue.Count != 0)
			{
				IList<int> roots = new List<int>();
				int size = treeNodesQueue.Count;
				while (size > 0)
				{
					var oldRoot = treeNodesQueue.Dequeue();
					var left = oldRoot.left;
					var right = oldRoot.right;
					if (left != null)
					{
						treeNodesQueue.Enqueue(left);
					}

					if (right != null)
					{
						treeNodesQueue.Enqueue(right);
					}

					roots.Add(oldRoot.val);
					size--;
				}

				list.Add(roots);
			}

			return list;
		}

		// https://leetcode.com/explore/learn/card/data-structure-tree/134/traverse-a-tree/930/
		// Binary Tree Postorder Traversal
		public IList<int> PostorderTraversal(TreeNode root)
		{
			var list = new List<int>();
			if (root == null)
			{
				return list;
			}

			var left = root.left;
			if (left != null)
			{
				list.AddRange(PostorderTraversal(left));
			}

			var right = root.right;
			if (right != null)
			{
				list.AddRange(PostorderTraversal(right));
			}

			list.Add(root.val);
			return list;
		}

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
