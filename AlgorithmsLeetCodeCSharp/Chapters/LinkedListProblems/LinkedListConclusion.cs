using static AlgorithmsLeetCodeCSharp.Chapters.LinkedListProblems.LinkedListConclusion;

namespace AlgorithmsLeetCodeCSharp.Chapters.LinkedListProblems
{
	public class LinkedListConclusionTests
	{
        public void ExecuteTests()
        {
            var solution = new LinkedListConclusion();
            var listNode = new ListNode(0, new ListNode(1, new ListNode(2)));
            var rotateRight1 = solution.RotateRight(listNode, 4);
            if(rotateRight1.val != 2)
			{
                throw new System.Exception("Failed");
			}

            listNode = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            var rotateRight2 = solution.RotateRight(listNode, 2);
            if(rotateRight2.val != 4)
			{
                throw new System.Exception("Failed");
            }

            listNode = new ListNode(1, new ListNode(2));
            var rotateRight3 = solution.RotateRight(listNode, 1);
            if (rotateRight3.val != 2)
            {
                throw new System.Exception("Failed");
            }

            var headNode = new Node(1, null,  null);
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
            if(headNode3.next != secondChildNode)
			{
                throw new System.Exception("Failed");
			}
        }
	}


    public class LinkedListConclusion
    {
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

        public class Node
        {
            public int val;
            public Node prev;
            public Node next;
            public Node child;

            public Node(int val, Node prev,  Node child)
			{
                this.val = val;
                this.prev = prev;
                this.child = child;
			}
        }

        // https://leetcode.com/explore/learn/card/linked-list/213/conclusion/1295/
        // Rotate List
        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null || head.next == null || k == 0)
            {
                return head;
            }

            int length = 0;
            ListNode curr = head;
            while (curr != null)
            {
                curr = curr.next;
                length++;
            }

            int newK = 0;
            if (k > length)
            {
                newK = k % length;
            }
            else
            {
                newK = k;
            }

            if (newK % length == 0)
            {
                return head;
            }

            if (length == 2)
            {
                var temp = head;
                head = head.next;
                head.next = temp;
                temp.next = null;
                return head;
            }

            int countDown = length - newK - 1;
            ListNode nodeToSwap = head;
            ListNode newHeadToSwap = head;
            ListNode nodeToSwapEnd = null;
            ListNode nodeToSwapStart = null;
            bool onlyFirstToSwap = false;
            if (countDown == 0)
            {
                onlyFirstToSwap = true;
                countDown = length - newK; 
            }

            while (countDown != 0)
            {
                countDown--;
                nodeToSwap = nodeToSwap.next;
            }

            nodeToSwapStart = nodeToSwap.next;
            nodeToSwapEnd = nodeToSwap.next;
            while (nodeToSwapEnd?.next != null)
            {
                nodeToSwapEnd = nodeToSwapEnd.next;
            }

            nodeToSwapEnd.next = newHeadToSwap;
            if(onlyFirstToSwap)
            {
                newHeadToSwap.next = null;
            } else
            {
                nodeToSwap.next = null;
            }

            return onlyFirstToSwap ? nodeToSwap : nodeToSwapStart;
        }

        // https://leetcode.com/explore/learn/card/linked-list/213/conclusion/1225/
        // Flatten a Multilevel Doubly Linked List
        public Node Flatten(Node head)
        {
            Node currHead = head;
            Node curr = head;
            while (curr != null)
            {
                if (curr.child != null)
                {
                    var currHeadOld = currHead;
                    var next = curr.next;
                    if (currHead == null)
                    {
                        currHead = Flatten(curr.child);
                    }
                    else
                    {
                        currHead.next = Flatten(curr.child);
                    }
                    var firstChild = currHead.next;
                    firstChild.prev = currHead;
                    var toNull = currHead;
                    while (toNull?.next != null)
                    {
                        toNull = toNull?.next;
                    }

                    var lastChild = toNull;
                    toNull.next = next;
                    currHead = toNull.next;
                    if (next != null)
                    {
                        next.prev = lastChild;
                    }
                    curr = next;
                    currHeadOld.child = null;
                }
                else
                {
                    currHead.next = curr.next;
                    if (currHead.next != null)
                    {
                        var firstChild = currHead.next;
                        firstChild.prev = currHead;
                    }

                    currHead = currHead.next;
                    curr = curr.next;
                }

            }

            return head;


            //       Node currHead = head;
            //       Node curr = head;
            //       while (curr != null)
            //       {
            //           if (curr.child != null)
            //           {
            //               var next = curr.next;
            //               currHead.next = Flatten(curr.child);
            //               currHead.child = null;
            //               var firstChild = currHead.next;
            //               firstChild.prev = currHead;
            //               var toNull = currHead;
            //while (toNull?.next != null)
            //{
            //                   toNull = toNull?.next;
            //}

            //               var lastChild = toNull;
            //               toNull.next = next;
            //               currHead = toNull.next;
            //               next.prev = lastChild;
            //               curr = next;
            //           }
            //           else
            //           {
            //               currHead.next = curr.next;
            //               if(currHead.next != null)
            //               {
            //                   var firstChild = currHead.next;
            //                   firstChild.prev = currHead;
            //               }

            //               currHead = currHead.next;
            //               curr = curr.next;
            //           }

            //       }

            //       return head;
        }
    }
}
