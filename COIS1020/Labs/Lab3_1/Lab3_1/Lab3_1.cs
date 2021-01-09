using System;
public static class Lab3_1
{
    public static void Main()
    {
        // declare variables
        int inpMark;
        string lastName;
        char grade = ' ';

        // enter the student's last name
        Console.Write("Enter the last name of the student => ");
        lastName = Console.ReadLine();
        // enter (and validate) the mark
        do
        {
            Console.Write("Enter a mark between 0 and 100 => ");
            inpMark = Convert.ToInt32(Console.ReadLine());
        } while (inpMark < 0 || inpMark > 100);

        // Use the method to convert the mark into a letter grade
        MarkToGrade(inpMark, ref grade);
        // print out the results
        Console.WriteLine("{0}'s mark of {1} converts to a {2}", lastName,
         inpMark, grade);
        Console.ReadLine();
    }

    // Method: MarkToGrade
    // Parameter
    //      mark: call by value parameter to be converted to a letter grade
    // Returns: the corresponding letter grade
    public static void MarkToGrade(int mark, ref char letterValue)
    {
        // multi-alternative If statement to determine letter grade
        if (mark > 0 && mark < 50)
            letterValue = 'F';
        else if (mark >= 50 && mark < 60)
            letterValue = 'D';
        else if (mark >= 60 && mark < 75)
            letterValue = 'C';
        else if (mark >= 75 && mark < 85)
            letterValue = 'B';
        else if (mark >= 85 && mark <= 100)
            letterValue = 'A';
        else
        {
            Console.WriteLine("***Error - invalid mark");
            letterValue = 'X';
        }
    }
}