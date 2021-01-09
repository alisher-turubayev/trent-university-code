/**
 * Class to store objects of equilateral triangle shape. Inherits from Triangle
 * @see Triangle
 * @author Alisher Turubayev, Trent University
 */
public class EquilateralTriangle extends Triangle {
    private double side;

    /**
     * Creates a new EquilateralTriangle with side equal to passed value
     * @param side Side of a triangle
     */
    public EquilateralTriangle(double side) {
        super(side, side, side);
        this.side = side;
    }
}
