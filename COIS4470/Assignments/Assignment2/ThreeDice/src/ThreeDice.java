/*
Assignment 2 Question 3
Written by Alisher Turubayev, Trent University

This program simulates an experiment where three dice are rolled, and the
largest value of three is recorded. Let X be that value. The program calculates
the estimated probability of X = {1, 2, 3, 4, 5, 6} for MAX number of rolls.
 */
import java.util.Random;

public class ThreeDice {
    public static void main (String[] args) {
        // Random number generator
        Random rand = new Random();
        // Number of rolls
        final double MAX = 1000;
        // Current roll number
        int index = 0;
        // Array of number of each X being the largest
        double[] array = new double[7];

        while (index < MAX) {
            index++;

            // Generate three faces
            int die1 = equilikely(rand),
                    die2 = equilikely(rand),
                    die3 = equilikely(rand);

            // Get the maximum of three and record it
            int max = Math.max(die1, Math.max(die2, die3));
            array[max]++;
        }

        // Output the probabilities
        for (int i = 1;i <= 6; i++) {
            System.out.println("For X = " + i
                    + ", the estimated probability is " + array[i] / MAX);
        }
    }

    private static int equilikely (Random rand) {
        return 1 + (int)(6 * rand.nextDouble());
    }
}
