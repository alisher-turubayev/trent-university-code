using System;
public static class Lab4_1
{
    public static void Main()
    {
        int[] dataArray = new int[10] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
        int n = 0;

        // Fill the array
        Fill(dataArray, ref n);

        // Display the array contents
        Dump(dataArray, n);

        // Display the array contents in reverse
        ReverseDump(dataArray, n);

        // Pause until user is done
        Console.ReadLine();
    }

    // Method:       Fill
    // Description:  Fill an array with values.
    // Parameters:   arrValues: the array to fill.
    //               num: number of elements in the array.
    // Returns:      void
    public static void Fill(int[] arrValues, ref int num)
    {
        // input the number of data values to put in the array
        do
        {
            Console.Write("Enter the number of elements (between 0 and 10) => ");
            num = Convert.ToInt32(Console.ReadLine());
        } while (num < 0 || num > 10);

        // loop to enter the values
        for (int i = 0; i < num; ++i)
        {
            Console.Write("Enter the Element {0} => ", i);
            arrValues[i] = Convert.ToInt32(Console.ReadLine());
        }
    }

    // Method:       Dump
    // Description:  Display the contents of an array.
    // Parameters:   arrVals: array to be displayed.
    //               num: number of elements in the array.
    // Returns:      void
    public static void Dump(int[] arrVals, int num)
    {
        // output the values from the array
        Console.WriteLine("The elements in the array are:");
        for (int i = 0; i < num; ++i)
            Console.WriteLine(" {0}", arrVals[i]);
    }

    // Method:       ReverseDump
    // Description:  Display the contents of an array in the reverse order.
    // Parameters:   arrItems: array to be displayed.
    //               num: number of elements in the array.
    // Returns:      void
    public static void ReverseDump(int[] arrItems, int num)
    {
        // output the values from the array
        Console.WriteLine("The elements in the array in reverse order are:");
        for (int i = num - 1; i >= 0; --i)
            Console.WriteLine(" {0}", arrItems[i]);
    }
}