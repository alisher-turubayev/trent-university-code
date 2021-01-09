using System;
using System.Collections.Generic;

namespace Assignment2
{
	// Node class for Huffman tree nodes
	class Node : IComparable
	{
		// Read/write properties for each field
		public char Character { get; set; }
		public int Frequency { get; set; }
		public Node Left { get; set; }
		public Node Right { get; set; }
		
		// Constructor
		public Node (char character, int frequency, Node left, Node right)
		{
			this.Character = character;
			this.Frequency = frequency;
			this.Left = left;
			this.Right = right;
		}

		// CompareTo method of ICompare interface
		// Compares two nodes by comparing the frequency
		public int CompareTo (Object obj)
		{
			// Check whether the object passed is of Node type
			if (obj is Node)
			{
				Node node = (Node)obj;
				if (this.Frequency > node.Frequency)
					return 1;
				else if (this.Frequency < node.Frequency)
					return -1;
				return 0;
			}
			else
			{
				throw new Exception("Cannot compare");
			}
		}
	}

	// Huffman tree implementation
	class Huffman
	{
		private Node HT;					 //Huffman tree to create codes and decode text
		private Dictionary<char, string> D;  //Dictionary to encode text

		// Constructor
		public Huffman(string S)
		{
			// Initialize dictionary
			D = new Dictionary<char, string>();

			// An array to save the frequencies of the characters in a given text
			int[] frequencies = AnalyzeText(S);

			// Build a Huffman tree and save it in node HT
			Build(frequencies);

			// If the resulting Huffman tree only consists of one node, don't start the recursion 
			// Else, create codes for each possible character using recursion
			if (HT.Left == null)
				D.Add(HT.Character, "0");
			else
				CreateCodes(HT, "");
		}

		// Returns the frequency of each character in the given text (invoked by constructor)
		private int[] AnalyzeText (string S)
		{
			// Array to store the frequency of each character
			int[] frequencies = new int[130];

			// Go through the text and increment the array values
			for (int i = 0; i < S.Length; i++)
				frequencies[S[i]]++;

			return frequencies;
		}

		// Builds a Huffman tree based on a character frequencies (invoked by constuctor)
		private void Build (int[] F)
		{
			// Priority queue to store the nodes for Huffman tree
			PriorityQueue<Node> PQ = new PriorityQueue<Node>(53);

			// Add space to the PQ if exists in text
			if (F[' '] > 0)  
				PQ.Add(new Node(' ', F[' '], null, null));

			// Add 'a' to 'z' characters to the priority queue if exist in text
			for (char i = 'a';i <= 'z'; i++)
			{
				if (F[i] > 0)
					PQ.Add(new Node(i, F[i], null, null));
			}

			// Add 'A' to 'Z' characters to the priority queue if exist in text
			for (char i = 'A';i <= 'Z'; i++)
			{
				if (F[i] > 0)
					PQ.Add(new Node(i, F[i], null, null));
			}

			while (PQ.Size() > 1)
			{
				// Take next nodes and remove them
				Node left = PQ.Front();
				PQ.Remove();
				Node right = PQ.Front();
				PQ.Remove();

				// Push the new node into the priority queue
				// Note: we put ambigious character @ to distinguish between internal and leaf nodes
				PQ.Add(new Node('@', left.Frequency + right.Frequency, left, right));
			}

			// Save the resulting Huffman tree in HT
			HT = PQ.Front();
		}

		// Creates the codes of 0s and 1s for each character by traversing the Huffman tree (invoked by constructor)
		private void CreateCodes (Node current, string buffer)
		{
			// If the current node is a leaf, stop the recursion and write the string value into dictionaries
			if (current.Character != '@')
			{
				D.Add(current.Character, buffer);
				return;
			}

			// Else, continue recursion into left node and right node
			CreateCodes(current.Left, buffer + "0");
			CreateCodes(current.Right, buffer + "1");
		}

		// Encodes the given text and return a string of 0s and 1s
		public string Encode (string S)
		{
			// String to store the result
			string result = "";

			// Go through the text and add value from dictionary to result
			for (int i = 0; i < S.Length; i++)
				result += D[S[i]];

			return result;
		}

		// Decodes the string of 0s and 1s and returns the original text
		public string Decode (string S)
		{
			// String to store the result
			string result = "";
			// Store the current node
			Node current = HT;

			// Go through the encoded text
			for (int i = 0;i < S.Length; i++)
			{
				
				if (S[i] == '0' && current.Left != null)
					current = current.Left;
				if (S[i] == '1')
					current = current.Right;

				if (current.Character != '@')
				{
					result += current.Character;
					current = HT;
				}
			}

			return result;
		}
	}
}
