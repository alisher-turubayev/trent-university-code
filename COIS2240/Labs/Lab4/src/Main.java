public class Main {
    public static void main (String[] args) {
        Circle circle = new Circle("Red", true, 15);
        Rectangle rectangle = new Rectangle("Blue", false, 16, 10);

        System.out.println("The circle is of color " + circle.getColor()
                + ", and is " + (circle.getFilled() ? "filled" : "not filled")
                + ".\nThe radius of the circle is " + circle.getRadius());

        System.out.println("The rectangle is of color " + rectangle.getColor()
                + ", and is " +  (rectangle.getFilled() ? "filled" : "not filled")
                + ".\nThe width is " + rectangle.getWidth()
                + " and the length is " + rectangle.getLength());
    }
}
