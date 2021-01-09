/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package assignment2q2;

/**
 *
 * @author Vanshree Mathur
 */
public class Test {
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        //Instantiating proxy objects
        IText Text1 = new ProxyRead();
        IText Text2 = new ProxyWrite();
        IText Text3 = new ProxyReadWrite();

        System.out.println("Default content of each text is Empty.\n");
        
        //Testing each proxy:
        //Read Access Proxy
        System.out.println("Read-only proxy:");
        Text1.setContent("rProxy");
        System.out.println(Text1.getContent());
        
        System.out.println();
        
        //Write Access Proxy
        System.out.println("Write-only proxy:");
        Text2.setContent("wProxy");
        System.out.println(Text2.getContent());
        
        System.out.println();
        
        //Read/Write Access Proxy
        System.out.println("Read/write proxy:");
        Text3.setContent("rwProxy");
        System.out.println(Text3.getContent());
        
        System.out.println();
    }
}
