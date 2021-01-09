package com.alisherturubayev;

import java.util.Random;

/**
 * COIS 4470 - Project 
 * 
 * This program simulates an inventory system with some initial conditions. 
 * Those conditions can be found in the report. 
 * Three systems are studied: T = 1, T = 5, and no T (i.e. T = -1)
 * 
 * Input is generated at random by program at startup.
 * @author alisherturubayev
 */
public class InventorySimulation {
    static Random rand = new Random();
    // Store demand
    static long[] demand1, demand2;
    // Constants declaration:
    // simulation time
    final static int N = 100;
    // review delay for policy 2
    final static int T = 5;
    // delivery lag for each product 
    final static int L1 = 3, L2 = 5;
    // maximum number of items
    final static long S = 300;
    // sale costs for each product
    final static long C1 = 120, C2 = 100;
    // order costs for each product 
    final static long O1 = 100, O2 = 80;
    // setup costs for each product
    final static long R1 = 400, R2 = 800;
    
    
    
    /**
     * Main method that is invoked by JVM
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // Generate demand
        generateInput();
        System.out.println("-------------------------");
        
        // Run simulation:
        // with policy 1 (review at t=1,2,3...)
        for (int i = 10;i <= 100; i += 10) {
            simulate(1, i);
        }
        System.out.println("-------------------------");
        
        // with policy 2 (review at t=T,2*T,3*T...)
        for (int i = 10;i <= 100; i += 10) {
            simulate(T, i);
        }
        System.out.println("-------------------------");
        
        // with policy 3 (review only when stock is 0)
        simulate(-1, 0);
    }
    
    /**
     * Generates random input and stores it in demand1, demand2 arrays
     */
    private static void generateInput() {
        demand1 = new long[N];
        demand2 = new long[N];
        
        for (int i = 0;i < N; i++) {
            demand1[i] = rand.nextInt((int)S / 2) + 1;
            demand2[i] = rand.nextInt((int)S / 2) + 1;
            System.out.print(demand1[i] + " " + demand2[i] + " | ");
        }
        System.out.println();
    }
    
    /**
     * This method runs the simulation and outputs the results
     * @param T review time period
     * @param s minimum inventory level 
     */
    private static void simulate(int T, int s) {
        // in1 - inventory level for product A,
        // in2 - for product B
        long in1 = S, 
             in2 = S;
        // order1 - order for product A
        // order2 - order for B.
        long order1 = 0, 
             order2 = 0;
        // Time left to receive an order
        long leftTimeOrder1 = 0,
             leftTimeOrder2 = 0;
        // Variables that hold revenue and expenses
        long revenue = 0,
             expenses = 0;
        // Variables that hold the number of items the warehouse 
        // could not fulfil
        long notFulfilled1 = 0,
             notFulfilled2 = 0;
        
        // Time keeper
        int t = 1;
        
        // Run the simulation
        while (t <= N) {
            // If the order A arrived, add to the inventory
            if (leftTimeOrder1 == 0 && order1 != 0) {
                in1 += order1;
                // Add order costs
                expenses += O1 * order1;
                // Add setup cost
                expenses += (order1 > 30 ? R2 : R1);
                order1 = leftTimeOrder1 = 0;
            }
            // If the order B arrived, add to the inventory
            if (leftTimeOrder2 == 0 && order2 != 0) {
                in2 += order2;
                // Add order costs
                expenses += O2 * order2;
                // Add setup cost
                expenses += (order2 > 30 ? R2 : R1);
                order2 = leftTimeOrder2 = 0;
            }
            
            // If it's time for review
            if (T == -1 || t % T == 0) {
                // If the inventory for A is 0 or below s and there is no order placed,
                // place an order
                if (in1 <= s && leftTimeOrder1 == 0) {
                    order1 = S - in1;
                    leftTimeOrder1 = L1;
                }
                // If the inventory for B is 0 or below s and there is no order placed,
                // place an order
                if (in2 <= s && leftTimeOrder2 == 0) {
                    order2 = S - in2;
                    leftTimeOrder2 = L2;
                }
            }
            
            // If there are not enough items of A in the inventory 
            if (demand1[t - 1] > in1) {
                revenue += C1 * in1;
                notFulfilled1 += demand1[t - 1] - in1;
                in1 = 0;
            }
            else {
                revenue += C1 * demand1[t - 1];
                in1 -= demand1[t - 1];
            }
            // If there are not enough items of B in the inventory
            if (demand2[t - 1] > in2) {
                revenue += C2 * in2;
                notFulfilled2 += demand2[t - 1] - in2;
                in2 = 0;
            }
            else {
                revenue += C2 * demand2[t - 1];
                in2 -= demand2[t - 1];
            }
            t++;
            if (leftTimeOrder1 != 0)
                leftTimeOrder1--;
            if (leftTimeOrder2 != 0)
                leftTimeOrder2--;
        }
        long lostRevenue = notFulfilled1 * C1 + notFulfilled2 * C2;
        
        // Output the results of simulation
        System.out.println("The results of simulation with N = " + N + " and S = " + S + ",");
        System.out.println("where T = " + T + " and s = " + s + ":");
        System.out.println(" profit: " + (revenue - expenses));
        System.out.println(" number of items unfulfilled for A: " + notFulfilled1);
        System.out.println(" number of items unfulfilled for B: " + notFulfilled2);
        System.out.println(" potential revenue lost: " + lostRevenue + "\n");
    }
}
