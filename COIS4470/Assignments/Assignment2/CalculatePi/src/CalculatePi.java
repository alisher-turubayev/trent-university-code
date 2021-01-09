/*
Assignment 2 Question 2
Written by Alisher Turubayev, Trent University

This program outputs an estimation of value Pi by generating points
and checking whether they lay in a quarter unit circle or in the square

The formula is (the number of points in a circle) / (the number of points in a square) * 4

The number of points generated is determined by value of MAX
 */

import java.util.Random;

public class CalculatePi {
    public static void main (String[] args) {
        //Points to generate
        final long MAX = 1000000;
        //Random number generator
        Random rand = new Random();
        //Number inside a circle
        long insideCircle = 0;
        //Index
        long index = 0;

        while (index < MAX) {
            index++;

            //Generate a point
            double x = rand.nextDouble(),
                    y = rand.nextDouble();
            //Calculate a distance
            double distance = sqr(x) + sqr(y);
            //Check if inside a circle
            if (Double.compare(distance, 1.0) < 0)
                insideCircle++;
        }

        //Output the result
        System.out.println("From generating " + index + " points, the estimate of Pi is "
                + (insideCircle / (double)index) * 4.0);
    }

    private static double sqr (double num) {
        return num * num;
    }
}
