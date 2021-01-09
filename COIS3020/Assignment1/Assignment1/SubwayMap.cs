using System;
using System.Collections.Generic;

namespace Assignment1
{
	class SubwayMap
	{
		private List<Station> stationList; 

		// Creates a new instance of SubwayMap class
		public SubwayMap() {
			this.stationList = new List<Station>();
		}

		// Inserts a new station to the list
		public void InsertStation(string name)
		{
			// Check if the station with that name already exists
			if (!Exists(name))
			{
				// Create a new station with the name and add it to the list
				Station station = new Station(name);
				stationList.Add(station);
			}
		}

		// Inserts a link between two stations with a given color
		public void InsertLink(string from, string to, Color color)
		{
			// Get stations
			Station stationFrom = FindStation(from);
			Station stationTo = FindStation(to);

			// If both stations exist and the link with a given color does not, add that link
			if (stationFrom != null && stationTo != null && !stationFrom.LinkExists(stationTo, color))
			{
				stationFrom.Links.Add(new KeyValuePair<Station, Color>(stationTo, color));
				stationTo.Links.Add(new KeyValuePair<Station, Color>(stationFrom, color));
			}
		}

		// Deletes a link between two stations with a given color
		public void DeleteLink(string from, string to, Color color)
		{
			// Get stations
			Station stationFrom = FindStation(from);
			Station stationTo = FindStation(to);

			// If both stations exist and the link exists, delete it
			if (stationFrom != null && stationTo != null && stationFrom.LinkExists(stationTo, color))
			{
				stationFrom.Links.Remove(new KeyValuePair<Station, Color>(stationTo, color));
				stationTo.Links.Remove(new KeyValuePair<Station, Color>(stationFrom, color));
				Console.WriteLine("Link succesfully deleted");
			}
			else
				Console.WriteLine("Link was not found");
		}

		// Finds the fastest route between two stations
		// The algorithm assumes that the path always exists between two existant stations
		public void FastestRoute(string from, string to)
		{
			// Get stations
			Station stationFrom = FindStation(from);
			Station stationTo = FindStation(to);

			// If two stations exist, find a path
			if (stationFrom != null && stationTo != null)
			{
				// Start the breadth-first search
				List<KeyValuePair<Station, Color>> path = BreadthFirstSearch(stationFrom, stationTo);

				// Store current station and color of link we arrived on
				Station currentStation = stationFrom;
				Color currentColor = Color.None;

				// Go through the path and output how to get to the final station
				foreach (KeyValuePair<Station, Color> part in path)
				{
					// Output directions
					if (currentColor == Color.None)
					{
						Console.WriteLine("Start by getting on {0} line to station {1}", 
							part.Value.ToString(), part.Key.Name);
						currentColor = part.Value;
					}
					else
					{
						if (currentColor.Equals(part.Value))
							Console.WriteLine("Continue on {0} line to station {1}", 
								part.Value.ToString(), part.Key.Name);
						else
						{
							Console.WriteLine("Change to {0} line and ride to station {1}",
								part.Value.ToString(), part.Key.Name);
							currentColor = part.Value;
						}
					}
				}
			}
			else
				Console.WriteLine("Stations do not exist");
		}

		// Returns a list of all critical stations (i.e. stations, that if deleted, create a disconnected subway map)
		// For more explanation on how the algorithm works, please refer to documentation
		public List<Station> CriticalStations()
		{
			// Contains the critical stations
			List<Station> criticalStations = new List<Station>();

			if (stationList.Count != 0)
				// Start the depth-first search
				DepthFirstSearch(stationList[0], new List<Station>(), new Dictionary<Station, int>(), new Dictionary<Station, 
					int>(), new Dictionary<Station, Station>(), criticalStations);

			return criticalStations;
		}

		public bool IsConnected()
		{
			if (stationList.Count == 0)
				return true;

			List<Station> visited = new List<Station>();

			// Start overloaded method for depth-first search
			DepthFirstSearch(stationList[0], visited);

			// Return whether the number of visited stations is equal to the total number of stations
			return visited.Count == stationList.Count;
		}

		// Runs a standard depth-first search. Invoked by IsConnected()
		void DepthFirstSearch(Station currentStation, List<Station> visited)
		{
			visited.Add(currentStation);

			foreach (KeyValuePair<Station, Color> link in currentStation.Links)
			{
				if (!visited.Contains(link.Key))
				{
					DepthFirstSearch(link.Key, visited);
				}
			}
		}

