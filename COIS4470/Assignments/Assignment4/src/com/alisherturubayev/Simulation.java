package com.alisherturubayev;

import java.util.Random;

class Simulation {
    // Random number generator
    private static Random rand = new Random();

    /**
     * Returns a random variate with exponential distribution with a given mean
     * @param mean mean of distribution
     * @return random variate with exponential distribution
     */
    static double generateExponential(double mean) {
        return ((-1) * mean * Math.log(1 - rand.nextDouble()));
    }

    /**
     * Generates a random variate with triangular distribution (pdf pre-defined)
     * @return a random variate
     */
    static double generateTriangular() {
        double r = rand.nextDouble();
        if (r <= 1.0 / 3.0)
            return Math.sqrt(3.0 * r);
        return (-1.0) * (-6.0 + Math.sqrt(-24.0 * r + 24.0) / 2.0);
    }

    /**
     * Generates a continuous random variate with a pre-defined pdf
     * @return a continuous random variate
     */
    static double generateContinuous() {
        double r = rand.nextDouble();

        if (r < (1.0 / 3.0))
            return (6.0 * r) - 1.0;
        else if (r < (2.0 / 3.0))
            return 9.0 * r;
        return 12.0 * r - 2;
    }
}

