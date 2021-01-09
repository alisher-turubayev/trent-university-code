/*
 * This program simulates a single-server machine shop using exponentially
 * distributed failure times, uniformly distributed service times and an FIFO
 * service queue
 * Sample Output:
 *  For a pool of 60 machines, and 10000 simulated failures,
 *  the average interarrival time: 1.73,
 *  the average waiting time: 5.21,
 *  the average delay time: 3.71,
 *  the average service time: 1.5,
 *  the average # in the node: 3.0,
 *  the average # in the queue: 2.14
 *  and the utilization rate: 86.0%.
 *  BUILD SUCCESSFUL (total time: 0 seconds)
 */
public class SingleServerMachineShop
{
    // Constants declaration
    private static double SPECIFIEDTIME1 = 2000, SPECIFIEDTIME2 = 10000; // Time for output
    private static double MAXTIME = 100000; // Total time for simulation
    private static double START = 0.0;      // Starting time
    private static int LAST = 100000;       // Total number of failures
    private static int M = 60;              // Number of machines


    public static void main(String[] args)
    {
        // Inner-method class declaration
        // Stores the total results for a simulation
        class Sum
        {
            double wait=0.0;            // Total waiting time
            double delay=0.0;           // Total delay time
            double service=0.0;         // Total service time
            double interarrival;        // Total interarrival time
        }

        long index = 0;                 // Machine failure index
        double arrival = START;         // Time of arrival (failure)
        double delay;                   // Delay in repair queue
        double service;                 // Service (repair) time
        double wait;                    // Waiting time: delay + service
        double departure = START;       // Time of service completion
        boolean wasOutputted1, wasOutputted2;
        wasOutputted1 = wasOutputted2 = false;

        // Object containing the machine index
        myInt m = new myInt();
        // List of next failure time for a machine
        double[] failure = new double[M];
        // List of total number of failures
        int[] numberFailures = new int[M];
        // Stores the results of a simulation
        Sum sum = new Sum();

        // Get the failure times for all machines
        for(int i = 0; i < M; i++)
            failure[i] = START + getFailure();

        while(true)
        {
            // Get the next failure of a machine
            arrival = nextFailure(failure, m);
            // If the arrival time of the next machine is bigger than the upper bound, stop simulation
            if (arrival > MAXTIME)
                break;

            index++;
            // If the last broken machine is still fixing when the next comes, there is a delay
            if(arrival < departure)
                delay = departure - arrival;
            else
                delay = 0.0;
            // Get the service time for current machine
            service = getService();
            // Calculate wait time: time for delay plus time for service
            wait = delay + service;
            departure = arrival + wait;
            // Increase the number of failures for this machine
            numberFailures[m.getInt()]++;
            // Get the next time of failure for this machine
            failure[m.getInt()] = departure + getFailure();
            // Add to the total
            sum.wait += wait;
            sum.delay += delay;
            sum.service += service;

            // If the time of the departure is bigger than the specified time, output the number of failures for each
            // machine and the number of machines in the queue
            if (departure >= SPECIFIEDTIME1 && !wasOutputted1) {
                wasOutputted1 = true;
                System.out.println("At a time " + SPECIFIEDTIME1 + ":");
                for (int i = 1;i < M; i++) {
                    System.out.print("  failures for machine " + i + ": ");
                    // If the failure time for machine i is smaller than specified time, increase the number
                    // of failures by 1
                    if (failure[i] <= SPECIFIEDTIME1)
                        System.out.println(numberFailures[i] + 1);
                    else
                        System.out.println(numberFailures[i]);
                }
                // Get the number of machines in queue, and include the current one (therefore +1)
                System.out.println("  the number of machines in a queue: " + (numberInQueue(failure, SPECIFIEDTIME1) + 1));
            }
            if (departure >= SPECIFIEDTIME2 && !wasOutputted2) {
                wasOutputted2 = true;
                System.out.println("At a time " + SPECIFIEDTIME2 + ":");
                for (int i = 1;i < M; i++) {
                    System.out.print("  failures for machine " + i + ": ");
                    // If the failure time for machine i is smaller than specified time, increase the number
                    // of failures by 1
                    if (failure[i] <= SPECIFIEDTIME2)
                        System.out.println(numberFailures[i] + 1);
                    else
                        System.out.println(numberFailures[i]);
                }
                // Get the number of machines in queue, and include the current one (therefore +1)
                System.out.println("  the number of machines in a queue: " + (numberInQueue(failure, SPECIFIEDTIME2) + 1));
            }
        }

        sum.interarrival= arrival - START;
        System.out.println("\n For a pool of " + M + " machines, and " + MAXTIME +
                " time boundary"
                +",\n the average interarrival time: "+quotient(sum.interarrival, index)
                +",\n the average waiting time: "+quotient(sum.wait, index)
                +",\n the average delay time: " +quotient(sum.delay, index)
                +",\n the average service time: "+quotient(sum.service, index)
                +",\n the average # in the node: "+quotient(sum.wait, departure)
                +",\n the average # in the queue: "+quotient(sum.delay, departure)
                +"\n and the utilization rate: "+quotient(sum.service, departure)*100+"%.");

    }

    /**A simple class to carry an int value
     */
    static class myInt
    {
        int n;
        void setInt(int n){this.n=n;}
        int getInt(){return this.n;}
    }

    /**Find the quotient of two numbers with two decimal places
     * @param dividend the dividend of the quotient
     * @param divisor the divisor of the quotient
     * @return the quotient with two decimal places for dividend/divisor
     */
    private static double quotient(double dividend, double divisor)
    {
        return  (int)(100*dividend/divisor)/100.0;
    }

    /**Generate a random exponential variate
     * @param m a multiplier >0
     * @return an exponential random variate
     */
    private static double exponential(double m)
    {
        return (-m * Math.log(1.0 - Math.random()));
    }

    /**Generate a uniform random variate between a and b
     * @param a the start of the interval
     * @param b the end of the interval
     * @return a uniform random variate between a and b
     */
    private static double uniform(double a, double b)
    {
        return a + (b - a) * Math.random();
    }

    /**Generate the operational time until nextfailure
     * @return the operational time until the next failure
     */
    private static double getFailure()
    {
        return exponential(100.0);
    }

    /**
     * Find the next failure time and index in the array
     * @param failure the array carrying the failure times
     * @param m an Integer object that carries the index of the failure time
     * @return the failure time
     */
    private static double nextFailure(double[] failure, myInt m)
    {
        double t = failure[0];
        m.setInt(0);

        for(int i = 1; i < M; i++) {
            if (failure[i] < t) {
                t = failure[i];
                m.setInt(i);
            }
        }
        return t;
    }

    /**
     * Find the number of machines in the single-server queue at a specified time
     * @param failure the array carrying the failure times
     * @param time the current time
     * @return the number of machines in a single-server queue
     */
    private static int numberInQueue(double[] failure, double time) {
        int result = 0;             // Stores the result

        // Go through the array of failure times and if the failure time of the machine is smaller than
        // the current time, it will be in the queue at the time.
        for (int i = 1;i < M; i++) {
            if (failure[i] <= time) {
                result++;
            }
        }

        return result;
    }

    /**Generates the next service time
     * @return the next service time
     */
    private static double getService()
    {
        return uniform(1.0, 2.0);
    }
}
