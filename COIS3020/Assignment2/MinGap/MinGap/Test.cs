using System;
using System.Collections.Generic;

namespace MinGap
{
	//
	// Summary:
	//		Runs a series of tests on AugmentedTreap class
	class Test
	{
		private static Random R = new Random();

		public static void Main()
		{
			// Run 10 tests on random treaps
			for (int i = 0; i < 10; i++)
				TestTreapInt();
			Console.ReadLine();
		}

		//
		// Summary:
		//		Runs a test on treap by populating it with random numbers from 1 to 100, 
		//		and outputting MinGap. Then, it deletes one random value from the treap and
		//		outputs the MinGap again. It repeats this process until the treap contains only
		//		one value.
		private static void TestTreapInt()
		{
			AugmentedTreap treap = new AugmentedTreap();
			List<int> array = new List<int>();

			// Add items
			for (int i = 1; i <= 100; i += R.Next(10) + 1)
			{
				treap.Add(i);
				array.Add(i);
			}

			Console.WriteLine("The treap contains {0} items", treap.Size());
			treap.Print();
			Console.WriteLine();

			while (treap.Size() > 1)
			{
				Console.WriteLine("Min gap for treap is {0}", treap.MinGap());
				Console.WriteLine();

				int removed = array[R.Next(array.Count)];
				Console.WriteLine("Removing value {0}...", removed);

				array.Remove(removed);
				treap.Remove(removed);
			}
			Console.WriteLine();
		}
	}
}
