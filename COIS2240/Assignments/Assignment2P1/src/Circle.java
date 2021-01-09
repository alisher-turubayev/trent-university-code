/**
 * Class to store objects of circle shape. Inherits from GeometricObject
 * @see GeometricObject
 * @author Alisher Turubayev, Trent University
 */
public class Circle extends GeometricObject {
    private double x, y;
    private double radius;

    /**
     * Creates a new Circle with center position at (0,0) and radius 1
     */
    public Circle () {
        super();
        x = y = 0.0;
        radius = 1.0;
    }

    /**
     * Creates a new Circle with given center coordinates and radius
     * @param x x-coordinate of center
     * @param y y-coordinate of center
     * @param radius Radius of a circle
     */
    public Circle (double x, double y, double radius) {
        super();
        this.x = x;
        this.y = y;
        this.radius = radius;
    }

    /**
     * Getter method for x property
     * @return double x-coordinate of circle center
     */
    public double getX () {
        return x;
    }

    /**
     * Getter method for y property
     * @return double y-coordinate of circle center
     */
    public double getY () {
        return y;
    }

    /**
     * Getter method for radius property
     * @return double radius of circle radius
     */
    public double getRadius () {
        return radius;
    }

    /**
     * Calculates and returns area of circle
     * @return double Area of circle
     */
    public double getArea () {
        return Math.PI * radius * radius;
    }

    /**
     * Calculates and returns perimeter of circle
     * @return double Perimeter of circle
     */
    public double getPerimeter () {
        return 2.0 * Math.PI * radius;
    }
}
