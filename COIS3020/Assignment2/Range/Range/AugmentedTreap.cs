using System;

namespace Range
{
	//
	// Summary:
	//		Represents a container that can be emptied, checked if empty, or size returned.
	// 
	// Type parameters:
	//   T:
	//		The type of elements in the container
	public interface IContainer<T>
	{
		void MakeEmpty();
		bool Empty();
		int Size();
	}

	//
	// Summary:
	//		Represents a data structure that can add and delete items, check if item is 
	//      contained in structure, print the contents of structure  
	// 
	// Type parameters:
	//   T:
	//		The type of items in the data structure
	public interface ISearchable<T> : IContainer<T>
	{
		void Add(T item);
		void Remove(T item);
		bool Contains(T item);
		void Print();
	}

	//
	// Summary:
	//		Represents a node that contains item of type T, a randomly-generated priority, 
	//      number of items in the subtree and references to left and right children (of class Node)
	// 
	// Type parameters:
	//   T:
	//		The type of item in the node
	class Node<T> where T : IComparable
	{
		private static Random R = new Random();
		
		public T Item { get; set; }
		public int Priority { get; set; }
		public int NumItems { get; set; }
		public Node<T> Left { get; set; }
		public Node<T> Right { get; set; }

		//
		// Summary:
		//     Initializes a new instance of the Node class that contains specified item,
		//     and null references as left and right children
		// Parameters:
		//	  item:
		//		The item to be contained in the node
		public Node (T item)
		{
			Item = item;
			Priority = R.Next(10, 100);
			NumItems = 1;
			Left = Right = null;
		}
	}

	//
	// Summary:
	//		Represents a treap data structure with augmented data to support the operation
	//      of finding the number of elements between certain boundaries
	//
	// Type parameters:
	//   T:
	//		The type of items in the augmented treap
	public class AugmentedTreap<T> : ISearchable<T> where T : IComparable
	{
		private Node<T> root;

		//
		// Summary:
		//     Initializes a new instance of the AugmentedTreap class that is empty
		public AugmentedTreap()
		{
			MakeEmpty();
		}

		//
		// Summary:
		//     Calculates the number of items in the tree for a node of which it is a root
		//
		// Parameters:
		//   node:
		//	   The object of class Node that needs number of items to be calculated
		private void CalcSize(Node<T> node)
		{
			node.NumItems = 1;
			if (node.Left != null)
				node.NumItems += node.Left.NumItems;
			if (node.Right != null)
				node.NumItems += node.Right.NumItems;
		}

		//
		// Summary:
		//     Performs a left rotation around specified node
		//
		// Parameters:
		//   node:
		//	   An object of type Node to rotate left
		//
		// Returns:
		//     Object of type Node that was rotated left
		private Node<T> LeftRotate(Node<T> node)
		{
			Node<T> temp = node.Right;
			node.Right = temp.Left;
			CalcSize(node);
			temp.Left = node;
			return temp;
		}

		//
		// Summary:
		//     Performs a right rotation around specified node
		//
		// Parameters:
		//   node:
		//	   An object of type Node to rotate right
		//
		// Returns:
		//     Object of type Node that was rotated right
		private Node<T> RightRotate(Node<T> node)
		{
			Node<T> temp = node.Left;
			node.Left = temp.Right;
			CalcSize(node);
			temp.Right = node;
			return temp;
		}

		//
		// Summary:
		//     Adds specified item to the augmented treap
		//
		// Parameters:
		//   item:
		//     The item to add
		public void Add(T item)
		{
			root = Add(item, root);
		}

		//
		// Summary:
		//     Returns a node that has specified item inserted in its subtree.
		//     Additionally, performs rotations to keep treap in correct structure
		//
		// Parameters:
		//   item:
		//     The item to add
		//
		//   node:
		//	   An object of type Node to which the item to be added
		//
		// Returns:
		//     Object of type Node that contains item in its subtree
		private Node<T> Add(T item, Node<T> node)
		{
			if (node == null)
				return new Node<T>(item);

			int cmp = item.CompareTo(node.Item);
			if (cmp > 0)
			{
				node.Right = Add(item, node.Right);
				if (node.Right.Priority > node.Priority)
					node = LeftRotate(node);
			}
			else if (cmp < 0)
			{
				node.Left = Add(item, node.Left);
				if (node.Left.Priority > node.Priority)
					node = RightRotate(node);
			}

			CalcSize(node);
			return node;
		}

