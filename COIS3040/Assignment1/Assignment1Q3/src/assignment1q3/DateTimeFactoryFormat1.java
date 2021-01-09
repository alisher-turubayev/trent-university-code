/*
 * COIS 3040 - Assignment #3
 * Trent University
 * 
 * Question #3
 * Assignment Group: Alisher Turubayev & Vanshree Mathur
 */
package assignment1q3;

/**
 * Factory that creates {@link DateObject} and {@link TimeObject} 
 * in format "MM/DD//YYYY" & "HH:MM:SS"
 * <p>
 * Implemented as Singleton with Eager initialization
 * @see DateTimeFactory
 * @see DateObject
 * @see TimeObject
 * @author Alisher Turubayev
 */
final class DateTimeFactoryFormat1 implements IDateTimeFactory{
    private static final DateTimeFactoryFormat1 FACTORY = new DateTimeFactoryFormat1();
    
    private DateTimeFactoryFormat1() {}
    
    /**
     * Returns a singleton instance of the class
     * @return  singleton instance of class DateTimeFactoryFormat1
     */
    static DateTimeFactoryFormat1 getInstance() {
        return FACTORY;
    }
    
    /**
     * Returns a DateObject in format "MM/DD//YYYY"
     * @return  a DateObject in format "MM/DD//YYYY"
     * @see DateObject
     */
    @Override
    public IDateObject createDateObject() {
        return new DateObjectFormat1();
    }
    
    /**
     * Returns a TimeObject in format "HH:MM:SS"
     * @return  a TimeObject in format "HH:MM:SS"
     * @see DateObject
     */
    @Override
    public ITimeObject createTimeObject() {
        return new TimeObjectFormat1();
    }
}
