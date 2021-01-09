/*
 * This program simulates a single server FIFO service node using exponentially
 * distributed interarrival times and uniformly distributed service time.
 * Sample Output:
 * For 10000 jobs,
 * the average interarrival time: 1.97
 * the average waiting time: 4.0
 * the average delay time: 2.5
 * the average service time: 1.49
 * the average # in the node: 2.03
 * the average # in the queue: 1.27
 * The percentage of time utilization: 75.0%
 * BUILD SUCCESSFUL (total time: 0 seconds)
 */
import java.util.Random;

public class SingleServerQueue
{
    // Const declarations
    private static long SPECIFIEDTIME1 = 300, SPECIFIEDTIME2 = 5000;
    private static double START = 0.0;
    private static long LAST = 100000;

    public static void main(String[] args)
    {
        // Method-local class declaration: stores the total results for the system
        class Sum
        {
            // Stores delay, maximum delay, wait, service and interarrival times
            int jobsDelayed = 0;
            double delay = 0.0;
            double maxDelay = 0.0;
            double wait = 0.0;
            double service = 0.0;
            double interarrival;
        }

        // Variables declaration
        long index = 0;                 // Job index
        double arrival = START;         // Time current customer arrives
        double delay;                   // Current delay time
        double service;                 // Time for this job's service
        double wait;                    // Delay + service time
        double departure = START;       // Time of last customer's departure
        boolean wasOutputted1 = false,
                wasOutputted2 = false;   // Were parameters outputted at the specified time 1 or 2

        // Create an object of sum
        Sum sum = new Sum();

        // While the number of jobs is smaller than the maximum number of jobs to be simulated
        while (index < LAST)
        {
            index++;
            // Get arrival time of current customer
            arrival = getArrival(arrival);
            // If the arrival time of the current customer is smaller than the departure time of last customer,
            // there is a delay in service
            if(arrival < departure) {
                delay = departure - arrival;
                sum.jobsDelayed++;
            }
            else
                delay = 0.0;
            // Get service time for this customer
            service = getService();
            wait = delay + service;
            // Compute time of departure for current customer
            departure = arrival + wait;
            // Increase total delay
            sum.delay += delay;
            // Compare maximum delay with the current delay
            sum.maxDelay = Math.max(sum.maxDelay, delay);
            // Increase total wait time
            sum.wait += wait;
            // Increase total service time
            sum.service += service;

            // If the departure time is after the specified time for output and the parameters were not outputted before
            // output the parameters
            if (departure >= SPECIFIEDTIME1 && !wasOutputted1) {
                wasOutputted1 = true;
                System.out.println("At time " + SPECIFIEDTIME1 + ",");
                System.out.println("  the number of jobs: " + index);
            }
            if (departure >= SPECIFIEDTIME2 && !wasOutputted2) {
                wasOutputted2 = true;
                System.out.println("At time " + SPECIFIEDTIME2 + ",");
                System.out.println("  the number of jobs: " + index);
            }
        }
        // Compute total interarrival time
        sum.interarrival = arrival - START;
        // Output the results
        System.out.println("For " + index + " jobs,");
        System.out.println("  the average interarrival time: "
                + quotient(sum.interarrival, index));
        System.out.println("  the average waiting time: "
                + quotient(sum.wait, index));
        System.out.println("  the average delay time: "
                + quotient(sum.delay, index));
        System.out.printf("  the maximum delay time: %.2f %n",
                sum.maxDelay);
        System.out.println("  the average service time: "
                + quotient(sum.service, index));
        System.out.println("  the average # in the node: "
                + quotient(sum.wait, departure));
        System.out.println("  the average # in the queue: "
                + quotient(sum.delay, departure));
        System.out.println("  the proportion of jobs delayed: "
                + quotient(sum.jobsDelayed, index));
        System.out.println("  the percentage of time utilization: "
                + quotient(sum.service, departure) * 100 + "%");
    }

    /**Find the quotient of two numbers
     * @param dividend the dividend of the quotient
     * @param divisor the divisor of the quotient
     * @return the quotient with two decimal places
     */
    public static double quotient(double dividend, double divisor)
    {
        return (int)((dividend / divisor) * 100) / 100.0;
    }

    /**Generate an exponential variate for m>0
     *@return a random number following the exponential distribution
     */
    public static double exponential(double m)
    {
        Random r = new Random();
        return (-m * Math.log(1.0 - r.nextDouble()));
    }

    /**Generate a uniform variate between a and b for a<b
     *@param a the start point of the uniform variate
     *@param b the end point of the uniform variate
     *@return a random number between a and b following the uniform distribution
     */
    public static double uniform(double a, double b)
    {
        Random r = new Random();
        return a + (b - a) * r.nextDouble();
    }

    /**Generate the next arrival time using the exponential distribution
     * @param preArrival the arrival time of the previous job
     * @return the next arrival time
     */
    public static double getArrival(double preArrival)
    {
        return preArrival + exponential(2.0);
    }

    /**Generate the next service time between 1 and 2 following the uniform distribution
     * @return a number between 1 and 2 following the uniform distribution
     */
    public static double getService()
    {
        return uniform(1.0, 2.0);
    }
}