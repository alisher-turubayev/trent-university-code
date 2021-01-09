namespace Assignment1
{ 
	// Commmon interface for all linear data structures
	public interface IContainer<T>
	{
		void MakeEmpty();		// Clears the content of the data structure
		bool Empty();           // Checks whether the data structure is empty or not
		int Size();				// Returns the size of the data structure
	}
	
	// Interface for queue containers
	public interface IQueue<T> : IContainer<T>
	{
		void Enqueue(T item);	// Adds the item at the end of the queue
		T Dequeue();			// Removes the item at the beginning of the queue and returns it
	}
	
	// Node class for Queue
	class Node<T>
	{
		public T Item { get; set; }			// Stores the item
		public Node<T> Next { get; set; }	// Stores reference to next item

		// Creates an empty node
		public Node()
		{
			this.Item = default(T);
			this.Next = null;
		}

		// Creates a node with given item and next reference
		public Node(T item, Node<T> next)
		{
			this.Item = item;
			this.Next = next;
		}
	}

	public class Queue<T> : IQueue<T>
	{
		Node<T> head;                   // Reference to the head (front) item
		Node<T> tail;                   // Reference to the tail (back) item
		int count;

		// Creates an empty queue
		public Queue() 
		{
			MakeEmpty();
		}

		// Adds an item to the queue
		public void Enqueue(T item)
		{
			Node<T> newNode = new Node<T>(item, null);
			if (count == 0)
			{
				head = tail = newNode;
			}
			else
			{
				tail = tail.Next = newNode;
			}
			count++;
		}

		// Deletes fist item from the queue and returns it
		public T Dequeue()
		{
			T result = default(T);
			if (!Empty())
			{
				result = head.Item;
				head = head.Next;
				count--;
			}
			return result;
		}
		
		public void MakeEmpty()
		{
			head = tail = null;
			count = 0;
		}

		public bool Empty()
		{
			return count == 0;
		}

		public int Size()
		{
			return count;
		}
	}
}
