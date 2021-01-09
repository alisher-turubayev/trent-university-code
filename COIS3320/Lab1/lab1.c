/*
 * Lab 1 - COIS 3320
 * Written by Alisher Turubayev using nano editor in MacOS terminal
 * 
 * Purpose:
 * This program is a "Rock, Paper, Scissors" game written in C. The program takes an 
 * input from the user (GetUserInput)  * and generates a computer's choice by using a 
 * standard random number generator in C. 
 * 
 * Dependencies:
 * None
 */

#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#include<ctype.h>
#include<time.h>

/*
 * ToLower function
 * 
 * Purpose:
 * Converts the string to lowercase letters
 * 
 * Parameters:
 * char* pstr - pointer to string to be converted
 * 
 * Returns:
 * None
 */
void ToLower(char *pstr)
{
	// Pointer copy so that the original is not corrupted
	char *p = pstr;
	// Current value stored at the pointer
	char curr = *p;
	while (curr) {
		*p = tolower(curr);
		p++;
		curr = *p;
	}	
}

/*
 * GetUserInput function
 * 
 * Purpose: 
 * Take user's input and convert it into a char for later use
 * 'p' represents paper, 'r' - rock and 's' - scissors
 * 
 * Parameters:
 * None
 * 
 * Returns:
 * char - the user's choice (either rock, paper or scissors)
 */
char GetUserInput() 
{
	// user_choice will hold the user's choice, initially 'x' - so that the loop starts
	char user_choice = 'x';
	
	// Stores string of the user input (supports 100 characters + null terminator)
	char *user_input = (char*) malloc(101 * sizeof(char));
	if (!user_input) 
	{
		printf("Memory allocation failed, terminating...");
		abort();
	}

	// Print instructions
	printf("You can input:\n\'Paper\', \'Rock\' or \'Scissors\'\n");
	printf("Note that the input is case-insensitive\n\n");

	// Do the loop while input cannot be processed
	while (user_choice == 'x') 
	{
		printf("Please, input your choice:\n");
		
		scanf("%s", user_input);

		//Convert the string to lowercase for comparison
		ToLower(user_input);		

		//Compare it to the predefined values to determine choice
		if (strcmp(user_input, "rock") == 0)
			user_choice = 'r';
		else if (strcmp(user_input, "paper") == 0)
			user_choice = 'p';
		else if (strcmp(user_input, "scissors") == 0)
			user_choice = 's';
		else 
			printf("Input cannot be processed, try again.\n");
	}

	free(user_input);
	return user_choice;
}

/*
 * GetComputerChoice function
 *
 * Purpose:
 * To generate the computer's choice (rock, paper or scissors) using standard random generator in C
 * Number 0 corresponds to Paper, 1 - Rock and 2 - Scissors
 * 
 * Arguments:
 * None
 * 
 * Returns:
 * char - the choice ('p' for paper, 'r' - rock and 's' - scissors)
 */
char GetComputerChoice() 
{
	// Set random seed to current time
	srand(time(0));

	// Stores generated number from 0 to 2
	int gen = rand() % 3;
	
	// Determine the choice ()
	if (gen == 0)
		return 'p';
	else if (gen == 1)
		return 'r';
	return 's';
}

/*
 * FindWinner function
 *
 * Purpose: finds the winner of the game of rock, paper, scissors
 *
 * Arguments:
 * user_choice - char. Contains the user's choice. Must be either 'p', 'r' or 's';
 * computer_choice - char. Contains the computer's choice. Must be either 'p', 'r' or 's'.
 *
 * Returns:
 * int - the result. 0 for tie, -1 - for computer and 1 - user.
 */
int FindWinner (char user_choice, char computer_choice) 
{
	if (user_choice == computer_choice)
		return 0;
	
	else if ((user_choice == 'p' && computer_choice == 'r') 
		|| (user_choice == 'r' && computer_choice == 's')
		|| (user_choice == 's' && computer_choice == 'p'))
		return 1;
	return -1;
}

int main () 
{
	//user_choice stores user's choice
	char user_choice = GetUserInput();
	char computer_choice = GetComputerChoice();

	// Output computer's choice and the winner
	printf("Computer chose: %c\n", computer_choice);
	printf("%d\n", FindWinner(user_choice, computer_choice));
	return 0;
}
