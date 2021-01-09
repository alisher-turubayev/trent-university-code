/**
 * Class to store objects of rectangle shape. Inherits from GeometricObject
 * @see GeometricObject
 * @author Alisher Turubayev, Trent University
 */
public class Rectangle extends GeometricObject {
    private double side1, side2;

    /**
     * Creates a Rectangle with sides 1, 1
     */
    public Rectangle () {
        side1 = side2 = 1;
    }

    /**
     * Creates a Rectangle with given sides
     * @param side1 side 1 of a new rectangle
     * @param side2 side 2 of a new rectangle
     */
    public Rectangle (double side1, double side2) {
        this.side1 = side1;
        this.side2 = side2;
    }

    /**
     * Calculates and returns area of rectangle
     * @return double Area of rectangle
     */
    public double getArea() {
        return side1 * side2;
    }

    /**
     * Calculates and returns perimeter of rectangle
     * @return double Perimeter of rectangle
     */
    public double getPerimeter () {
        return 2.0 * (side1 + side2);
    }
}
