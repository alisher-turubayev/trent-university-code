public class Test {
    public static void main (String[] args) {
        // Create and define array
        GeometricObject[] gObjectArray = new GeometricObject[5];

        gObjectArray[0] = new Circle(5,5,5);
        gObjectArray[1] = new EquilateralTriangle(5);
        gObjectArray[2] = new Triangle(5, 5, 5);
        gObjectArray[3] = new Rectangle(5, 5);
        gObjectArray[4] = new Square(5);

        // Iterate over array and output area and perimeter of each object
        for (GeometricObject gObject : gObjectArray) {
            printAreaAndPerimeter(gObject);
        }
    }

    /**
     * Prints out area and perimeter of a given geometric object
     * @param gObject An object to print area and perimeter of
     */
    private static void printAreaAndPerimeter (GeometricObject gObject) {
        System.out.println("The shape has area of " + gObject.getArea() +
                " and perimeter of " + gObject.getPerimeter());
    }
}
