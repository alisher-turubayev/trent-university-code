/*
 * COIS 3040 - Assignment #2
 * Trent University
 *
 * Question #1
 * Assignment Group: Alisher Turubayev & Vanshree Mathur
 */
package assingment2q1;

import java.util.LinkedList;
import java.util.Scanner;

/**
 * Testing class for the question #1
 * @author Alisher Turubayev
 */
public class Test {
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        System.out.println("Tesing program for Composite/Builder Design Patterns.\n");
        
        System.out.println("Please input your test case in format: ");
        System.out.println("(1 (2 3) (4 5) (6 4))");
        System.out.println("where the opening bracket will create, "
                + "and closing bracket will stop putting items in a second-level list.\n");
        
        System.out.println("Please note that only second-level lists are supported. " 
                + "Additionally, only single-digit positive numbers are supported "
                + "(from the assignment requirements understanding).");
        
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();
        
        LinkedList<String> tokenList = tokenizeInput(input);
        
        ListBuilder builder = new ListBuilder();
        for(int i = 0;i < tokenList.size(); i++) {
            String token = tokenList.get(i);
            
            if (token.equals("("))
                builder.buildOpenBracket();
            else if(token.equals(")"))
                builder.buildClosingBracket();
            else
                builder.buildElement(Integer.parseInt(token));
        }
        
        ListComponent list = builder.getList();
        
        if (list != null) {
            list.printValue();
            System.out.println();
        }
        else
            System.out.println("Input was of incorrect format; nothing to output");
    }

    public static LinkedList<String> tokenizeInput(String input) {
        LinkedList<String> list = new LinkedList();
        
        for (int i = 0;i < input.length(); i++) {
            String token = String.valueOf(input.charAt(i));
            
            if (token.equals(" "))
                continue;
            list.add(token);
        }
        
        return list;
    }
}
