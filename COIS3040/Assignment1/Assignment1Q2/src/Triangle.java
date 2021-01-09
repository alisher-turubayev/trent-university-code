/*
 * COIS 3040 - Assignment #1
 * Trent University
 *
 * Question #2
 * Assignment Group: Alisher Turubayev & Vanshree Mathur
 */

/**
 * Concrete class that extends the Shape Class
 * It utilizes methods from the IColour interface
 */

public class Triangle extends Shape {
    /**
     * Calls for a method from a super class
     */
    public Triangle (IColour colour, String thickness) {
        super(colour, thickness);
    }

    /**
     * Overrides the method from the Shape class
     * Returns string of rectangle
     */
    @Override
    public String toString() {
        return "This is a " + thickness + " " + colour.getColour() +  " rectangle ";
    }



}