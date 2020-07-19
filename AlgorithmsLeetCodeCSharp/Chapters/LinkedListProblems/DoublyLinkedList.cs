using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace AlgorithmsLeetCodeCSharp.Chapters.LinkedListProblems
{
    public class SetupDoublyLinkedListTests
	{
        public void ExecuteExampleFromProblem()
        {
            var doublyLinkedList = new DoublyLinkedList();
            /* 
             * ["MyLinkedList","addAtHead","addAtTail","addAtIndex","get","deleteAtIndex","get"]
             * [[],[1],[3],[1,2],[1],[1],[1]]
            */
            //first failing case
            doublyLinkedList.addAtHead(1);
            doublyLinkedList.addAtTail(3);
            doublyLinkedList.addAtIndex(1, 2);
            var firstResult = doublyLinkedList.get(1);
            doublyLinkedList.deleteAtIndex(1);
            if (firstResult != 2
                || doublyLinkedList.get(0) != 1
                || doublyLinkedList.get(1) != 3)
            {
                throw new System.Exception("Failed");
            }

            //second failing case
            doublyLinkedList = new DoublyLinkedList();
            doublyLinkedList.addAtHead(1);
            doublyLinkedList.deleteAtIndex(0);

            /*
             * ["MyLinkedList",
             * "addAtHead",
             * "addAtHead",
             * "addAtHead",
             * "addAtIndex",
             * "deleteAtIndex",
             * "addAtHead",
             * "addAtTail",
             * "get",
             * "addAtHead",
             * "addAtIndex",
             * "addAtHead"]
             * [[],[7],[2],[1],[3,0],[2],[6],[4],[4],[4],[5,0],[6]]
             * 
             * should be
             * 6 - 4 - 6 - 1 - 2 - 0 - 0 - 4
            */
            //third failing case
            doublyLinkedList = new DoublyLinkedList();
            doublyLinkedList.addAtHead(7);
            doublyLinkedList.addAtHead(2);
            doublyLinkedList.addAtHead(1);
            doublyLinkedList.addAtIndex(3, 0);
            doublyLinkedList.deleteAtIndex(2);
            doublyLinkedList.addAtHead(6);
            doublyLinkedList.addAtTail(4);
            var thirdResult = doublyLinkedList.get(4);
            doublyLinkedList.addAtHead(4);
            doublyLinkedList.addAtIndex(5, 0);
            doublyLinkedList.addAtHead(6);
            if (thirdResult != 4
                || doublyLinkedList.get(0) != 6
                || doublyLinkedList.get(7) != 4)
            {
                throw new System.Exception("Failed");
            }

            /*
             * ["MyLinkedList",
             * "addAtIndex",
             * "addAtIndex",
             * "addAtIndex",
             * "get"]
             * [[],[0,10],[0,20],[1,30],[0]]
             * 
             * should be
             * 20 - 30 - 10
            */
            //fourth failing case
            doublyLinkedList = new DoublyLinkedList();
            doublyLinkedList.addAtIndex(0, 10);
            doublyLinkedList.addAtIndex(0, 20);
            doublyLinkedList.addAtIndex(1, 30);
            var fourthResult = doublyLinkedList.get(0);
            if (fourthResult != 20
                || doublyLinkedList.get(1) != 30
                || doublyLinkedList.get(2) != 10)
            {
                throw new System.Exception("Failed");
            }

            /*
             * ["MyLinkedList",
             * "addAtHead",
             * "deleteAtIndex",
             * "addAtHead",
             * "addAtHead",
             * "addAtHead",
             * "addAtHead",
             * "addAtHead",
             * "addAtTail",
             * "get",
             * "deleteAtIndex",
             * "deleteAtIndex"]
             * [[],[2],[1],[2],[7],[3],[2],[5],[5],[5],[6],[4]]
             * 
             * should be
             * 5 - 3 - 2 - 7 - 2
             */
            //fifth failed case
            doublyLinkedList = new DoublyLinkedList();
            doublyLinkedList.addAtHead(2);
            doublyLinkedList.deleteAtIndex(1);
            doublyLinkedList.addAtHead(2);
            doublyLinkedList.addAtHead(7);
            doublyLinkedList.addAtHead(3);
            doublyLinkedList.addAtHead(2);
            doublyLinkedList.addAtHead(5);
            doublyLinkedList.addAtTail(5);
            var fifthResult = doublyLinkedList.get(5);
            doublyLinkedList.deleteAtIndex(6);
            doublyLinkedList.deleteAtIndex(4);
            if(fifthResult != 2
                || doublyLinkedList.get(0) != 5
                || doublyLinkedList.get(4) != 2)
            {
                throw new System.Exception("Failed");
            }

            /*
             * ["MyLinkedList",
             * "addAtHead",
             * "get",
             * "addAtIndex",
             * "addAtIndex",
             * "deleteAtIndex",
             * "addAtHead",
             * "addAtHead",
             * "deleteAtIndex",
             * "addAtIndex",
             * "addAtHead",
             * "deleteAtIndex"]
             * [[],[9],[1],[1,1],[1,7],[1],[7],[4],[1],[1,4],[2],[5]]
             * 
             * should be
             * 2 - 4 - 4 - 9 - 1
             */
            //sixth failed case
            doublyLinkedList = new DoublyLinkedList();
            doublyLinkedList.addAtHead(9);
            var sixResult = doublyLinkedList.get(1);
            doublyLinkedList.addAtIndex(1, 1);
            doublyLinkedList.addAtIndex(1, 7);
            doublyLinkedList.deleteAtIndex(1);
            doublyLinkedList.addAtHead(7);
            doublyLinkedList.addAtHead(4);
            doublyLinkedList.deleteAtIndex(1);
            doublyLinkedList.addAtIndex(1, 4);
            doublyLinkedList.addAtHead(2);
            doublyLinkedList.deleteAtIndex(5);
            if(sixResult != -1
                || doublyLinkedList.get(0) != 2
                || doublyLinkedList.get(4) != 1)
            {
                throw new System.Exception("Failed");
            }


            /*
             * ["MyLinkedList",
             * "addAtHead",
             * "get",
             * "addAtTail",
             * "deleteAtIndex",
             * "get",
             * "addAtTail",
             * "get",
             * "deleteAtIndex",
             * "addAtHead",
             * "addAtHead",
             * "addAtHead",
             * "addAtHead",
             * "addAtTail",
             * "addAtTail",
             * "addAtTail",
             * "deleteAtIndex",
             * "addAtIndex",
             * "addAtHead",
             * "addAtIndex",
             * "addAtTail",
             * "addAtHead",
             * "get",
             * "addAtHead",
             * "addAtTail",
             * "addAtHead",
             * "addAtHead",
             * "get",
             * "addAtHead",
             * "addAtHead",
             * "addAtTail",
             * "addAtHead",
             * "addAtTail",
             * "addAtTail",
             * "deleteAtIndex",
             * "addAtTail",
             * "deleteAtIndex",
             * "addAtHead",
             * "addAtTail",
             * "addAtIndex",
             * "addAtHead",
             * "addAtTail",
             * "addAtHead",
             * "deleteAtIndex",
             * "deleteAtIndex",
             * "addAtHead",
             * "addAtTail",
             * "addAtTail",
             * "addAtHead",
             * "addAtHead",
             * "get",
             * "deleteAtIndex",
             * "addAtHead",
             * "addAtTail",
             * "deleteAtIndex",
             * "addAtTail",
             * "addAtTail",
             * "addAtTail",
             * "addAtIndex",
             * "addAtIndex",
             * "get",
             * "addAtTail",
             * "addAtTail",
             * "addAtHead",
             * "addAtTail",
             * "addAtTail",
             * "addAtHead",
             * "get",
             * "addAtTail",
             * "get",
             * "deleteAtIndex",
             * "addAtHead",
             * "addAtHead",
             * "addAtHead",
             * "addAtIndex",
             * "addAtIndex",
             * "deleteAtIndex",
             * "get",
             * "addAtTail",
             * "addAtTail",
             * "addAtHead",
             * "get",
             * "addAtHead",
             * "addAtTail",
             * "addAtIndex",
             * "deleteAtIndex",
             * "addAtHead",
             * "addAtHead",
             * "addAtTail",
             * "get",
             * "deleteAtIndex",
             * "addAtHead",
             * "addAtTail",
             * "addAtTail",
             * "addAtHead",
             * "addAtHead",
             * "deleteAtIndex",
             * "get",
             * "addAtHead",
             * "addAtTail",
             * "addAtHead",
             * "addAtTail"]
             * [[],[24],[1],[18],[1],[1],[30],[2],[1],[3],[3],[33],[97],[43],[12],[10],[1],[1,56],[30],[8,83],[57],[74],[5],[98],[72],[34],[61],[6],[70],[24],[91],[99],[13],[10],[17],[84],[16],[73],[88],[4,19],[59],[41],[57],[10],[18],[2],[12],[25],[1],[77],[1],[7],[34],[87],[13],[4],[12],[11],[10,92],[21,55],[11],[38],[31],[45],[4],[21],[38],[4],[88],[12],[22],[40],[22],[23],[13,96],[24,50],[8],[14],[25],[53],[42],[6],[58],[55],[18,72],[13],[30],[97],[59],[47],[24],[37],[26],[31],[93],[66],[11],[43],[70],[36],[31],[28]]
            */
            doublyLinkedList = new DoublyLinkedList();
            var sixMethods = new string[] {
                "DoublyLinkedList","addAtHead","get","addAtTail","deleteAtIndex","get","addAtTail","get","deleteAtIndex","addAtHead","addAtHead","addAtHead","addAtHead","addAtTail","addAtTail","addAtTail","deleteAtIndex","addAtIndex","addAtHead","addAtIndex","addAtTail","addAtHead","get","addAtHead","addAtTail","addAtHead","addAtHead","get","addAtHead","addAtHead","addAtTail","addAtHead","addAtTail","addAtTail","deleteAtIndex","addAtTail","deleteAtIndex","addAtHead","addAtTail","addAtIndex","addAtHead","addAtTail","addAtHead","deleteAtIndex","deleteAtIndex","addAtHead","addAtTail","addAtTail","addAtHead","addAtHead","get","deleteAtIndex","addAtHead","addAtTail","deleteAtIndex","addAtTail","addAtTail","addAtTail","addAtIndex","addAtIndex","get","addAtTail","addAtTail","addAtHead","addAtTail","addAtTail","addAtHead","get","addAtTail","get","deleteAtIndex","addAtHead","addAtHead","addAtHead","addAtIndex","addAtIndex","deleteAtIndex","get","addAtTail","addAtTail","addAtHead","get","addAtHead","addAtTail","addAtIndex","deleteAtIndex","addAtHead","addAtHead","addAtTail","get","deleteAtIndex","addAtHead","addAtTail","addAtTail","addAtHead","addAtHead","deleteAtIndex","get","addAtHead","addAtTail","addAtHead","addAtTail"
            };
            var sixParamethers = @"[[],[24],[1],[18],[1],[1],[30],[2],[1],[3],[3],[33],[97],[43],[12],[10],[1],[1,56],[30],[8,83],[57],[74],[5],[98],[72],[34],[61],[6],[70],[24],[91],[99],[13],[10],[17],[84],[16],[73],[88],[4,19],[59],[41],[57],[10],[18],[2],[12],[25],[1],[77],[1],[7],[34],[87],[13],[4],[12],[11],[10,92],[21,55],[11],[38],[31],[45],[4],[21],[38],[4],[88],[12],[22],[40],[22],[23],[13,96],[24,50],[8],[14],[25],[53],[42],[6],[58],[55],[18,72],[13],[30],[97],[59],[47],[24],[37],[26],[31],[93],[66],[11],[43],[70],[36],[31],[28]]";
            ParseWithReflection(doublyLinkedList, sixMethods, sixParamethers);
        }

        private void ParseWithReflection(DoublyLinkedList doublyLinkedList, string[] methods, string paramethersJson)
		{
            //var paramethersJson = @"[[],[84],[2],[39],[3],[1],[42],[1,80],[14],[1],[53],[98],[19],[12],[2],[16],[33],[4,17],[6,8],[37],[43],[11],[80],[31],[13,23],[17],[4],[10,0],[21],[73],[22],[24,37],[14],[97],[8],[6],[17],[50],[28],[76],[79],[18],[30],[5],[9],[83],[3],[40],[26],[20,90],[30],[40],[56],[15,23],[51],[21],[26],[83],[30],[12],[8],[4],[20],[45],[10],[56],[18],[33],[2],[70],[57],[31,24],[16,92],[40],[23],[26],[1],[92],[3,78],[42],[18],[39,9],[13],[33,17],[51],[18,95],[18,33],[80],[21],[7],[17,46],[33],[60],[26],[4],[9],[45],[38],[95],[78],[54],[42,86]]";
			var paramethers = JsonConvert.DeserializeObject<List<int[]>>(paramethersJson);

			Type thisType = doublyLinkedList.GetType();
			int index = 0;
			foreach (var method in methods)
			{
				if (index == 0)
				{
					index++;
					continue;
				}

				MethodInfo theMethod = thisType.GetMethod(method);

				object firstParam = paramethers[index][0];
				if (paramethers[index].Length > 1)
				{
					object? secondParam = paramethers[index]?[1];
					var obj = new object?[2] { firstParam, secondParam };
					theMethod.Invoke(doublyLinkedList, obj);
				}
				else
				{
					var obj = new object?[1] { firstParam };
					var result = theMethod.Invoke(doublyLinkedList, obj);
					if (result != null)
					{
						Console.WriteLine(result);
					}
				}

				index++;
			}
		}
    }


	/** Initialize your data structure here. */
    public class DoublyLinkedList
	{
		public class DoublyNode
		{
			public int val { get; set; }
			public DoublyNode next { get; set; }
			public DoublyNode prev { get; set; }

            public DoublyNode(int val)
			{
                this.val = val;
			}
		}

		public DoublyNode head = null;
		public DoublyNode tail = null;
		int length = 0;

        /** Get the value of the index-th node in the linked list. 
         * If the index is invalid, return -1. */
        public int get(int index)
        {
            int countDown = 0;
            var counter = head;
            while (countDown != index && counter != null)
            {
                countDown++;
                counter = counter.next;
            }

            if (counter == null)
            {
                return -1;
            }

            return counter.val;
        }

        /** Add a node of value val before the first element of the linked list. After the insertion, 
         * the new node will be the first node of the linked list. */
        public void addAtHead(int val)
        {
            var newHead = new DoublyNode(val);
            if (head == null)
			{
                tail = newHead;
                head = newHead;
                length++;
                return;
			}

            var oldHead = head;
            head = newHead;
            newHead.next = oldHead;
            newHead.prev = null;
            oldHead.prev = newHead;
            length++;
        }

        /** Append a node of value val to the last element of the linked list. */
        public void addAtTail(int val)
        {
            var newTail = new DoublyNode(val);
            if (tail == null)
			{
                tail = newTail;
                head = newTail;
                length++;
                return;
			}

            var oldTail = tail;
            tail = newTail;
            oldTail.next = newTail;
            tail.prev = oldTail;
            tail.next = null;
            length++;
        }

        /** Add a node of value val before the index-th node in the linked list. 
         * If index equals to the length of linked list, the node will be appended to the end of linked list.
         * If index is greater than the length, the node will not be inserted. */
        public void addAtIndex(int index, int val)
        {
            if(index > length)
			{
                return;
			}

            if(index == 0)
			{
                addAtHead(val);
                return;
            }

            var newNode = new DoublyNode(val);
            if (index == length)
            {
                addAtTail(val);
                return;
            }

            int countDown = 0;
            var counter = head;
            while(countDown != index && counter != null)
			{
                countDown++;
                counter = counter.next;
			}

            if (counter == null)
            {
                return;
            }

            var prev = counter.prev;
            newNode.prev = prev;
            newNode.next = counter;
            prev.next = newNode;
            counter.prev = newNode;
            length++;
        }

        /** Delete the index-th node in the linked list, if the index is valid. */
        public void deleteAtIndex(int index)
        {
            if (index >= length)
            {
                return;
            }

            if(index == 0)
			{
                var nextHead = head.next;
                head = nextHead;
                if(head == null)
				{
                    return;
				}

                head.prev = null;
                length--;
                return;
			}

            var prev = tail.prev;
            if (index == length - 1)
            {
                tail = prev;
                if(tail == null)
				{
                    return;
				}

                tail.next = null;
                length--;
                return;
            }

            int countDown = 0;
            var counter = head;
            while (countDown != index && counter != null)
            {
                countDown++;
                counter = counter.next;
            }

            if(counter == null)
			{
                return;
			}

            prev = counter.prev;
            var next = counter.next;
            if(prev != null)
            {
                prev.next = next;
            }
            next.prev = prev;
            length--;
        }
    }
}
