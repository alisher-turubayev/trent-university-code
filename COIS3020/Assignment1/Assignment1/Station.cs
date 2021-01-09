using System;
using System.Collections.Generic;

namespace Assignment1
{
	// Color enum for link coloring
	public enum Color
	{
		None,
		Red,
		Orange,
		Yellow,
		Green,
		Blue,
		Purple,
		Pink,
		Brown,
		Grey,
		Black,
		White
	}

	class Station
	{
		public string Name { get; }
		public List<KeyValuePair<Station, Color>> Links { get; }

		public Station(string name)
		{
			this.Name = name;
			this.Links = new List<KeyValuePair<Station, Color>>();
		}

		// Checks whether the link between stations exist
		public bool LinkExists(Station to, Color color)
		{
			// Go over the list and check whether the link exists
			foreach (KeyValuePair<Station, Color> link in Links)
			{
				if (link.Key.Equals(to) && link.Value.Equals(color))
					return true;
			}
			return false;
		}

		// Checks whether current instance equals to the passed object
		public override bool Equals(object obj)
		{
			if (obj is Station)
			{
				Station station = (Station)obj;
				// ToLower is used because the station names are case-insensitive
				// See documentation for more information
				return this.Name.ToLower() == station.Name.ToLower();
			}
			else throw new ArgumentException();
		}

		// Returns a hash code of the name attribute
		public override int GetHashCode()
		{
			return this.Name.GetHashCode();
		}
	}
}
