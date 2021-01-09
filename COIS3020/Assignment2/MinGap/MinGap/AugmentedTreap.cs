using System;

namespace MinGap
{
	//
	// Summary:
	//		Represents a container that can be emptied, checked if empty, or size returned.
	public interface IContainer
	{
		void MakeEmpty();
		bool Empty();
		int Size();
	}

	//
	// Summary:
	//		Represents a data structure that can add and delete items, check if item is 
	//      contained in structure, print the contents of structure  
	public interface ISearchable : IContainer
	{
		void Add(int item);
		void Remove(int item);
		bool Contains(int item);
		void Print();
	}

	//
	// Summary:
	//		Represents a node that contains item of type T, a randomly-generated priority, 
	//      number of items in the subtree and references to left and right children (of class Node)
	public class Node
	{
		private static Random R = new Random();

		public int Item { get; set; }
		public int Priority { get; set; }
		public int Min { get; set; }
		public int Max { get; set; }
		public int MinGap { get; set; }
		public Node Left { get; set; }
		public Node Right { get; set; }

		//
		// Summary:
		//     Initializes a new instance of the Node class that contains specified item,
		//     and null references as left and right children
		// Parameters:
		//	  item:
		//		The item to be contained in the node
		public Node (int item)
		{
			Item = item;
			Min = Max = item;
			MinGap = int.MaxValue;
			Priority = R.Next(10, 100);
			Left = Right = null;
		}
	}

	//
	// Summary:
	//		Represents a treap data structure with augmented data to support the operation
	//      of finding the minimum gap (i.e. magnitute of difference between the closest
	//		numbers in treap)
	public class AugmentedTreap : ISearchable
	{
		private int numItems;
		private Node root;

		//
		// Summary:
		//     Initializes a new instance of the AugmentedTreap class that is empty
		public AugmentedTreap()
		{
			MakeEmpty();
		}

		//
		// Summary:
		//     Calculates the minimum and maximum in the tree for a node of which it is a root
		//
		// Parameters:
		//   node:
		//	   The object of class Node that needs minimum and maximum to be calculated
		private void CalcMinMax(Node node)
		{
			node.Min = node.Max = node.Item;
			if (node.Left != null)
				node.Min = Math.Min(node.Min, node.Left.Min);
			if (node.Right != null)
				node.Max = Math.Max(node.Max, node.Right.Max);
		}

		//
		// Summary:
		//     Calculates the minimum gap in the tree for a node of which it is a root
		//
		// Parameters:
		//   node:
		//	   The object of class Node that needs minimum gap to be calculated
		private void CalcMinGap(Node node)
		{
			node.MinGap = int.MaxValue;
			if (node.Left != null)
			{
				node.MinGap = Math.Min(node.MinGap, node.Left.MinGap);
				node.MinGap = Math.Min(node.MinGap, node.Item - node.Left.Max);
			}
			if (node.Right != null)
			{
				node.MinGap = Math.Min(node.MinGap, node.Right.MinGap);
				node.MinGap = Math.Min(node.MinGap, node.Right.Min - node.Item);
			}
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
		private Node LeftRotate(Node node)
		{
			Node temp = node.Right;
			node.Right = temp.Left;
			CalcMinMax(node);
			CalcMinGap(node);
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
		private Node RightRotate(Node node)
		{
			Node temp = node.Left;
			node.Left = temp.Right;
			CalcMinMax(node);
			CalcMinGap(node);
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
		public void Add(int item)
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
		private Node Add(int item, Node node)
		{
			if (node == null)
			{
				numItems++;
				return new Node(item);
			}
			if (item > node.Item)
			{
				node.Right = Add(item, node.Right);
				if (node.Right.Priority > node.Priority)
					node = LeftRotate(node);
			}
			else if (item < node.Item)
			{
				node.Left = Add(item, node.Left);
				if (node.Left.Priority > node.Priority)
					node = RightRotate(node);
			}
			CalcMinMax(node);
			CalcMinGap(node);
			return node;
		}

		//
		// Summary:
		//     Removes specified item from the augmented treap
		//
		// Parameters:
		//   item:
		//     The item to remove
		public void Remove(int item)
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
		private Node Remove(int item, Node node)
		{
			if (node == null)
				return null;

			if (item < node.Item)
				node.Left = Remove(item, node.Left);
			else if (item > node.Item)
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
				{
					numItems--;
					return null;
				}

				node = Remove(item, node);
			}
			CalcMinMax(node);
			CalcMinGap(node);
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
		public bool Contains(int item)
		{
			Node current = root;

			while (current != null)
			{
				if (item < current.Item)
					current = current.Left;
				else if (item > current.Item)
					current = current.Right;
				else
					return true;
			}

			return false;
		}

		//
		// Summary:
		//     Returns the minimum gap (i.e. magnitute of difference between the closest numbers)
		//     of AugmentedTreap instance
		//
		// Returns:
		//	   Minimum gap of the AugmentedTreap instance or 0 if treap contains only one item
		public int MinGap()
		{
			return (root.MinGap == int.MaxValue ? 0 : root.MinGap);
		}

		//
		// Summary:
		//     Makes instance of class AugmentedTreap empty
		public void MakeEmpty()
		{
			root = null;
			numItems = 0;
		}

		//
		// Summary:
		//     Returns the size of AugmentedTreap instance
		//
		// Returns:
		//	   Number of items in the AugmentedTreap instance
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
			return numItems;
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
		private void Print(Node node)
		{
			if (node == null)
				return;

			Print(node.Left);
			Console.Write("{0} ", node.Item);
			Print(node.Right);
		}
	}
}
