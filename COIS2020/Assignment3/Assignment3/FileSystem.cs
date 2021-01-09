using System;
using System.Collections.Generic;

public class Node
{
	// Data fields
	private string directory; 
	private List<string> file;
	private Node leftMostChild;
	private Node rightSibling;

	// One argument constructor
	public Node(string directory)
	{
		this.directory = directory;
		this.file = new List<string>();
		this.leftMostChild = null;
		this.rightSibling = null;
	}
		
	// Read-only or read/write properties for each field
	public string Directory
	{
		get
		{
			return this.directory;
		}
		set
		{
			this.directory = value;
		}
	}
	public List<string> File
	{
		get
		{
			return this.file; 
		}
	}
	public Node LeftMostChild
	{
		get
		{
			return this.leftMostChild;
		}
		set
		{
			this.leftMostChild = value;
		}
	}
	public Node RightSibling
	{
		get
		{
			return this.rightSibling;
		}
		set
		{
			this.rightSibling = value;
		}
	}
}

public class FileSystem
{
	// Stores the root directory of the filesystem
	private Node root;

	// Creates a file system with a root directory
	public FileSystem ()
	{
		root = new Node("");
	}

	// Adds a file at the given address
	// Returns false if the file already exists or the path is undefined; true otherwise
	public bool AddFile(string address)
	{
		// Stores the current node. Start at root
		Node current = root;
		// Stores the parsed address
		List<string> path = ParseAddress(address);

		// If the path does not contain file name, return false
		if (path.Count == 0)
			return false;

		// Go through each level and try to find it in the filesystem
		while (path.Count > 1)
		{
			// Go one level down
			current = current.LeftMostChild;
			// Try to find the directory on current level
			while (current != null && current.Directory != path[0])
				current = current.RightSibling;
			// If can't, return null
			if (current == null)
				return false;
			// Remove found directory from queue
			path.RemoveAt(0);
		}

		// Search for a file in directory
		// If found, return false
		if (current.File.Contains(path[0]))
			return false;

		// Add the file to the directory
		current.File.Add(path[0]);
		return true;
	}

	// Removes the file at the given address
	// Returns false if the file is not found or the path is underfined; true otherwise
	public bool RemoveFile (string address)
	{
		// Stores the current node. Start at root
		Node current = root;
		// Stores the parsed address
		List<string> path = ParseAddress(address);

		// If the path does not contain file name, return false
		if (path.Count == 0)
			return false;

		// Go through each level and try to find it in the filesystem
		while (path.Count > 1)
		{
			// Go one level down
			current = current.LeftMostChild;
			// Try to find a directory on current level
			while (current != null && current.Directory != path[0])
				current = current.RightSibling;
			// If can't, return false
			if (current == null)
				return false;
			// Remove found directory from queue
			path.RemoveAt(0);
		}

		// If there is no such file in the directory, return false
		if (!current.File.Contains(path[0]))
			return false;
		
		// Otherwise, delete file and return true
		current.File.Remove(path[0]);
		return true;
	}

	// Adds a directory at the given address
	// Returns false if the directory already exists or	path is undefined; true otherwise
	public bool AddDirectory (string address)
	{
		// Stores the current node. Start at root
		Node current = root;
		// Stores the parsed address
		List<string> path = ParseAddress(address);

		// If the path does not contain new directory name, return false 
		if (path.Count == 0)
			return false;
			
		// Go through each level and try to find it in the filesystem
		while (path.Count > 1)
		{
			// Go one level down
			current = current.LeftMostChild;
			// Try to find the directory on the current level
			while (current != null && current.Directory != path[0])
				current = current.RightSibling;
			// If can't, return false
			if (current == null)
				return false;
			// Remove found directory from queue
			path.RemoveAt(0);
		}

		if (current.LeftMostChild == null)
		{
			current.LeftMostChild = new Node(path[0]);
			return true;
		}
			
		// Go one last level down
		current = current.LeftMostChild;
			
		// Save the previous node for insertion
		Node prev = current;

		// Check on the current level if we have the directory with the same name
		while (current != null)
		{
			// If we do, return false
			if (current.Directory == path[0])
				return false;
			prev = current;
			current = current.RightSibling;
		}

		// Insert the new directory to the right of the rightmost node
		prev.RightSibling = new Node(path[0]);
		return true;
	}

