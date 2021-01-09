// Name: Alisher Turubayev
// Student Number: 0630908
// Lab 3, Part 2
// Program Description: This program uses two user defined methods to compute 
//    the gross pay and net pay for an employee after entering the employee's
//    last name, hours worked, hourly rate, and percentage of tax.

using System;
public static class Lab3_2
{
    public static void Main()
    {
        // declare variables
        int hrsWrked;
        double ratePay, taxRate, grossPay, netPay = 0;
        string lastName;

        // enter the employee's last name
        Console.Write("Enter the last name of the employee => ");
        lastName = Console.ReadLine();

        // enter (and validate) the number of hours worked (positive number)
        do
        {
            Console.Write("Enter the number of hours worked (> 0) => ");
            hrsWrked = Convert.ToInt32(Console.ReadLine());
        } while (hrsWrked < 0);

        // enter (and validate) the hourly rate of pay (positive number)
        do
        {
            Console.Write("Enter the rate of pay per hour (> 0) => ");
            ratePay = Convert.ToDouble(Console.ReadLine());
        } while (ratePay < 0);

        // enter (and validate) the percentage of tax (between 0 and 1)
        do
        {
            Console.Write("Enter the tax percentage (0 <= x <= 1) => ");
            taxRate = Convert.ToDouble(Console.ReadLine());
        } while (taxRate > 1 || taxRate < 0);

        // Call a method to calculate the gross pay + overtime pay (calls by value) 
        grossPay = CalculateGross(hrsWrked, ratePay);
        grossPay += CalculateOT(hrsWrked, ratePay);

        // Invoke a method to calculate the net pay (call by reference)
        CalculateNet(grossPay, taxRate, ref netPay);

        // print out the results
        Console.WriteLine("{0} worked {1} hours at {2:C} per hour", lastName,
                          hrsWrked, ratePay);
        Console.WriteLine("They earned {0:C} in total, {1:C} after taxes", grossPay, netPay);
        Console.ReadLine();
    }

    // Method: CalculateGross
    // Parameters
    //      hours: integer storing the number of hours of work
    //      rate: double storing the hourly rate
    // Returns: double storing the computed gross pay
    public static double CalculateGross(int hours, double rate)
    {
        //variable declaration
        //grossPay: double storing the computed gross pay
        double grossPay;

        //calculate the result
        grossPay = (double)hours * rate;
        //return the computer gross pay
        return grossPay;
    }

    // Method: CalculateOT
    // Parameters
    //      hours: int storing the number of hours of work
    //      rate: double storing the hourly rate
    // Returns: double storing the computer overtime pay
    public static double CalculateOT(int hours, double rate)
    {
        //const declaration
        //OVERTIME_RATE: double storing the flat rate of overtime pay
        const double OVERTIME_RATE = 0.5d;
        //variable declaration
        //overtimePay: double storing the computer overtime pay
        double overtimePay;

        //if the number of hours is bigger than 40, calculate the overtime pay
        if (hours > 40)
        {
            hours -= 40;
            overtimePay = hours * rate * OVERTIME_RATE;
        }
        //else, set overtimePay to 0
        else
            overtimePay = 0;

        return overtimePay;
    }

    // Method: CalculateNet
    // Parameters
    //      grossP: double storing the grossPay
    //      tax: double storing tax percentage to be removed from gross pay
    //      netP: call by reference double storing the computed net pay
    // Returns: void 
    public static void CalculateNet(double grossP, double tax, ref double netP)
    {
        netP = grossP - grossP * tax;
    }
}