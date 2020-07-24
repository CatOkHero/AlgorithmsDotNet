using AlgorithmsLeetCodeCSharp.Chapters.LinkedListProblems;
using System;
using System.Collections.Generic;

namespace AlgorithmsLeetCode.Chapters.LinkedListProblems
{

	public class ListProblems
	{
		// https://leetcode.com/explore/learn/card/linked-list/213/conclusion/1229/
		//   Copy List with Random Pointer

		public NodeWithRadom CopyRandomList(NodeWithRadom head)
		{
			if(head == null)
			{
				return head;
			}

			var map = new Dictionary<NodeWithRadom, NodeWithRadom>();
			var current = head;
			while (current != null)
			{
				map[current] = new NodeWithRadom(current.val);
				current = current.next;
			}

			current = head;
			while (current != null)
			{
				map[current].next = current.next != null ? map[current.next] : null;
				map[current].random = current.random != null ? map[current.random] : null;
				current = current.next;
			}

			return map[head];


			//IDictionary<int, KeyValuePair<Node, int?>> dictionary = new Dictionary<int, KeyValuePair<Node, int?>>();
			//Node curr = head;
			//int index = 0;
			//while (curr != null)
			//{
			//	int? randomIndex = null;
			//	if (curr.random != null)
			//	{
			//		Node newCurr = head;
			//		randomIndex = 0;
			//		while (newCurr != curr.random)
			//		{
			//			randomIndex++;
			//			newCurr = newCurr.next;
			//		}
			//	}

			//	dictionary.Add(index, KeyValuePair.Create(new Node(curr.val), randomIndex));
			//	curr = curr.next;
			//	index++;
			//}

			//Node newHead = dictionary[0].Key;
			//if (dictionary[0].Value != null)
			//{
			//	var randomIndex = dictionary[0].Value.Value;
			//	newHead.random = dictionary.FirstOrDefault(item => item.Key == randomIndex).Value.Key;
			//}

			//Node currNewHead = newHead;
			//for (int i = 1; i < dictionary.Count(); i++)
			//{
			//	currNewHead.next = dictionary[i].Key;
			//	currNewHead = currNewHead.next;
			//	if (dictionary[i].Value != null)
			//	{
			//		var randomIndex = dictionary[i].Value.Value;
			//		currNewHead.random = dictionary.FirstOrDefault(item => item.Key == randomIndex).Value.Key;
			//	}
			//}

			//return newHead;
		}

		public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
		{
			var curr1 = l1;
			var curr2 = l2;
			int sum = curr1.val + curr2.val;
			// 10 because in a sum of two 1 digit numbers there couldn't 
			// be more then 20 (max is 18)
			// 9 + 9 = 18
			// 8 + 8 = 16
			// so everywhere we have 18 - 10 = 8 (that would be the answer)
			int? change = sum >= 10 ? sum - 10 : default(int?);
			var listNode = new ListNode(change ?? sum);
			var currListNode = listNode;
			curr1 = curr1.next;
			curr2 = curr2.next;
			while (curr1 != null || curr2 != null)
			{
				int? newSum = (curr1?.val ?? 0) + (curr2?.val ?? 0) + (change == null ? 0 : 1);
				change = newSum >= 10 ? newSum - 10 : default(int?);
				currListNode.next = new ListNode(change ?? (newSum ?? 0));
				currListNode = currListNode.next;

				if (curr1 != null)
				{
					curr1 = curr1.next;
				}

				if (curr2 != null)
				{
					curr2 = curr2.next;
				}
			}

			if(change != null)
			{
				currListNode.next = new ListNode(1);
			}

			return listNode;
		}

		//  Palindrome Linked List
		// O(n)
		public bool IsPalindrome(ListNode head)
		{
			ListNode fast = head;
			ListNode slow = head;

			while (fast != null && fast.next != null)
			{
				fast = fast.next.next;
				slow = slow.next;
			}

			fast = head;
			slow = ReverseNode(slow);

			while (slow != null)
			{
				if(fast.val != slow.val)
				{
					return false;
				}

				fast = fast.next;
				slow = slow.next;
			}

			return true;

		}

		private ListNode ReverseNode(ListNode listNode)
		{
			ListNode prev = null;
			ListNode curr = listNode;
			while(curr != null)
			{
				ListNode next = curr.next;
				curr.next = prev;
				prev = curr;
				curr = next;
			}

			return prev;
		}