	// Removes the directory (and its subdirectories) at the given address
	// Returns false if the directory is not found or the path is undefined; true otherwise
	public bool RemoveDirectory (string address)
	{
		// Stores current node. Start at root
		Node current = root;
		// Stores parsed address
		List<string> path = ParseAddress(address);

		// If the path does not contain the 
		if (path.Count == 0)
			return false;

		while (path.Count > 1)
		{
			// Go one level down
			current = current.LeftMostChild;
			// Try to find directory on current level
			while (current != null && current.Directory != path[0])
				current = current.RightSibling;
			// If can't, return false
			if (current == null)
				return false;
			// Remove found directory from queue
			path.RemoveAt(0);
		}
		// If the current node has no child, return false
		if (current.LeftMostChild == null)
			return false;
		// If the leftmost child is the directory for deletion, reassign the next directory on the same level to it
		else if (current.LeftMostChild.Directory == path[0])
			current.LeftMostChild = current.LeftMostChild.RightSibling;
		// Else, find the directory on level
		else
		{
			// Go last level down
			current = current.LeftMostChild;

			// Save a previous node
			Node prev = current;

			// Look for a directory for deletion on a current level
			while (current != null)
			{
				if (current.Directory == path[0])
					break;
				prev = current;
				current = current.RightSibling;
			}

			// If we couldn't find it, return false
			if (current == null)
				return false;
			// Go around a deleted node
			prev.RightSibling = current.RightSibling;
		}
		return true;
	}
		
	// Returns the number of files in the file system
	public int NumberFiles()
	{
		// Stores the number of files in the filesystem
		int result = 0;
		// Stores the queue of nodes
		List<Node> queue = new List<Node>();

		// Add a root to the queue
		queue.Add(root);

		while (queue.Count > 0)
		{
			// Take next node from queue
			Node current = queue[0];
			// Remove it from queue
			queue.RemoveAt(0);

			// Add the number of files to result
			result += current.File.Count;

			// If exist, add the leftmost child and right sibling to queue
			if (current.LeftMostChild != null)
				queue.Add(current.LeftMostChild);
			if (current.RightSibling != null)
				queue.Add(current.RightSibling);
		}
		// Return the result
		return result;
	}
	
	// Print the directories in a pre-order fashion along with their files
	public void PrintFileSystem()
	{
		PrintNode(root);
	}

	// Prints out the address of current directory and all of the files in it
	private void PrintNode (Node current, string previousAddress = "")
	{
		// Stores the current address for a directory
		string currentAddress = previousAddress;
		if (current.Directory != "")
			currentAddress += "/" + current.Directory;

		// Print the address and all of the files
		Console.WriteLine(currentAddress);
		foreach (string file in current.File)
			Console.WriteLine(currentAddress + "/" + file);

		// Try to go to the next node on the level
		if (current.RightSibling != null)
			PrintNode(current.RightSibling, previousAddress);
		// Go down a level if possible
		if (current.LeftMostChild != null)
			PrintNode(current.LeftMostChild, currentAddress);
	}

	/*	Address parser. Returns a list of directories and a file name (if invoked from AddFile or RemoveFile) 
	 *	Note: no validation of address correctness is made, the address sent is assumed to be in correct format
	 *	(i.e in absolute terms - "/Directory/Directory/File" or "/Directory/Directory") 
	*/
	List<string> ParseAddress (string address)
	{
		// Stores the path in a list of directories to follow in an order
		List<string> path = new List<string>();
		// Used as a buffer
		string buffer = "";
			
		// Parse the address
		for (int i = 0;i < address.Length; i++)
		{
			if (address[i] == '/' && buffer != "")
			{
				path.Add(buffer);
				buffer = "";
			}
			else if (address[i] != '/')
				buffer += address[i];
		}
		// If the buffer contains last file or directory name, add it to the list
		if (buffer != "")
			path.Add(buffer);

		return path;
	}
}
