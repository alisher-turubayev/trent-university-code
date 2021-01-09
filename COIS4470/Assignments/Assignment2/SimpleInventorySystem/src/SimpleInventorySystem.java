/*
 * Assignment 2 Question 1 part f
 * Modified by Alisher Turubayev, Trent University
 *
 * This program simulates a simple (s, S) inventory system using demand read from
 * a text file. Backlogging is permitted and there is no delivery lag. The output
 * statics are the average demand and order per time interval (they should be equal),
 * the relative frequency of setup and the time averaged held (+) and short (-)
 * inventory levels.
 * Note: Use 0<=MINIMUM < MAXIMUM, i.e., 0<+s<S.
 */
import java.io.File;
import java.util.Scanner;

public class SimpleInventorySystem
{
    public static void main(String[] args)
    {
        //Data file name: sis1.dat
        final long MINIMUM = 40; //'s' inventory policy
        final long MAXIMUM = 80; //'S' inventory policy
        long inventory=MAXIMUM;  //Current inventory level
        long demand;             //Amount of demand
        long order;              //Amount of order
        long numReturn = 0;      //Number of customers to return next week
        long index = 0;          //time interval index
        class Sum
        {
            double setup;        //setup instances
            double holding;      //inventory held (+)
            double shortage;     //inventory short (=)
            double order;        //orders
            double demand;       //demands
        }
        Sum sum=new Sum();
        try
        {
            Scanner input=new Scanner(new File(System.getProperty("user.dir") + "\\out\\production\\SimpleInventorySystem\\sis1.dat"));  //Open file
            while(input.hasNextInt())                                   //while not end of file
            {
                index++;
                if(inventory < MINIMUM || inventory == 0)               //Place an order
                {
                    order = MAXIMUM - inventory;
                    sum.setup++;
                    sum.order += order;
                }
                else                                                    //No order
                    order = 0;
                inventory  += order;                                    //There is no delivery lag
                demand = input.nextInt() + numReturn;                   //Read a demand from file and add customers from last week
                sum.demand += demand;
                sum.holding += inventory - 0.5 * demand;                //No back ordering
                numReturn = Math.max(0, -1 * (inventory - demand));
                inventory = Math.max(0, inventory - demand);
            }
            if(inventory < MAXIMUM)          //force the final inventory
            {                                //to match the initial inventory
                order = MAXIMUM - inventory;
                sum.setup ++;
                sum.order += order;
                inventory += order;
            }
        }catch(Exception e)
        {
            System.out.println(e.getMessage());
        }
        // Calculate average holding, shortage, setup and total cost per week
        double averageHoldingCost = 25.0 * quotient(sum.holding, index),
                averageShortageCost = 700.0 * quotient(sum.shortage, index),
                averageSetupCost = 1000.0 * quotient(sum.setup, index),
                averageTotalCost = averageHoldingCost + averageShortageCost + averageSetupCost;

        System.out.println(" For "+ index +" time intervals with an average demand of "
                + sum.demand + " and policy parameters (" + MINIMUM + ", " + MAXIMUM + "), "
                + "\n the average order: " + quotient(sum.order, index)
                + ",\n the setup frequency: " + quotient(sum.setup, index)
                + ",\n the average holding level: " + quotient(sum.holding, index)
                + ",\n the average shortage level: " + quotient(sum.shortage, index)
                + ",\n\n the average holding cost per week: " + averageHoldingCost
                + ",\n the average shortage cost per week: " + averageShortageCost
                + ",\n the average setup cost per week: " + averageSetupCost
                + ", and \n the sum of three costs per week: " + averageTotalCost);
    }
    public static double sqr(double x)
    {
        return x * x;
    }

    public static double quotient(double a, double b)
    {
        return ((int)(a / b * 100)) / 100.0;
    }
}