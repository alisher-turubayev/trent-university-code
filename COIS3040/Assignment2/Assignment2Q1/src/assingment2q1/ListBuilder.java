/*
 * COIS 3040 - Assignment #2
 * Trent University
 *
 * Question #1
 * Assignment Group: Alisher Turubayev & Vanshree Mathur
 */
package assingment2q1;

/**
 * Class that adheres to the Builder design pattern and creates a composite list 
 * of two levels. Only two levels are supported based on the description of the
 * assignment.
 * @author Alisher Turubayev
 */
public class ListBuilder {
    private ListComponent list;
    private boolean isComplete;
    private int level, index;
    
    // Creates a null parent with starting values
    public ListBuilder() {
        list = null;
        isComplete = false;
        level = 0;
        index = 0;
    }

    /**
     * Creates a child list. If parent list is not initialized, 
     * creates a new parent.
     * 
     * If creating list causes third-level child, warning is outputted.
     * Lastly, if any new input is provided after build assumed to be complete, 
     * warning is outputted too.
     */
    public void buildOpenBracket() {
        if (isComplete) 
            System.out.println("List building completed; cannot accept more queries");
        else if (list == null) 
            list = new ListComposite();
        else if (level == 0) {
            list.addChild(index, new ListComposite());
            level++;
        }
        else {
            System.out.println("Operation not supported, as only two-level list can be created");
        }
    }
    
    /**
     * Causes the current child to stop accepting new elements. If the level
     * is 0 (i.e. it is a parent list), the builder assumes the build to be complete.
     */
    public void buildClosingBracket() {
        if (level == 0) {
            isComplete = true;
        }
        else {
            level--;
            index++;
        }
    }
    
    /**
     * Adds a leaf element.
     * @param element the value of the leaf element
     */
    public void buildElement(int element) {
        Item item = new Item(element);
        if (level > 0) 
            list.getChild(index).addChild(-1, item);
        else {
            list.addChild(index, item);
            index++;
        }
    }

    /**
     * Returns a complete list.
     * @return complete list; or, if the build is incomplete (the format of input)
     * was wrong, null is returned. 
     */
    ListComponent getList() {
        if (!isComplete)
            return null;
        return list;
    }
}
