using System;

namespace Rope
{
	interface IRope
	{
		void Insert(string S, int index);
		void Delete(int left, int right);
		string Substring(int left, int right);
		int Find(string S);
		char CharAt(int index);
		void Print();
	}


	class Rope : IRope
	{
		private const int JoinThreshold = 5;
		private const int SplitThreshold = 10;
		private const double RebalanceRatio = 1.2;

		public string Segment { get; set; }
		public int NumChars { get; set; }
		public Rope Left { get; set; }
		public Rope Right { get; set; }

		// Creates a rope with given string and adjusts it (i.e. splits if needed)
		public Rope(string segment)
		{
			Segment = segment;
			NumChars = segment.Length;
			Left = Right = null;
			Adjust();
		}

		// Inserts a string S on index into rope
		// Does nothing if index is out of bounds
		// Expected O(logN)
		public void Insert(string S, int index)
		{
			if (index < 0 || index >= NumChars)
				return;

			if (Segment != "")
			{
				// Split at index
				Split(index);

				// Create new rope from S and concatenate with Left of current Rope
				Rope temp = new Rope(S);
				Left.Concatenate(new Rope(Left.Segment), temp);
				
				// Concatenate Left and Right back into one rope
				Concatenate(Left, Right);
				// Adjust if needed (i.e. split if segment too long)
				Adjust();
			}
			else
			{
				if (index >= Left.NumChars)
					Right.Insert(S, index - Left.NumChars);
				else
					Left.Insert(S, index);
				NumChars = Left.NumChars + Right.NumChars;
			}
		}

		// Deletes a substring S[left, right] from rope
		// Does nothing if bounds are incorrect
		// O(N)
		public void Delete(int left, int right)
		{
			if (left > right || left < 0 || right >= NumChars)
				return;

			if (Segment != "")
			{
				string partLeft = Segment.Substring(0, left),
					partRight = Segment.Substring(Math.Min(right + 1, NumChars - 1), NumChars - right - 1);

				Segment = partLeft + partRight;
				NumChars = Segment.Length;
			}
			else
			{
				Right.Delete(Math.Max(0, left - Left.NumChars), right - Left.NumChars);
				Left.Delete(left, Math.Min(right, Left.NumChars - 1));
				NumChars = Left.NumChars + Right.NumChars;
				Adjust();
			}
		}

		// Returns substring S[left, right] (inclusive) or empty string if: 
		//	1. out of bounds;
		//  2. bounds are incorrect.
		// O(N)
		public string Substring(int left, int right)
		{
			if (left > right || left < 0 || right >= NumChars)
				return "";

			if (Segment != "")
				return Segment.Substring(left, right - left + 1);

			return Left.Substring(left, Math.Min(right, Left.NumChars - 1))
				+ Right.Substring(Math.Max(0, left - Left.NumChars + 1), right - Left.NumChars);
		}

		// Adjusts rope (concatenating small ropes together and diving long ones into two)
		// O(1)
		private void Adjust()
		{
			if (Segment != "")
			{
				if (Segment.Length >= SplitThreshold)
					Split(Segment.Length / 2);
			}
			else
			{
				if (Left == null || Right == null)
					return;

				else if (Left.NumChars == 0 || Right.NumChars == 0)
					Concatenate(Left, Right);

				else if (Left.Segment != "" && Right.Segment != "")
					Concatenate(Left, Right);
			}
		}

		// Concatenate two ropes into one
		// O(1)
		private void Concatenate(Rope a, Rope b)
		{
			if (a.NumChars == 0 ^ b.NumChars == 0)
			{
				if (a.NumChars == 0)
				{
					Segment = b.Segment;
					NumChars = b.NumChars;
					Left = b.Left;
					Right = b.Right;
				}
				else
				{
					Segment = a.Segment;
					NumChars = a.NumChars;
					Left = a.Left;
					Right = a.Right;
				}
				return;
			}
			else if (a.Segment == "" ^ b.Segment == "")
			{
				if (a.NumChars != 0 && b.NumChars != 0)
				{
					Left = a;
					Right = b;
					Segment = "";
					NumChars = Left.NumChars + b.NumChars;
					return;
				}
			}

			Segment = a.Segment + b.Segment;
			NumChars = Segment.Length;
			Left = Right = null;
		}

		// Split the rope into two on index
		// O(1)
		private void Split(int index)
		{
			if (Segment == "")
				return;

			index++;
			string leftSegment = Segment.Substring(0, index),
				rightSegment = Segment.Substring(index, Segment.Length - index);
			Left = new Rope(leftSegment);
			Right = new Rope(rightSegment);
			Segment = "";
		} 

		// Returns char at index, 'NUL' (ASCII 0) if out of bounds
		// Expected O(logN)
		public char CharAt(int index)
		{
			if (index < 0 || index > NumChars)
				return (char)0;

			if (Segment != "")
				return Segment[index];

			if (index > Left.NumChars)
				return Right.CharAt(index - Left.NumChars);
			return Left.CharAt(index);
		}

		// Finds index of first occurrence of S in rope, -1 if not found
		// O(N)
		public int Find(string S)
		{
			string text = ToString();
			for (int i = 0;i < text.Length - S.Length + 1; i++)
			{
				string buffer = text.Substring(i, S.Length);
				if (buffer == S)
					return i;
			}
			return -1;
		}

		// Prints the whole string to console (without saving)
		// O(N)
		public void Print()
		{
			if (Segment == "")
			{
				if (NumChars == 0)
					return;
				Left.Print();
				Right.Print();
			}
			else
				Console.Write(Segment);
		}

		// Returns the whole string 
		// O(N)
		public override string ToString()
		{
			if (Segment == "")
				return Left.ToString() + Right.ToString();
			return Segment;
		}
	}
}
