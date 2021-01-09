namespace Assignment1
{
	public class Node<T>
	{
		private T item;
		private Node<T> next;

		// Creates a node with given item to store and a link to a next node
		public Node (T item, Node<T> next)
		{
			this.item = item;
			this.next = next;
		}

		// Read/write properties for each data member		
		public T Item
		{
			get
			{
				return item;
			}
			set
			{
				item = value;
			}
		}
		public Node<T> Next
		{
			get
			{
				return next;
			}
			set
			{
				next = value;
			}
		}
	}
}
