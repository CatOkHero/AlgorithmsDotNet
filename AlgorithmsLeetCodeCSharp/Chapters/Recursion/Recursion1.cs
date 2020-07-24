using System;
using System.Collections.Generic;

namespace AlgorithmsLeetCode.Chapters.Recursion
{
	public class Recursion1
	{
        //  K-th Symbol in Grammar
        public int KthGrammar(int N, int K)
        { 
            if(N == 1)
			{
                return 0;
			}

            int length = (int)Math.Pow(2, N - 1) / 2;

            if(K > length)
			{
                K = K - length;
                return Convert.ToInt32(RecursionGrammar(true, K, length));
			}

            return Convert.ToInt32(RecursionGrammar(false, K, length));
        }

        private bool RecursionGrammar(bool root, int K, int length)
        {
            if(K == 1)
			{
                return root;
			}

            if(K == 2)
			{
                return !root;
			}

            length = length / 2;
            if(K > length)
            {
                K = K - length;
                return RecursionGrammar(!root, K, length);
            }

            return RecursionGrammar(root, K, length);
        }

        //  Merge Two Sorted Lists
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;
            if (l1.val <= l2.val)
            {
                l1.next = MergeTwoLists(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = MergeTwoLists(l1, l2.next);
                return l2;
            }
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

		//   Pow(x, n)
		public double MyPow(double x, int n)
        {
            if (n == 0)
            {
                return 1;
            }

            if (n == 1)
            {
                return x;
            }

            if (n > 0)
            {
                return HelperRecursion(x, n);
            }
            else
            {

                return 1 / HelperRecursion(x, n);
            }
        }

        private double HelperRecursion(double x, int n)
        {
            if (n == 0)
            {
                return 1;
            }

            var returnVal = HelperRecursion(x, n / 2);
            if (n % 2 == 0)
            {
                return returnVal * returnVal;
            }

            return returnVal * returnVal * x;
        }

        //   Maximum Depth of Binary Tree
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int maxLeft = MaxDepth(root.left) + 1;
            int maxRight = MaxDepth(root.right) + 1;
            return Math.Max(maxRight, maxLeft);
        }

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


		//   Fibonacci Number
		private Dictionary<int, int> cache = new Dictionary<int, int>();
        public int Fib(int N)
        {
            if (cache.ContainsKey(N))
            {
                return cache[N];
            }

            if (N < 2)
            {
                return N;
            }

            int result = Fib(N - 1) + Fib(N - 2);
            cache.Add(N, result);
            return result;
        }
    }
}
