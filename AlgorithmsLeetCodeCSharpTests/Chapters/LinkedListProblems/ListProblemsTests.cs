using AlgorithmsLeetCode.Chapters.LinkedListProblems;
using AlgorithmsLeetCodeCSharp.Chapters.LinkedListProblems;
using NUnit.Framework;

namespace AlgorithmsLeetCodeCSharpTests.Chapters.LinkedListProblems
{
	public class ListProblemsTests
	{
		ListProblems solution = new ListProblems();
		NodeWithRadom node1 = null;
		NodeWithRadom node2 = null;
		NodeWithRadom node3 = null;
		NodeWithRadom node4 = null;
		NodeWithRadom node5 = null;

		[Test]
		public void Check_CopyRandomList_BaseCase()
		{
			node1 = new NodeWithRadom(7);
			node2 = new NodeWithRadom(13);
			node3 = new NodeWithRadom(11);
			node4 = new NodeWithRadom(10);
			node5 = new NodeWithRadom(1);

			node1.next = node2;
			node1.random = null;

			node2.next = node3;
			node2.random = node1;

			node3.next = node4;
			node3.random = node5;

			node4.next = node5;
			node4.random = node3;

			node5.next = null;
			node5.random = node1;

			var copyRandomListResult1 = solution.CopyRandomList(node1);
			Assert.IsTrue(copyRandomListResult1.random == null);
			Assert.IsTrue(copyRandomListResult1.next.random.val == node1.val);
		}


		[Test]
		public void Check_CopyRandomList_SecondFailedCase()
		{
			node1 = new NodeWithRadom(1);
			node2 = new NodeWithRadom(2);

			node1.next = node2;
			node1.random = node2;

			node2.next = null;
			node2.random = node2;

			var copyRandomListResult2 = solution.CopyRandomList(node1);
			Assert.IsTrue(copyRandomListResult2.val == node1.val);
			Assert.IsTrue(copyRandomListResult2.next.val == node2.val);
			Assert.IsTrue(copyRandomListResult2.next.random.val == node2.val);
		}


		[Test]
		public void Check_CopyRandomList_ThirdFailedCase()
		{
			node1 = new NodeWithRadom(-1);

			node1.next = null;
			node1.random = node1;

			var copyRandomListResult3 = solution.CopyRandomList(node1);
			Assert.IsTrue(copyRandomListResult3.val == node1.val);
			Assert.IsTrue(copyRandomListResult3.random.val == node1.val);
		}
	}
}
