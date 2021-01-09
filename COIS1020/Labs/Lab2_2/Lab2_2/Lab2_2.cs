using System;
public static class Lab2_2
{
    public static void Main()
    {
        int value = 0, sum = 0, count = 0;
        double average = 0.0;
        
        // if the inputted value is not the sentinel value, process it
        while (value >= 0)
        {
            // prompt the user to enter an integer
            Console.Write("Enter a positive integer (-1 to stop): ");
            value = Convert.ToInt32(Console.ReadLine());

            // Calculate the running total
            sum += value;         // same as sum = sum + value;   
            // Keep track of the number of inputted values 
            count++;              // same as count = count + 1;
        }

        // Calculate average (only if the user inputted any numbers
        if (count > 0)
            average = sum / (1.0 * count);
        else
            average = 0;
        
        // Print results
        Console.WriteLine("sum = {0}, count = {1}", sum, count);
        Console.WriteLine("average = {0:F2} ", average);
        Console.ReadLine();
    }
}
