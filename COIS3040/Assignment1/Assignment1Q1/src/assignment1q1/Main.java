/*
 * COIS 3040 - Assignment #1
 * Trent University
 *
 * Question #1 - part (b)-(c)
 * Assignment Group: Alisher Turubayev & Vanshree Mathur
 */

package assignment1q1;

/**
 *
 * @author Vanshree Mathur
 */
public class Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        /*
         * Instantiate the Object Adapter ArrayList
         * Add different elements to the ArrayList
         */
        List classList = new ListClassAdapter();

        classList.append( "Object 1");
        classList.append( "Object 2");
        classList.append( "Object 3");
        classList.append( "Object 4");
        classList.append( "Object 5");

        System.out.println("Implementation for Class Adapter:" + "\n");
        System.out.println(classList + "\n");

        /*
         *Prints the number of elements in the ArrayList
         */

        System.out.println("The number of elements in the list: " + classList.count());

        /*
         *Prints 2nd element in the ArrayList (list starts at 0)
         */

        System.out.println("The second element in the list is: " + classList.get(1));


        /*
         *Prints first element in the ArrayList
         */

        System.out.println("The first element in the list: " + classList.first());


        /*
         *Prints last element in the ArrayList
         */

        System.out.println("The last element in the list: " + classList.last());

        /*
         *Checks if Object 1 exists in the ArrayList
         */

        System.out.println("Does Object 1 exist? : " + classList.include("Object 1") + "\n");


        /*
         *Adds 'Object 6' to the back to the ArrayList
         */

        classList.append("Object 6");
        System.out.println("Object 6 is added to the back of the list");
        System.out.println(classList + "\n");


        /*
         *Adds 'Object 0' to the end of the ArrayList
         */

        classList.prepend("Object 0");
        System.out.println("Object 0 is added to the front of the list");
        System.out.println(classList + "\n");

        /*
         *Deletes the first element from the ArrayList
         */

        classList.deleteFirst();
        System.out.println("The first element is deleted off the list");
        System.out.println(classList + "\n");

        /*
         *Deletes the last element from the ArrayList
         */

        classList.deleteLast();
        System.out.println("The last element is deleted off the list");
        System.out.println(classList + "\n");

        /*
         *Deletes an objects called 'Object 3' from the ArrayList
         */

        classList.delete ("Object 3");
        System.out.println("All instances of Object 3 are deleted off the list");
        System.out.println(classList + "\n");


        /*
         *Deletes all elements in the ArrayList
         */

        classList.deleteAll();
        System.out.println("All objects have been deleted off the list");
        System.out.println(classList + "\n" + "\n");

        //----------------------------------------------------------------------------------------------------------

        /*
         * Instantiate the Object Adapter ArrayList
         * Add different elements to the ArrayList
         */

        List objectList = new ListObjectAdapter();

        objectList.append( "Object 1");
        objectList.append( "Object 2");
        objectList.append( "Object 3");
        objectList.append( "Object 4");
        objectList.append( "Object 5");

        System.out.println("Implementation for Object Adapter:" + "\n");
        System.out.println(objectList + "\n");

        /*
         *Prints the number of elements in the ArrayList
         */

        System.out.println("The number of elements in the list: " + objectList.count());

        /*
         *Prints 2nd element in the ArrayList (list starts at 0)
         */

        System.out.println("The second element in the list is: " + objectList.get(1));


        /*
         *Prints first element in the ArrayList
         */

        System.out.println("The first element in the list: " + objectList.first());


        /*
         *Prints last element in the ArrayList
         */

        System.out.println("The last element in the list: " + objectList.last());

        /*
         *Checks if Object 1 exists in the ArrayList
         */

        System.out.println("Does Object 1 exist? : " + objectList.include("Object 1") + "\n");


        /*
         *Adds 'Object 6' to the back to the ArrayList
         */

        objectList.append("Object 6");
        System.out.println("Object 6 is added to the back of the list");
        System.out.println(objectList +"\n");

        /*
         *Adds 'Object 0' to the end of the ArrayList
         */

        objectList.prepend("Object 0");
        System.out.println("Object 0 is added to the front of the list");
        System.out.println(objectList +"\n");

        /*
         *Deletes the first element from the ArrayList
         */

        objectList.deleteFirst();
        System.out.println("The first element is deleted off the list");
        System.out.println(objectList +"\n");

        /*
         *Deletes the last element from the ArrayList
         */

        objectList.deleteLast();
        System.out.println("The last element is deleted off the list");
        System.out.println(objectList +"\n");

        /*
         *Deletes an objects called 'Object 3' from the ArrayList
         */

        objectList.delete ("Object 3");
        System.out.println("All instances of Object 3 are deleted off the list");
        System.out.println(objectList +"\n");


        /*
         *Deletes all elements in the ArrayList
         */

        objectList.deleteAll();
        System.out.println("All objects have been deleted off the list");
        System.out.println(objectList +"\n");

    }
}
