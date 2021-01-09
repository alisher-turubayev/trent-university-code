/* Student name: Alisher Turubayev
 * Student ID: 0630908
 * Program: this is a personal bank account manager
 * The program supports three operations: withdrawal, deposit and current balance output
 * It is assumed that the input is always correct data type, so no data integrity check is required
 * 
 * Notice! The withdrawal/deposit amount of 0 is considered wrong, so the user is prompt to enter the value again
*/
using System;

class Assignment3
{
    public static void Main()
    {
        //const declaration
        //CODE_{WITHDRAWAL, DEPOSIT, PRINT, QUIT}: char. Char codes for different operations
        const char CODE_WITHDRAWAL = 'W';
        const char CODE_DEPOSIT = 'D';
        const char CODE_PRINT = 'P';
        const char CODE_QUIT = 'Q';

        //variable declaration
        //transactionCode: char. Holds the current transaction
        char transactionCode;
        //balance: double. Holds the balance amount. Zero by default
        double balance = 0.0d;

        //greet the user
        Console.WriteLine("Hello to DT Bank!");
        Console.WriteLine("This is your personal bank account manager");
        Console.WriteLine("We are pleased to have you as a customer of DT Bank");
        Console.WriteLine("Remember, there are codes for operations you can use:\n");
        Console.WriteLine("{0} for money withdrawal", CODE_WITHDRAWAL);
        Console.WriteLine("{0} for money deposit", CODE_DEPOSIT);
        Console.WriteLine("{0} for displaying your current account balance", CODE_PRINT);
        Console.WriteLine("{0} to close your personal account manager\n", CODE_QUIT);

        //start the loop
        do
        {
            //prompt the user input and convert it to uppercase letter
            Console.Write("What transaction type you want to do? => ");
            transactionCode = Char.ToUpper(Convert.ToChar(Console.ReadLine()));

            switch (transactionCode)
            {
                case CODE_WITHDRAWAL:
                    Withdrawal(GetAmount(), ref balance);
                    break;
                case CODE_DEPOSIT:
                    Deposit(GetAmount(), ref balance);
                    break;
                case CODE_PRINT:
                    Print(balance);
                    break;
                case CODE_QUIT:
                    Console.WriteLine("Terminating the program...\n");
                    break;
                default:
                    Console.WriteLine("Transaction code incorrect, please try again.\n");
                    break;
            }
        } while (transactionCode != CODE_QUIT);

        //goodbye message :D
        Console.WriteLine("Thank you for using your personal account manager!");
        Console.WriteLine("And thank you for being a loyal DT customer!");
        Console.WriteLine("Goodbye!");
        Console.ReadLine();
    }

    /*
     * GetAmount: double
     * Parameters: none
     * Returns: double amount
     * Purpose: validate user input and return a valid number for withdrawal/deposit operations
     */
    public static double GetAmount()
    {
        //variable declaration
        //amount: double. Holds the value of the user input: withdrawal/deposit amount
        double amount;

        do
        {
            Console.WriteLine("What amount?");
            amount = Convert.ToDouble(Console.ReadLine());

            if (amount <= 0)
                Console.WriteLine("Invalid input: the number cannot be negative. Please, try again.");
        } while (amount <= 0);
        return amount;
    }

    /*
     * Withdrawal: void
     * Parameters: amount(double, by value): the amount of withdrawal 
     *             and balance(double, by reference): the current account balance
     * Returns: nothing
     * Purpose: to check and apply the withdrawal operation
     */
    public static void Withdrawal(double amount, ref double balance)
    {
        //const declaration
        //SERVICE_CHARGE: double. Flat charge of $1.50 is applied on each withdrawal.
        const double SERVICE_CHARGE = 1.50d;

        //variable declaration
        //totalAmount: double. Contains a total amount (amount + service charge).
        double totalAmount = amount + SERVICE_CHARGE;

        //I don't do the direct comparison between two doubles, as it can cause a precision error
        if (balance - totalAmount < 0)
        {
            //If there is not enough balance, transaction is denied.
            Console.WriteLine("Transaction failed. Not enough balance to make a transaction.");
        }
        else
        {
            //If enough, then deduce the amount from the balance.
            balance -= totalAmount;
            Console.WriteLine("Transaction successful! You have withdrawn {0:C}, service charge of {1:C} was applied.\n",
                amount, SERVICE_CHARGE);
        }
        //exit the method
        return;
    }

    /*
     * Deposit: void
     * Parameters: amount(double, by value): the amount of deposit
     *             and balance(double, by reference): the current account balance
     * Returns: nothing
     * Purpose: to apply the deposit operation
     */
    public static void Deposit(double amount, ref double balance)
    {
        //const declaration
        //BONUS: double. Flat bonus rate of 1% on transactions larger than $2000.00
        const double BONUS = 0.01d;
        //variable declaration
        //totalAmount: double. Stores total amount of deposit, with the flat bonus applied.
        double totalAmount;

        //check if bonus can be applied
        if (amount >= 2000.0)
            totalAmount = amount + amount * BONUS;
        else
            totalAmount = amount;

        //add the totalAmount to the balance
        balance += totalAmount;
        Console.WriteLine("Transaction successful! You have deposited {0:C}.\n", totalAmount);
    }

    /*
     * Print: void. 
     * Parameters: balance(by value): the current balance
     * Returns: nothing
     * Purpose: output balance in the formatted way (currency)
     */
    public static void Print(double balance)
    {
        //outputs the balance in the neat way
        Console.WriteLine("Your current bank balance is: {0:C}.\n", balance);
    }
    // Just Monika :3
}
