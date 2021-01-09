using System;
using System.Collections.Generic;

namespace Range
{
	//
	// Summary:
	//		Runs a series of tests on AugmentedTreap class
	class Test
	{
		private static Random R = new Random();

		public static void Main ()
		{
			// Run 10 tests on random treaps
			for (int i = 0; i < 10; i++)
				TestTreapInt(R.Next(5) + 5);
			Console.ReadLine();
		}

		//
		// Summary:
		//		Runs a test on treap by populating it with random numbers from 1 to 100, 
		//		then querying it by InRange function. The result of InRange is tested 
		//      against array of same numbers. The function then deletes one value from 
		//      the treap and calls InRange(1, 100)
		// 
		// Parameters:
		//    numRange:
		//		The number of InRange queries to run on a treap
		private static void TestTreapInt (int numRange)
		{
			AugmentedTreap<int> treap = new AugmentedTreap<int>();
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
			Console.WriteLine("Query treap {0} times:", numRange);

			for (int i = 0; i < numRange; i++)
			{
				int left = R.Next(100) + 1, right = Math.Min(100, R.Next(100) + left + 1);
				Console.WriteLine("There are {0} items between {1} and {2}", 
					treap.InRange(left, right), left, right);
				Console.WriteLine("Array returns {0} items between {1} and {2}\n", 
					FindRangeArray(array, left, right), left, right);
			}

			treap.Remove(array[R.Next(array.Count)]);
			Console.WriteLine("There are {0} items between 1 and 100", 
				treap.InRange(1, 100));

			Console.WriteLine();
		}

		//
		// Summary:
		//		Returns the number of values between left and right boundaries (inclusive)
		//		in the List<int> object
		// 
		// Parameters:
		//    array:
		//		The array of type List<int> where to find the number of values
		//
		//    left:
		//		Left boundary
		//
		//    right
		//		Right boundary
		//
		// Returns:
		//		The number of items in array between left and right
		private static int FindRangeArray (List<int> array, int left, int right)
		{
			int indexLeft = 0;
			foreach (int item in array)
			{
				if (item > left)
					break;
				indexLeft++;
			}

			int indexRight = 0;
			foreach (int item in array)
			{
				if (item > right)
					break;
				indexRight++;
			}

			if (!array.Contains(left))
				return indexRight - indexLeft;

			return indexRight - indexLeft + 1;
		}
	}
}
