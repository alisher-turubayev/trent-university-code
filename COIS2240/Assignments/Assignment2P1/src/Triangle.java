/**
 * Class to store objects of triangle shape. Inherits from GeometricObject
 * @see GeometricObject
 * @author Alisher Turubayev, Trent University
 */
public class Triangle extends GeometricObject {
    private double side1, side2, side3;

    /**
     * Creates a new Triangle with all sides 1.0
     */
    public Triangle() {
        side1 = side2 = side3 = 1.0;
    }

    /**
     * Creates new Triangle with given sides
     * @param side1 Side 1 of a new triangle
     * @param side2 Side 2 of a new triangle
     * @param side3 Side 3 of a new triangle
     */
    public Triangle(double side1, double side2, double side3) {
        this.side1 = side1;
        this.side2 = side2;
        this.side3 = side3;
    }

    /**
     * Calculates and returns area of triangle
     * @return double Area of triangle
     */
    public double getArea() {
        double s = (side1 + side2 + side3) / 2;
        return Math.sqrt(s * (s - side1) * (s - side2) * (s - side3));
    }

    /**
     * Calculates and returns perimeter of triangle
     * @return double Perimeter of triangle
     */
    public double getPerimeter() {
        return side1 + side2 + side3;
    }

    /**
     * Returns string representation of triangle
     * @return string String representation of triangle
     */
    @Override
    public String toString () {
        return "Triangle with sides " + side1 + " " + side2 + " " + side3;
    }
}
