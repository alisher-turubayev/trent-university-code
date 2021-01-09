// Name: Alisher Turubayev
// Student Number: 0630908
// Lab 4, Part 2
// Program Description: This program uses four user-defined methods: one
//    to input an array of numbers, one to compute the average the array, one 
//    to find the largest number in the array, and one to find the smallest 
//    number in the array.

using System;
public static class Lab4_2
{
    public static void Main()
    {
        int[] compStats = new int[25];
        int n = 0, large, small;
        double avg = 0;

        // Input values into the array
        InpArray(compStats, ref n);

        // Find the average of the elements in the array
        avg = FindAverage(compStats, n);

        // Find the largest element in the array
        large = FindLarge(compStats, n);

        // Find the smallest element in the array
        small = FindSmall(compStats, n);

        // Print out the results
        Console.WriteLine("\nThe Average of the array is {0:F}", avg);
        Console.WriteLine("\nThe largest element is {0}, the smallest is {1}", large, small);

        // Pause until user is done
        Console.ReadLine();
    }

    // Method:       InpArray
    // Description:  Input values into an array.
    // Parameters:   arrValues: the array to fill.
    //               num: number of elements in the array.
    // Returns:      void
    public static void InpArray(int[] arrValues, ref int num)
    {
        // input the number of data values to put in the array
        do
        {
            Console.Write("Enter the number of elements (<= 25) => ");
            num = Convert.ToInt32(Console.ReadLine());
        } while (num < 0 || num > 25);

        // loop to enter the values
        for (int i = 0; i < num; ++i)
        {
            Console.Write("Enter the Element {0} => ", i);
            arrValues[i] = Convert.ToInt32(Console.ReadLine());
        }
    }

    // Method:       FindAverage
    // Description:  Computes the average of the elements in the array.
    // Parameters:   arrVals: array to be processed
    //               num: number of elements in the array.
    // Returns:      the average of the elements in the array
    public static double FindAverage(int[] arrVals, int num)
    {
        // sum: double. Stores the sum of all values to find the average of the array.
        // avg: double. Stores the average of the values in the array.
        double sum = 0, avg = 0;
        
        // Add all values in the array
        for (int i = 0;i < num; i++)
        {
            sum += arrVals[i];
        }

        // average is sum over the number of elements in the array
        avg = sum / (double)num;
        // Return found value
        return avg;
    }

    // Method:       FindLarge
    // Description:  Determines the largest element in the array.
    // Parameters:   arrVals: array to be processed
    //               num: number of elements in the array.
    // Returns:      the largest element in the array
    public static int FindLarge(int[] arrVals, int num)
    {
        // largest: int. Stores the current largest element in the array.
        // Initially, it is the minimum possible value for the int data type. 
        int largest = int.MinValue;

        // find the largest value in the array
        for (int i = 0; i < num; i++)
        {
            // if the current value in the array is bigger, then equalize largest to that value
            if (largest < arrVals[i])
                largest = arrVals[i];
        }

        // Return found value
        return largest;
    }

    // Method:       FindSmall
    // Description:  Determines the smallest element in the array.
    // Parameters:   arrVals: array to be processed
    //               num: number of elements in the array.
    // Returns:      the smallest element in the array
    public static int FindSmall(int[] arrVals, int num)
    {
        // smallest: int. Stores the current smallest element in the array.
        // Initially, it is the maximum possible value for the int data type. 
        int smallest = int.MaxValue;

        // find the smallest value in the array
        for (int i = 0; i < num; i++)
        {
            // if the current value in the array is smaller, then equalize smallest to that value
            if (smallest > arrVals[i])
                smallest = arrVals[i];
        }

        // Return found value
        return smallest;
    }
}