namespace AlgorithmsLeetCodeCSharp.Chapters.LinkedListProblems
{
	public class NodeWithRadom
	{
		public int val;
		public NodeWithRadom next;
		public NodeWithRadom random;

		public NodeWithRadom(int _val)
		{
			val = _val;
			next = null;
			random = null;
		}
	}

	public class Node
	{
		public int val;
		public Node prev;
		public Node next;
		public Node child;

		public Node(int val, Node prev, Node child)
		{
			this.val = val;
			this.prev = prev;
			this.child = child;
		}
	}
}
