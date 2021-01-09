/*
 * COIS 3040 - Assignment #3
 * Trent University
 * 
 * Question #3
 * Assignment Group: Alisher Turubayev & Vanshree Mathur
 */
package assignment1q3;

/**
 * Acts as a facade for Factories of different types. Two formats of date/time 
 * are supported: "MM/DD/YYYY HH:MM:SS" & "DD-MM-YYYY SS,MM,HH". 
 * @author  Alisher Turubayev
 */
public class FactoryProvider {
    /**
     * Returns a factory of desired date/time format. If a choice is invalid, 
     * defaults to the first format
     * @param   choice    a choice of format
     * @return  a DateTimeFactory that produces date/time in a desired format
     */
    public static IDateTimeFactory getFactory(int choice) {
        if (choice == 2)
            return DateTimeFactoryFormat2.getInstance();
        return DateTimeFactoryFormat1.getInstance();
    }
}
