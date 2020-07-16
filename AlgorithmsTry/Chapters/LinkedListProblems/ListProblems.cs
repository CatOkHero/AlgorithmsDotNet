using System.Collections.Generic;

namespace AlgorithmsLeetCode.Chapters.LinkedListProblems
{
	public class ListProblems
	{
		//   Reverse Linked List
		public ListNode ReverseList(ListNode head)
		{
			// 			if(head == null || head.next == null)
			// 			{
			// 				return head;
			// 			}

			// 			ListNode dummyNode = new ListNode(head.val);
			// 			ListNode listNode = head.next;
			// 			while (listNode != null)
			// 			{
			// 				ListNode temp = dummyNode;
			// 				dummyNode = new ListNode(listNode.val);
			// 				dummyNode.next = temp;
			// 				listNode = listNode.next;
			// 			}

			//			return dummyNode;
			if (head == null || head.next == null)
			{
				return head;
			}

			ListNode dummyNode = null;
			ListNode listNode = head;
			while (listNode != null)
			{
				ListNode temp = listNode.next;
				listNode.next = dummyNode;
				dummyNode = listNode;
				listNode = temp;
			}

			return dummyNode;
		}

		//   Remove Nth Node From End of List
		public ListNode RemoveNthFromEnd(ListNode head, int n)
		{
			if(head == null || head.next == null)
			{
				return null;
			}

			int steps = n;
			int length = 0;
			int slowRunnerLength = 0;
			ListNode slowRunner = head;
			ListNode fastRuner = head;
			while(fastRuner != null)
			{
				fastRuner = fastRuner.next;
				length++;
				if (steps > 0)
				{
					steps--;
				} else if(steps == 0)
				{
					slowRunner = slowRunner.next;
					steps = n;
					slowRunnerLength++;
				}
			}

			int countDown = length - n - 1;
			while (countDown > slowRunnerLength)
			{
				slowRunner = slowRunner.next;
				slowRunnerLength++;
			}

			if (countDown < 0)
			{
				return head.next;
			}

			if (countDown < slowRunnerLength)
			{
				head.next = head?.next?.next;
				return head;
			}

			slowRunner.next = slowRunner?.next?.next;
			return head;
		}

		//   Intersection of Two Linked Lists
		public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
		{
			var itA = headA;
			var itB = headB;

			while (itA != itB)
			{
				itA = itA != null ? itA.next : headB;
				itB = itB != null ? itB.next : headA;
			}

			return itA;
		}

		//public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
		//{
		//	if(headA == null || headB == null)
		//	{
		//		return null;
		//	}

		//	int lengthHeadA = 1;
		//	int lengthHeadB = 1;
		//	ListNode lastANodeElement = null;
		//	ListNode lastBNodeElement = null;
		//	ListNode aNode = headA;
		//	ListNode bNode = headB;
		//	while (aNode?.next != null || bNode?.next != null)
		//	{
		//		if (bNode.next != null)
		//		{
		//			bNode = bNode.next;
		//			lengthHeadB++;
		//		}

		//		if (aNode.next != null)
		//		{
		//			aNode = aNode.next;
		//			lengthHeadA++;
		//		}

		//		if (aNode.next == null)
		//		{
		//			lastANodeElement = aNode;
		//		}

		//		if (bNode.next == null)
		//		{
		//			lastBNodeElement = bNode;
		//		}
		//	}

		//	if (lastANodeElement != lastBNodeElement)
		//	{
		//		return null;
		//	}

		//	if (lengthHeadA == lengthHeadB)
		//	{
		//		bNode = headB;
		//		aNode = headA;
		//	}
		//	else
		//	{
		//		int cuttedLength = 0;
		//		if (lengthHeadA > lengthHeadB)
		//		{
		//			cuttedLength = lengthHeadA - lengthHeadB;
		//			//reusing the same variable to iterate over all nodes
		//			bNode = headB;
		//			aNode = headA;
		//			while (cuttedLength != 0)
		//			{
		//				aNode = aNode.next;
		//				cuttedLength--;
		//			}

		//		}
		//		else
		//		{
		//			cuttedLength = lengthHeadB - lengthHeadA;
		//			//reusing the same variable to iterate over all nodes
		//			bNode = headB;
		//			aNode = headA;
		//			while (cuttedLength != 0)
		//			{
		//				bNode = bNode.next;
		//				cuttedLength--;
		//			}
		//		}
		//	}

		//	while (bNode != aNode)
		//	{
		//		bNode = bNode.next;
		//		aNode = aNode.next;
		//	}

		//	return aNode;
		//}

		/*
		 *	ListNode firstNode = new ListNode(3);
			ListNode secondNode = new ListNode(2);
			ListNode thirdNode = new ListNode(0);
			ListNode fourthNode = new ListNode(-4);
			firstNode.next = secondNode;
			secondNode.next = thirdNode;
			thirdNode.next = fourthNode;
			fourthNode.next = secondNode;

			Console.WriteLine(DetectCycle(firstNode).val);
		*/

		// Linked List Cycle II
		public ListNode DetectCycle(ListNode head)
		{
			if (head == null || head.next == null)
			{
				return null;
			}

			ListNode slowRunner = head;
			ListNode fastRunner = head?.next;
			while (slowRunner != fastRunner)
			{
				if (fastRunner == null || fastRunner.next == null)
				{
					return null;
				}

				slowRunner = slowRunner?.next;
				fastRunner = fastRunner?.next?.next;
			}

			slowRunner = head;
			fastRunner = fastRunner.next;
			while (slowRunner != fastRunner)
			{
				slowRunner = slowRunner.next;
				fastRunner = fastRunner.next;
			}

			return slowRunner;
		}

		// Linked List Cycle
		public static bool HasCycle(ListNode head)
		{
			if (head == null || head.next == null)
			{
				return false;
			}

			ListNode slowRunner = head;
			ListNode fastRunner = head?.next;
			while (slowRunner != fastRunner)
			{
				if (fastRunner == null || fastRunner.next == null)
				{
					return false;
				}

				slowRunner = slowRunner?.next;
				fastRunner = fastRunner?.next?.next;
			}

			return true;
		}

		public class ListNode
		{
			public int val;
			public ListNode next;
			public ListNode(int x)
			{
				val = x;
				next = null;
			}
		}
	}
}
