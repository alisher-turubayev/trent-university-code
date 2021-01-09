import java.util.Scanner;

public class BallotCreation extends VotePersonalInformation{
    private String ballotName;
    private Candidate[] candidates;

    /*
    Creates a ballot with provided information
    Does not validate data correctness
    */
    public BallotCreation(String voterFirstName, String voterLastName, int voterSIN, String voterAddress,
                          String voterProvince, String voterCity, String voterPostalCode, String ballotName, Candidate[] candidates) {
        super(voterFirstName, voterLastName, voterSIN, voterAddress, voterProvince, voterCity, voterPostalCode);
        this.ballotName = ballotName;
        this.candidates = candidates;
    }

    /**
     * Displays a ballot with a given name and candidates without creating an instance of BallotCreation
     * @param ballotName Name of the ballot to be outputted
     * @param candidates Array of candidates to be outputted
     */
    public static void displayBallot (String ballotName, Candidate[] candidates) {
        System.out.println("The ballot " + ballotName + " has " + candidates.length + " candidates:");
        for (int i = 0;i < candidates.length; i++) {
            System.out.println((i + 1) + ". " + candidates[i]);
        }
        System.out.println();
    }

    /**
     * Gets a candidate number user wishes to vote for and returns a text with that number
     * @return String A text declaring the result of voting
     */
    public String submitBallot () {
        // Check if the voter information is correct
        if (successfullyRegistered().equals(""))
            return "Incorrect voter information. Cannot proceed with voting";
        if (!validateBallot(this))
            return "Ballot information is incorrect or missing. Cannot proceed with voting";

        // Output a ballot
        displayBallot(ballotName, candidates);

        // Get a correct candidate position
        Scanner scanner = new Scanner(System.in);
        System.out.println("Please, input the number of the candidate you wish to vote for:");
        int votedFor = 0;
        while (votedFor <= 0 || votedFor > candidates.length) {
            while (!scanner.hasNextInt()) {
                System.out.println("Not a number. Please, try again.");
                scanner.nextLine();
            }
            votedFor = scanner.nextInt();
            if (votedFor <= 0 || votedFor > candidates.length)
                System.out.println("The number is out of bounds. Please, try again.");
        }
        return "On ballot " + ballotName + ", the voter with ID " + voterID() +
                " voted for candidate number " + votedFor;
    }

    /**
     * Validates whether the ballot has all the needed information
     * @param ballot Ballot to validate
     * @return boolean Whether a ballot is correct or not
     */
    public static boolean validateBallot (BallotCreation ballot) {
        return ballot.ballotName.length() != 0 && ballot.candidates.length != 0;
    }
}
