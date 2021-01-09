public class Shape {
    private String color;
    private boolean filled;

    public Shape () {
        this.color = "None";
        this.filled = false;
    }

    public Shape (String color, boolean filled) {
        this.color = color;
        this.filled = filled;
    }

    public String getColor () {
        return this.color;
    }

    public boolean getFilled () {
        return this.filled;
    }
}