		// Runs a depth-first search(DFS) to find critical stations. Invoked by CriticalStations()
		void DepthFirstSearch(Station currentStation, List<Station> visited, Dictionary<Station, int> discoveryTime,
			Dictionary<Station, int> lowestTime, Dictionary<Station, Station> parent, List<Station> criticalStations, int timer = 0)
		{
			// Increase the timer
			timer++;
			// Mark as visited
			visited.Add(currentStation);
			// Note the time of visit
			discoveryTime.Add(currentStation, timer);
			lowestTime.Add(currentStation, timer);

			// Contains the number of children
			int numberChildren = 0;

			foreach (KeyValuePair<Station, Color> link in currentStation.Links)
			{
				if (!visited.Contains(link.Key))
				{
					numberChildren++;
					// Set parent of station
					parent.Add(link.Key, currentStation);
					// Start DFS from that station
					DepthFirstSearch(link.Key, visited, discoveryTime, lowestTime, parent, criticalStations, timer);

					// Save the lowest discovery time for current station 
					lowestTime[currentStation] = Math.Min(lowestTime[currentStation], lowestTime[link.Key]);
					// First if: the current station is a root with more than one child, it is a critical station
					// Second if: the current station has no back link, therefore, it is a critical station
					if (!parent.ContainsKey(currentStation) && numberChildren > 1 && !criticalStations.Contains(currentStation))
						criticalStations.Add(currentStation);
					else if (parent.ContainsKey(currentStation) && lowestTime[link.Key] >= discoveryTime[currentStation] 
						&& !criticalStations.Contains(currentStation))
						criticalStations.Add(currentStation);
				}
				// If the station linked to current station is not a parent, check for back link
				// If lowestTime of current station gets updated, the back link is found 
				else if (parent.ContainsKey(currentStation) && parent[currentStation] != link.Key)
					lowestTime[currentStation] = Math.Min(lowestTime[currentStation], discoveryTime[link.Key]);
			}
		}

		// Runs a breadth-first search (BFS) from the given station
		List<KeyValuePair<Station, Color>> BreadthFirstSearch(Station start, Station end)
		{
			// Stores the path by which we arrived to the station
			List<KeyValuePair<Station, Color>> path = new List<KeyValuePair<Station, Color>>();

			// Stores the parent of each station (i.e. how BFS got there)
			Dictionary<Station, KeyValuePair<Station, Color>> parent = new Dictionary<Station, KeyValuePair<Station, Color>>();

			// Stores whether the station was visited or not
			List<Station> visited = new List<Station>();

			// Queue for BFS algorithm
			Queue<Station> queue = new Queue<Station>();
			queue.Enqueue(start);
			visited.Add(start);

			// Stores the current station we are taking look at
			Station currentStation;

			while (queue.Size() > 0)
			{
				currentStation = queue.Dequeue();

				// Check each link and add in queue if not visited
				foreach (KeyValuePair<Station, Color> link in currentStation.Links)
				{
					// If not visited
					if (!visited.Contains(link.Key))
					{
						// Push it into queue
						queue.Enqueue(link.Key);
						visited.Add(link.Key);
						// Save the parent and color into parent dictionary
						parent.Add(link.Key, new KeyValuePair<Station, Color>(currentStation, link.Value));
					}
				}
			}

			// Redefine current to end station and trace backwards by parents to find the path
			currentStation = end;
			while (currentStation != start)
			{
				try
				{
					KeyValuePair<Station, Color> linkToParent = new KeyValuePair<Station, Color>();
					// Try getting the link
					if (parent.TryGetValue(currentStation, out linkToParent))
					{
						KeyValuePair<Station, Color> linkToCurrent = new KeyValuePair<Station, Color>
							(currentStation, linkToParent.Value);
						path.Add(linkToCurrent);

						currentStation = linkToParent.Key;
					}
					else
					{
						Console.WriteLine("Found an error: the dictionary does not contain the value for the key provided");
						Console.ReadLine();
						Environment.Exit(-1);
					}
				}
				catch (ArgumentNullException ex)
				{
					Console.WriteLine(ex.ToString());
					Console.ReadLine();
					Environment.Exit(-1);
				}
			}

			// Reverse the path (because the transfers were added in reverse order)
			path.Reverse();

			return path;
		}

		// Returns station with a given name from list or null
		Station FindStation(string name)
		{
			// Make name lowercase - names are case-insensitive
			name = name.ToLower();

			// Stores the found station
			Station result = null;

			// Go over list and find the station
			foreach (Station station in stationList)
				if (station.Name.ToLower() == name)
					result = station;

			// Return station or null if not found
			return result;
		}

		// Checks whether the station with passed name already exists
		bool Exists(string name)
		{
			// Check each station in the list
			foreach (Station station in stationList)
			{
				if (station.Name.Equals(name))
					return true;
			}
			return false;
		}
	}
}
