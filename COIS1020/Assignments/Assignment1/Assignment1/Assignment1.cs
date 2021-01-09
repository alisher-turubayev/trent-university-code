/*
* Student name: Alisher Turubayev
* Student ID: 0630908
* Program: this is a program to calculate the amount of money a user should pay based on how much donuts they bought. 
* The program checks if the user has inputted a negative number, but the 0 is percieved as a valid purchase.
* It is assumed that the input is a number, so no checking for invalid data type is required
* The last name of the user is assumed to be always correct, so the program does not check the lastName variable. 
*/
using System;

class Assignment1
{
    public static void Main()
    {
        // constants declaration
        const Decimal premiumCharge = 0.25m;
        const Decimal taxHST = 0.13m;

        // variables declaration    
        Decimal subTotalCost, totalCost, costPerDonut;
        Int64 donutsPurchased;
        String lastName;

        // greet the user
        Console.WriteLine("Welcome to Rich Horton's!");
        Console.WriteLine("This is an automated donut purchasing system!\n");
        Console.WriteLine("Notice: because of high donut demand, we are charging you 25 cents extra.");
        Console.WriteLine("Thank you for your understanding\n");

        // prompt the user to input the last name and save it in lastName 
        Console.Write("In order to use your membership, you need to provide us your surname: ");
        lastName = Console.ReadLine();

        // prompt the user to input the number of donuts to purchase and save it in donutsPurchased
        Console.Write("Input the number of donuts you want to buy today: ");
        donutsPurchased = Convert.ToInt64(Console.ReadLine());

        // if statement: because the cost per donut depends on the number of donuts purchased, 
        // we are checking the number of the donuts to adjust the costPerDonut variable

        if (donutsPurchased <= 7)
            costPerDonut = 1.00m;
        else if (donutsPurchased < 15)
            costPerDonut = 0.90m;
        else
            costPerDonut = 0.75m;

        // calculate the subtotal (without tax)
        subTotalCost = costPerDonut * Convert.ToDecimal(donutsPurchased) + premiumCharge;

        // calculate the total (tax is applied only if the number of the donuts is 12 or more)
        if (donutsPurchased < 12)
            totalCost = subTotalCost + subTotalCost * taxHST;
        else
            totalCost = subTotalCost;

        // output the lastName, donutsPurchased and totalCost in a neat sentence :3
        if (donutsPurchased < 0)
            Console.WriteLine("Dear customer, your input was invalid, and no donuts were purchased :)\n");
        else if (donutsPurchased == 1)
            Console.WriteLine("Dear {0}, you bought {1} donut, and your total is: {2:C}\n",
            lastName, donutsPurchased, totalCost);
        else
            Console.WriteLine("Dear {0}, you bought {1} donuts, and your total is: {2:C}\n",
            lastName, donutsPurchased, totalCost);

        // bye message!
        Console.WriteLine("Thank you for using Rich Horton's automated donut purchasing system!");
        Console.WriteLine("Have a great day!");
        Console.ReadLine();
    }
    //Just Monika :3
}