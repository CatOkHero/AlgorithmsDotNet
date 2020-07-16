using System;

namespace AlgorithmsLeetCode.Chapters.MyLinkedList
{

	// Tries with LinkedList

	//var myLinkedList = new MyLinkedList();

	//var methods = new string[] { "MyLinkedList", "addAtHead", "addAtTail", "addAtTail", "get", "get", "addAtTail", "addAtIndex", "addAtHead", "addAtHead", "addAtTail", "addAtTail", "addAtTail", "addAtTail", "get", "addAtHead", "addAtHead", "addAtIndex", "addAtIndex", "addAtHead", "addAtTail", "deleteAtIndex", "addAtHead", "addAtHead", "addAtIndex", "addAtTail", "get", "addAtIndex", "addAtTail", "addAtHead", "addAtHead", "addAtIndex", "addAtTail", "addAtHead", "addAtHead", "get", "deleteAtIndex", "addAtTail", "addAtTail", "addAtHead", "addAtTail", "get", "deleteAtIndex", "addAtTail", "addAtHead", "addAtTail", "deleteAtIndex", "addAtTail", "deleteAtIndex", "addAtIndex", "deleteAtIndex", "addAtTail", "addAtHead", "addAtIndex", "addAtHead", "addAtHead", "get", "addAtHead", "get", "addAtHead", "deleteAtIndex", "get", "addAtHead", "addAtTail", "get", "addAtHead", "get", "addAtTail", "get", "addAtTail", "addAtHead", "addAtIndex", "addAtIndex", "addAtHead", "addAtHead", "deleteAtIndex", "get", "addAtHead", "addAtIndex", "addAtTail", "get", "addAtIndex", "get", "addAtIndex", "get", "addAtIndex", "addAtIndex", "addAtHead", "addAtHead", "addAtTail", "addAtIndex", "get", "addAtHead", "addAtTail", "addAtTail", "addAtHead", "get", "addAtTail", "addAtHead", "addAtTail", "get", "addAtIndex" };

	//var paramethersJson = @"[[],[84],[2],[39],[3],[1],[42],[1,80],[14],[1],[53],[98],[19],[12],[2],[16],[33],[4,17],[6,8],[37],[43],[11],[80],[31],[13,23],[17],[4],[10,0],[21],[73],[22],[24,37],[14],[97],[8],[6],[17],[50],[28],[76],[79],[18],[30],[5],[9],[83],[3],[40],[26],[20,90],[30],[40],[56],[15,23],[51],[21],[26],[83],[30],[12],[8],[4],[20],[45],[10],[56],[18],[33],[2],[70],[57],[31,24],[16,92],[40],[23],[26],[1],[92],[3,78],[42],[18],[39,9],[13],[33,17],[51],[18,95],[18,33],[80],[21],[7],[17,46],[33],[60],[26],[4],[9],[45],[38],[95],[78],[54],[42,86]]";
	//var paramethers = JsonConvert.DeserializeObject<List<int[]>>(paramethersJson);

	//Type thisType = myLinkedList.GetType();
	//int index = 0;
	//foreach (var method in methods)
	//{
	//	if(index == 0)
	//	{
	//		index++;
	//		continue;
	//	}

	//	MethodInfo theMethod = thisType.GetMethod(method);

	//	object firstParam = paramethers[index][0];
	//	if(paramethers[index].Length > 1)
	//	{
	//		object? secondParam = paramethers[index]?[1];
	//		var obj = new object?[2] { firstParam, secondParam };
	//		theMethod.Invoke(myLinkedList, obj);
	//	} else
	//	{
	//		var obj = new object?[1] { firstParam };
	//		var result = theMethod.Invoke(myLinkedList, obj);
	//		if(result != null)
	//		{
	//			Console.WriteLine(result);
	//		}
	//	}

	//	index++;
	//}


