/* Program for Assignment 1 - COIS 2020
 * 
 * Written by Alisher Turubayev and Vanshree Mathur,
 *	Trent University
 * 
 * Purpose: this was written to demonstrate the knowledge of singly-linked lists and List<T> class
 * 
 * Functions: Univariative polynomial list manipulator allows the user to create a new univariative polynomial,
 *	add it to a list of polynomials, manipulate the entries in the list (add or multiply two entries, 
 *	delete an entry, or evaluate the polynomial).
 *	
 * Uses Polynomials, Polynomial, Term classes. 
*/
namespace Assignment1
{
	public class Console
	{
		// Main program method - initialized with start of a program
		public static void Main()
		{
			// Variables for operation letter codes
			const char CODE_CREATE = 'C';
			const char CODE_ADD = 'A';
			const char CODE_MULTIPLY = 'M';
			const char CODE_DELETE = 'D';
			const char CODE_EVALUATE = 'E';
			const char CODE_QUIT = 'Q';
			// Variable to store the user's input
			char userInput;
			// List of polynomials
			Polynomials list = new Polynomials();

			// Program introduction
			System.Console.WriteLine("Hello! And welcome to UPLM! (univariable polynomial list manipulator)\n");
			System.Console.WriteLine("There are several commands available for you,");
			System.Console.WriteLine("and they are accessible by letter codes.\n");

			// Letter codes declaration
			System.Console.WriteLine("Use '{0}' to create and add a polynomial to the list", CODE_CREATE);
			System.Console.WriteLine("Use '{0}' to add two polynomials in the list and insert the result into the list", 
				CODE_ADD);
			System.Console.WriteLine("Use '{0}' to multiply two polynomials in the list and insert the result into the list", 
				CODE_MULTIPLY);
			System.Console.WriteLine("Use '{0}' to delete a polynomial at a certain position in the list", CODE_DELETE);
			System.Console.WriteLine("Use '{0}' to evaluate a certain polynomial with a given x", CODE_EVALUATE);
			System.Console.WriteLine("Use '{0}' to quit the program\n", CODE_QUIT);

			// Prompt the user to input the first command
			System.Console.WriteLine("Please, choose the first command:");
			userInput = GetUserInputChar(System.Console.ReadLine());

			// Start the loop
			while (userInput != 'Q')
			{
				// Output the empty line for easy-to-read formatting
				System.Console.WriteLine();

				// Start a method corresponding to the operation
				switch (userInput)
				{
					case CODE_CREATE:
						Create(list);
						break;
					case CODE_ADD:
						AddPolynomials(list);
						break;
					case CODE_MULTIPLY:
						MultiplyPolynomials(list);
						break;
					case CODE_DELETE:
						DeletePolynomial(list);
						break;
					case CODE_EVALUATE:
						EvaluatePolynomial(list);
						break;
					default:
						System.Console.WriteLine("Wrong code provided");
						break;
				}

				// Output the current list
				System.Console.WriteLine("\nCurrently, the list is:");
				list.Print();
				System.Console.WriteLine("\n");

				// Prompt the user to input the next command
				System.Console.WriteLine("Please, choose the next command:");
				userInput = char.ToUpper(GetUserInputChar(System.Console.ReadLine()));
			}

			System.Console.WriteLine("Thank you for using our program!");
			System.Console.WriteLine("Press 'Enter' to close the program");
			System.Console.ReadLine();
		}
		 
