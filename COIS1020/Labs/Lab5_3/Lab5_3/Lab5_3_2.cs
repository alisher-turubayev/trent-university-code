// BankAccount Class
// Class Description: Objects of this class will possess the data and operations
//    consistent with bank accounts.  There are two private data members to 
//    store the account number and balance.  The account number has a read/write
//    property while the property for balance is read-only. The balance is updated
//    using one of the methods: Deposit, Withdrawal, or Interest. Finally, there
//    is an overloaded operator that permits two bank account objects to be 
//    combined to create a new bank account.

using System;
public class BankAccount
{
    private int acctNum;
    private double balance;
    public const double SERVICE_CHARGE = 1.00;  // for Withdrawals only
    public const double INTEREST_RATE = 0.015;  // fixed interest rate

    // no arg constructor
    public BankAccount()
    {
        acctNum = 0;
        balance = 0;
    }

    // two arg constructor
    public BankAccount(int aNumber, double bal)
    {
        acctNum = aNumber;
        // ensuring the balance is not negative
        if (bal < 0)
            balance = 0;
        else
            balance = bal;
    }

    // AcctNum Property
    public int AcctNum
    {
        set
        { acctNum = value; }
        get
        { return acctNum; }
    }

    // Balance Property (read-only)
    public double Balance
    {
        get
        { return balance; }
    }

    // Deposit Method
    public void Deposit(double amt)
    {
        // check to see that the deposit amount is positive
        if (amt > 0)
            balance += amt;
    }

    // Withdrawal Method (a Service Charge)
    public void Withdrawal(double amt)
    {
        if (amt > 0 && balance >= amt + SERVICE_CHARGE)
            balance -= amt + SERVICE_CHARGE;
    }

    // instance method to add interest onto the balance
    public void Interest()
    {
        balance += balance * INTEREST_RATE;
    }

    // overloaded operator + to combine the contents of two accounts
    //        Assume new account number will be the average of the 
    //        two account numbers and the balance will be the sum
    // Parameters: the two accounts to be combined
    // Returns: the new account with the 
    public static BankAccount operator +(BankAccount acc1, BankAccount acc2)
    {
        BankAccount acc3 = new BankAccount();

        acc3.acctNum = (acc1.acctNum + acc2.acctNum) / 2;
        acc3.balance = acc1.balance + acc2.balance;

        return acc3;
    }
}