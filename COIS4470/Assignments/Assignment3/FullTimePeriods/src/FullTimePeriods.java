/*
Assignment 3 Question 3(b)
Written by Alisher Turubayev,
            Trent University

This program finds and outputs all full-period multipliers for a Lehmer random number generator
with formula given as follows:
    x_i+1 = g(x_i) = a * x_i mod 127 for all i >= 1
 */

public class FullTimePeriods {
    private final static long m = 127;
    public static void main (String[] args) {
        long[] fullPeriodMlt = loopFind();

        System.out.println("There are " + fullPeriodMlt.length + " full-period multipliers for m = 127:");
        for (long a : fullPeriodMlt) {
            System.out.print(a + " ");
        }
        System.out.println();
    }

    private static long[] loopFind () {
        long[] result = new long[36];
        int index = 0;

        for (long a = 1;a <= m; a++) {
            long p = 1, x = a;

            while (x != 1) {
                p++;
                x = (a * x) % m;
            }
            if (p == m - 1) {
                result[index] = a;
                index++;
                if (index == 36)
                    break;
            }
        }
        return result;
    }
}
