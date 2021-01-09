public class Candidate {
    private String candidateName;
    private String candidateBiography;

    /*
    Creates a candidate with a given name and biography
    Does not validate data correctness
     */
    public Candidate (String candidateName, String candidateBiography) {
        this.candidateName = candidateName;
        this.candidateBiography = candidateBiography;
    }

    /**
     * Validates whether a given candidate name is correct or not
     * @param candidateName Candidate name to check
     * @return boolean Whether a name is correct or not
     */
    public static boolean validateName (String candidateName) {
        for (int i = 0;i < candidateName.length(); i++) {
            if (!Character.isLetter(candidateName.charAt(i)))
                return false;
        }
        // Check whether the passed value is not empty
        return !candidateName.equals("");
    }

    @Override
    public String toString () {
        return candidateName + "\n" + candidateBiography;
    }
}
