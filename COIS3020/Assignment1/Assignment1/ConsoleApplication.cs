/* Program for Assignment 1 - COIS 3020
 * 
 * Written by Alisher Turubayev,
 *	Trent University
 * 
 * Purpose: creates and manipulates a subway system. Demonstrates knowledge of graphs, depth-first search,
 *	breadth-first search, and generic data structures 
 * 
 * Uses SubwayMap class
 * 
 * PLEASE NOTE: 
 *	Queue was not working on my machine, so I had to reimplement it using the code from Brian Patrick.
 *	More information is available in the Description document
 */
using System;
using System.IO;
using System.Collections.Generic;

namespace Assignment1
{
	class ConsoleApplication
	{
		public static void Main ()
		{	
			// Greet the user
			Console.WriteLine("Welcome to subway system simulator!");
			Console.WriteLine("The input is taken from file, named 'input.txt' in the current folder.");
			Console.WriteLine("Please consult the documentation for file format and operation codes.\n");

			if (!ParseFileAndEvaluate())
			{
				Console.WriteLine("Failed to parse information due to errors above. The application will be terminated.");
				Console.ReadLine();
				return;
			}

			// Farewell!
			Console.WriteLine("Thank you for using the program! Good bye!");
			Console.ReadLine();
		}
		
		// Returns false if at any point of parsing the input from the file error occurs (for example, wrong data or station/command not found)
		static bool ParseFileAndEvaluate()
		{
			// Create an instance of SubwayMap
			SubwayMap map = new SubwayMap();
			
			// Stores the path to the file
			string filePath;
			try
			{
				filePath = Directory.GetCurrentDirectory();
			} catch (UnauthorizedAccessException)
			{
				Console.WriteLine("Cannot access the directory.");
				return false;
			}

			// Add a file name
			filePath += "\\input.txt";

			// If file doesn't exist, exit method
			if (!File.Exists(filePath))
			{
				Console.WriteLine("The file does not exist or permission is denied.");
				return false;
			}

			// Read the file using StreamReader
			StreamReader reader = new StreamReader(filePath);
			// Line counter
			int counter = 1;

			// If can't get the number of stations, stop reading file
			if (!Int32.TryParse(reader.ReadLine(), out int numberStations))
			{
				Console.WriteLine("Error on line {0}: Number of stations is not defined.", counter);
				return false;
			}
			counter++;

			// Try to read station names
			for (int index = 0; index < numberStations; index++)
			{
				// If can't read the next station's name, stop
				string name;
				if ((name = reader.ReadLine()) == null)
				{
					Console.WriteLine("Error on line {0}: Not enough stations defined.", counter);
					return false;
				}
				counter++;

				// If the station's name contains a space, stop
				if (name.Contains(" "))
				{
					Console.WriteLine("Error on line {0}: Station's name contains a space, which is not allowed.",
						counter);
					return false;
				}

				map.InsertStation(name);
			}

			// If can't get the number of links, stop reading file
			if (!Int32.TryParse(reader.ReadLine(), out int numberLinks))
			{
				Console.WriteLine("Error on line {0}: Number of links is not defined.", counter);
				return false;
			}
			counter++;
			
			// Try to read links
			for (int index = 0; index < numberLinks; index++)
			{
				// If can't read next link, stop
				string link;
				if ((link = reader.ReadLine()) == null)
				{
					Console.WriteLine("Error on line {0}: Not enough links defined.", counter);
					return false;
				}
				// If incorrect number of arguments, stop
				string[] parts = link.Split(' ');
				if (parts.Length != 3)
				{
					Console.WriteLine("Error on line {0}: Link is improperly defined.", counter);
					return false;
				}

				Color linkColor = GetColor(parts[2]); 
				if (linkColor == Color.None)
				{
					Console.WriteLine("Error on line {0}: Link color is incorrect.", counter);
					return false;
				}

				map.InsertLink(parts[0], parts[1], linkColor);
				counter++;
			}

			// Validate the subway map, i.e. check that the map is connected
			if (!map.IsConnected())
			{
				Console.WriteLine("Error on line {0}: The resultant map is not connected.", counter);
				return false;
			}

			// If can't get the number of operations, stop reading file
			if (!Int32.TryParse(reader.ReadLine(), out int numberOperation))
			{
				Console.WriteLine("Error on line {0}: Number of operations is not defined.", counter);
				return false;
			}
			counter++;

			// Try to read operations
			for (int index = 0; index < numberOperation; index++)
			{
				// If can't read next line, stop
				string operation;
				if ((operation = reader.ReadLine()) == null)
				{
					Console.WriteLine("Error on line {0}: Not enough operations defined.", counter);
					return false;
				}

				// If incorrect number of arguments, stop
				string[] parts = operation.Split(' ');
				switch (parts.Length)
				{
					case 1:
						// The only operation with no arguments is CriticalStations. The operation code is "CS" 
						if (parts[0].ToLower() != "cs")
						{
							Console.WriteLine("Error on line {0}: Operation code is incorrect.", counter);
							return false;
						}
						List<Station> criticalStations = map.CriticalStations();

						Console.WriteLine("There are {0} critical stations:", criticalStations.Count);
						foreach (Station station in criticalStations)
						{
							Console.WriteLine(station.Name);
						}
						Console.WriteLine();
						break;
					case 3:
						// The only operation with two arguments is FastestRoute. The operation code is "FR"
						if (parts[0].ToLower() != "fr")
						{
							Console.WriteLine("Error on line {0}: Operation code is incorrect.", counter);
							return false;
						}
						map.FastestRoute(parts[1], parts[2]);
						Console.WriteLine();
						break;
					case 4:
						// The only operation with three arguments is DeleteLink. The operation code is "DL"
						if (parts[0].ToLower() != "dl")
						{
							Console.WriteLine("Error on line {0}: Operation code is incorrect.", counter);
							return false;
						}
						map.DeleteLink(parts[1], parts[2], GetColor(parts[3]));
						Console.WriteLine();

						// Check if the map is still connected
						if (!map.IsConnected())
						{
							Console.WriteLine("Error on line {0}: After deletion, map is disconnected.", counter);
							return false;
						}
						break;
					default:
						Console.WriteLine("Error on line {0}: Operation is improperly defined.", counter);
						return false;
				}
				counter++;
			}

			return true;
		}

		// Returns a enum Color based on string name
		static Color GetColor (string name)
		{
			Color result;
			switch (name.ToLower())
			{
				case "black":
					result = Color.Black;
					break;
				case "blue":
					result = Color.Blue;
					break;
				case "brown":
					result = Color.Brown;
					break;
				case "grey":
					result = Color.Grey;
					break;
				case "green":
					result = Color.Green;
					break;
				case "orange":
					result = Color.Orange;
					break;
				case "pink":
					result = Color.Pink;
					break;
				case "purple":
					result = Color.Purple;
					break;
				case "red":
					result = Color.Red;
					break;
				case "white":
					result = Color.White;
					break;
				case "yellow":
					result = Color.Yellow;
					break;
				default:
					result = Color.None;
					break;
			}
			return result;
		}
	}
}
// PURIFICATION! PURIFICATION! PURIFICATION!!!
