using System;

namespace Assignment1
{ 
	public class Term : IComparable, ICloneable
 	{
		private double coefficient;
		private byte exponent;

		// Creates a term with the given coefficient and exponent
		public Term (double coefficient, byte exponent)
		{
			this.coefficient = coefficient;
			this.exponent = exponent;
		}
		
		// Read/write properties for each data member
		public double Coefficient
		{
			get
			{
				return coefficient;
			}
			set
			{
				coefficient = value;
			}
		}
		public byte Exponent
		{
			get
			{
				return exponent;
			}
			set
			{
				exponent = value;
			}
		}

		// Evaluates the current term for a given x
		public double Evaluate (double x)
		{
			double result = coefficient;

			for (int i = 1; i <= this.exponent; i++)
				result *= x;

			return result;
		}

		// Returns -1, 0, or 1 if the exponent of the current term
		// is less than, equal to, or greater than the exponent of obj
		public int CompareTo (Object obj)
		{
			if (obj is Term)
			{
				Term term = (Term)obj;
				if (this.exponent == term.exponent)
				{
					if (this.Coefficient > term.Coefficient)
						return 1;
					else if (this.Coefficient < term.Coefficient)
						return -1;
					return 0;
				}
				else
				{
					if (this.Exponent > term.Exponent)
						return 1;
					return -1;
				}
			}
			else
			{
				throw new Exception("Cannot compare");
			}
		}

		// Returns a string representation of a term
		public override string ToString()
		{
			// Check whether the exponent is one or zero and output the correct notation
			if (exponent > 1)
			{
				// Omit the coefficient if 1 or -1
				if (this.coefficient == 1)
					return "x^" + this.exponent.ToString();
				else if (this.coefficient == -1)
					return "-x^" + this.exponent.ToString();
				return this.coefficient.ToString() + "x^" + this.exponent.ToString();
			}
			else if (exponent == 1)
			{
				// Omit the coefficient if 1 or -1
				if (this.coefficient == 1)
					return "x";
				else if (this.coefficient == -1)
					return "-x";
				return this.coefficient.ToString() + "x";
			}
			else
				return this.coefficient.ToString();
		}


		public object Clone()
		{
			Term term = (Term)this.MemberwiseClone();
			term.coefficient = (double)this.coefficient;
			term.exponent = (byte)this.exponent;
			return term;
		}
	}
}