		// Method to handle create operation
		public static void Create (Polynomials p)
		{
			// Variable for stop code
			const string CODE_STOP = "STOP";
			// New polynomial to be added to a list
			Polynomial polynomial = new Polynomial();
			
			// Variables for user input
			string userInput = "";
			double coefficient;
			byte exponent;

			// Declare a stop code 
			System.Console.WriteLine("Use '{0}' command to stop accepting new entries", CODE_STOP);

			while (userInput.ToUpper() != CODE_STOP)
			{
				// Prompt the user to input coefficient
				System.Console.WriteLine("Please, input the coefficient of the term:");
				userInput = System.Console.ReadLine();

				// Check for stop command
				if (userInput.ToUpper() == CODE_STOP)
					break;

				coefficient = GetUserInputDouble(userInput);
				
				// Prompt the user to input exponent
				System.Console.WriteLine("Please, input the exponent of the term:");

				userInput = System.Console.ReadLine();

				// Check for stop command
				if (userInput.ToUpper() == CODE_STOP)
					break;

				exponent = GetUserInputByte(userInput);
				
				// Add a term to the polynomial
				polynomial.AddTerm(new Term(coefficient, exponent));
			}

			// Remove all zero-coefficient terms
			polynomial.Trim();

			// Print out the resultant polynomial 
			System.Console.WriteLine("Resultant polynomial is:");
			polynomial.Print();

			p.Insert(polynomial);
		}

		// Method to handle add operation
		public static void AddPolynomials (Polynomials p)
		{
			if (p.Count() == 0)
			{
				System.Console.WriteLine("Cannot perform operation with zero items in the list");
				return;
			}

			// Variables to store user input
			// Note that they are equal to list size + 1, because we need to seed the loop for index validation
			int index1 = p.Count() + 1, index2 = p.Count() + 1;

			// Prompt the user to input first index
			System.Console.WriteLine("Please, input the index of the first polynomial to add:");

			// Start 'index in bounds' validation loop
			while (index1 > p.Count() || index1 < 1)
			{
				index1 = GetUserInputInt(System.Console.ReadLine());

				if (index1 <= p.Count() && index1 > 0)
					break;

				System.Console.WriteLine("Index out of bounds, please try again:");
			}

			// Prompt the user to input second index
			System.Console.WriteLine("Please, input the index of the second polynomial to add:");

			while (index2 > p.Count() || index2 < 1)
			{
				index2 = GetUserInputInt(System.Console.ReadLine());

				if (index2 <= p.Count() && index2 > 0)
					break;

				System.Console.WriteLine("Index out of bounds, please try again:");
			}

			// Add two polynomials and trim the result
			Polynomial result = p.Retrieve(index1) + p.Retrieve(index2);
			result.Trim();

			// Output the result
			System.Console.WriteLine("The resultant polynomial is:");
			result.Print();

			p.Insert(result);
		}

		// Method to handle multiply operation
		public static void MultiplyPolynomials (Polynomials p)
		{
			if (p.Count() == 0)
			{
				System.Console.WriteLine("Cannot perform operation with zero items in the list");
				return;
			}

			// Variables to store user input
			// Note that they are equal to list size + 1, because we need to seed the loop for index validation
			int index1 = p.Count() + 1, index2 = p.Count() + 1;

			// Prompt the user to input first index
			System.Console.WriteLine("Please, input the index of the first polynomial to multiply:");

			// Start 'index in bounds' validation loop
			while (index1 > p.Count() || index1 < 1)
			{
				index1 = GetUserInputInt(System.Console.ReadLine());

				if (index1 <= p.Count() && index1 > 0)
					break;

				System.Console.WriteLine("Index out of bounds, please try again:");
			}

			// Prompt the user to input second index
			System.Console.WriteLine("Please, input the index of the second polynomial to mutiply:");
			while (index2 > p.Count() || index2 < 1)
			{
				index2 = GetUserInputInt(System.Console.ReadLine());

				if (index2 <= p.Count() && index2 > 0)
					break;

				System.Console.WriteLine("Index out of bounds, please try again:");
			}
			
			// Multiply two polynomials and trim the result
			Polynomial result = p.Retrieve(index1) * p.Retrieve(index2);
			result.Trim();

			// Output the result
			System.Console.WriteLine("The resultant polynomial is:");
			result.Print();

			p.Insert(result);
		}
	
		// Method to handle delete operation
		public static void DeletePolynomial (Polynomials p)
		{
			if (p.Count() == 0)
			{
				System.Console.WriteLine("Cannot perform operation with zero items in the list");
				return;
			}

			// Variable to store user input
			// Note that it is equal to list size + 1, for because we need to seed the loop for index validation 
			int index = p.Count() + 1;

			// Prompt the user to input the index
			System.Console.WriteLine("Please, input the index of polynomial you wish to delete:");

			// Start 'index in bounds' validation loop
			while (index > p.Count() || index < 1)
			{
				index = GetUserInputInt(System.Console.ReadLine());

				if (index <= p.Count() && index > 0)
					break;

				System.Console.WriteLine("Index out of bounds, please try again:");
			}

			// Delete the polynomial from the list
			p.Delete(index);
		}
		
