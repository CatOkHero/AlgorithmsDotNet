using AlgorithmsLeetCodeCSharp.Chapters.LinkedListProblems;
using NUnit.Framework;

namespace AlgorithmsLeetCodeCSharpTests.Chapters.LinkedListProblems
{
	public class LinkedListConclusionTests
	{
        private LinkedListConclusion solution = new LinkedListConclusion();

        [Test]
        public void Check_RotateRight_BaseCase()
        {
            var listNode = new ListNode(0, new ListNode(1, new ListNode(2)));
            var rotateRight1 = solution.RotateRight(listNode, 4);
            Assert.IsTrue(rotateRight1.val == 2);
        }

        [Test]
        public void Check_RotateRight_SecondCase()
		{
            var listNode = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            var rotateRight2 = solution.RotateRight(listNode, 2); 
            Assert.IsTrue(rotateRight2.val == 4);
        }

        [Test]
        public void Check_RotateRight_ThirdCase()
        {
            var listNode = new ListNode(1, new ListNode(2));
            var rotateRight3 = solution.RotateRight(listNode, 1);
            Assert.IsTrue(rotateRight3.val == 2);
        }

        [Test]
        public void Check_Flatten_BaseCase()
		{
            var headNode = new Node(1, null, null);
            var secondChildNode = new Node(7, null, null);
            var thirdChildNode = new Node(11, null, null);

            var headNode2 = new Node(2, headNode, null);
            var headNode3 = new Node(3, headNode2, secondChildNode);
            var headNode4 = new Node(4, headNode3, null);
            var headNode5 = new Node(5, headNode4, null);
            var headNode6 = new Node(6, headNode5, null);
            headNode.next = headNode2;
            headNode2.next = headNode3;
            headNode3.next = headNode4;
            headNode4.next = headNode5;
            headNode5.next = headNode6;

            var secondChildNode2 = new Node(8, secondChildNode, thirdChildNode);
            var secondChildNode3 = new Node(9, secondChildNode2, null);
            var secondChildNode4 = new Node(10, secondChildNode3, null);
            secondChildNode.next = secondChildNode2;
            secondChildNode2.next = secondChildNode3;
            secondChildNode3.next = secondChildNode4;

            var thirdChildNode2 = new Node(12, thirdChildNode, null);
            thirdChildNode.next = thirdChildNode2;

            var flattenResult = solution.Flatten(headNode);
            Assert.AreEqual(headNode3.next, secondChildNode);
            Assert.IsTrue(flattenResult.val == 1);
        }
    }
}
