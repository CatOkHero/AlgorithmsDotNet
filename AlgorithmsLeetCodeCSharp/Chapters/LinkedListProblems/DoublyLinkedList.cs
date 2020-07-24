namespace AlgorithmsLeetCodeCSharp.Chapters.LinkedListProblems
{
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

            var newNode = new DoublyNode(val);
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
