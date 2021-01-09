/*
 * COIS 3040 - Assignment #1
 * Trent University
 *
 * Question #2
 * Assignment Group: Alisher Turubayev & Vanshree Mathur
 */

/**
 * Abstract Class called Shape
 * @author Vanshree Mathur
 */

public abstract class Shape {
    protected IColour colour;
    protected String thickness;

    public Shape (IColour colour, String thickness) {
        this.colour = colour;
        this.setThickness(thickness);
    }

    public IColour colour() {
        return this.colour;
    }

    public String getThickness() {
        return this.thickness;
    }

    // By default is thin
    public void setThickness(String thickness) {
        if (thickness.equalsIgnoreCase("Thick"))
            this.thickness = "Thick";
        else
            this.thickness = "Thin";
    }

    @Override
    public abstract String toString();
}