		//
		// Summary:
		//     Removes specified item from the augmented treap
		//
		// Parameters:
		//   item:
		//     The item to remove
		public void Remove(T item)
		{
			root = Remove(item, root);
		}

		//
		// Summary:
		//     Returns a node that has specified item removed in its subtree.
		//     Additionally, performs rotations to keep treap in correct structure
		//
		// Parameters:
		//   item:
		//     The item to remove
		//
		//   node:
		//	   An object of type Node from which the item to be removed 
		//
		// Returns:
		//     Object of type Node that does not contain item in its subtree
		private Node<T> Remove(T item, Node<T> node)
		{
			if (node == null)
				return null;

			int cmp = item.CompareTo(node.Item);
			if (cmp < 0)
				node.Left = Remove(item, node.Left);
			else if (cmp > 0)
				node.Right = Remove(item, node.Right);
			else
			{
				if (node.Left != null && node.Right != null)
				{
					if (node.Left.Priority > node.Right.Priority)
						node = RightRotate(node);
					else
						node = LeftRotate(node);
				}
				else if (node.Left != null)
					node = RightRotate(node);
				else if (node.Right != null)
					node = LeftRotate(node);
				else
					return null;

				node = Remove(item, node);
			}

			CalcSize(node);
			return node;
		}

		//
		// Summary:
		//     Determines whether an item is in AugmentedTreap
		//
		// Parameters:
		//   item:
		//	   The item to be checked
		//
		// Returns:
		//     true if item is in AugmentedTreap; otherwise, false 
		public bool Contains(T item)
		{
			Node<T> current = root;

			while (current != null)
			{
				if (item.CompareTo(current.Item) < 0)
					current = current.Left;
				else if (item.CompareTo(current.Item) > 0)
					current = current.Right;
				else
					return true;
			}

			return false; 
		}

		//
		// Summary:
		//     Swaps the values of item 1 and item 2
		//
		// Parameters:
		//   item1:
		//	   First item
		//
		//   item2:
		//     Second item
		private static void Swap(ref T item1, ref T item2)
		{
			T temp = item1;
			item1 = item2;
			item2 = temp;
		}

		//
		// Summary:
		//     Returns the rank of specified item as if it was in the tree of which the root is node.
		//     If the item is in tree, returns its rank
		//
		// Parameters:
		//   item:
		//	   The item to find rank of
		//
		//   node:
		//     Current node operating on
		//
		// Returns:
		//     Int that represents a rank of item in tree of which the root is node
		private int Rank(T item, Node<T> node)
		{
			// If item does not exist in treap, return 0
			if (node == null)
				return 0;

			int cmp = item.CompareTo(node.Item);
			if (cmp < 0)
				return Rank(item, node.Left);
			else if (cmp > 0)
				return Rank(item, node.Right) + (node.Left == null ? 1 : node.Left.NumItems + 1);

			return (node.Left == null ? 1 : node.Left.NumItems + 1);
		}

		//
		// Summary:
		//     Returns the number of items that are between specified boundaries (inclusive).
		//     Note that boundaries are switched if left boundary is bigger than right
		//
		// Parameters:
		//   X:
		//	   Left boundary
		//
		//   Y:
		//     Right boundary
		//
		// Returns:
		//     Int that contains the number of items between X and Y
		public int InRange(T X, T Y)
		{
			if (Y.CompareTo(X) < 0)
				Swap(ref X, ref Y);

			if (!Contains(X))
				return Rank(Y, root) - Rank(X, root);

			return Rank(Y, root) - Rank(X, root) + 1;
		}

		//
		// Summary:
		//     Makes instance of class AugmentedTreap empty
		public void MakeEmpty()
		{
			root = null;
		}

		//
		// Summary:
		//     Determines whether an instance of class AugmentedTreap is empty
		//
		// Returns:
		//	   true if treap is empty; otherwise, false
		public bool Empty()
		{
			return root == null;
		}

		//
		// Summary:
		//     Returns the size of AugmentedTreap instance
		//
		// Returns:
		//	   Number of items in the AugmentedTreap instance
		public int Size()
		{
			return root.NumItems;
		}

		//
		// Summary:
		//     Prints the contents of AugmentedTreap instance in increasing order
		public void Print()
		{
			Print(root);
		}

		//
		// Summary:
		//		Prints all items in the tree of which the node is root
		//
		// Parameters:
		//    node:
		//		The root of tree to be printed
		private void Print(Node<T> node)
		{
			if (node == null)
				return;

			Print(node.Left);
			Console.Write("{0} ", node.Item);
			Print(node.Right);
		}
	}
}
