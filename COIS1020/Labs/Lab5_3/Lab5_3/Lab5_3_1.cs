// Name: Alisher Turubayev	
// Code File: Lab5_3_1.cs
// Student Number: 0630908
// Lab 5, Part 3
// Program Description: This program consists of two classes: a dynamic BankAccount
//    and a static BankAccountDemo (which contains Main()).  The sole purpose of
//    Main() is to test the various properties and methods of BankAccount objects.

using System;
public static class BankAccountDemo
{
    public static void Main()
    {
        int acctNumber;
        double amount;
        BankAccount savings = new BankAccount();
        BankAccount chequing = new BankAccount(12345, 350.45);
        BankAccount newAcct;

        // input a 5 digit account number and balance for savings
        do
        {
            Console.Write("Enter a 5-digit account number => ");
            acctNumber = Convert.ToInt32(Console.ReadLine());
        } while ((acctNumber < 10000) || (acctNumber > 99999));
        savings.AcctNum = acctNumber;

        // print out the account information
        Console.WriteLine("Account {0} contains {1:C2}", savings.AcctNum, savings.Balance);
        Console.WriteLine("Account {0} contains {1:C2}", chequing.AcctNum, chequing.Balance);

        // prompt the user to enter an amount to deposit to savings
        Console.Write("Enter the amount to deposit to account {0} => ", savings.AcctNum);
        amount = Convert.ToDouble(Console.ReadLine());

        // perform the deposit to savings
        savings.Deposit(amount);

        // print out the savings account information
        Console.WriteLine("Account {0} contains {1:C2}", savings.AcctNum, savings.Balance);

        // prompt the user to enter an amount to withdraw from chequing
        Console.Write("Enter the amount to withdraw from account {0} => ", chequing.AcctNum);
        amount = Convert.ToDouble(Console.ReadLine());

        // perform the withdrawal from chequing
        chequing.Withdrawal(amount);

        // print out the chequing account information
        Console.WriteLine("Account {0} contains {1:C2}", chequing.AcctNum, chequing.Balance);

        // apply the interest to savings
        savings.Interest();

        // print out the savings account information
        Console.WriteLine("Account {0} contains {1:C2}", savings.AcctNum, savings.Balance);

        // combine chequing and savings into newAcct using overloaded operator
        newAcct = chequing + savings;

        // print out the newAcct account information
        Console.WriteLine("Account {0} contains {1:C2}", newAcct.AcctNum, newAcct.Balance);
        Console.ReadLine();
    }
}