		// Method to handle evaluate operation
		public static void EvaluatePolynomial (Polynomials p)
		{
			if (p.Count() == 0)
			{
				System.Console.WriteLine("Cannot perform operation with zero items in the list");
				return;
			}

			// Variables to store user input
			// Note that index is equal to list size + 1, for because we need to seed the loop for index validation 
			int index = p.Count() + 1;
			double value;

			// Prompt the user to input the index
			System.Console.WriteLine("Please, input the index of polynomial you wish to evaluate:");

			// Start 'index in bounds' validation loop
			while (index > p.Count() || index < 1)
			{
				index = GetUserInputInt(System.Console.ReadLine());

				if (index <= p.Count() && index > 0)
					break;

				System.Console.WriteLine("Index out of bounds, please try again:");
			}

			// Prompt the user to input the value for x
			System.Console.WriteLine("Please, input the value of x:");
			value = GetUserInputDouble(System.Console.ReadLine());

			// Output the result
			System.Console.WriteLine("The result is {0}", p.Retrieve(index).Evaluate(value));
		}
			
		// Method to handle char input and to conduct data validation
		public static char GetUserInputChar (string userInput)
		{
			// Variable to store result
			char result = ' ';

			// Bool to check whether we have correct data or not
			bool endLoop = false;

			// Start input data validation loop
			while (!endLoop)
			{
				try
				{
					result = System.Convert.ToChar(userInput);
					endLoop = true;
				}
				catch (System.Exception)
				{
					System.Console.WriteLine("Please, try again:");
					userInput = System.Console.ReadLine();
				}
			}

			return result;
		}

		// Method to handle integer input and to conduct data validation
		public static int GetUserInputInt (string userInput)
		{
			// Variable to store result
			int result = 0;

			// Bool to check whether we have correct data or not
			bool endLoop = false;

			// Start input data validation loop
			while (!endLoop)
			{
				try
				{
					result = System.Convert.ToInt32(userInput);
					endLoop = true;
				}
				catch (System.FormatException)
				{
					System.Console.WriteLine("Wrong data format, please input a number:");
					userInput = System.Console.ReadLine();
				}
				catch (System.OverflowException)
				{
					System.Console.WriteLine("Number too large to store, please try again:");
					userInput = System.Console.ReadLine();
				}
			}

			return result;
		}

		// Method to handle double input and to conduct data validation
		public static double GetUserInputDouble(string userInput)
		{
			// Variable to store result
			double result = 0.0;

			// Bool to check whether we have correct data or not
			bool endLoop = false;

			// Start input data validation loop
			while (!endLoop)
			{
				try
				{
					result = System.Convert.ToDouble(userInput);
					endLoop = true;
				}
				catch (System.FormatException)
				{
					System.Console.WriteLine("Wrong data format, please input a number:");
					userInput = System.Console.ReadLine();
				}
				catch (System.OverflowException)
				{
					System.Console.WriteLine("Number too large to store, please try again:");
					userInput = System.Console.ReadLine();
				}
			}

			return result;
		}

		// Method to handle byte input and to conduct data validation
		public static byte GetUserInputByte(string userInput)
		{
			// Variable to store result
			byte result = 0;

			// Bool to check whether we have correct data or not
			bool endLoop = false;

			// Start input data validation loop
			while (!endLoop)
			{
				try
				{
					result = System.Convert.ToByte(userInput);
					endLoop = true;
				}
				catch (System.FormatException)
				{
					System.Console.WriteLine("Wrong data format, please input a number:");
					userInput = System.Console.ReadLine();
				}
				catch (System.OverflowException)
				{
					System.Console.WriteLine("Number too large to store, please try again:");
					userInput = System.Console.ReadLine();
				}
			}

			return result;
		}
	}
}
