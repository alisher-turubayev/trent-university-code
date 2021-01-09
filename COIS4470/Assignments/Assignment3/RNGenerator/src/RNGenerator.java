/*
Assignment 3 Question 3(c,d)
Written by Alisher Turubayev,
            Trent University

This program generates a desired number of random variates based on a Lehmer random number generator
with a given formula:
        x_i+1 = g(x_i) = a * x_i % m, where i >= 1 and a = 3, m = 127
 */
import java.util.Scanner;

public class RNGenerator {
    private final static long m = 127;
    private final static long a = 3;

    public static void main (String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n;
        System.out.println("Enter the number of random variates to be generated:");
        n = scanner.nextInt();

        long[] x = new long[n + 1];

        System.out.println("Enter the seed for the sequence:");
        x[0] = scanner.nextLong();

        for (int i = 1;i <= n; i++) {
            x[i] = (x[i - 1] * a) % m;
        }

        System.out.println("The random variates generated are:");
        for (int i = 1;i <= n; i++) {
            System.out.println((double)x[i] / (double)m);
        }
    }
}
