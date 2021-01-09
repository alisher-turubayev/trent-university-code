/* Program for Assignment 2 - COIS 2020
 * 
 * Written by Alisher Turubayev and Angsar Kamel,
 *	Trent University
 * 
 * Purpose: this was written to demonstrate the knowledge of Huffman trees and priority queues, 
 *	as well as usage of Dictionary<> class
 * 
 * Functions: Huffman codes generator creates a Huffman tree for a given text, encodes and decodes the text
 *	
 * Uses Huffman, Priority Queue classes. 
*/
using System;

namespace Assignment2
{
	static class Console
	{
		// Main program method that starts with application start
		public static void Main ()
		{
			// String to store user input
			string userInput = "";

			// Greet the user
			System.Console.WriteLine("Hello, and welcome to the Huffman codes generator!");
			System.Console.WriteLine("The program is simple to use,");
			System.Console.WriteLine("just input the text consisting of letters a-z, A-Z and spaces.");
			System.Console.WriteLine("The program will then generate a Huffman tree for your text,");
			System.Console.WriteLine("encode it and decode back. \n");
			
			// Prompt to write text
			System.Console.WriteLine("Please, enter the text:");

			// Bool for loop closure
			bool loopEnd = false;

			// Start text validation loop
			while (!loopEnd)
			{
				userInput = System.Console.ReadLine();
				if (TextCheck(userInput) && userInput.Length > 0)
					loopEnd = true;
				else
				{
					System.Console.WriteLine("Text input contains charactars other than a-z, A-Z and space");
					System.Console.WriteLine("or is too small to be encoded. Please, try again");
				}
			}

			// Create Huffman tree
			Huffman tree = new Huffman(userInput);
				
			// Store encoded text
			string encodeResult = tree.Encode(userInput);
				
			// Output result
			System.Console.WriteLine("Encode result:");
			System.Console.WriteLine(encodeResult);

			System.Console.WriteLine("Decode result:");
			System.Console.WriteLine(tree.Decode(encodeResult));
			System.Console.ReadLine();
		}

		// Checks for illegal characters in given text
		static bool TextCheck (string text)
		{
			for (int i = 0;i < text.Length; i++)
				if (!char.IsLetter(text[i]) && text[i] != ' ')
					return false;
			return true;
		}
	}
}
