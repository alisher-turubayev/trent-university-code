/* Program for Assignment 3 - COIS 2020
 * 
 * Written by Alisher Turubayev,
 *	Trent University
 * 
 * Purpose: this was written to demonstrate the knowledge of leftmost child, right-sibling trees, tree traversals
 *	as well as implementation skills
 * 
 * Functions: file system allows creation/deletion of files/directories, outputting the total file number in the system and the  
 *	directories in the pre-order fashion
 *	
 * Uses FileSystem class.
 * 
 * PLEASE NOTE: the address for operations is considered to be always in correct format, so no checking is done
 *				names of files and directories are case-sensitive, so FILE and file are considered as different
*/

using System;

class MainProgram
{
	public static void Main ()
	{
		// Operation codes
		const string CODE_ADD_FILE = "AF";
		const string CODE_REMOVE_FILE = "DF";
		const string CODE_ADD_DIRECTORY = "AD";
		const string CODE_REMOVE_DIRECTORY = "DD";
		const string CODE_NUMBER_FILES = "NF";
		const string CODE_PRINT = "PR";
		const string CODE_QUIT = "Q";
		// Stores the file system
		FileSystem fileSystem = new FileSystem();
		// Stores user input
		string userInput = "";
		 
		// Greet the user
		Console.WriteLine("Hello and welcome to the file system manipulator (FSM)!");
		Console.WriteLine("This program allows you to add/remove files/directories in a file system,");
		Console.WriteLine("which is implemented using a leftmost-child, right-sibling data structure.\n");
		
		// Explain controls
		Console.WriteLine("The possible operations are:");
		Console.WriteLine("Use '{0}' to add a new file", CODE_ADD_FILE);
		Console.WriteLine("Use '{0}' to remove a file", CODE_REMOVE_FILE);
		Console.WriteLine("Use '{0}' to add a new directory", CODE_ADD_DIRECTORY);
		Console.WriteLine("Use '{0}' to remove a directory", CODE_REMOVE_DIRECTORY);
		Console.WriteLine("Use '{0}' to output a number of files", CODE_NUMBER_FILES);
		Console.WriteLine("Use '{0}' to print the directories in a pre-order fashion along with their files", CODE_PRINT);
		Console.WriteLine("Use '{0}' to quit the program\n", CODE_QUIT);

		//Ask for an input
		Console.WriteLine("What do you want to do?");
		userInput = Console.ReadLine().ToUpper();

		// Ask for an input while the code of operation is not CODE_QUIT
		while (userInput != CODE_QUIT)
		{
			// Use desired operation
			switch (userInput)
			{
				case CODE_ADD_FILE:
					Console.WriteLine("Please, input the address:");
					// Say whether the operation was successful or not
					if (fileSystem.AddFile(Console.ReadLine()))
						Console.WriteLine("Successfully added new file.\n");
					else
						Console.WriteLine("Path not found or file exists.\n");
					break;
				case CODE_REMOVE_FILE:
					Console.WriteLine("Please, input the address:");
					// Say whether the operation was successful or not
					if (fileSystem.RemoveFile(Console.ReadLine()))
						Console.WriteLine("Successfully removed the file.\n");
					else
						Console.WriteLine("Path not found or file does not exist.\n");
					break;
				case CODE_ADD_DIRECTORY:
					Console.WriteLine("Please, input the address:");
					// Say whether the operation was successful or not
					if (fileSystem.AddDirectory(Console.ReadLine()))
						Console.WriteLine("Successfully added a directory. \n");
					else
						Console.WriteLine("Path not found or directory exists.\n");
					break;
				case CODE_REMOVE_DIRECTORY:
					Console.WriteLine("Please, input the address:");
					// Say whether the operation was successful or not
					if (fileSystem.RemoveDirectory(Console.ReadLine()))
						Console.WriteLine("Successfully removed the directory.\n");
					else
						Console.WriteLine("Path not found or directory does not exist.\n");
					break;
				case CODE_NUMBER_FILES:
					Console.WriteLine("Currently, the file system contains {0} file(s).\n", fileSystem.NumberFiles());
					break;
				case CODE_PRINT:
					Console.WriteLine("Currently, the file system contains:");
					fileSystem.PrintFileSystem();
					break;
				default:
					System.Console.WriteLine("Invalid command, please try again.\n");
					break;
			}
			// Ask for a next input
			Console.WriteLine("What do you want to do?");
			userInput = Console.ReadLine().ToUpper();
		}

		// Goodbye, see you soon!
		Console.ReadLine();
	}
}
