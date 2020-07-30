namespace AlgorithmsLeetCodeCSharp.Chapters.QueueAndStackProblems
{
	// https://leetcode.com/explore/learn/card/queue-stack/228/first-in-first-out-data-structure/1337/
	public class MyCircularQueue
	{
        int length = 0;
        int[] queue = null;  // is int? fast as int ?
        int? head = null;
        int? tail = null;
        
        /** Initialize your data structure here. Set the size of the queue to be k. */
        public MyCircularQueue(int k)
        {
            queue = new int[k];
            length = k - 1;
        }

        /** Insert an element into the circular queue. Return true if the operation is successful. */
        public bool EnQueue(int value)
        {
            if (head == null)
            {
                head = 0;
                tail = 0;
                queue[tail.Value] = value;
                return true;
            }

            if(tail != length && tail + 1 != head)
            {
                tail++;
                queue[tail.Value] = value;
                return true;
			}

            if(tail == length && head != 0)
            {
                tail = 0;
                queue[tail.Value] = value;
                return true;
            }

            return false;
        }

        /** Delete an element from the circular queue. Return true if the operation is successful. */
        public bool DeQueue()
        {
            if(head == null)
			{
                return false;
			}

            if(head == length && tail != length && tail != 0)
            {
                head = 0;
                queue[head.Value] = -1;
                return true;
            }

            if(head == tail)
            {
                queue[head.Value] = -1;
                head = null;
                tail = null;
                return true;
            }

            queue[head.Value] = -1;
            head++;
            return true;
        }

        /** Get the front item from the queue. */
        public int Front()
        {
            if (IsEmpty())
            {
                return -1;
            }

            return queue[head.Value];
        }

        /** Get the last item from the queue. */
        public int Rear()
        {
			if (IsEmpty())
			{
                return -1;
			}

            return queue[tail.Value];
        }

        /** Checks whether the circular queue is empty or not. */
        public bool IsEmpty()
        {
            return head == null && tail == null;
        }

        /** Checks whether the circular queue is full or not. */
        public bool IsFull()
        {
            return ((head != null) && ((head == 0 && tail == length) || (tail + 1 == head)));
        }
    }
}
