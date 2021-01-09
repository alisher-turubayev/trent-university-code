using System;

namespace Assignment3
{
	//
	// Summary:
	//		A data structure that resembles a red-black tree, supporting insertions
	//		of nodes into the tree with two available colors: red and black.
	//		This class is needed to complete the assignment and illustrate that 
	//		red-black trees are an isometry of 2-3-4 trees.
	// 
	// Type parameters:
	//   T:
	//		The type of items in to be stored in red-black tree
	public class RBTree<T> where T : IComparable
	{
		//
		// Summary:
		//		Enumerator that describes the available colors for nodes in 
		//		red-black trees
		public enum Color { RED, BLACK };

		//
		// Summary:
		//		Internal generic support class to store the nodes of red-black tree 
		private class Node
		{
			public T Item { get; set; }
			public Color Color { get; set; }
			public Node Left { get; set; }
			public Node Right { get; set; }

			public Node (T item, Color color)
			{
				Item = item;
				Color = color;
				Left = Right = null;
			}
		}

		private Node root;

		public RBTree()
		{
			root = null;
		}

		// Adds an item with a specified color in a same fashion as regular binary trees
		// Does not allow duplicates
		// Note that there is no attempt in rebalancing the tree and no integrity checks
		// (i.e. whether the properties of red-black trees hold) are made
		public void Add (T item, Color color)
		{
			if (root == null)
			{
				root = new Node(item, color);
				return;
			}

			Node current = root;
			bool inserted = false;

			while (!inserted)
			{
				if (item.CompareTo(current.Item) < 0)
				{
					if (current.Left == null)
					{
						current.Left = new Node(item, color);
						inserted = true;
					}
					else
						current = current.Left;
				}
				else if (item.CompareTo(current.Item) > 0)
				{
					if (current.Right == null)
					{
						current.Right = new Node(item, color);
						inserted = true;
					}
					else
						current = current.Right;
				}
				// Already exists in a tree
				else
					inserted = true;
			}
		} 

		// Prints the contents of a tree by inorder traversal
		public void Print()
		{
			Print(root);
			Console.WriteLine();
		}

		// Private method that prints the content of a node and its color
		private void Print(Node node, int offset = 0)
		{
			if (node == null)
				return;

			string space = new string(' ', offset),
				color = node.Color == Color.RED ? "R" : "B";

			Print(node.Left, offset + 4);
			Console.WriteLine(space + node.Item.ToString() + color);
			Print(node.Right, offset + 4);
		}
	}
}
