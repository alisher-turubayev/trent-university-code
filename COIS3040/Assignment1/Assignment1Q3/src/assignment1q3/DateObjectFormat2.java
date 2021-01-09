/*
 * COIS 3040 - Assignment #3
 * Trent University
 * 
 * Question #3
 * Assignment Group: Alisher Turubayev & Vanshree Mathur
 */
package assignment1q3;

import java.time.LocalDate;

/**
 * A class that produces date in a format "DD-MM-YYYY"
 * @author  Alisher Turubayev
 */
class DateObjectFormat2 implements IDateObject {
    /**
     * Returns date in a format "DD-MM-YYYY".
     * <p>
     * The date returned represents the call date + additional 
     * overhead of internal calculations.
     * @return  String representation of date in "DD-MM-YYYY".
     */
    @Override
    public String toString() {
        LocalDate date = LocalDate.now();
        
        String month = "", day = "", year = "";
        // Convert day number into DD format if necessary
        if (date.getDayOfMonth() < 10)
            day += "0";
        day += date.getDayOfMonth();
        
        // Convert month number into MM format if necessary
        if (date.getMonthValue() < 10)
            month += "0";
        month += date.getMonthValue();
        
        year += date.getYear();
        
        return day + "-" + month + "-" + year;
    }
}
