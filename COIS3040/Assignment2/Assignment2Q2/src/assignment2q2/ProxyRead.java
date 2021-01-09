/*
 * COIS 3040 - Assignment #2
 * Trent University
 *
 * Question #2
 * Assignment Group: Alisher Turubayev & Vanshree Mathur
 */
package assignment2q2;

//ProxyRead Class, implements IText Interface
public class ProxyRead implements IText {
    private final IText text;

    //Creating an object from RealText class
    public ProxyRead() {
        text = new Text();
    }

    //Overrides getContent() and setContent() from Interface IText
    @Override
    public String getContent() {
        //Displays Read Access Content
        System.out.println("Current contents:");
        return text.getContent();
    }

    @Override
    public void setContent(String content) {
        System.out.println("Error: Cannot write content.");
    }
}
