/*
 * COIS 3040 - Assignment #2
 * Trent University
 *
 * Question #1
 * Assignment Group: Alisher Turubayev & Vanshree Mathur
 */
package assingment2q1;

/**
 * Leaf list component that adheres to the Composite Design Pattern.
 * @author Alisher Turubayev
 */
public class Item implements ListComponent {
    private int item;
    
    /**
     * Creates an instance with value 0.
     */
    public Item() {
        item = 0;
    }
    
    /**
     * Creates an instance with a specified value.
     * @param item value that instance needs to save.
     */
    public Item(int item) {
        this.item = item;
    }
    
    /**
     * Prints out the value of the leaf.
     */
    @Override
    public void printValue() {
        System.out.print(item);
    }
    
    /**
     * Leaf node; this method is not applicable to this class. See assignment details
     * for more information.
     * @param index
     * @param child 
     */
    @Override
    public void addChild(int index, ListComponent child) {
        // Leaf node; this method is not applicable to this class
    }
    
    /**
     * Leaf node; this method is not applicable to this class. See assignment details
     * for more information.
     * @param index
     */
    @Override
    public void removeChild(int index) {
        // Leaf node; this method is not applicable to this class
    }
    
    /**
     * Leaf node; this method is not applicable to this class. See assignment details
     * for more information.
     * @param index
     * @return
     */
    @Override
    public ListComponent getChild(int index) {
        // Leaf node; this method is not applicable to this class
        return null;
    }
}
