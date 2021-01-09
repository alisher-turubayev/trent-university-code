import java.util.Scanner;

public class Test {
    public static void main (String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.println("Welcome to automated voting system!");
        // Prompt and validate first name from user
        System.out.println("Please, input your first name:");
        String firstName = scanner.nextLine();
        while (!BallotCreation.validateFirstName(firstName)) {
            System.out.println("Input contains illegal characters. Please, try again.");
            firstName = scanner.nextLine();
        }
        // Prompt and validate last name from user
        System.out.println("Input your last name:");
        String lastName = scanner.nextLine();
        while (!BallotCreation.validateLastName(lastName)) {
            System.out.println("Input contains illegal characters. Please, try again.");
            lastName = scanner.nextLine();
        }
        // Prompt and validate Social Insurance number from user
        System.out.println("Input your Social Insurance number (without spaces):");
        int SIN;
        while (true) {
            while(!scanner.hasNextInt()) {
                scanner.nextLine();
                System.out.println("Input is not a number. Please, try again.");
            }
            SIN = scanner.nextInt();
            if (!BallotCreation.validateSIN(SIN))
                System.out.println("Input is not a SIN. Please, try again.");
            else
                break;
        }
        scanner.nextLine();
        // Prompt address from user (only checks for empty address)
        System.out.println("Input your address:");
        String address = scanner.nextLine();
        while (address.equals("")) {
            System.out.println("Address cannot be empty. Please, try again:");
            address = scanner.nextLine();
        }
        // Prompt and validate province from user
        System.out.println("Input your Canadian province (code in format 'AA'):");
        String province = scanner.nextLine();
        while (!BallotCreation.validateProvince(province)) {
            System.out.println("Province code is incorrect. Please, try again.");
            province = scanner.nextLine();
        }
        // Prompt and validate city from user
        System.out.println("Input your city:");
        String city = scanner.nextLine();
        while (!BallotCreation.validateCity(city)) {
            System.out.println("Input contains illegal characters. Please, try again.");
            city = scanner.nextLine();
        }
        // Prompt and validate postal code
        System.out.println("Input your postal code (format 'A1A 1A1'):");
        String postalCode = scanner.nextLine();
        while (!BallotCreation.validatePostalCode(postalCode)) {
            System.out.println("Input is of incorrect format. Please, try again.");
            postalCode = scanner.nextLine();
        }

        // Prompt name of ballot (only checks for empty strings)
        System.out.println("Input ballot name:");
        String ballotName = scanner.nextLine();
        while (ballotName.equals("")) {
            System.out.println("Ballot name cannot be empty. Please, try again.");
            ballotName = scanner.nextLine();
        }
        // Prompt number of candidates
        System.out.println("Input the number of candidates:");
        int numCandidates;
        while (true) {
            while(!scanner.hasNextInt()) {
                scanner.nextLine();
                System.out.println("Input is not a number. Please, try again.");
            }
            numCandidates = scanner.nextInt();
            if (numCandidates <= 0)
                System.out.println("Input cannot be less than or equal to zero. Please, try again.");
            else
                break;
        }
        scanner.nextLine();
        // Create and fill the array of candidates
        Candidate[] candidates = new Candidate[numCandidates];
        for (int i = 0;i < numCandidates; i++) {
            // Prompt and validate the next candidate
            System.out.println("Input the name of candidate number " + (i + 1) + ":");
            String candidateName = scanner.nextLine();
            while (!Candidate.validateName(candidateName)) {
                System.out.println("Input contains illegal characters. Please, try again.");
                candidateName = scanner.nextLine();
            }
            // Prompt the next candidate biography (no validation)
            System.out.println("Input the biography of candidate number " + (i + 1) + ":");
            String candidateBiography = scanner.nextLine();
            // Create and store new candidate
            candidates[i] = new Candidate(candidateName, candidateBiography);
        }
        // Create a ballot with given parameters
        BallotCreation ballot = new BallotCreation(firstName, lastName, SIN, address,
                province, city, postalCode, ballotName, candidates);
        // Submit the ballot
        System.out.println(ballot.submitBallot());
    }
}
