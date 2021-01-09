/*
 * COIS 3040 - Assignment #2
 * Trent University
 *
 * Question #3
 * Assignment Group: Alisher Turubayev & Vanshree Mathur
 */
package assignment2q3;

/**
 *
 * @author RainyCloudStudent
 */
public class ArrayListObserver extends Observer {
    public ArrayListObserver(Subject s) {
        this.subj = s;
    }
    
    @Override
    public void update() {
        System.out.println("Subject array list was changed: item deleted.");
    }
}
