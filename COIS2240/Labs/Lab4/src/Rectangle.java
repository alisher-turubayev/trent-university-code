public class Rectangle extends Shape {
    private double width;
    private double length;

    public Rectangle (String color, boolean filled, double width, double length) {
        super(color, filled);
        this.width = width;
        this.length = length;
    }

    public double getWidth() {
        return this.width;
    }

    public double getLength() {
        return this.length;
    }
}
