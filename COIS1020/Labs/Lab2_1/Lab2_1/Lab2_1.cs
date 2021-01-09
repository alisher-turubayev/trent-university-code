using System;

public static class Lab2_1
{
    public static void Main()
    {
        // declare the variables and constants
        const double FLAT = 1.25;
        double weight;
        double cost, pricePerKg = 0;

        // Input the weight
        Console.Write("Enter a positive weight of the package => ");
        weight = Convert.ToDouble(Console.ReadLine());

        // Determine the cost per kilogram
        if (weight <= 0)
            Console.WriteLine("*** Invalid weight");
        else if (weight < 1)
            pricePerKg = 0.25;
        else if (weight <= 3.5)
            pricePerKg = 0.5;
        else
            pricePerKg = 1.0;

        // Compute the cost to send the package
        if (weight > 0)
            cost = weight * pricePerKg + FLAT;
        else
            cost = 0;
        // Output the results
        Console.WriteLine("The cost to send the package is {0:C}", cost);
        Console.ReadLine();
    }
}
