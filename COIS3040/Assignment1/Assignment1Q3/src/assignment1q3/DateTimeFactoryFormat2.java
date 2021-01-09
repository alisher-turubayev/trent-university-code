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
 * in format "DD-MM-YYYY" & "SS,MM,HH"
 * <p>
 * Implemented as Singleton with Eager initialization
 * @see DateTimeFactory
 * @see DateObject
 * @see TimeObject
 * @author Alisher Turubayev
 */
final class DateTimeFactoryFormat2 implements IDateTimeFactory{
    private static final DateTimeFactoryFormat2 FACTORY = new DateTimeFactoryFormat2();
    
    private DateTimeFactoryFormat2() {}
    
    /**
     * Returns a singleton instance of the class
     * @return  singleton instance of class DateTimeFactoryFormat2
     */
    static DateTimeFactoryFormat2 getInstance() {
        return FACTORY;
    }
    
    /**
     * Returns a DateObject in format "DD-MM-YYYY"
     * @return  a DateObject in format "DD-MM-YYYY"
     * @see DateObject
     */
    @Override
    public IDateObject createDateObject() {
        return new DateObjectFormat2();
    }
    
    /**
     * Returns a TimeObject in format "SS,MM,HH"
     * @return  a TimeObject in format "SS,MM,HH"
     * @see DateObject
     */
    @Override
    public ITimeObject createTimeObject() {
        return new TimeObjectFormat2();
    }
}
