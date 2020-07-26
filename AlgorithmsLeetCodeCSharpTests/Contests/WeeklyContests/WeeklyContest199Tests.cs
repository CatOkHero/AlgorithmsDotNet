using AlgorithmsLeetCodeCSharp.Chapters.BinaryTreeProblems;
using AlgorithmsLeetCodeCSharp.Contests.WeeklyContests;
using NUnit.Framework;

namespace AlgorithmsLeetCodeCSharpTests.Contests
{
	public class WeeklyContest199Tests
	{
		private WeeklyContest199 solution = new WeeklyContest199();
		TreeNode node7 = null;
		TreeNode node6 = null;
		TreeNode node5 = null;
		TreeNode node4 = null;
		TreeNode node3 = null;
		TreeNode node2 = null;
		TreeNode node1 = null;

		[TestCase("101", 3)]
		[TestCase("10111", 3)]
		[TestCase("00000", 0)]
		[TestCase("001011101", 5)]
		public void Check_MinFlips_BaseCase(string binary, int result)
		{
			var minFlips = solution.MinFlips(binary);
			Assert.IsTrue(minFlips == result);
		}

		[Test]
		public void Check_CountPairs_BaseCase()
		{
			node4 = new TreeNode(4);
			node3 = new TreeNode(3);
			node2 = new TreeNode(2, null, node4);
			node1 = new TreeNode(1, node2, node3);
			var countPairs1 = solution.CountPairs(node1, 3);
			Assert.IsTrue(countPairs1 == 1);
		}

		[Test]
		public void Check_CountPairs_SecondCase()
		{
			// [11,99,88,77,null,null,66,55,null,null,44,33,null,null,22]
			// 4
			var node9 = new TreeNode(22);
			var node8 = new TreeNode(33);
			node7 = new TreeNode(44, node9, null);
			node6 = new TreeNode(55, null, node8);
			node5 = new TreeNode(66, null, node7);
			node4 = new TreeNode(77, node6, null);
			node3 = new TreeNode(88, null, node5);
			node2 = new TreeNode(99, node4, null);
			node1 = new TreeNode(11, node2, node3);
			var countPairs2 = solution.CountPairs(node1, 4);
			Assert.IsTrue(countPairs2 == 0);
		}

		[Test]
		public void Check_CountPairs_ThirdCase()
		{
			node7 = new TreeNode(7);
			node6 = new TreeNode(6);
			node5 = new TreeNode(5);
			node4 = new TreeNode(4);
			node3 = new TreeNode(3, node6, node7);
			node2 = new TreeNode(2, node4, node5);
			node1 = new TreeNode(1, node2, node3);
			var countPairs3 = solution.CountPairs(node1, 3);
			Assert.IsTrue(countPairs3 == 2);
		}

		[Test]
		public void Check_CountPairs_FourthCase()
		{
			node7 = new TreeNode(7);
			node6 = new TreeNode(6);
			node5 = new TreeNode(5);
			node4 = new TreeNode(4);
			node3 = new TreeNode(3, node6, node7);
			node2 = new TreeNode(2, node4, node5);
			node1 = new TreeNode(1, node2, node3);
			var node01 = new TreeNode(8);
			var node0 = new TreeNode(0, node1, node01);
			var countPairs4 = solution.CountPairs(node0, 4);
			Assert.IsTrue(countPairs4 == 10);
		}

		[TestCase("codeleet", new int[] { 4, 5, 6, 7, 0, 2, 1, 3 }, "leetcode")]
		[TestCase("abc", new int[] { 0, 1, 2 }, "abc")]
		[TestCase("aiohn", new int[] { 3, 1, 4, 2, 0 }, "nihao")]
		[TestCase("aaiougrt", new int[] { 4, 0, 2, 6, 7, 3, 1, 5 }, "arigatou")]
		[TestCase("art", new int[] { 1, 0, 2 }, "rat")]
		public void Check_RestoreString_BaseCase(string s, int[] indices, string result)
		{
			var restoredString = solution.RestoreString(s, indices);
			Assert.AreEqual(restoredString, result);
		}
	}
}
