/* Student name: Alisher Turubayev
 * Student ID: 0630908
 * Program: this is a program to calculate the average salary for different degree types
 * The program checks whether the degree type is correct (i.e. a letter code) and whether the salary is negative
 * It is assumed that the salary is a number, so no checking for invalid data type is required
 * 
 * Notice! The salary of 0 is considered correct, thus it is used in the final calculation
 */
using System;

class Assignment2
{
    public static void Main ()
    {
        //const declaration
        //all degree codes are not hardcoded; instead, they are fully flexible.
        //if one wishes to change the code for a degree, they can change it here.
        //DEGREE_{HIGH_SCHOOL, UNIVERSITY, COLLEGE} - char. Used to determine the degree type
        const char DEGREE_HIGH_SCHOOL = 'H';
        const char DEGREE_UNIVERSITY = 'U';
        const char DEGREE_COLLEGE = 'C';
        //QUIT - char. Specifies the code to exit the program
        const char QUIT = 'Q';

        //variable declaration
        //total{University, College, HighSchool} - Decimal. Holds the sum of all salaries for a given category
        Decimal totalUniversity = 0.00m, totalCollege = 0.00m, totalHighSchool = 0.00m;
        //average{University, College, HighSchool} - Decimal. Holds the average (i.e. the final answer) for a given category
        Decimal averageUniversity, averageCollege, averageHighSchool;
        //num{University, College, HighSchool} - int. Counter. Counts the number of salaries for a given category
        int numUniversity = 0, numCollege = 0, numHighSchool = 0;
        //salaryData - Decimal. Holds the annual salary.
        Decimal salaryData;
        //userInput - string. Holds the user input. Used to maintain the data integrity
        string userInput;
        //edType - char. Holds the code for the current processing degree type
        char edType;

        //greet the user
        Console.WriteLine("Welcome to Statistics Canada!");
        Console.WriteLine("We have finally automated the process of calculating the average annual salary for different degree types");
        Console.WriteLine("Again, you can input '{0}' for university degree, '{1}' for college, or '{2}' for high school.", 
            DEGREE_UNIVERSITY, DEGREE_COLLEGE, DEGREE_HIGH_SCHOOL);
        Console.WriteLine("You can also type '{0}' to quit the program", QUIT);
        Console.WriteLine("Program initiated!\n");

        //prompt the user to seed the loop
        Console.Write("Enter the degree type ('{0}' to quit): ", QUIT);
        userInput = Console.ReadLine();
        edType = Char.ToUpper(Convert.ToChar(userInput));

        // if the user input (degree type) is incorrect, prompt the user to input again until the input is correct
        while (edType != QUIT && edType != DEGREE_UNIVERSITY && edType != DEGREE_COLLEGE && edType != DEGREE_HIGH_SCHOOL)
        {
            Console.Write("Invalid type of the degree, try again: ");
            userInput = Console.ReadLine();
            edType = Char.ToUpper(Convert.ToChar(userInput));
        }

        while (edType != QUIT)
        {
            // check for correctness of the degree code
            if (edType == DEGREE_UNIVERSITY || edType == DEGREE_COLLEGE || edType == DEGREE_HIGH_SCHOOL)
            {
                //prompt the user to input the salary
                Console.Write("Enter the annual salary: ");
                userInput = Console.ReadLine();
                salaryData = Convert.ToDecimal(userInput);

                //check if number is positive
                //note that the salary of 0 is considered a valid one
                if (salaryData < 0.00m)
                    Console.WriteLine("Salary is invalid, please try again.\n");
                else if (Char.ToUpper(edType) == DEGREE_UNIVERSITY)
                {
                    numUniversity++;
                    totalUniversity += salaryData;
                }
                else if (Char.ToUpper(edType) == DEGREE_COLLEGE)
                {
                    numCollege++;
                    totalCollege += salaryData;
                }
                else
                {
                    numHighSchool++;
                    totalHighSchool += salaryData;
                }
            }
            else
                Console.WriteLine("Invalid type of the degree, please try again.\n");

            //prompt the user for new input
            Console.Write("Enter the degree type ('{0}' to quit): ", QUIT);
            userInput = Console.ReadLine();
            edType = Char.ToUpper(Convert.ToChar(userInput));
        }

        // if there was no input, the total number of marks will be zero
        // we only do calculations when we have at least one mark
        if (numUniversity + numCollege + numHighSchool == 0)
            Console.WriteLine("No data was inputted. Hence, no data is available :(\n");
        else
        {
            // if there is data, we proceed to calculate the averageUniversity
            // if not, we equalize the averageUniversity to 0
            if (numUniversity > 0)
                averageUniversity = totalUniversity / (Decimal)numUniversity;
            else
                averageUniversity = 0.00m;

            // if there is data, we proceed to calculate the averageCollege
            // if not, we equalize the averageCollege to 0
            if (numCollege > 0)
                averageCollege = totalCollege / (Decimal)numCollege;
            else
                averageCollege = 0.00m;

            // if there is data, we proceed to calculate the averageHighSchool
            // if not, we equalize the averageHighSchool to 0
            if (numHighSchool > 0)
                averageHighSchool = totalHighSchool / (Decimal)numHighSchool;
            else
                averageHighSchool = 0.00m;

            // output the data in the neat manner :3
            // also, the ternary if is used to make the sentence grammatically correct c:
            Console.WriteLine("Among {0} with university degree, the average annual salary is {1:C}\n", 
                Convert.ToString(numUniversity) + (numUniversity == 1 ? " person" : " people"), averageUniversity);
            Console.WriteLine("Among {0} with college degree, the average annual salary is {1:C}\n",
                Convert.ToString(numCollege) + (numCollege == 1 ? " person" : " people"), averageCollege);
            Console.WriteLine("Among {0} with high school degree, the average annual salary is {1:C}\n",
                Convert.ToString(numHighSchool) + (numHighSchool == 1 ? " person" : " people"), averageHighSchool);
        }

        //good bye! :3
        Console.WriteLine("Thank you for using the Statistics Canada program!");
        Console.WriteLine("Good bye!");
        Console.ReadLine();
    }
    // Just Monika :D
}