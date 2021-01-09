/*
 * COIS 3040 - Assignment #2
 * Trent University
 *
 * Question #3
 * Assignment Group: Alisher Turubayev & Vanshree Mathur
 */
package assignment2q3;

/**
 * Interface for Observer Design Pattern.
 * @author Alisher Turubayev
 */
public abstract class Observer {
    protected Subject subj;
    public abstract void update();
}
