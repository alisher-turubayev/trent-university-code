import java.util.Scanner;

public class PrivilegedAccount {
	// Static fields declaration
		private String accountType = "Privileged account";
		// Data fields declarations
		private double accountBalance;
		private String ownerName;
		private double monthlyCharge;
		
		public PrivilegedAccount () {
			this.accountBalance = 0.0;
			this.monthlyCharge = 0.0;
			this.ownerName = "";
			getDetails();
		}
		
		public PrivilegedAccount (double initialAmount) {
			this.accountBalance = initialAmount;
			this.monthlyCharge = 0.0;
			this.ownerName = "";
			getDetails();
		}
		
		void getDetails() {
			Scanner reader = new Scanner(System.in);
			
			// Ask for name
			System.out.println("What is your name?");
			this.ownerName = reader.nextLine();
			
			// Ask for the expected number of transactions
			System.out.println("What number of transactions are you expecting to have?");
			
			while(!reader.hasNextInt()) {
				reader.nextLine();
				System.out.println("Input is not a valid number. Please, try again.");
			}
			
			// Determine the monthly charge
			int numberTransactions = reader.nextInt();
			if (numberTransactions < 30) {
				this.monthlyCharge = 10.0;
			}
			else {
				this.monthlyCharge = 100.0;
			}
			
			return;
		}
		
		public void printDetails() {
			System.out.println("Type of account: " + this.accountType);
			System.out.println("The name of the owner: " + this.ownerName);
			System.out.println("Balance: " + this.accountBalance);
			System.out.println("Monthly charge: " + this.monthlyCharge);
		}
}
