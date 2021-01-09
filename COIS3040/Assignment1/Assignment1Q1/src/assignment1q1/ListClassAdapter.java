/*
 * COIS 3040 - Assignment #1
 * Trent University
 * 
 * Question #1 - part (a)
 * Assignment Group: Alisher Turubayev & Vanshree Mathur
 */
package assignment1q1;

import java.util.ArrayList;

/**
 * Implements a class adapter for {@link ArrayList}. The implementation
 * is consistent with interface definition in "Design Patterns
 * - Elements of Reusable Object-Oriented Software"
 * @see java.util.ArrayList
 * @author Alisher Turubayev
 */
public class ListClassAdapter extends ArrayList implements List {
   /**
     * Initiates an instance of ListClassAdapter
     * <p>
     * The size is defaulted to 10 because of {@link ArrayList}'s constructor
     * implementation
     * @see     java.util.ArrayList
     */
    public ListClassAdapter() {
        super();
    }
    
     /**
     * Returns the number of elements in the list
     * @return  the number of elements
     */
    @Override
    public int count() {
        return size();
    }
    
    /**
     * Returns the element on a specified position
     * @param   index the position that is needed
     * @return  the element on a specified position
     */
    @Override 
    public Object get(int index) {
        return super.get(index);
    }
    
    /**
     * Returns the element on the first position
     * @return  element on the first position
     */
    @Override
    public Object first() {
        return super.get(0);
    }
    
    /**
     * Returns the last element in the list
     * @return  the last element in the list
     */
    @Override
    public Object last() {
        return super.get(size() - 1);
    }
    
    /**
     * Checks whether an element is in the list
     * @param obj   an object to search in the list
     * @return true if object is present in the list; false otherwise
     */
    @Override
    public boolean include(Object obj) {
        return contains(obj);
    }
    
    /**
     * Adds an object to the end of the list
     * @param obj   an object to add to the end of the list
     */
    @Override
    public void append(Object obj) {
        add(obj);
    }
    
    /**
     * Adds an object to the beginning of the list
     * @param obj   an object to add to the end of the list
     */
    @Override
    public void prepend(Object obj) {
        add(0, obj);
    }
    
    /**
     * Removes <b>all instances</b> of object in the list
     * <p>
     * <b>Note:</b> the book does not explicitly specify whether all or one
     * instance of element needs to be deleted from the list. As such, a decision
     * was made to make sure that all instances of the object need to be deleted. 
     * @param obj 
     */
    @Override
    public void delete(Object obj) {
        /* 
        Please see comment above for the explanation on the empty while loop 
        */
        while (!remove(obj))
        {}
    }
    
    /**
     * Removes last element from the list
     */
    @Override
    public void deleteLast() {
        remove(size() - 1);
    }
    
    /**
     * Removes first element from the list
     */
    @Override
    public void deleteFirst() {
        remove(0);
    }
    
    /**
     * Removes all elements from the list
     */
    @Override
    public void deleteAll() {
        clear();
    }
}
