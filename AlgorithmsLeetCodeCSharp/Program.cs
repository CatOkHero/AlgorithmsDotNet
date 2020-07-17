using AlgorithmsLeetCode.Chapters.LinkedListProblems;
using AlgorithmsLeetCode.Concurency;
using AlgorithmsLeetCode.Contests;
using AlgorithmsLeetCode.Problems;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static AlgorithmsLeetCode.Chapters.LinkedListProblems.ListProblems;

namespace AlgorithmsLeetCode
{
	class Program
	{
		static void Main(string[] args)
		{
			var nums = new int[] { 1 };
			var index = new int[] { 2 };
			//var nums = new int[4][] { 
			//	new int[]{ 10, 20 }, 
			//	new int[]{ 30, 200 }, 
			//	new int[]{ 400, 50 }, 
			//	new int[]{ 30, 20 } 
			//};
			var easyProblems = new EasyProblems();
			//var result = easyProblems.CreateTargetArray(nums,index);

			var mediumProblems = new MediumProblems();
			//var result = mediumProblems.ChangeRecursion(5, nums);

			var juneContest = new JuneLeetCodingChallenge();
			//var result = juneContest.TopKFrequent(nums, 2);

			//var tree = new Recursion.TreeLiNode(3, new Recursion.TreeNode(9, new Recursion.TreeNode(5, new Recursion.TreeNode(4, new Recursion.TreeNode(2))), null), new Recursion.TreeNode(20, new Recursion.TreeNode(15), new Recursion.TreeNode(7)));
			//var l1 = new Recursion.ListNode(1, new Recursion.ListNode(3, new Recursion.ListNode(5)));
			//var l2 = new Recursion.ListNode(2, new Recursion.ListNode(4, new Recursion.ListNode(6)));
			//var chapters = new Recursion();
			//var result = chapters.KthGrammar(1, 1);

			//ListNode firstNode = new ListNode(3);
			//ListNode secondNode = new ListNode(2);
			//ListNode thirdNode = new ListNode(0);
			//ListNode fourthNode = new ListNode(-4);
			//firstNode.next = secondNode;
			//secondNode.next = thirdNode;
			//thirdNode.next = fourthNode;
			////third2Node.next = fourthNode;
			//fourthNode.next = secondNode;

			//var listChapter = new ListProblems();
			//var result = listChapter.DetectCycle(firstNode);

			ListNode a1 = new ListNode(1);
			ListNode a2 = new ListNode(2);
			ListNode a3 = new ListNode(3);
			ListNode shared1 = new ListNode(4);
			ListNode shared2 = new ListNode(5);
			ListNode shared3 = new ListNode(6);
			////ListNode b1 = new ListNode(6);
			////ListNode b2 = new ListNode(7);
			a1.next = a2;
			a2.next = a3;
			a3.next = shared1;
			shared1.next = shared2;
			shared2.next = shared3;
			//b1.next = b2;
			//b2.next = shared1;

			var linkedListChapter = new ListProblems();
			var resultNode = linkedListChapter.OddEvenList(a1);

			//	var concurency = new PrintOrder();
			//	Task.Run(() => concurency.Second(() => Console.WriteLine("second")));
			//	Task.Run(() => concurency.Third(() => Console.WriteLine("third")));
			//	Task.Run(() => concurency.First(() => Console.WriteLine("first")));
			//});

			//	task.Wait();

			//	Task.Delay(100000).Wait();
		}
	}
}
