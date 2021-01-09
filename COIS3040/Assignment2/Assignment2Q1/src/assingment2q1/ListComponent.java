/*
 * COIS 3040 - Assignment #2
 * Trent University
 *
 * Question #1
 * Assignment Group: Alisher Turubayev & Vanshree Mathur
 */
package assingment2q1;

/**
 * Interface to support the composite list creation that adheres to the Composite
 * Design Pattern.
 * @author Alisher Turubayev
 */
public interface ListComponent {
    void printValue();
    void addChild(int index, ListComponent child);
    void removeChild(int index);
    ListComponent getChild(int index);
}
