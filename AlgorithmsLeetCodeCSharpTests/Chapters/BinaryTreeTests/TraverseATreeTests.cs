using AlgorithmsLeetCodeCSharp.Chapters.BinaryTreeProblems;
using NUnit.Framework;

namespace AlgorithmsLeetCodeCSharpTests.Chapters.BinaryTreeTests
{
	public class TraverseATreeTests
	{
		private readonly TraverseATreeProblems solution = new TraverseATreeProblems();
		TreeNode node9 = null;
		TreeNode node8 = null;
		TreeNode node7 = null;
		TreeNode node6 = null;
		TreeNode node5 = null;
		TreeNode node4 = null;
		TreeNode node3 = null;
		TreeNode node2 = null;
		TreeNode node1 = null;
				 
		[Test]
		public void Check_PreorderTraversal_BaseCase()
		{
			node6 = new TreeNode(6);
			node5 = new TreeNode(5, node6);
			node4 = new TreeNode(4);
			node3 = new TreeNode(3, node4, node5);
			node2 = new TreeNode(2, null, null);
			node1 = new TreeNode(1, node2, node3);

			var preorderTraversal1 = solution.PreorderTraversal(node1);

			Assert.IsTrue(preorderTraversal1.Count == 6);
			Assert.IsTrue(preorderTraversal1[0] == 1);
			Assert.IsTrue(preorderTraversal1[3] == 4);
		}

		[Test]
		public void Check_InorderTraversal_BaseCase()
		{ 
			node6 = new TreeNode(6);
			node5 = new TreeNode(5);
			node4 = new TreeNode(4, node5, node6);
			node3 = new TreeNode(3, node4, null);
			node2 = new TreeNode(2, null, null);
			node1 = new TreeNode(1, node2, node3);

			var inorderTraversal1 = solution.InorderTraversal(node1);

			Assert.IsTrue(inorderTraversal1.Count == 6);
			Assert.IsTrue(inorderTraversal1[0] == 2);
			Assert.IsTrue(inorderTraversal1[2] == 5);
		}

		[Test]
		public void Check_InorderTraversal_FirstFailedCase()
		{
			node9 = new TreeNode(9);
			node8 = new TreeNode(8, null, node9);
			node7 = new TreeNode(7);
			node6 = new TreeNode(6);
			node5 = new TreeNode(5, node7, node8);
			node4 = new TreeNode(4, node6, null);
			node3 = new TreeNode(3, null, null);
			node2 = new TreeNode(2, node4, node3);
			node1 = new TreeNode(1, node2, node5);

			var inorderTraversal2 = solution.InorderTraversal(node1);

			Assert.IsTrue(inorderTraversal2.Count == 9);
			Assert.IsTrue(inorderTraversal2[0] == 6);
			Assert.IsTrue(inorderTraversal2[3] == 3);
			Assert.IsTrue(inorderTraversal2[5] == 7);
			Assert.IsTrue(inorderTraversal2[8] == 9);
		}

		[Test]
		public void Check_InorderTraversal_SecondFailedCase()
		{
			node3 = new TreeNode(3);
			node2 = new TreeNode(2, node3);
			node1 = new TreeNode(1, null, node2);

			var inorderTraversal3 = solution.InorderTraversal(node1);

			Assert.IsTrue(inorderTraversal3.Count == 3);
			Assert.IsTrue(inorderTraversal3[0] == 1);
			Assert.IsTrue(inorderTraversal3[1] == 3);
			Assert.IsTrue(inorderTraversal3[2] == 2);
		}

		[Test]
		public void Check_PostorderTraversal_BasedCase()
		{
			node3 = new TreeNode(3);
			node2 = new TreeNode(2, node3);
			node1 = new TreeNode(1, null, node2);

			var postOrderTraverse1 = solution.PostorderTraversal(node1);
			Assert.IsTrue(postOrderTraverse1.Count == 3);
			Assert.IsTrue(postOrderTraverse1[0] == 3);
			Assert.IsTrue(postOrderTraverse1[1] == 2);
			Assert.IsTrue(postOrderTraverse1[2] == 1);
		}

		[Test]
		public void Check_LevelOrder_BasedCase()
		{
			// [3,9,20,null,null,15,7,null,null,8,null]
			node6 = new TreeNode(8);
			node5 = new TreeNode(7, node6);
			node4 = new TreeNode(15);
			node3 = new TreeNode(20, node4, node5);
			node2 = new TreeNode(9);
			node1 = new TreeNode(3, node2, node3);
			var levelOrder = solution.LevelOrder(node1);
			Assert.IsTrue(levelOrder.Count == 4);
			Assert.IsTrue(levelOrder[0][0] == 3);
			Assert.IsTrue(levelOrder[1][0] == 9);
			Assert.IsTrue(levelOrder[3][0] == 8);
		}
	}
}
