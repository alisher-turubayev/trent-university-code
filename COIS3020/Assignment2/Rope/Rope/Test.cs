using System;

namespace Rope
{ 
	class Test
	{
		static readonly string text = "Return the substring";
		static Random R = new Random();

		public static void Main ()
		{
			Rope rope = new Rope(text);

			// Testing insert at specific index
			rope.Insert("hi ", 2);
			// Testing insert at beginning
			rope.Insert("Op ", 0);
			// Testing insert with negative index
			rope.Insert("Lia", -1);
			// Testing insert at end
			rope.Insert("weS", rope.NumChars - 1);

			// Outputting the resultant rope
			rope.Print();
			Console.WriteLine();

			// Test delete five times
			for (int test = 0; test < 5; test++)
			{
				// Generate left and right bounds
				int left = R.Next(rope.NumChars), right = Math.Min(rope.NumChars - 1, R.Next(rope.NumChars) + left) - 1;
				Console.WriteLine("Deleting substring [{0}, {1}]", left, right);
				rope.Delete(left, right);

				if (rope.NumChars <= 1)
					break;

				// Print resultant rope
				rope.Print();
				Console.WriteLine("\n");
			}

			rope.Insert("Insert(S,i):Insert stringSat indexi(7 marks)", rope.NumChars - 1);
			// Test substring five times
			for (int test = 0; test < 5; test++)
			{
				// Generate left and right bounds
				int left = R.Next(rope.NumChars), right = Math.Min(rope.NumChars - 1, R.Next(rope.NumChars) + left) - 1;
				Console.WriteLine("Substring from {0} to {1} is {2}", 
					left, right, rope.Substring(left, right));
			}
			Console.WriteLine();

			// Test CharAt with index 0
			Console.WriteLine("Char at index 0 is {0}", rope.CharAt(0));
			// Test CharAt with last index
			Console.WriteLine("Char at index {0} is {1}", rope.NumChars - 1, rope.CharAt(rope.NumChars - 1));
			// Test out of bounds
			Console.WriteLine("Char at index -1 is {0}", rope.CharAt(-1));
			Console.WriteLine();

			// Test find with string known to be in rope
			Console.WriteLine("'Insert' starts on index {0}", rope.Find("Insert"));
			// Test find with string not in rope
			Console.WriteLine("'8' starts on index {0}", rope.Find("8"));
			// Test find with string at the end
			Console.WriteLine("'rks)' starts on index {0}", rope.Find("rks)"));
			Console.ReadLine();
		}
	}
}
