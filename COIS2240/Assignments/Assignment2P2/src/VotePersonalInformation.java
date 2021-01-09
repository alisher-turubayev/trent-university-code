import java.util.Random;

public class VotePersonalInformation {
    // List of allowed provinces (Canadian provinces)
    // Retrieved from https://www12.statcan.gc.ca/census-recensement/2011/ref/dict/table-tableau/table-tableau-8-eng.cfm
    private static String[] provinces = {"NL", "PE", "NS", "NB", "QC", "ON", "MB", "SK", "AB", "BC", "YT", "NT", "NU"};
    // Static random generator
    private static Random rand = new Random();
    // Data fields
    private String voterFirstName;
    private String voterLastName;
    private int voterSIN;
    private String voterAddress;
    private String voterProvince;
    private String voterCity;
    private String voterPostalCode;

    /*
    Constructor to create an instance with given parameters
    Note that the postal code and province are saved in upper case
    Does not validate data correctness
     */
    public VotePersonalInformation(String voterFirstName, String voterLastName, int voterSIN,
                                   String voterAddress, String voterProvince, String voterCity, String voterPostalCode) {
        this.voterFirstName = voterFirstName;
        this.voterLastName = voterLastName;
        this.voterSIN = voterSIN;
        this.voterAddress = voterAddress;
        // Saves province in upper case format
        this.voterProvince = voterProvince;
        this.voterCity = voterCity;
        // Saves postal code in upper case format
        this.voterPostalCode = voterPostalCode.toUpperCase();
    }

    /**
     * Validates whether a first name provided is of correct format
     * Does not allow non-alphabetic characters
     * @param voterFirstName First name to check
     * @return boolean Whether a first name is correct or not
     */
    public static boolean validateFirstName(String voterFirstName) {
        for (int i = 0;i < voterFirstName.length(); i++) {
            if (!Character.isLetter(voterFirstName.charAt(i)))
                return false;
        }
        // Check whether the passed value is not empty
        return !voterFirstName.equals("");
    }

    /**
     * Validates whether a last name provided is of correct format
     * Does not allow any non-alphabetic characters
     * @param voterLastName Last name to check
     * @return boolean Whether a last name is correct or not
     */
    public static boolean validateLastName(String voterLastName) {
        for (int i = 0;i < voterLastName.length(); i++) {
            if (!Character.isLetter(voterLastName.charAt(i)))
                return false;
        }
        // Check whether the passed value is not empty
        return !voterLastName.equals("");
    }

    /**
     * Validates whether a provided Social Insurance Number is correct
     * @param voterSIN SIN to check
     * @return boolean Whether a SIN is correct or not
     */
    public static boolean validateSIN (int voterSIN) {
        return (voterSIN >= 10000000 && voterSIN <= 999999999);
    }

    /**
     * Validates whether a provided province is from a list of allowed province codes
     * @param voterProvince Province code to check
     * @return boolean Whether a province is correct or not
     */
    public static boolean validateProvince (String voterProvince) {
        for (String province : provinces) {
            if (voterProvince.toUpperCase().equals(province))
                return true;
        }
        return false;
    }

    public static boolean validateCity (String voterCity) {
        for (int i = 0;i < voterCity.length(); i++) {
            if (!Character.isLetter(voterCity.charAt(i)))
                return false;
        }
        // Check whether the passed value is not empty
        return !voterCity.equals("");
    }

    /**
     * Validates whether a provided postal code is correct format
     * The validator allows both upper case or lower case characters
     * Format is "A1A 1A1", i.e. standard Canadian postal code format
     * @param voterPostalCode Postal code to check
     * @return boolean Whether a postal code is correct or not
     */
    public static boolean validatePostalCode (String voterPostalCode) {
        return voterPostalCode.matches("\\w\\d\\w \\d\\w\\d");
    }

    /**
     * Validates whether a voter is successfully registered or not
     * @return String An output to the user on whether the registration is successful or not
     */
    public String successfullyRegistered () {
        // Validate all fields for their correctness
        boolean isCorrect = validateFirstName(voterFirstName)
                && validateLastName(voterLastName)
                && validateSIN(voterSIN)
                && validateProvince(voterProvince)
                && validateCity(voterCity)
                && validatePostalCode(voterPostalCode);

        // Return a string that informs whether a registration is successful or not
        if (isCorrect)
            return "Voter successfully registered";
        return "";
    }

    /**
     * Generates a unique voterID for a given voter
     * The generated voterID is of pattern "AA-AAAAAAAAAA", where first two letters are initials
     * @return String Generated voter ID
     */
    public String voterID () {
        String initials = voterFirstName.substring(0, 1) + voterLastName.substring(0, 1) + "-";
        return initials + getRandomString(10);
    }

    /**
     * Returns random string of upper-case letters with provided length
     * @param length The length of required string
     * @return String Generated string
     */
    private String getRandomString(int length) {
        // Use StringBuilder to create string
        StringBuilder result = new StringBuilder();
        // Generate next letter and append it to the string
        for (int i = 0;i < length; i++) {
            char next = (char)(rand.nextInt(25) + 65);
            result.append(next);
        }
        return result.toString();
    }

    @Override
    public String toString () {
        String result = "";
        result += "The voter information is as follows:" +
                "\nFirst name: " + voterFirstName +
                "\nLast name: " + voterLastName +
                "\nSIN:" + voterSIN +
                "\nAddress: " + voterAddress +
                "\nProvince: " + voterProvince +
                "\nCity: " + voterCity +
                "\nPostal Code: " + voterPostalCode;
        return result;
    }
}
