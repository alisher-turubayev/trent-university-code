using System;
using System.Collections.Generic;

namespace Assignment1
{
	public class Polynomials
	{
		private List<Polynomial> P;

		// Creates an empty list of polynomials
		public Polynomials ()
		{
			P = new List<Polynomial>();
		}
		
		// Retrieves the polynomial at position i-1 in the list
		public Polynomial Retrieve (int i)
		{
			// If the position is correct, retrieve the item
			// Else, throw exception
			if (P.Count >= i - 1)
				return P[i - 1];
			else
				throw new ArgumentOutOfRangeException();
		}

		// Inserts the polynomial p into the list of polynomials
		public void Insert (Polynomial p)
		{
			// Create a variable that will store the position of the insertion
			int index = 0;

			// Go through the list and look for the first item smaller than the given p
			foreach (Polynomial current in P)
			{
				if (!current.Order(p))
					break;
				index++;
			}

			// Insert p in given position
			P.Insert(index, p);
		}

		// Deletes the polynomial at index i-1
		public void Delete (int i)
		{
			// We use predefined method RemoveAt
			// No error-checking required, as this method will throw ArgumentOutOfRangeException if needed
			P.RemoveAt(i - 1);
		}

		// Prints out the list of polynomials (beginning with polynomial 1)
		public void Print ()
		{
			if (P.Count == 0)
			{
				System.Console.WriteLine("Empty");
				return;
			}

			// Create a variable that stores the index of a current item starting at 1
			int index = 1;

			// Go through the list and output each polynomial with the index
			foreach (Polynomial current in P)
			{
				System.Console.Write(index.ToString() + ". ");
				current.Print();
				System.Console.WriteLine();

				// Increment the index
				index++;
			}
		}

		// Returns the number of items in the list
		public int Count ()
		{
			return P.Count;
		}
	}
}
