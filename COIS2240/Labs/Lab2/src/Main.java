import java.util.Scanner;

public class Main {

	public static void main(String[] args) {
		// Open the reader
		Scanner reader = new Scanner(System.in);
		
		// Greet the user
		System.out.println("Welcome to BICB bank!");
		System.out.println("Do you want to open an account? Input Y/N");
		
		// While the input is incorrect, ask again
		while (!reader.hasNext("[Y, N, y, n]")) 
		{
			reader.nextLine();
			System.out.println("Please, try again. Y/N");
		}
		
		// Get the input
		// If the user does not want to create account, exit the program
		String userInput = reader.next();
		if (userInput.toLowerCase() == "n") {
			System.out.println("Sorry to see you go!");
			System.out.println("Goodbye!");
			return;
		}
		
		// Else, continue
		System.out.println("Amazing that you would like to open an account!\n");
		System.out.println("What initial amount you want to upload?");
		// While the input is of incorrect type, ask again
		while (!reader.hasNextDouble()) {
			System.out.println("Input is not a valid number. Please, try again.");
		}
		
		// Get the input
		Double initialAmount = reader.nextDouble();
		
		if (initialAmount < 100000.0) {
			NormalAccount account = new NormalAccount(initialAmount);
			account.printDetails();
		}
		else {
			PrivilegedAccount account = new PrivilegedAccount(initialAmount);
			account.printDetails();
		}
	}

}
