using System;
using System.Collections.Generic;

namespace Assignment3
{
	//
	// Summary:
	//		Class that tests the functionality of 2-3-4 tree implementation
	class Test
	{
		private static Random rand = new Random();

		public static void Main (string[] args)
		{
			// Run the tests; 5 by default
			int numTests;
			if (args.Length == 1 && Int32.TryParse(args[0], out numTests))
				RunTests(numTests);
			else
				Console.WriteLine("Incorrect number of arguments; specify one number: # of tests to run");

			Console.ReadLine();
		}

		private static void RunTests(int numTests)
		{
			while(numTests > 0)
			{
				numTests--;

				Tree<int> tree = new Tree<int>();
				List<int> list = new List<int>();

				// Test delete without any items
				tree.Delete(rand.Next());
				
				// Insert 20 values into the tree (note that duplicate values are not inserted)
				for (int i = 0;i < 20; i++)
				{
                    int item = -1;
                    while (item < 0 || list.Contains(item)) {
					    item = rand.Next(100) + 1;
                    }
					tree.Insert(item);
					list.Add(item);
				}

                for (int i = 0; i < list.Count; i++)
                    Console.Write("{0} ", list[i]);
                Console.WriteLine();

                // Test printing
                tree.Print();

                // Test converting to Red-Black tree
                RBTree<int> rbtree = tree.Convert();
                rbtree.Print();

				// Randomize for delete testing
				list = Randomize<int>(list);

				// Check if all items are in
				for (int i = 0; i < list.Count; i++)
					if (!tree.Contains(list[i]))
						Console.WriteLine("Something horrible happened here.");

				// Test delete
				for (int i = 0; i < list.Count; i++)
					tree.Delete(list[i]);

				// Output the number of items
				Console.WriteLine("The item count is (should be 0): {0}", tree.Size());

                // Test inserting them back
                for (int i = 0; i < list.Count; i++)
                    tree.Insert(list[i]);

                // Output the number of items
                Console.WriteLine("The item count is (should be {0}): {1}", list.Count, tree.Size());
                Console.WriteLine();
			}
		}

		// Randomizes the items in the list
		private static List<T> Randomize<T>(List<T> input)
		{
			List<T> output = new List<T>();

			while (input.Count > 0)
			{
				int index = rand.Next(0, input.Count);
				output.Add(input[index]);
				input.RemoveAt(index);
			}

			return output;
		}
	}
}
