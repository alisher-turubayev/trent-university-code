// Name: Alisher Turubayev	
// Code File: Assignment5
// Student Number: 0630908
// Assignment 5
// Program Description: This program consists of two classes: a dynamic Fraction
//    and a static Assignment5 (which contains Main()).  The sole purpose of
//    Main() is to test the various properties and methods of Fraction objects.

using System;

class Assignment5
{
    public static void Main ()
    {
        // constant declaration
        // QUIT_CODE: char. Stores the quit code
        char QUIT_CODE = 'Q';

        // variable declaration
        // fract{1,2}: Fraction. Stores the two fractions to test the Fraction class
        Fraction fract1, fract2;
        // fractNew: Fraction. Used to test the addition and multiplication properties
        Fraction fractNew;
        // isCycle: bool. Stores whether we need to continue cycle or not. True by default
        bool isCycle = true;
        // num/den: int. Stores the user input: numerator and denominator for the fraction
        int num, den;
        // userInput: char. Stores the user input for quiiting the cycle and stopping the program
        char userInput;

        // usage of no parameter constructor
        fract1 = new Fraction();

        // greet the user
        Console.WriteLine("Hello!");
        Console.WriteLine("Welcome to the new teaching system!");
        Console.WriteLine("Today, we will test how to use fractions");
        
        // start the loop
        do
        {
            // prompt the user to input the numerator for the first fraction
            Console.WriteLine("Please, input the numerator for the first fraction:");
            num = Convert.ToInt32(Console.ReadLine());

            // prompt the user to input the denominator for the first fraction
            Console.WriteLine("Please, input the denominator for the first fraction:");
            den = Convert.ToInt32(Console.ReadLine());

            // usage of two parameter constructor
            fract1 = new Fraction(num, den);

            // extra space for legibility
            Console.WriteLine();

            // prompt the user to input the numerator for the second fraction
            Console.WriteLine("Please, input the numerator for the second fraction:");
            num = Convert.ToInt32(Console.ReadLine());

            // prompt the user to input the denominator for the second fraction
            Console.WriteLine("Please, input the denominator for the second fraction:");
            den = Convert.ToInt32(Console.ReadLine());

            // usage of two parameter constructor
            fract2 = new Fraction(num, den);

            // output the fractions
            Console.WriteLine("The first fraction is: " + fract1.ToString());
            Console.WriteLine("The second fraction is: " + fract2.ToString());
            Console.WriteLine();

            // compare two fractions using overloaded operators
            Console.WriteLine("The first fraction is bigger than or equal to second: " +
                (fract1 >= fract2 ? "TRUE" : "FALSE"));
            Console.WriteLine("The first fraction is less than or equal to second: " +
                (fract1 <= fract2 ? "TRUE" : "FALSE"));
            Console.WriteLine();

            // add and multiply two fractions using overloaded operators
            fractNew = fract1 + fract2;
            Console.WriteLine("The new fraction after addition is: " + fractNew.ToString());
            fractNew = fract1 * fract2;
            Console.WriteLine("The new fraction after multiplication is: " + fractNew.ToString());
            Console.WriteLine();

            // prompt the user to leave, if necessary
            Console.WriteLine("If you want to leave, press {0}", QUIT_CODE);
            Console.WriteLine("Else, press any key:");
            userInput = Char.ToUpper(Convert.ToChar(Console.ReadLine()));

            // check whether the input is quit code
            if (userInput == QUIT_CODE)
            {
                // if yes, break the cycle
                isCycle = false;
            }
        } while (isCycle);

        // goodbye :D
        Console.WriteLine("Thank you for using our program!");
        Console.WriteLine("Goodbye!");
        Console.ReadLine();
    }
}
//Just Sayori :3