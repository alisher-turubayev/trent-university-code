/*
 * COIS 3040 - Assignment #1
 * Trent University
 *
 * Question #2
 * Assignment Group: Alisher Turubayev & Vanshree Mathur
 */

/**
 * This class implements interface IColour
 */

public class Red implements IColour {
    private String colour;
    public Red() {
        colour = "red";
    }

    @Override
    public String getColour() {
        return colour;
    }
}
