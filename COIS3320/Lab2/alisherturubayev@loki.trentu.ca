/* 
 * Lab 2 - COIS 3320
 * Written by Alisher Turubayev using nano editor in MacOS terminal
 * 
 * Purpose:
 *  This program is to demonstrate knowledege in accepting and operating on command
 *  line arguments. 
 *
 * Assumptions:
 *  Same arguments can be called multiple times.
 *  
 * Dependencies:
 *  None
 */

#include <stdio.h>
#include <ctype.h>
#include <stdlib.h>
#include <string.h>

/*
 * parse_args function
 * 
 * Purpose: 
 *  Processes the arguments and determines what arguments are supported by the program based on the list 
 *  of supported arguments
 *
 * Arguments:
 *  args - int. The number of arguments
 *  argv - char*[]. The pointer to the array where arguments are stored.
 *  supported_args - char*[]. The pointer to the array where supported arguments are stored.
 * 
 * Returns:
 *  nothing
 */

void parse_args (int args, char *argv[], char supported_args[]) {
	if (args == 1) {
		printf("No arguments called\n");
		return;
	}
	
	for (int i = 1; i < args; i++) {
		for (int j = 0; j < strlen(argv[i]); j++) {
			// Don't check the dash		
			if (argv[i][j] == '-')
				continue;			

			// Indicates whether the current argument being processed is supported, 'n' for no by default; 'y' for yes.
			char isSupported = 'n';

			// Go over the supported arguments array and check whether the current argument is supported
			for (int k = 0; k < strlen(supported_args); k++) {
				if (argv[i][j] == supported_args[k]) {
					// Change isSupported to 'y'
					isSupported = 'y';
					printf("Argument %c called\n", argv[i][j]);
					break;
				}
			}
			
			// If isSupported is still 'n', the argument is not supported
			if (isSupported == 'n') 
				printf("Invalid argument - %c\n", argv[i][j]);
		}
	}
}

int main (int argc, char *argv[]) {
	// Char array with supported arguments. Can be changed if required
	char supported_args[8] = {'a', 'A', 'b', 'x', 'v', 'z', 'R', '\0'};
	
	// Parse arguments
	parse_args(argc, argv, supported_args);
}
	
