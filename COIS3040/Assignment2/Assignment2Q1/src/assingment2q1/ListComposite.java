/*
 * COIS 3040 - Assignment #2
 * Trent University
 *
 * Question #1
 * Assignment Group: Alisher Turubayev & Vanshree Mathur
 */
package assingment2q1;

import java.util.LinkedList;

/**
 * Parent list component that adheres to the Composite Deisgn Pattern.
 * @author Alisher Turubayev
 */
public class ListComposite implements ListComponent {
    private final LinkedList<ListComponent> list;
    
    /**
     * Creates a new composite list
     */
    public ListComposite() {
        list = new LinkedList();
    }
    
    /**
     * Prints the stored value of the list. Value is formatted according to the
     * same format as input. See assignment description for more details.
     */
    @Override
    public void printValue() {
        System.out.print("(");
        for (int i = 0;i < list.size(); i++) {
            ListComponent item = list.get(i);
            item.printValue();
            
            if (i + 1 != list.size())
                System.out.print(" ");
        }
        System.out.print(")");
    }
    
    /**
     * Adds a child either at the end of the list (if index is -1) or at a 
     * specified index.
     * @param index place that child needs to be inserted. If -1, child is inserted at the back.
     * @param child child that needs insertion.
     */
    @Override
    public void addChild(int index, ListComponent child) {
        if (index == -1) {
            list.add(child);
        }
        else
            list.add(index, child);
    }
    
    /**
     * Removes a child from a particular index.
     * @param index the place that child needs to be removed from.
     */
    @Override
    public void removeChild(int index) {
        list.remove(index);
    }
    
    /**
     * Retrieves a child from a particular index.
     * @param index the place that child needs to be retrieved from.
     * @return the child at that index. 
     */
    @Override
    public ListComponent getChild(int index) {
        return list.get(index);
    }
}
