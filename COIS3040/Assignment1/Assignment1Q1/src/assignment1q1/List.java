/*
 * COIS 3040 - Assignment #1
 * Trent University
 * 
 * Question #1 - part (a)-(c)
 * Assignment Group: Alisher Turubayev & Vanshree Mathur
 */
package assignment1q1;

/**
 * An interface consistent with the definition in "Design Patterns
 * - Elements of Reusable Object-Oriented Software"
 */
interface List {
    /**
     * Returns the number of elements in the list
     * @return  the number of elements
     */
    int count();
    
    /**
     * Returns the element on a specified position
     * @param   index the position that is needed
     * @return  the element on a specified position
     */
    Object get(int index); 
    
    /**
     * Returns the element on the first position
     * @return  element on the first position
     */
    Object first(); 
    
    /**
     * Returns the last element in the list
     * @return  the last element in the list
     */
    Object last();
    
    /**
     * Checks whether an element is in the list
     * @param obj   an object to search in the list
     * @return true if object is present in the list; false otherwise
     */
    boolean include(Object obj); 
    
    /**
     * Adds an object to the end of the list
     * @param obj   an object to add to the end of the list
     */
    void append(Object obj); 
    
    /**
     * Adds an object to the beginning of the list
     * @param obj   an object to add to the end of the list
     */
    void prepend(Object obj);
    
    /**
     * Removes <b>all instances</b> of object in the list
     * <p>
     * <b>Note:</b> the book does not explicitly specify whether all or one
     * instance of element needs to be deleted from the list. As such, a decision
     * was made to make sure that all instances of the object need to be deleted. 
     * @param obj 
     */
    void delete(Object obj);
    
    /**
     * Removes last element from the list
     */
    void deleteLast(); 
    
    /**
     * Removes first element from the list
     */
    void deleteFirst();
    
    /**
     * Removes all elements from the list
     */
    void deleteAll();
}
