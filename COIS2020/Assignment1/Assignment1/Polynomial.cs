using System;

namespace Assignment1
{
	// User-defined interface with single defined method Order
	interface IDegree
	{
		bool Order(Object obj);
	}

	public class Polynomial : IDegree
	{
		// A reference to the first node of a singly-linked list
		// Note that the first node is a dummy node that just contains the reference to the next node
		private Node<Term> front;

		// Creates a polynomial 0
		public Polynomial ()
		{
			// Create a node with both references null
			// Needed for later checking (see void AddTerm)
			this.front = new Node<Term>(null, null);
		}

		// Inserts the given term t into the current polynomial in its proper order
		public void AddTerm (Term t)
		{
			// Create a pointer to move along the list
			Node<Term> current = this.front;
			
			// Move the pointer while the next node is available and it is bigger than the t
			while (current.Next != null && current.Next.Item.CompareTo(t) == 1 && current.Next.Item.Exponent != t.Exponent)
				current = current.Next;
			
			// Check whether exponent of t is not equal to the exponent of the current term
			// If equal, add the coefficients together
			// Else, create a deep copy of the term and add it to the polynomial
			if (current.Next != null && current.Next.Item.Exponent == t.Exponent)
				current.Next.Item.Coefficient += t.Coefficient;
			else
				current.Next = new Node<Term>((Term)t.Clone(), current.Next);
		}

		// Adds the given polynomials p and q to yield a new polynomial
		public static Polynomial operator+ (Polynomial p, Polynomial q)
		{
			// Create a polynomial that stores the result
			Polynomial result = new Polynomial();

			// Create two pointers for each of the polynomials
			Node<Term> currentP = p.front.Next, currentQ = q.front.Next;

			// Go through the both polynomials
			while (currentP != null || currentQ != null)
			{
				// Check if one is bigger than the other
				if (currentP == null || (currentQ != null && currentQ.Item.CompareTo(currentP.Item) >= 0))
				{
					// Add a term from first polynomial
					result.AddTerm((Term)currentQ.Item.Clone());
					currentQ = currentQ.Next;
				}
				else if (currentQ == null || (currentP != null && currentP.Item.CompareTo(currentQ.Item) >= 0))
				{
					// Add a term from second polynomial
					result.AddTerm((Term)currentP.Item.Clone());
					currentP = currentP.Next;
				}
			}

			return result;
		}
		
		// Multiplies the given polynomials p and q to yield a new polynomial
		public static Polynomial operator* (Polynomial p, Polynomial q)
		{
			// Create a polynomial that stores the result
			Polynomial result = new Polynomial();
			// Create two pointers for two polynomials
			Node<Term> currentP = p.front.Next, currentQ = q.front.Next;

			// Multiply each term by second polynomial (fountain priniciple)
			while (currentP != null)
			{
				// Create a temporary polynomial to store result for one term multiplication
				Polynomial temporary = new Polynomial();
				
				// Go through the second polynomial and multiply it out
				while (currentQ != null)
				{
					Term newTerm = new Term(currentP.Item.Coefficient * currentQ.Item.Coefficient,
						(byte)(currentP.Item.Exponent + currentQ.Item.Exponent));
					temporary.AddTerm(newTerm);

					currentQ = currentQ.Next;
				}

				// Add the temporary polynomial to the overall result
				result = result + temporary;

				// Move the first pointer to the next node, return the second pointer back to beginning
				currentP = currentP.Next;
				currentQ = q.front.Next;
			}

			return result;
		}

		// Evaluates the current polynomial for a given x
		public double Evaluate (double x)
		{
			// Create a variable that stores the result
			double result = 0.0;
			// Create a pointer to go through the list
			Node<Term> current = this.front.Next;

			// Add each term to the result
			while (current != null)
			{
				result += current.Item.Evaluate(x);
				current = current.Next;
			}

			return result;
		}

		// Outputs a string representation of a polynomial
		public void Print ()
		{
			// Create a string that will contain the result
			String result = "";
			// Create a pointer to move along the list
			Node<Term> current = this.front.Next;

			// If the list is empty, return "0"
			// Else, go through the list adding terms
			if (current == null)
				result = "0";
			else
			{
				while (current != null)
				{				
					result += current.Item.ToString();
					current = current.Next;

					if (current != null && current.Item.Coefficient > 0)
						result += "+";
				}
			}
			// Write the result
			System.Console.WriteLine(result);
		}

		// Returns true if the current polynomial has a degree greater than or equal to the given polynomial (obj)
		public bool Order (Object obj)
		{
			// Compare if the passed object is of class Polynomial
			if (obj is Polynomial)
			{
				// Convert to polynomial
				Polynomial p = (Polynomial)obj;

				// Create two pointers for two polynomials
				Node<Term> current1 = this.front.Next, current2 = p.front.Next;

				// Check by terms
				while (current1 != null && current2 != null)
				{
					if (current1.Item.CompareTo(current2.Item) == 1)
						return true;
					else if (current1.Item.CompareTo(current2.Item) == -1)
						return false;

					current1 = current1.Next;
					current2 = current2.Next;
				}

				// If the second polynomial ended first, return true
				// If they are equal, or the first polynomial ended first, return false
				if (current2 == null)
					return true;
				return false;
			}
			else
			{
				throw new Exception("Cannot compare");
			}
		}
		
		// Deletes all terms with coefficient 0
		public void Trim ()
		{
			Node<Term> current = this.front;

			// Go through the array and delete all terms with coefficient 0
			while (current != null && current.Next != null)
			{
				if (current.Next.Item.Coefficient == 0.0)
				{
					current.Next = current.Next.Next;
				}
				current = current.Next;
			}
		}
	}
}
