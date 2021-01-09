/*
 * COIS 3040 - Assignment #3
 * Trent University
 * 
 * Question #3
 * Assignment Group: Alisher Turubayev & Vanshree Mathur
 */
package assignment1q3;

import java.util.Scanner;

/**
 * 
 * @author  Vanshree Mathur
 */
public class Client {

    /**
     * Client method to test the program
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        System.out.println("You can choose a format to display date/time in.");
        System.out.println("Format 1: MM/DD/YYYY HH/MM/SS \n");
        System.out.println("Format 2: DD-MM-YYYY SS,MM,HH \n");
        
        System.out.println("Please choose a format: "
                + "number 1 for first, 2 - for second");
        Scanner scanner = new Scanner(System.in);
        
        // Use a FactoryProvider class to get a factory of a desired format
        int choice = scanner.nextInt();
        if(choice != 1 && choice != 2)
            System.out.println("Invalid input, defaulting to format 1\n");
        IDateTimeFactory factory = FactoryProvider.getFactory(choice);
        
        // Using newly assigned factory, get DateObject and TimeObject
        IDateObject date = factory.createDateObject();
        ITimeObject time = factory.createTimeObject();
        
        boolean isQuit = false;
        while(!isQuit) {
            System.out.println("What would you like to do?");
            System.out.println("'d' - display current date");
            System.out.println("'t' - display current time");
            System.out.println("'q' - exit the program");
            
            char operation = scanner.next().charAt(0);
            
            switch (operation) {
                case 'd':
                    System.out.println(date + "\n");
                    break;
                case 't':
                    System.out.println(time + "\n");
                    break;
                case 'q':
                    isQuit = true;
                    break;
                default:
                    System.out.println("Invalid operation\n");
                    break;
            }
        }
        
        System.out.println("Thank you for using this program.");
        System.out.println("Terminating...");
    }
    
}