	//myLinkedList.AddAtHead(38);
	//myLinkedList.AddAtTail(66);
	//myLinkedList.AddAtTail(61);
	//myLinkedList.AddAtTail(76);
	//myLinkedList.AddAtTail(26);
	//myLinkedList.AddAtTail(37);
	//myLinkedList.AddAtTail(8);
	//myLinkedList.DeleteAtIndex(6);
	//myLinkedList.AddAtHead(4);
	//myLinkedList.AddAtHead(45);
	//Console.WriteLine( myLinkedList.Get(4));
	//myLinkedList.AddAtTail(85);
	//myLinkedList.AddAtHead(37);
	//Console.WriteLine(myLinkedList.Get(5));
	//myLinkedList.AddAtTail(93);
	//myLinkedList.AddAtIndex(10, 23);
	//myLinkedList.AddAtTail(21);
	//myLinkedList.AddAtHead(52);
	//myLinkedList.AddAtHead(15);
	//myLinkedList.AddAtHead(47);
	//Console.WriteLine(myLinkedList.Get(12));
	//myLinkedList.AddAtIndex(6, 24);
	//myLinkedList.AddAtHead(64);
	//Console.WriteLine(myLinkedList.Get(4));
	//myLinkedList.AddAtHead(31);
	//myLinkedList.DeleteAtIndex(6);
	//myLinkedList.AddAtHead(40);
	//myLinkedList.AddAtTail(17);
	//myLinkedList.AddAtTail(15);
	//myLinkedList.AddAtIndex(19, 2);
	//myLinkedList.AddAtTail(11);
	//myLinkedList.AddAtHead(86);
	//Console.WriteLine(myLinkedList.Get(17));





	//myLinkedList.AddAtHead(5);
	//myLinkedList.DeleteAtIndex(3);
	//myLinkedList.AddAtHead(7);
	//myLinkedList.Get(3);
	//myLinkedList.Get(3);
	//myLinkedList.Get(3);
	//myLinkedList.AddAtHead(1);
	//myLinkedList.DeleteAtIndex(4);

	//myLinkedList.AddAtHead(2);
	//myLinkedList.AddAtHead(1);
	//myLinkedList.AddAtIndex(3, 0);
	//myLinkedList.DeleteAtIndex(2);
	//myLinkedList.AddAtHead(6);
	//myLinkedList.AddAtTail(4);
	//myLinkedList.Get(4);
	//myLinkedList.AddAtHead(4);
	//myLinkedList.AddAtIndex(5, 0);
	//myLinkedList.AddAtHead(6);

	//var list = myLinkedList;
	//while (list != null)
	//{
	//	Console.WriteLine(list.Value);
	//	list = list.Next;
	//}

	//var item = myLinkedList.Get(1);
	//myLinkedList.DeleteAtIndex(1);
	//item = myLinkedList.Get(1);

	public class MyLinkedList
    {
        private class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        private ListNode _head = null;
        private ListNode _tail = null;
        private int _length = 0;

        public MyLinkedList()
        {

        }

        public int Get(int index)
        {
            if (index < 0 || index >= _length)
            {
                return -1;
            }

            int i = 0;
            var curr = _head;
            while (i != index)
            {
                i++;
                curr = curr.next;
            }

            return curr.val;
        }

        public void AddAtHead(int val)
        {
            var newHead = new ListNode(val);
            newHead.next = _head;
            _head = newHead;

            if (_tail == null)
            {
                if (_length != 0)
                {
                    throw new Exception($"Tail was null but length = {_length}");
                }

                _tail = newHead;
            }

            _length++;
        }

        public void AddAtTail(int val)
        {
            if (_tail == null)
            {
                AddAtHead(val);
                return;
            }

            _tail.next = new ListNode(val);
            _tail = _tail.next;
            _length++;
        }

        public void AddAtIndex(int index, int val)
        {
            if (index == _length)
            {
                AddAtTail(val);
                return;
            }

            if (index == 0)
            {
                AddAtHead(val);
                return;
            }

            if (index < 0 || index > _length)
            {
                return;
            }

            index--;
            int i = 0;
            var curr = _head;
            while (i != index)
            {
                i++;
                curr = curr.next;
            }

            var next = curr.next;
            curr.next = new ListNode(val);
            curr.next.next = next;
            _length++;
        }

