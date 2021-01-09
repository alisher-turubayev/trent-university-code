package com.alisherturubayev;

/**
 * Assignment 4
 * Written by Alisher Turubayev,
 *              Trent University
 *
 * This code generates 1000 random variates generated using exponential distribution with provided mean,
 * triangular distribution with pdf provided in assignment document, and a distribution provided in
 * assignment document.
 *
 * The output of this program is used to plot the histograms that are available in the document
 * submitted with this assignment.
 */
public class Main {
    public static void main (String[] args) {
        double exponentialMean = 1.9707546682959;
        // Generate 1000 variates using exponential distribution
        for (int i = 0; i < 1000; i++) {
            System.out.println(Simulation.generateExponential(exponentialMean));
        }
        System.out.println();

        // Generate 1000 variates using triangular distribution
        for (int i = 0; i < 1000; i++) {
            System.out.println(Simulation.generateTriangular());
        }
        System.out.println();

        // Generate 1000 variates using continuous distribution
        for (int i = 0; i < 1000; i++) {
            System.out.println(Simulation.generateContinuous());
        }
        System.out.println();
    }

    /**
     * Used to calculate the answer for Question 6 part c. The values outputted are approximates,
     * as floating-point numbers tend to carry a significant error in any computer language due
     * to the nature of saving numbers in binary.
     */
    @SuppressWarnings("unused")
    private static void calculateQ6 () {
        double p0 = 0.0738358358, lambda = 0.51, minus = 0.49;

        System.out.println("P(0): " + p0);
        for (int i = 1;i <= 10; i++) {
            System.out.println("P(" + i + "): " + Math.pow(lambda, i) * p0 / Math.pow(minus, i));
        }
    }
}
