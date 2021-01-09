/*
* COIS 3040 - Assignment #2
* Trent University
*
* Question #3
* Assignment Group: Alisher Turubayev & Vanshree Mathur
*/
package assignment2q3;

import java.util.ArrayList;

/**
 *
 * @author Alisher Turubayev
 */
public class ArrayListSubject implements Subject {
    private final ArrayList list;
    private final ArrayList<Observer> observers;
    
    public ArrayListSubject() {
        list = new ArrayList();
        observers = new ArrayList();
    }
    
    @Override
    public void attach(Observer o) {
        observers.add(o);
    }
    
    public void append(Object obj) {
        list.add(obj);
    }
    
    public void delete(Object obj) {
        list.remove(obj);
        notifyObservers();
    }
    
    private void notifyObservers() {
        for(Observer o : observers) {
            o.update();
        }
    }
}