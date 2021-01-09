/**
 * Class to store objects of square shape. Inherits from Rectangle
 * @see Rectangle
 * @author Alisher Turubayev, Trent University
 */
public class Square extends Rectangle {
    private double side;

    /**
     * Creates a Square with given side
     * @param side Side of a square
     */
    public Square (double side) {
        super(side, side);
        this.side = side;
    }

    /**
     * Calculates and returns the area of square
     * @return double Area of square
     */
    public double getArea () {
        return side * side;
    }

    /**
     * Calculates and returns the perimeter of square
     * @return double Perimeter of square
     */
    public double getPerimeter () {
        return 4.0 * side;
    }
}