        public void DeleteAtIndex(int index)
        {
            if (index < 0 || index >= _length)
            {
                return;
            }

            if (index == 0)
            {
                _head = _head.next;
                if (_length == 1)
                {
                    _tail = null;
                }
            }
            else
            {
                index--;
                int i = 0;
                var curr = _head;
                while (i != index)
                {
                    i++;
                    curr = curr.next;
                }

                var itemToRemove = curr.next;
                curr.next = itemToRemove.next;
                if (itemToRemove == _tail)
                {
                    _tail = curr;
                }
            }

            _length--;
        }
    }

	//public class MyLinkedList
	//{
	//	public MyLinkedList Next { get; set; }
	//	public int? Value { get; set; }

	//	/** Initialize your data structure here. */
	//	public MyLinkedList()
	//	{
	//		Value = null;
	//		Next = null;
	//	}

	//	public MyLinkedList(int val)
	//	{
	//		Value = val;
	//		Next = null;
	//	}

	//	public MyLinkedList(int val, MyLinkedList next)
	//	{
	//		Value = val;
	//		Next = next;
	//	}

	//	/** Get the value of the index-th node in the linked list.
	//	 * If the index is invalid, return -1. */
	//	public int get(int index)
	//	{
	//		if (index == 0)
	//		{
	//			return Value ?? int.MinValue;
	//		}

	//		var nextItem = this;
	//		int newIndex = 0;
	//		while (index != newIndex && nextItem != null)
	//		{
	//			nextItem = nextItem.Next;
	//			newIndex++;
	//		}

	//		if (nextItem != null)
	//		{
	//			return nextItem.Value ?? int.MinValue;
	//		}

	//		return -1;
	//	}

	//	/** Add a node of value val before the first element of the linked list. 
	//	 * After the insertion, the new node will be the first node of the linked list. */
	//	public void addAtHead(int val)
	//	{
	//		if (Next == null && Value == null)
	//		{
	//			Value = val;
	//			return;
	//		}

	//		var next = Next;
	//		var currentValue = Value ?? int.MinValue;

	//		Value = val;
	//		Next = new MyLinkedList(currentValue, next);
	//	}

	//	/** Append a node of value val to the last element of the linked list. */
	//	public void addAtTail(int val)
	//	{
	//		var nextItem = this;
	//		while (nextItem.Next != null)
	//		{
	//			nextItem = nextItem.Next;
	//		}

	//		nextItem.Next = new MyLinkedList(val);
	//	}

	//	/** Add a node of value val before the index-th node in the linked list. 
	//	 * If index equals to the length of linked list, the node will be appended to the end of linked list. 
	//	 * If index is greater than the length, the node will not be inserted. */
	//	public void addAtIndex(int index, int val)
	//	{
	//		if (index == 0)
	//		{
	//			Value = val;
	//			return;
	//		}

	//		var nextItem = this;
	//		var lastItem = this;
	//		int newIndex = 0;
	//		while (index != newIndex && nextItem != null)
	//		{
	//			lastItem = nextItem;
	//			nextItem = nextItem.Next;
	//			newIndex++;
	//		}

	//		if (nextItem != null)
	//		{
	//			var oldValue = nextItem.Value;
	//			var oldNext = nextItem.Next;
	//			nextItem.Value = val;
	//			nextItem.Next = new MyLinkedList(oldValue ?? int.MinValue, oldNext);
	//			return;
	//		}

	//		if (index == newIndex)
	//		{
	//			lastItem.Next = new MyLinkedList(val, null);
	//		}
	//	}

	//	/** Delete the index-th node in the linked list, if the index is valid. */
	//	public void deleteAtIndex(int index)
	//	{
	//		if (index == 0)
	//		{
	//			Value = Next?.Value;
	//			Next = Next?.Next;
	//			return;
	//		}

	//		var nextItem = this;
	//		int newIndex = 0;
	//		while (index != newIndex && nextItem != null)
	//		{
	//			nextItem = nextItem.Next;
	//			newIndex++;
	//		}

	//		if (nextItem != null)
	//		{
	//			var oldValue = nextItem.Next?.Value;
	//			var oldNext = nextItem.Next?.Next;
	//			nextItem.Value = oldValue;
	//			nextItem.Next = oldNext;
	//		}
	//	}
	//}
}
