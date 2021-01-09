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
 * @author Alisher Turubayev
 */
public class Test {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        ArrayListSubject subj = new ArrayListSubject();
        subj.attach(new ArrayListObserver(subj));
        
        System.out.println("Testing program for Observer Design Pattern.\n");
        
        System.out.println("First case: adding an item:");
        subj.append("x");
        System.out.println();
        
        System.out.println("Second case: deleting an item:");
        subj.delete("x");
        System.out.println();
        
        System.out.println("Third case: adding another observer and adding an item:");
        subj.attach(new ArrayListObserver(subj));
        subj.append("y");
        System.out.println();
        
        System.out.println("Fourth case: deleting an item again:");
        subj.delete("y");
        System.out.println();
    }
    
}
