/*
 * COIS 3040 - Assignment #3
 * Trent University
 * 
 * Question #3
 * Assignment Group: Alisher Turubayev & Vanshree Mathur
 */
package assignment1q3;

import java.time.LocalTime;

/**
 * A class to support output of time in format "HH:MM:SS" 
 * consistent with {@link TimeObject} interface.
 * <p>
 * <b>Note that because of calculations that need to be done, 
 * time returned will not be accurate to the second.</b>
 * @see     TimeObject
 * @author  Alisher Turubayev
 */
public class TimeObjectFormat1 implements ITimeObject {
    /**
     * Returns a string representation of time in the format "HH:MM:SS". 
     * The time returned represents the call time + additional 
     * overhead of internal calculations.
     * @return  String representation of time
     */
    @Override
    public String toString() {
        LocalTime time = LocalTime.now();
        
        String hour = "", minute = "", second = "";
        
        // Convert hour into "HH" format if necessary
        if (time.getHour() < 10)
            hour += "0";
        hour += time.getHour();
        
        // Convert minute into "MM" format if necessary
        if (time.getMinute() < 10)
            minute += "0";
        minute += time.getMinute();
        
        // Convert second into "SS" format if necessary
        if (time.getSecond() < 10)
            second += "0";
        second += time.getSecond();
        
        return hour + ":" + minute + ":" + second;
    }
}
