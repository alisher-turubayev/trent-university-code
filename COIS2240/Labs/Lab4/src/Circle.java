public class Circle extends Shape {
    private float radius;

    public Circle (String color, boolean filled, float radius) {
        super(color, filled);
        this.radius = radius;
    }

    public float getRadius () {
        return this.radius;
    }
}
