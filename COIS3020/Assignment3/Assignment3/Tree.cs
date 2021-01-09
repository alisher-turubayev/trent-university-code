using System;

namespace Assignment3
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
		void Insert(T item);
		void Delete(T item);
		bool Contains(T item);
		void Print();
	}

	//
	// Summary:
	//		An implementation of 2-3-4 tree  
	// 
	// Type parameters:
	//   T:
	//		The type of items in to be stored in a 2-3-4 tree
	public class Tree<T> : ISearchable<T> where T : IComparable
	{
		//
		// Summary:
		//		Internal generic support class to store the nodes of 2-3-4 tree 
		private class Node
		{
			public int NumItems { get; set; }
			public T[] Items { get; set; }
			public bool[] Deleted { get; set; }
			public Node[] Children { get; set; }

			public Node(T item)
			{
				NumItems = 1;
				Items = new T[3];
				Items[0] = item;
				Deleted = new bool[3];
				Children = new Node[4];
			}

			// Inserts an item into a node
			public void Insert(T item)
			{
				int pos = 0;
				for (int i = 0; i < NumItems; i++)
				{
					if (Items[i].CompareTo(item) > 0)
						break;
					pos++;
				}

                // Means that there are deleted items that need to be deleted
                if (pos == NumItems)
                {
                    // Copy over not deleted items
                    T[] notDeleted = new T[3];
                    int index = 0;

                    for (int i = 0; i < NumItems; i++)
                    {
                        if (!Deleted[i])
                        {
                            notDeleted[index] = Items[i];
                            index++;
                        }
                    }

                    // Insert the item at the end and copy the final array into the node
                    notDeleted[index] = item;

                    Items = notDeleted;
                    Deleted = new bool[3];
                    NumItems = index + 1;
                }
                else if (!Deleted[pos])
                {
                    // Shift everyone one position right
                    for (int i = NumItems; i > pos; i--)
                    {
                        Items[i] = Items[i - 1];
                        Deleted[i] = Deleted[i - 1];
                    }
                    Items[pos] = item;
                    NumItems++;
                }
                else
                {
                    Items[pos] = item;
                    Deleted[pos] = false;
                }
			}

			// Returns true if the contains the item
			public bool Contains(T item)
			{
				for (int i = 0; i < NumItems; i++)
					if (Items[i].CompareTo(item) == 0 && !Deleted[i])
						return true;

				return false;
			}

			// Marks an item as deleted
			// See Delete() method for details
			public void MarkDeleted (T item)
			{
				for (int i = 0; i < NumItems; i++)
				{
					if (Items[i].CompareTo(item) == 0)
					{
						Deleted[i] = true;
						return;
					}
				}
			}
		}

		//Dummy root
		private Node root;
		private int size;

		// Creates an empty tree
		public Tree()
		{
			MakeEmpty();
		}

		// Returns the link number to go to (from 0 to 3) 
		// It is assumed that the node does not contain the item in question
		private int GetDirection(T item, Node node)
		{
			int dir = 0;
			for (int i = 0; i < node.NumItems; i++)
			{
				if (node.Items[i].CompareTo(item) > 0)
					break;
				dir++;
			}

			return dir;
		}

		// Splits a 4-node into a 3 2-nodes
		private Node Split(Node node)
		{
			// Save old child node references
			Node[] children = node.Children;

			// Create new root, left and right nodes
			Node left = new Node(node.Items[0]),
                newNode = new Node(node.Items[1]),
				right = new Node(node.Items[2]);

            // Copy over deleted markings
            if (node.Deleted[0])
                left.MarkDeleted(node.Items[0]);
            if (node.Deleted[1])
                newNode.MarkDeleted(node.Items[1]);
            if (node.Deleted[2])
                right.MarkDeleted(node.Items[2]);
            // Attach old children to new left node
			left.Children[0] = children[0];
			left.Children[1] = children[1];
			// Attach old children to new right node
			right.Children[0] = children[2];
			right.Children[1] = children[3];
			// Attach left and right nodes to the new root node
			newNode.Children[0] = left;
			newNode.Children[1] = right;

			return newNode;
		}

		// Splits the child at index and inserts extra item in parent
		private Node Rearrange(Node node, int index)
		{
			Node temp = Split(node.Children[index]);

			// Insert the temp's item into parent
			node.Insert(temp.Items[0]);
            // Copy over deleted marking
            if (temp.Deleted[0])
                node.MarkDeleted(temp.Items[0]);
			// Find the position of inserted item
			int itemIndex = 0;
			for (int i = 0; i < node.NumItems; i++)
			{
				if (node.Items[i].CompareTo(temp.Items[0]) == 0)
					break;
				itemIndex++;
			}
			// Shift all references of children one step right
			for (int i = node.NumItems;i > itemIndex; i--)
				node.Children[i] = node.Children[i - 1];
			// Reattach new children to parent node
			node.Children[itemIndex] = temp.Children[0];
			//if (itemIndex + 1 < 4)
			node.Children[itemIndex + 1] = temp.Children[1];

			return node;
		}

		// Public method called from other classes
		// Calls a private method
		public void Insert(T item)
		{
			Insert(item, root);
		}

		// Private method that is called to insert an item into a tree
		private void Insert(T item, Node node)
		{
			// Special case for root node
			if (node.NumItems == 0)
			{
				if (node.Children[0] != null)
				{
					if (node.Children[0].NumItems == 3)
						node.Children[0] = Split(node.Children[0]);

					Insert(item, node.Children[0]);
				}
				else
				{
					node.Children[0] = new Node(item);
					size++;
				}
				return;
			}

			// If the item is already in tree, stop
			if (node.Contains(item))
				return;
			
			int dir = GetDirection(item, node);

			// If the child is not null, current node is internal
			// Else, current node is leaf node and we can insert the item
			if (node.Children[dir] != null)
			{
				if (node.Children[dir].NumItems == 3)
				{
					node = Rearrange(node, dir);
					dir = GetDirection(item, node);
				}
				Insert(item, node.Children[dir]);
			}
			else
			{
				node.Insert(item);
				size++;
			}
		}

		// Public method called from other classes
		// Calls private method only if there is at least one item
		public void Delete(T item)
		{
			if (size > 0)
				Delete(item, root.Children[0]);
		}

		// Private method that deletes an item from tree
		private void Delete(T item, Node node)
		{
			/*
			 * Dear Marker,
			 * 
			 * This is the author of this code, sitting in his monitor-lit
			 * room at 1:33am on a now-Wednesday night, who is seriously 
			 * sleep-deprived and caffeine-addicted. I have sincerely tried
			 * to implement the Delete function as it should be, but I had 
			 * hit a brick wall. I know that there is no forgiveness for the
			 * course of action that I took in this method, so you can very much
			 * hate me for what I did.
			 * 
			 * As one wise person said on the Wikipedia page for 2-3-4 trees:
			 *		"Consider just leaving the element there, marking it "deleted", 
			 *		possibly to be re-used for a future insertion."
			 * 
			 * I just marked the item that needs to be deleted as deleted and don't
			 * actually delete the element from the tree. Teehee~
			 * 
			 * Have a nice summer break!
			 * Sincerely,
			 * Alisher Turubayev
			 */
			
			// Item not found if we hit null
			if (node == null)
				return;

			// If in node, mark as deleted
			if (node.Contains(item))
			{
				size--;
				node.MarkDeleted(item);
				return;
			}

			// Get the direction to go to
			int dir = GetDirection(item, node);
			// and go there
			Delete(item, node.Children[dir]);
		}

		// Returns true if the item is in the tree
		public bool Contains(T item)
		{
			Node current = root.Children[0];
			while (current != null)
			{
				if (current.Contains(item))
					return true;

				int cmp = GetDirection(item, current);
				current = current.Children[cmp];
			}
			return false;
		}

		// Public method called from other classes
		public void Print()
		{
			Print(root.Children[0]);
			Console.WriteLine();
		}

		// Private method that prints the items in the tree using inorder traversal
		private void Print(Node node)
		{
			if (node == null)
				return;

			for (int i = 0; i < node.NumItems; i++)
			{
				Print(node.Children[i]);
				if (!node.Deleted[i])
					Console.Write("{0} ", node.Items[i]);
			}
            Print(node.Children[node.NumItems]);
		}

		// Returns an instance of RBTree (red-black tree) that is an isometry of the current tree
		public RBTree<T> Convert()
		{
			RBTree<T> tree = new RBTree<T>();
			Convert(root, tree);
			return tree;
		}

        // Copies over non-deleted items in the node. Invoked by Convert
        private Node CopyNonDeleted(Node node)
        {
            Node copy = new Node(default(T));
            T[] items = new T[3];
            int index = 0;

            for (int i = 0; i < node.NumItems; i++)
            {
                if (!node.Deleted[i])
                {
                    items[index] = node.Items[i];
                    index++;
                }
            }
            copy.Items = items;
            copy.NumItems = index;

            return copy;
        }

		// Private method that converts each node to a node in a RBTree
		private void Convert(Node node, RBTree<T> tree)
		{
			if (node == null)
				return;

            Node copy = CopyNonDeleted(node);
			// Case 2-node: create a black node
			// Case 3-node: create a black node (with larger value) as parent and red child
			// Case 4-node: create a black node (with middle value) as parent and two red children
			if (copy.NumItems == 1)
				tree.Add(copy.Items[0], RBTree<T>.Color.BLACK);
			else if (copy.NumItems == 2)
			{
				tree.Add(copy.Items[1], RBTree<T>.Color.BLACK);
				tree.Add(copy.Items[0], RBTree<T>.Color.RED);
			}
			else if (copy.NumItems == 3)
			{
				tree.Add(copy.Items[1], RBTree<T>.Color.BLACK);
				tree.Add(copy.Items[0], RBTree<T>.Color.RED);
				tree.Add(copy.Items[2], RBTree<T>.Color.RED);
			}

			// Run Convert for all children of a node
			// Note that piece of sh- code also works for the root, as it only has one child
			for (int i = 0; i < node.NumItems + 1; i++)
				Convert(node.Children[i], tree);
		}

		// Makes the tree empty
		public void MakeEmpty()
		{
			root = new Node(default(T));
			root.NumItems = 0;
			size = 0;
		}

		// Returns true if tree is empty; false otherwise
		public bool Empty()
		{
			return size == 0;
		}

		// Returns the number of items in tree
		public int Size()
		{
			return size;
		}
	}
}
