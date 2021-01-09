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

public class Blue implements IColour{
    private String colour;
    public Blue() {
        colour = "blue";
    }

    @Override
    public String getColour() {
        return colour;
    }
}
