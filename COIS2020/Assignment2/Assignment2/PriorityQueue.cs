using System;

namespace Assignment2
{
	// Common interface for all non-linear data structures
	public interface IContainer<T>
	{
		void MakeEmpty();  // Reset an instance to empty
		bool Empty();      // Test if an instance is empty
		int Size();        // Return the number of items in an instance
	}

	// Priority queue interface
	public interface IPriorityQueue<T> : IContainer<T> where T : IComparable
	{
		void Add(T item);  // Add an item to a priority queue
		void Remove();     // Remove the item with the highest priority
		T Front();         // Return the item with the highest priority
	}

	// Priority Queue in binary heap implementation
	public class PriorityQueue<T> : IPriorityQueue<T> where T : IComparable
	{
		private int capacity;  // Maximum number of items in a priority queue
		private T[] A;         // Array of items
		private int count;     // Number of items in a priority queue

		// Constructor
		public PriorityQueue(int size)
		{
			this.capacity = size;
			// Create array of T of size + 1 as the indexing starts at 1
			this.A = new T[size + 1];
			this.count = 0;
		}

		// Percolates up from the position index
		private void PercolateUp(int index)
		{
			// Ints to store the current node position and parent's index
			int current = index, parent;

			// While we are not at the root of a tree
			while (current > 1)
			{
				// Parent's node position is child's node position divided by 2
				parent = current / 2;

				// If the current node has more priority than parent, swap them
				// Else, the current node is in the right position
				if (A[current].CompareTo(A[parent]) < 0)
				{
					Swap(ref A[current], ref A[parent]);
					// Move up the tree
					current = parent;
				}
				else
					return;
			}
		}

		// Percolates down from the position index
		private void PercolateDown(int index)
		{
			// Ints to store current node position and child node position
			int current = index, child;

			// While we can move down the tree
			while (current * 2 <= count)
			{
				child = current * 2;

				// If right child has more priority than left, change to right
				if (child < count && A[child + 1].CompareTo(A[child]) < 0)
					child++;

				// If the current node has less priority than child, swap them
				// Else, the current node is in the right position
				if (A[current].CompareTo(A[child]) > 0)
				{
					Swap(ref A[current], ref A[child]);
					// Move down the tree
					current = child;
				}
				else
					return;
			}
		}

		// Adds a new item to the queue
		public void Add(T item)
		{
			if (count < capacity)
			{
				// Add the item to the end of the queue
				A[++count] = item;
				// Percolate up from that position
				PercolateUp(count);
			}
		}

		// Deletes the top item of the queue
		public void Remove()
		{
			if (!Empty())
			{
				// Remove item with highest priority and replace with last item
				A[1] = A[count--];
				// Percolate down the new root
				PercolateDown(1);
			}
		}

		public T Front()
		{
			if (!Empty())
				return A[1];
			else
				return default(T);
		}

		// Makes the queue empty by setting count to zero
		public void MakeEmpty()
		{
			count = 0;
			return;
		}

		// Checks if empty by comparing the count to zero
		public bool Empty()
		{
			return count == 0;
		}

		// Returns current size of queue
		public int Size()
		{
			return count;
		}

		// Swaps two values
		public static void Swap (ref T item1, ref T item2)
		{
			T temp = item1;
			item1 = item2;
			item2 = temp;
		}
	}
}
