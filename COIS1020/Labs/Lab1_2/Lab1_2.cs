using System;

public static class Lab1_2
{
    public static void Main()
    {
        int idNum;
        double payRate, hours, taxRate, grossPay, netPay;
        string firstName, lastName;

        // prompt the user to enter employee's first name
        Console.Write("Enter employee's first name => ");
        firstName = Console.ReadLine();

        // prompt the user to enter employee's last name
        Console.Write("Enter employee's last name => ");
        lastName = Console.ReadLine();

        // prompt the user to enter a six digit employee number
        Console.Write("Enter a six digit employee's ID => ");
        idNum = Convert.ToInt32(Console.ReadLine());

        // prompt the user to enter the number of hours employee worked
        Console.Write("Enter the number of hours employee worked => ");
        hours = Convert.ToDouble(Console.ReadLine());

        // prompt the user to enter the employee's hourly pay rate
        Console.Write("Enter employee's hourly pay rate: ");
        payRate = Convert.ToDouble(Console.ReadLine());

        // prompt the user to enter the tax rate
        Console.Write("Enter the tax rate (in per cents): ");
        taxRate = Convert.ToDouble(Console.ReadLine());

        // calculate gross pay
        grossPay = hours * payRate;

        // calculate net pay
        // .0 are used to maintain the data type double
        netPay = grossPay * (1.0 - taxRate / 100.0);

        // output results
        Console.WriteLine("{0}: {1} => {2:C}", lastName, idNum, netPay);
        Console.ReadLine();
    }
}