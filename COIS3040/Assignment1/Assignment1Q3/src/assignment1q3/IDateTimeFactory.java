/*
 * COIS 3040 - Assignment #3
 * Trent University
 * 
 * Question #3
 * Assignment Group: Alisher Turubayev & Vanshree Mathur
 */
package assignment1q3;

/**
 * Abstract factory for date/time objects
 * Provides a template for concrete factories
 * @author  Alisher Turubayev
 */
public interface IDateTimeFactory {
    /**
     * Returns a DateObject in a desired format
     * @return  a DateObject in a desired format
     * @see     DateObject
     */
    IDateObject createDateObject();
    
    /**
     * Returns a TimeObject in a desired format
     * @return  a TimeObject in a desired format
     * @see     TimeObject
     */
    ITimeObject createTimeObject();
}
