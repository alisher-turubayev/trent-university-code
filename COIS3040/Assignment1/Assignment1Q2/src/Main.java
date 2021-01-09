/*
 * COIS 3040 - Assignment #1
 * Trent University
 *
 * Question #2
 * Assignment Group: Alisher Turubayev & Vanshree Mathur
 */

public class Main {

    public static void main(String[] args) {

        /**
         * A rectangle that is red, thin
         */

        Shape RedThinRectangle = new Rectangle(new Red(), "Thin");
        System.out.println(RedThinRectangle);

        /**
         *  A rectangle that is blue, thick
         */

        Shape BlueThickRectangle = new Rectangle(new Blue(), "Thick");
        System.out.println(BlueThickRectangle);

        /**
         * A triangle that is red, thick
         */

        Shape RedThickTriangle = new Rectangle(new Red(), "Thick");
        System.out.println(RedThickTriangle);

        /**
         * A triangle that is blue, thin
         */

        Shape BlueThinTriangle = new Triangle(new Blue(), "Thin");
        System.out.println(BlueThinTriangle);
    }

}