		// O(n^2)
		//	if(head == null)
		//	{
		//		return true;
		//	}

		//	int length = 0;
		//	ListNode curr = head;
		//	while (curr != null)
		//	{
		//		curr = curr.next;
		//		length++;
		//	}

		//	int index = 0;
		//	curr = head;
		//	while (curr != null)
		//	{
		//		if(index > length / 2 + 1)
		//		{
		//			break;
		//		}

		//		ListNode palindrom = GetNthNode(length, index, curr);
		//		if (palindrom.val == curr.val)
		//		{
		//			curr = curr.next;
		//			index += 2;
		//		}
		//		else
		//		{
		//			return false;
		//		}
		//	}

		//	return true;
		//}

		//private ListNode GetNthNode(int length, int index, ListNode head)
		//{
		//	int shouldGoThrought = length - index - 1;
		//	ListNode curr = head;
		//	while (shouldGoThrought > 0)
		//	{
		//		curr = curr.next;
		//		shouldGoThrought--;
		//	}

		//	return curr;
		//}

		// 83. Remove Duplicates from Sorted List
		// O(n)
		public ListNode DeleteDuplicates(ListNode head)
		{
			ListNode slow = head;
			ListNode fast = head.next;
			while (fast != null)
			{
				if (slow.val == fast.val)
				{
					fast = fast.next;
					slow.next = fast;
				}
				else
				{
					slow = slow.next;
					fast = fast.next;
				}
			}

			return head;
		}

		// 876. Middle of the Linked List
		public ListNode MiddleNode(ListNode head)
		{
			ListNode fast = head;
			ListNode slow = head;
			while(fast != null && fast.next != null)
			{
				fast = fast.next.next;
				slow = slow.next;
			}

			return slow;

			//if (head == null || head.next == null)
			//{
			//	return head;
			//}

			//int length = 0;
			//ListNode curr = head;
			//while (curr != null)
			//{
			//	length++;
			//	curr = curr.next;
			//}

			//curr = head;
			//int index = length / 2;
			//while (index != 0)
			//{
			//	curr = curr.next;
			//	index--;
			//}

			//return curr;
		}

		// 1290. Convert Binary Number in a Linked List to Integer
		public int GetDecimalValue(ListNode head)
		{
			int num = 0;
			while (head != null)
			{
				num = (num * 2) + head.val;
				head = head.next;
			}
			return num;
			//if(head == null)
			//{
			//	return 0;
			//}

			//StringBuilder stringBuilder = new StringBuilder();
			//while(head != null)
			//{
			//	stringBuilder.Append(head.val);
			//	head = head.next;
			//}

			//return Convert.ToInt32(stringBuilder.ToString(), 2);
		}


		//  Odd Even Linked List
		public ListNode OddEvenList(ListNode head)
		{
			if(head == null)
			{
				return head;
			}

			ListNode evenHead = head.next;
			ListNode odd = head;
			ListNode even = evenHead;

			while (even != null && even.next != null)
			{
				odd.next = even.next;
				odd = even.next;
				even.next = odd.next;
				even = even.next;
			}
			odd.next = evenHead;

			return head;

			//int length = 0;
			//ListNode current = head;
			//while (current != null)
			//{
			//	current = current.next;
			//	length++;
			//}

			//if (length < 3)
			//{
			//	return head;
			//}

			//ListNode oddListNode = head;
			//ListNode oddHead = head;
			//ListNode evenHead = head.next;
			//ListNode evenListNode = head.next;
			//int index = 1;
			//ListNode curr = head.next.next;
			//while (curr != null && index != length)
			//{
			//	if (index % 2 == 0)
			//	{
			//		evenListNode.next = curr;
			//		evenListNode = evenListNode.next;
			//	}
			//	else
			//	{
			//		oddListNode.next = curr;
			//		oddListNode = oddListNode.next;
			//	}

			//	index++;
			//	curr = curr.next;
			//}

			//evenListNode.next = null;

			//oddListNode.next = evenHead;
			//return oddHead;
		}

		//  Remove Linked List Elements
		public ListNode RemoveElements(ListNode head, int val)
		{
			if(head == null)
			{
				return head;
			}

			if (head.val == val)
				return RemoveElements(head.next, val);

			head.next = RemoveElements(head.next, val);
			return head;
		}

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
			public ListNode(int val = 0, ListNode next = null)
			{
				this.val = val;
				this.next = next;
			}
		}
	}
}
