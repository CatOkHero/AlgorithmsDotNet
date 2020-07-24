namespace AlgorithmsLeetCodeCSharp.Chapters.LinkedListProblems
{
    public class LinkedListConclusion
    {
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
