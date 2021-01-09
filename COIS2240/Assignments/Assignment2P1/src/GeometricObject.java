/**
 * Parent abstract class defining a blueprint for other geometric shapes
 * Uses no other classes
 * @author Alisher Turubayev, Trent University
 */
import java.util.Date;

public abstract class GeometricObject {
    private String color = "white";
    private boolean filled;
    private Date dateCreated;

    /**
     * Records a date of the shape creation,
     * color is "white" and filled is false by default
     */
    protected GeometricObject () {
        dateCreated = new Date();
    }

    /**
     * Records a date and stores color/filled properties
     * @param color Denotes a color of the new shape
     * @param filled Denotes whether a shape is filled or not
     */
    protected GeometricObject (String color, boolean filled) {
        this.color = color;
        this.filled = filled;
        dateCreated = new Date();
    }

    /**
     * Getter method for color property
     * @return string A color of the shape
     */
    public String getColor () {
        return color;
    }

    /**
     * Setter method for color property
     * @param color A new color to assign
     */
    public void setColor (String color) {
        this.color = color;
    }

    /**
     * Getter method for filled property
     * @return boolean Whether a shape is filled or not
     */
    public boolean isFilled() {
        return filled;
    }

    /**
     * Setter method for filled property
     * @param filled Whether the shape should be filled or not
     */
    public void setFilled(boolean filled) {
        this.filled = filled;
    }

    /**
     * Getter method for dateCreated property
     * @return java.util.Date A date of shape creation
     */
    public Date getDateCreated () {
        return dateCreated;
    }

    /**
     * Returns a string representation of a geometric shape
     * @return String A string representation of a shape
     */
    @Override
    public String toString () {
        return "Created on " + dateCreated +
                " with color " + color +
                " and " + (filled ? "filled" : "not filled");
    }

    // Abstract methods getArea and getPerimeter
    public abstract double getArea();
    public abstract double getPerimeter();
}
